using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player player)
            : base(player)
        {
        }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            return GetMovePatternSquares(board)
                .Where(square => square.IsValid() && !board.SquareOccupiedBy(square, Player));
        }

        private IEnumerable<Square> GetMovePatternSquares(Board board)
        {
            var position = board.FindPiece(this);
            var a = GetPairOfMoves(board, position, 2, true);
            var b = (GetPairOfMoves(board, position, -2, true));
            var c = (GetPairOfMoves(board, position, 2, false));
            var d = (GetPairOfMoves(board, position, -2, false));
            return a.Concat(b).Concat(c).Concat(d);
        }

        private IEnumerable<Square> GetPairOfMoves(Board board,Square position, int increment, bool vertical)
        {
            if (vertical)
            {
                yield return Square.At(position.Row + increment, position.Col + 1);
                yield return Square.At(position.Row + increment, position.Col - 1);
            }
            else
            {
                yield return Square.At(position.Row + 1, position.Col + increment);
                yield return Square.At(position.Row - 1, position.Col + increment);
            }
        }

}
}