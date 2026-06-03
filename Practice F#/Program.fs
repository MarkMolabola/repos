// For more information see https://aka.ms/fsharp-console-apps

let indent numSpaces s =
    let spaces = String.replicate numSpaces " "
    spaces + s

let lines = ["x  = 10";"y = int(input())";"print(x*y)"]
let newLines = List.map(indent 4) lines
printfn "%A" newLines