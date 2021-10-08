using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var position = board.FindPiece(this);
            return GetDiagonalMoves(position, 1, 1)
                .Concat(GetDiagonalMoves(position, 1, -1))
                .Concat(GetDiagonalMoves(position, -1, 1))
                .Concat(GetDiagonalMoves(position, -1, -1));
        }

        private IEnumerable<Square> GetDiagonalMoves(Square position, int rowIncrement, int colIncrement)
        {
            var newSquare = Square.At(position.Row + colIncrement, position.Col + rowIncrement);
            while (newSquare.IsValid())
            {
                yield return newSquare;
                newSquare = Square.At(newSquare.Row + colIncrement, newSquare.Col + rowIncrement);
            }
        }
        
    }
}