using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player)
            : base(player)
        {
        }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            return GetMovePatternSquares(board)
                .Where(square => !board.SquareOccupied(square) && !board.PathBlocked(GetPath(board, square)));
        }

        private IEnumerable<Square> GetPath(Board board, Square destination)
        {
            var location = board.FindPiece(this);
            var rowDifference = Math.Abs(destination.Row - location.Row);
            if (rowDifference == 2)
            {
                var rowInBetween = (destination.Row + location.Row) / 2;
                yield return Square.At(rowInBetween, location.Col);
            }
        }

        private IEnumerable<Square> GetMovePatternSquares(Board board)
        {
            var location = board.FindPiece(this);
            if (Player == Player.Black)
            {
                yield return Square.At(location.Row + 1, location.Col);
                if (!HasBeenMoved)
                {
                    yield return Square.At(location.Row + 2, location.Col);
                }
            }
            else
            {
                yield return Square.At(location.Row - 1, location.Col);
                if (!HasBeenMoved)
                {
                    yield return Square.At(location.Row - 2, location.Col);
                }
            }
        }
    }
}