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
            GetPairOfMoves();
        }

        private IEnumerable<Square> GetPairOfMoves()
        {
            
        }

}
}