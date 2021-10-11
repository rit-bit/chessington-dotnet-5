

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

        public int GetWhiteScore()
        {
            return _board.CapturedPieces
                .Where(piece => piece.Player == Player.Black)
                .Sum(piece => piece.Value);
        }

        public int GetBlackScore()
        {
            return _board.CapturedPieces
                .Where(piece => piece.Player == Player.White)
                .Sum(piece => piece.Value);
        }
    }
}