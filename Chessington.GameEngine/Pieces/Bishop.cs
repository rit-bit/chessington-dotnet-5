using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : StraightLinePiece
    {
        public Bishop(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var position = board.FindPiece(this);
            return GetStraightLineMoves(board, position, 1, 1)
                .Concat(GetStraightLineMoves(board, position, 1, -1))
                .Concat(GetStraightLineMoves(board, position, -1, 1))
                .Concat(GetStraightLineMoves(board, position, -1, -1));
        }

        
        
    }
}