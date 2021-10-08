using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var location = board.FindPiece(this);
            if (Player == Player.Black)
            {
                yield return Square.At(location.Row + 1, location.Col);
            }
            else
            {
                yield return Square.At(location.Row - 1, location.Col);
            }
        }
    }
}