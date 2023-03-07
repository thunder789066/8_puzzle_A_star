namespace _8_puzzle_A_star
{
    public class AStarSolver
    {
        public static List<int[,]> Solve(int[,] startBoard)
        {
            _8_puzzle startState = new _8_puzzle(startBoard, 0, 0, null);
            List<_8_puzzle> openList = new List<_8_puzzle>();
            HashSet<int[,]> closedList = new HashSet<int[,]>();

            openList.Add(startState);

            while (openList.Count > 0)
            {
                _8_puzzle currentState = openList[0];
                openList.RemoveAt(0);
                closedList.Add(currentState.Board);

                if (currentState.IsGoalState())
                {
                    List<int[,]> solution = new List<int[,]>();
                    while (currentState != null)
                    {
                        solution.Add(currentState.Board);
                        currentState = currentState.Parent;
                    }
                    solution.Reverse();
                    return solution;
                }

                List<_8_puzzle> successors = currentState.GetSuccessors();
                foreach (_8_puzzle successor in successors)
                {
                    if (!closedList.Contains(successor.Board))
                    {
                        _8_puzzle openState = openList.Find(state => state.Board.Equals(successor.Board));
                        if (openState == null)
                        {
                            openList.Add(successor);
                        }
                        else if (successor.F < openState.F)
                        {
                            openState.G = successor.G;
                            openState.H = successor.H;
                            openState.Parent = successor.Parent;
                        }
                    }
                }

                openList.Sort((state1, state2) => state1.F.CompareTo(state2.F));
            }

            return null;
        }
    }
}
