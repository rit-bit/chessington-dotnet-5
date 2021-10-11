using System.Collections.Generic;
using Chessington.GameEngine.Pieces;

namespace Chessington.GameEngine
{
    public interface IBoard
    {
        public Player CurrentPlayer { get; set; }
        public IList<Piece> CapturedPieces { get; set; }

        public void AddPiece(Square square, Piece pawn);

        public Piece GetPiece(Square square);

        public Square FindPiece(Piece piece);

        public bool SquareOccupied(Square square);

        public bool SquareOccupiedBy(Square square, Player player);

        public bool PathBlocked(IEnumerable<Square> path);

        public void MovePiece(Square from, Square to);
        
        public delegate void PieceCapturedEventHandler(Piece piece);
        
        public event PieceCapturedEventHandler PieceCaptured;

        protected abstract void OnPieceCaptured(Piece piece);

        public delegate void CurrentPlayerChangedEventHandler(Player player);

        public event CurrentPlayerChangedEventHandler CurrentPlayerChanged;

        protected abstract void OnCurrentPlayerChanged(Player player);
    }
}