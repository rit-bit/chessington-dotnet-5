using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    public abstract class Piece
    {
        public abstract int Value { get; }
        protected Piece(Player player)
        {
            Player = player;
        }

        public Player Player { get; private set; }
        public bool HasBeenMoved { get; private set; }

        public abstract IEnumerable<Square> GetAvailableMoves(Board board);

        // protected abstract IEnumerable<Square> GetMovePatternSquares(Board board);

        public void MoveTo(Board board, Square newSquare)
        {
            var currentSquare = board.FindPiece(this);
            board.MovePiece(currentSquare, newSquare);
            HasBeenMoved = true;
        }
    }
}