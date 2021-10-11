using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public override int Value => 1;
        
        public Pawn(Player player)
            : base(player)
        {
        }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var moveSquares = GetValidMovePatternSquares(board)
                .Where(square => !board.SquareOccupied(square) && !board.PathBlocked(GetPath(board, square)));
            var attackSquares = GetValidAttackPatternSquares(board)
                .Where(square => board.SquareOccupiedBy(square, Player.Other()));
            return moveSquares.Concat(attackSquares);
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

        private IEnumerable<Square> GetValidMovePatternSquares(Board board)
        {
            return GetMovePatternSquares(board)
                .Where(square => square.IsValid());
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

        private IEnumerable<Square> GetValidAttackPatternSquares(Board board)
        {
            return GetAttackPatternSquares(board)
                .Where(square => square.IsValid());
        }

        private IEnumerable<Square> GetAttackPatternSquares(Board board)
        {
            var location = board.FindPiece(this);
            return GetTwoAttackSquares(Player == Player.Black ? location.Row + 1 : location.Row - 1, location.Col);
        }

        private static IEnumerable<Square> GetTwoAttackSquares(int row, int middleCol)
        {
            yield return Square.At(row, middleCol + 1);
            yield return Square.At(row, middleCol - 1);
        }
    }
}