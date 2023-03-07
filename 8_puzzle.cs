namespace _8_puzzle_A_star
{
    internal class _8_puzzle
    {
        public int[,] Board;
        public int G;
        public int H;
        public int F;
        public int BlankRow;
        public int BlankCol;
        public _8_puzzle Parent;

        public _8_puzzle(int[,] board, int g, int h, _8_puzzle parent)
        {
            Board = board;
            G = g;
            H = h;
            F = G + H;
            Parent = parent;
            FindBlankPosition();
        }

        private void FindBlankPosition()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (Board[row, col] == 0)
                    {
                        BlankRow = row;
                        BlankCol = col;
                        return;
                    }
                }
            }
        }

        public bool IsGoalState()
        {
            int count = 1;
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (Board[row, col] != count % 9)
                    {
                        return false;
                    }
                    count++;
                }
            }
            return true;
        }

        public List<_8_puzzle> GetSuccessors()
        {
            List<_8_puzzle> successors = new List<_8_puzzle>();
            if (BlankRow > 0)
            {
                int[,] newBoard = (int[,])Board.Clone();
                newBoard[BlankRow, BlankCol] = newBoard[BlankRow - 1, BlankCol];
                newBoard[BlankRow - 1, BlankCol] = 0;
                successors.Add(new _8_puzzle(newBoard, G + 1, CalculateH(newBoard), this));
            }
            if (BlankRow < 2)
            {
                int[,] newBoard = (int[,])Board.Clone();
                newBoard[BlankRow, BlankCol] = newBoard[BlankRow + 1, BlankCol];
                newBoard[BlankRow + 1, BlankCol] = 0;
                successors.Add(new _8_puzzle(newBoard, G + 1, CalculateH(newBoard), this));
            }
            if (BlankCol > 0)
            {
                int[,] newBoard = (int[,])Board.Clone();
                newBoard[BlankRow, BlankCol] = newBoard[BlankRow, BlankCol - 1];
                newBoard[BlankRow, BlankCol - 1] = 0;
                successors.Add(new _8_puzzle(newBoard, G + 1, CalculateH(newBoard), this));
            }
            if (BlankCol < 2)
            {
                int[,] newBoard = (int[,])Board.Clone();
                newBoard[BlankRow, BlankCol] = newBoard[BlankRow, BlankCol + 1];
                newBoard[BlankRow, BlankCol + 1] = 0;
                successors.Add(new _8_puzzle(newBoard, G + 1, CalculateH(newBoard), this));
            }
            return successors;
        }

        private int CalculateH(int[,] board)
        {
            int h = 0;
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    int value = board[row, col];
                    if (value != 0)
                    {
                        int targetRow = (value - 1);
                        int targetCol = (value - 1) % 3;
                        h += Math.Abs(row - targetRow) + Math.Abs(col - targetCol);
                    }
                }
            }
            return h;
        }
    }
}