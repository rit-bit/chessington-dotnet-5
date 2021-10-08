using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    public abstract class StraightLinePiece : Piece
    {
        protected StraightLinePiece(Player player) : base(player)
        {
        }
        
        protected IEnumerable<Square> GetStraightLineMoves(Board board, Square position, int rowIncrement, int colIncrement)
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