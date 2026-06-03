open System

// This is a very basic math interpreter, using unions to discriminate between 
// expression operators.


// An expression is either a constant value, or an arithmetic function applied to
// one or more operands that are expressions.

type Expression =
    | Literal of float
    | Add     of Expression * Expression
    | Sub     of Expression * Expression
    | Neg     of Expression
    | Mul     of Expression * Expression
    | Div     of Expression * Expression
    | Sqrt    of Expression
    | Pow     of Expression * Expression
    | Input   of string
    | Var     of string
    | Call    of string * Expression list   //added function name + argument expressions

type Condition =
    | Equals   of Expression * Expression
    | LessThan of Expression * Expression
    | And      of Condition  * Condition
    | Or       of Condition  * Condition
    | Not      of Condition

and Statement = 
    | Noop
    | PrintStr of string
    | PrintExp of Expression
    | Assign   of string    * Expression
    | For      of Statement * Condition * Statement * Statement list
    | Function of string    * string list * Statement list   // name, params, body
    | Return   of Expression
    | Branch   of Condition * Statement list * Statement list option //if then else 
    | Repeat   of int       * Statement list
    | While    of Condition * Statement list
// The program state maps names to either a variable value or a function definition.

type NamedEntity =
    | Variable    of float
    | FunctionDef of string list * Statement list  // parameter names + body
//dict with string keys
type State = Map<string, NamedEntity>


//Interpreter

let rec evaluate (expr: Expression) (state: State) : float =
    match expr with
    | Literal c  -> c
    | Add  (a, b) -> evaluate a state + evaluate b state
    | Sub  (a, b) -> evaluate a state - evaluate b state
    | Neg   a     -> -(evaluate a state)
    | Mul  (a, b) -> evaluate a state * evaluate b state
    | Div  (a, b) -> evaluate a state / evaluate b state
    | Sqrt  a     -> sqrt (evaluate a state)
    | Pow  (a, b) -> (evaluate a state) ** (evaluate b state)
    | Var name   ->
        match Map.find name state with
        | Variable v -> v  //returns value from map
        | _ -> invalidArg name $"'{name}' is a function, not a variable."//if namedEntity is a func
    | Input msg   ->
        printf $"{msg} "
        Console.ReadLine() |> float
    | Call (funcName, argExprs) ->
        match Map.find funcName state with
        | FunctionDef (parameters, body) ->
            let argValues   = List.map (fun e -> evaluate e state) argExprs //evaluate each argExpr down to a float
            let paramList   = List.map2 (fun p v -> p, Variable v) parameters argValues//combine to a list of tuples..a,val1; b, val2; 
            let onlyFunctionDef (_, v) = match v with FunctionDef _ -> true | _ -> false
            let funcList  = state
                            |> Map.toList//change dic to list of tuples
                            |> List.filter onlyFunctionDef  //filters out variable   
            let funcState   = funcList @ paramList |> Map.ofList //dict with only global funcs + params;
            let resultState = interpretProgram body funcState //body is list of statements
            match Map.tryFind "_returned_" resultState with
            | Some namedEntity ->
                 match namedEntity with
                 | Variable v -> v
                 | _ -> failwith "error"
            | _ -> failwith $"Function '{funcName}' did not return a value." //no return statement in func body 
        | _ -> failwith $"'{funcName}' is a variable, not a function."//if namedEntity is a variable

and testCondition (cond: Condition) (state: State) : bool =
    match cond with
    | Equals   (a, b) -> evaluate a state =  evaluate b state
    | LessThan (a, b) -> evaluate a state <  evaluate b state
    | And      (c, d) -> testCondition c state && testCondition d state
    | Or       (c, d) -> testCondition c state || testCondition d state
    | Not       c     -> not (testCondition c state)

and interpret (statement: Statement) (state: State) : State =
    match statement with
    | Noop              -> state
    | PrintStr s    -> printfn $"{s}"; state
    | PrintExp expr -> printfn $"{evaluate expr state}"; state
    | Assign (name, e)  -> Map.add name (Variable (evaluate e state)) state
    | Function (name, parameters, body) ->
        Map.add name (FunctionDef (parameters, body)) state
    | Return expr ->
        Map.add "_returned_" (Variable (evaluate expr state)) state
    | Branch (cond, thenBranch, elseBranch) ->
        if testCondition cond state then
            interpretProgram thenBranch state
        else
            match elseBranch with
            | None       -> state
            | Some elseStatements -> interpretProgram elseStatements state
    | Repeat (n, body) ->
        let rec loop count s =
            if count <= 0 then s
            else loop (count - 1) (interpretProgram body s)
        loop n state
    | While (cond, body) ->
        let rec loop s =
            if testCondition cond s then loop (interpretProgram body s)
            else s
        loop state
    | For (initializer, cond, incrementor, body) ->
        interpretProgram [initializer; While (cond, body @ [incrementor]) ] state

and interpretProgram (statements: Statement list) (state: State) : State =
    match statements with
    | [] -> state
    | head :: tail -> interpretProgram tail (interpret head state)

    
//Transcompiler
let rec expressionToPython expr =
    match expr with
    | Literal c         -> $"{c:G}"
    | Var name          -> name
    | Add  (a, b)       -> $"{expressionToPython a} + {expressionToPython b}"
    | Sub  (a, b)       -> $"{expressionToPython a} - {expressionToPython b}"
    | Neg   a           -> $"-{expressionToPython a}"
    | Mul  (a, b)       -> $"{expressionToPython a} * {expressionToPython b}"
    | Div  (a, b)       -> $"{expressionToPython a} / {expressionToPython b}"
    | Sqrt  a           -> $"math.sqrt({expressionToPython a})"
    | Pow  (a, b)       -> $"{expressionToPython a} ** {expressionToPython b}"
    | Input msg         -> $"float(input('{msg}'))" //assuming input is always a float
    | Call (name, args) ->
        let argStr = args |> List.map expressionToPython |> String.concat ", "
        $"{name}({argStr})" //ex: Call ("add", [Var "x"; Var "y"]) -> "add(x, y)"

let rec conditionToPython cond = 
    match cond with
    | Equals   (a, b) -> $"{expressionToPython a} == {expressionToPython b}"
    | LessThan (a, b) -> $"{expressionToPython a} < {expressionToPython b}"
    | And      (c, d) -> $"{conditionToPython c} and {conditionToPython d}"
    | Or       (c, d) -> $"{conditionToPython c} or {conditionToPython d}"
    | Not       c     -> $"not ({conditionToPython c})"

let rec statementToPython (prefix: string) (statement: Statement) : string =
    let indent = prefix + "    "
    match statement with
    | Noop              -> $"{prefix}pass" 
    | PrintStr s        -> $"{prefix}print('{s}')" //ex: PrintStr "Hello" -> "print('Hello')"
    | PrintExp expr     -> $"{prefix}print({expressionToPython expr})"//ex: PrintExp (Add (Var "x", Literal 1.0)) -> "print(x + 1)"
    | Assign (name, e)  -> $"{prefix}{name} = {expressionToPython e}"//ex: Assign ("x", Add (Literal 1.0, Var "x")) -> "x = 1 + x"
    | Return expr       -> $"{prefix}return {expressionToPython expr}"//ex: Return (Mul (Var "a", Var "a")) -> "return a * a"
    | Branch (cond, thenBranch, elseBranch) ->    //ex: Branch (Equals (Var "x", Literal 0.0), [PrintStr "Zero"], Some [PrintStr "Non-zero"]) -> 
        let thenStr = thenBranch |> List.map (statementToPython indent) |> String.concat "\n"
        match elseBranch with
        | None ->
            $"{prefix}if {conditionToPython cond}:\n{thenStr}" //"if x == 0:\n    print('Zero')\nelse:\n    print('Non-zero')"
        | Some stmts ->
            let elseStr = stmts |> List.map (statementToPython indent) |> String.concat "\n"
            $"{prefix}if {conditionToPython cond}:\n{thenStr}\n{prefix}else:\n{elseStr}"
    | Repeat (n, body) ->                                    //ex: Repeat (3, [PrintStr "Hello"]) -> "for _ in range(3):\n    print('Hello')"   
        let bodyStr = body |> List.map (statementToPython indent) |> String.concat "\n"
        $"{prefix}for _ in range({n}):\n{bodyStr}"
    | While (cond, body) ->                                  //ex: While (LessThan (Var "i", Literal 10.0), [PrintExp (Var "i"); /Assign ("i", Add (Var "i", Literal 1.0))]) ->
                                                             // "while i < 10:\n    print(i)\n    i = i + 1"
        let bodyStr = body |> List.map (statementToPython indent) |> String.concat "\n"
        $"{prefix}while {conditionToPython cond}:\n{bodyStr}"
    | For (init, cond, incr, body) -> //ex: For (Assign ("i", Literal 0.0), LessThan (Var "i", Literal 10.0), Assign ("i", Add (Var "i", Literal 1.0)), [PrintExp (Var "i")]) ->
                                                             // "for i in range(0, 10):\n    print(i)"
        let initStr = statementToPython prefix init
        let bodyStr = body |> List.map (statementToPython indent) |> String.concat "\n"
        let incrStr = statementToPython indent incr
        $"{initStr}\n{prefix}while {conditionToPython cond}:\n{bodyStr}\n{incrStr}"
    | Function (name, parameters, body) -> //ex: Function ("squared", ["a"], [Return (Mul (Var "a", Var "a"))]) -> 
                                                //"def squared(a):\n    return a * a"
        let paramStr = String.concat ", " parameters
        let bodyStr  = body |> List.map (statementToPython indent) |> String.concat "\n"
        $"{prefix}def {name}({paramStr}):\n{bodyStr}"



//TESTS

// Test 1 should print 5
printfn "=== Test 1: evaluate (expect 5) ==="

let t1State = Map.ofList [("x", Variable 4.0)]
let expr = Add (Literal 1, Var "x")
evaluate expr t1State |> printfn "%g"

// Test 2 should print 5 then the state map
printfn "\n=== Test 2: interpret PrintExp (expect 5 then state) ==="
let t2State = Map.ofList [("x", Variable 4.0)]
interpret (PrintExp (Add (Literal 1.0, Var "x"))) t2State |> printfn "%O"

// Test 3 should print state with x = Variable 5
printfn "\n=== Test 3: Assign (expect x=5 in state) ==="
let t3State = Map.ofList [("x", Variable 4.0)]
interpret (Assign ("x", Add (Literal 1.0, Var "x"))) t3State |> printfn "%O"

// Test 4 should print 5, 0, then state x=0
let initialState = Map.ofList [("x",Variable 4.0)]  
let programResult =
  initialState
|> interpret (Assign ("x", Add (Literal 1.0, Var "x")))
|> interpret (PrintExp (Var "x"))
|> interpret (Assign ("x", Literal 0.0))
|> interpret (PrintExp (Var "x"))
|> printfn "%O"

// Test 5 should print 5, 0, state x=0
printfn "\n=== Test 5: interpretProgram ==="
let prog5 = [
    Assign ("x", Add (Literal 1.0, Var "x"))
    PrintExp (Var "x")
    Assign ("x", Literal 0.0)
    PrintExp (Var "x")
]
interpretProgram prog5 (Map.ofList [("x", Variable 4.0)]) |> printfn "%O"

// Test 6 should print 0-9 then 20
printfn "\n=== Test 6: While loop (expect 0..9 then 20) ==="
let prog6 = [
    Assign ("i", Literal 0.0)
    While (Not (Equals (Literal 10.0, Var "i")), [
        PrintExp (Var "i")
        Assign ("i", Add (Var "i", Literal 1.0))
    ])
    PrintExp (Mul (Literal 2.0, Var "i"))
]
interpretProgram prog6 Map.empty |> ignore

// Test 7: should print 0-9 then 20
printfn "\n=== Test 7: For loop (expect 0..9 then 20) ==="
let prog7 = [
    For (
        Assign ("i", Literal 0.0),
        Not (Equals (Literal 10.0, Var "i")),
        Assign ("i", Add (Var "i", Literal 1.0)),
        [ PrintExp (Var "i") ]
    )
    PrintExp (Mul (Literal 2.0, Var "i"))
]
interpretProgram prog7 Map.empty |> ignore

// Test 8: Functions (enter 5 when prompted; expect 5 then "squared is equal to" then 25)
printfn "\n=== Test 8: Functions ==="
let prog8 = [
    Function ("squared", ["a"], [
        Return (Mul (Var "a", Var "a"))
    ])
    Assign ("x", Literal 5.0)
    Assign ("result", Call ("squared", [Var "x"]))
    PrintExp (Var "x")
    PrintStr "squared is equal to"
    PrintExp (Var "result")
]
interpretProgram prog8 Map.empty |> ignore

// Test 9: Transcompiler output for prog8
printfn "\n=== Test 9: Python transcompiler ==="
prog8 |> List.map (statementToPython "") |> String.concat "\n" |> printfn "%s"

