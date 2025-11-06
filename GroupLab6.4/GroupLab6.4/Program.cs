namespace GroupLab6._4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Old Matrix: ");
            int[][] matrix = new int[][]
            {
                new int[] { 1, 2, 3, 4 },
                new int[] { 5, 6, 7, 8 },
                new int[] { 9, 10, 11, 12 }
            };


            PrintMatrix(matrix);
            Console.WriteLine("New Matrix: ");
            PrintMatrix(newMatrix(matrix, 6, 2));
        }
        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.Write("|");
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + "|");
                }
                Console.WriteLine();
            }
        }

        static void PrintMatrix(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                Console.Write("|");
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write(matrix[i][j] + "|");
                }
                Console.WriteLine();
            }
        }

        static int[][] newMatrix(int[][] matrix, int r, int c)
        {
            int numElements = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                numElements += matrix[i].Length;
            }

            if (numElements != r * c)
            {
                throw new ArgumentException("The new matrix size must match the original matrix size.");
            }

            int row = 0, col = 0;
            int[][] newMatrix = new int[r][];
            for (int i = 0; i < r; i++)
            {
                newMatrix[i] = new int[c];
                for (int j = 0; j < c; j++)
                {
                    newMatrix[i][j] = matrix[row][col++];

                    if (col >= matrix[row].Length)
                    {
                        row++;
                        col = 0;
                    }
                }
            }

            return newMatrix;
        }
    }
}
