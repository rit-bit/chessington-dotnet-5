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
            return GetPairOfMoves(board, position, a)
                .Concat(GetPairOfMoves(board, position, b))
                .Concat(GetPairOfMoves(board, position, c))
                .Concat(GetPairOfMoves(board, position, d));
        }

        private IEnumerable<Square> GetPairOfMoves(Board board,Square position, other)
        {
            
        }

}
}