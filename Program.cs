using _8_puzzle_A_star;

int[,] startBoard = new int[,] { { 7, 2, 4 }, { 5, 0, 6 }, { 8, 3, 1 } };
List<int[,]> solution = AStarSolver.Solve(startBoard);

if (solution != null)
{
    Console.WriteLine("Solution found:");
    foreach (int[,] board in solution)
    {
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                Console.Write(board[row, col] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}
else
{
    Console.WriteLine("No solution found.");
}