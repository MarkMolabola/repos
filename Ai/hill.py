import time
import random
from board import Board

N = 5
MAX_RESTARTS = 100 
MAX_STEPS_PER_RESTART = 100 #avoid inf loops

# Generate all neighbors by placing the queen in each possible spot
def get_bestfit(board): 
    
    n = board.n_queen
    current_map = board.get_map()
    best_board = None
    best_fit = board.get_fitness()

    for row in range(n):
        # find the col of queen in this row
        current_col = current_map[row].index(1)
        for col in range(n):
            if col == current_col:
                continue

            #copy board with new position of queen
            neighbor = Board(board.n_queen)
            neighbor.reset()
            src_map = board.get_map()

            for i in range(board.n_queen):
                for j in range(board.n_queen):
                    neighbor.map[i][j] = src_map[i][j]

            neighbor.map[row][current_col] = 0
            neighbor.map[row][col] = 1
            
            fit = neighbor.get_fitness()
            if fit < best_fit:
                best_fit = fit
                best_board = neighbor

    return best_board, best_fit


def hill_algorithm():
    start_time = time.time()
    the_best_board = None
    the_best_fitness = float("inf")

    for _ in range(MAX_RESTARTS):
        board = Board(N)
        current_fitness = board.get_fitness()

        for _ in range(MAX_STEPS_PER_RESTART):
            if current_fitness == 0:
                end_time = time.time()
                return board, current_fitness, (end_time - start_time)

            neighbor, neighbor_fitness = get_bestfit(board)

            # No better neighbor → local minimum
            if neighbor is None or neighbor_fitness >= current_fitness:
                break

            board = neighbor
            current_fitness = neighbor_fitness

        #track best seen
        if current_fitness < the_best_fitness:
            the_best_fitness = current_fitness
            the_best_board = board
        #solution found
        if the_best_fitness == 0:
            end_time = time.time()
            return the_best_board, the_best_fitness, (end_time - start_time)

    end_time = time.time()
    return the_best_board, the_best_fitness, (end_time - start_time)


if __name__ == "__main__":
    solution_board, fitness, elapsed = hill_algorithm()
    #print results
    print(f"Running time: {elapsed * 1000:.4f}ms")
    solution_board.print_map()
    