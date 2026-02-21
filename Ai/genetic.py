import time
import random
from board import Board


N = 5
MAX_RESETS = 100 #retry limit


#make newboard/encode 
def random_individual():
    fresh_board = Board(N)
    return fresh_board.encode()

#since GA maximizes fitness, have to invert the score, helper
def fitness_score(board):
    H = board.get_fitness()
    return 1.0 / (1 + H)

#decode to board, helper
def decode_to_board(code):
    fresh_board = Board(N)
    fresh_board.decode(code)
    return fresh_board

#score each encoding into a tuple list 
def score_encodings(pop):
    evaluated = []
    for i in pop:
        b = decode_to_board(i)
        fit = fitness_score(b)
        evaluated.append((i, fit))
    return evaluated


def random_selection(evaluated_pop):
  
    total_score = 0
    for ind, fit in evaluated_pop:
        total_score += fit

  
    if total_score == 0:
        return random.choice(evaluated_pop)[0]

    
    rand = random.random() * total_score

    #iterate through encodings, fitness tuple
    cumulative = 0
    for i, fit in evaluated_pop:
        cumulative += fit
        if cumulative >= rand:
            return i

    #in case of rounding issues, return last encoding
    return evaluated_pop[-1][0]



def crossover(parent1, parent2):
    if len(parent1) != len(parent2):
        raise ValueError("Parents must have same length")
    n = len(parent1)
    #get random point and mix
    point = random.randint(1, n - 1)
    child1 = parent1[:point] + parent2[point:]
    child2 = parent2[:point] + parent1[point:]
    return child1, child2

#mutate a digit in an encoding
def mutate(i):
    n = len(i)
    idx = random.randint(0, n - 1)
    new_col = random.randint(0, N - 1)
  
    while str(new_col) == i[idx]:
        new_col = random.randint(0, N - 1)
    return i[:idx] + str(new_col) + i[idx + 1:]

def genetic_algorithm():
    start_time = time.time()
    state = [random_individual() for _ in range(8)]

    for gen in range(MAX_RESETS):
        evaluated = score_encodings(state)
        # check for perfect solution (fitness corresponding to 0 attacks)
        for i, fit in evaluated:
            temp_board = decode_to_board(i)
            if temp_board.get_fitness() == 0:
                end_time = time.time()
                return temp_board, 0, (end_time - start_time), gen

        new_state = []

        #generate new states
        while len(new_state) < 8:
            parent1 = random_selection(evaluated)
            parent2 = random_selection(evaluated)
            child1, child2 = crossover(parent1, parent2)
            child1 = mutate(child1)
            child2 = mutate(child2)
            new_state.append(child1)
            if len(new_state) < 8:
                new_state.append(child2)

        state = new_state

    evaluated = score_encodings(state)
    best_ind, _ = max(evaluated, key=lambda x: x[1])
    best_board = decode_to_board(best_ind)
    end_time = time.time()
    return best_board, best_board.get_fitness(), (end_time - start_time), MAX_RESETS

if __name__ == "__main__":
    solution_board, fitness, elapsed, generations = genetic_algorithm()
    #print results
    print(f"Running time: {elapsed * 1000:.4f}ms")
    solution_board.print_map()
   