using System;
using System.Collections.Generic;
using System.Linq;
using Chessington.GameEngine.Pieces;

namespace Chessington.GameEngine
{
    public class Board
    {
        private readonly Piece[,] _board;
        public Player CurrentPlayer { get; private set; }
        public IList<Piece> CapturedPieces { get; private set; } 

        public Board()
            : this(Player.White) { }

        public Board(Player currentPlayer, Piece[,] boardState = null)
        {
            _board = boardState ?? new Piece[GameSettings.BoardSize, GameSettings.BoardSize]; 
            CurrentPlayer = currentPlayer;
            CapturedPieces = new List<Piece>();
        }

        private Board(Board board)
        {
            _board = ClonePieceArray(board._board);
            CurrentPlayer = board.CurrentPlayer;
            CapturedPieces = board.CapturedPieces;
        }

        public Board Clone()
        {
            return new Board(this);
        }

        private static Piece[,] ClonePieceArray(Piece[,] toClone)
        {
            var pieces = new Piece[GameSettings.BoardSize, GameSettings.BoardSize];
            foreach (var square in Square.All())
            {
                // pieces[square.Row, square.Col] = toClone[square.Row, square.Col].Clone();
                // TODO Implement cloning on Pieces/subclasses ?
            }
            return pieces;
        }

        public void AddPiece(Square square, Piece pawn)
        {
            _board[square.Row, square.Col] = pawn;
        }
    
        public Piece GetPiece(Square square)
        {
            return _board[square.Row, square.Col];
        }
        
        public Square FindPiece(Piece piece)
        {
            for (var row = 0; row < GameSettings.BoardSize; row++)
                for (var col = 0; col < GameSettings.BoardSize; col++)
                    if (_board[row, col] == piece)
                        return Square.At(row, col);

            throw new ArgumentException("The supplied piece is not on the board.", "piece");
        }

        public bool SquareOccupied(Square square)
        {
            return _board[square.Row, square.Col] != null;
        }
        
        public bool SquareOccupiedBy(Square square, Player player)
        {
            if (!SquareOccupied(square))
            {
                return false;
            }

            return _board[square.Row, square.Col].Player == player;
        }

        public bool PathBlocked(IEnumerable<Square> path)
        {
            return path.Any(SquareOccupied);
        }

        public bool IsInCheck(Square position, Player defender)
        {
            foreach (var square in Square.All())
            {
                if (SquareOccupied(square))
                {
                    var piece = _board[square.Row, square.Col];
                    if (piece.Player == defender.Other() && piece.GetAvailableMoves(this).Contains(position))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public void MovePiece(Square from, Square to)
        {
            var movingPiece = _board[from.Row, from.Col];
            if (movingPiece == null) { return; }

            if (movingPiece.Player != CurrentPlayer)
            {
                throw new ArgumentException("The supplied piece does not belong to the current player.");
            }

            //If the space we're moving to is occupied, we need to mark it as captured.
            if (_board[to.Row, to.Col] != null)
            {
                OnPieceCaptured(_board[to.Row, to.Col]);
            }

            //Move the piece and set the 'from' square to be empty.
            _board[to.Row, to.Col] = _board[from.Row, from.Col];
            _board[from.Row, from.Col] = null;

            CurrentPlayer = movingPiece.Player.Other();
            OnCurrentPlayerChanged(CurrentPlayer);
        }
        
        public delegate void PieceCapturedEventHandler(Piece piece);
        
        public event PieceCapturedEventHandler PieceCaptured;

        protected virtual void OnPieceCaptured(Piece piece)
        {
            var handler = PieceCaptured;
            handler?.Invoke(piece);
        }

        public delegate void CurrentPlayerChangedEventHandler(Player player);

        public event CurrentPlayerChangedEventHandler CurrentPlayerChanged;

        protected virtual void OnCurrentPlayerChanged(Player player)
        {
            var handler = CurrentPlayerChanged;
            handler?.Invoke(player);
        }
    }
}
