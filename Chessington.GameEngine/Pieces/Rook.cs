using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : StraightLinePiece
    {
        public Rook(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var position = board.FindPiece(this);
            return GetStraightLineMoves(board, position, 1, 0)
                .Concat(GetStraightLineMoves(board, position, -1, 0))
                .Concat(GetStraightLineMoves(board, position, 0, 1))
                .Concat(GetStraightLineMoves(board, position, 0, -1));
        }

        
    }
}