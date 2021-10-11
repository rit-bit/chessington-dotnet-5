using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Queen : StraightLinePiece
    {
        public override int Value => 9;
        
        public Queen(Player player)
            : base(player)
        {
        }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var position = board.FindPiece(this);
            // Orthogonals
            return GetStraightLineMoves(board, position, 1, 0)
                .Concat(GetStraightLineMoves(board, position, -1, 0))
                .Concat(GetStraightLineMoves(board, position, 0, 1))
                .Concat(GetStraightLineMoves(board, position, 0, -1))
                // Diagonals
                .Concat(GetStraightLineMoves(board, position, 1, 1))
                .Concat(GetStraightLineMoves(board, position, 1, -1))
                .Concat(GetStraightLineMoves(board, position, -1, 1))
                .Concat(GetStraightLineMoves(board, position, -1, -1));
        }
    }
}