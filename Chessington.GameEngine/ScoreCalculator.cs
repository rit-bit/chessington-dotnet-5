

using System.Linq;

namespace Chessington.GameEngine
{
    public class ScoreCalculator
    {
        private IBoard _board;

        public ScoreCalculator(IBoard board)
        {
            _board = board;
        }

        public int GetScore(Player player)
        {
            return _board.CapturedPieces
                .Where(piece => piece.Player == player.Other())
                .Sum(piece => piece.Value);
        }
    }
}