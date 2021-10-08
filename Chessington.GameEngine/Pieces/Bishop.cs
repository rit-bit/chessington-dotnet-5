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
            return GetDiagonalMoves(board, position, 1, 1)
                .Concat(GetDiagonalMoves(board, position, 1, -1))
                .Concat(GetDiagonalMoves(board, position, -1, 1))
                .Concat(GetDiagonalMoves(board, position, -1, -1));
        }

        private IEnumerable<Square> GetDiagonalMoves(Board board, Square position, int rowIncrement, int colIncrement)
        {
            var newSquare = Square.At(position.Row + colIncrement, position.Col + rowIncrement);
            while (newSquare.IsValid())
            {
                if (board.SquareOccupiedBy(newSquare, Player.Other()))
                {
                    yield return newSquare;
                }
                if (board.SquareOccupied(newSquare))
                {
                    yield break;
                }
                yield return newSquare;
                newSquare = Square.At(newSquare.Row + colIncrement, newSquare.Col + rowIncrement);
            }
        }
        
    }
}