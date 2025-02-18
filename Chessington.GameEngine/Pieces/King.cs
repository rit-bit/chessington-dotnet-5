using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class King : Piece
    {
        public King(Player player)
            : base(player) { }

        public override int Value => 0;

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var location = board.FindPiece(this);
            /*foreach (var move in GetUnoccupiedMoves(board))
            {
                var clone = board.Clone();
                clone.MovePiece(location, move);
                if (clone.IsInCheck(move, Player))
                {
                    yield return move;
                }
            }*/
            return GetUnoccupiedMoves(board); // TODO Remove when uncommenting the code above
        }

        private IEnumerable<Square> GetUnoccupiedMoves(Board board)
        {
            return GetValidMoves(board)
                .Where(square => !board.SquareOccupiedBy(square, Player));
        }

        private IEnumerable<Square> GetValidMoves(Board board)
        {
            return GetMovePatternSquares(board).Where(square => square.IsValid());
        }

        private IEnumerable<Square> GetMovePatternSquares(Board board)
        {
            var location = board.FindPiece(this);
            for (var rowDif = -1; rowDif <= 1; rowDif++)
            {
                for (var colDif = -1; colDif <= 1; colDif++)
                {
                    if (!(rowDif == 0 && colDif == 0))
                    {
                        yield return Square.At(location.Row + rowDif, location.Col + colDif);
                    }
                }
            }
        }
    }
}