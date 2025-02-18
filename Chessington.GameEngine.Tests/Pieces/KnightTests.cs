﻿using System.Linq;
using Chessington.GameEngine.Pieces;
using FluentAssertions;
using NUnit.Framework;

namespace Chessington.GameEngine.Tests.Pieces
{
    [TestFixture]
    public class KnightTests
    {
        [Test]
        public void KnightMovesFromCornerOfBoard()
        {
            var board = new Board();
            var knight = new Knight(Player.White);
            board.AddPiece(Square.At(0, 0), knight);
            var moves = knight.GetAvailableMoves(board).ToList();
            
            moves.Count.Should().Be(2);
            moves.Should().Contain(Square.At(2, 1));
            moves.Should().Contain(Square.At(1, 2));
        }
        
        [Test]
        public void KnightMovesFromCentreOfBoard()
        {
            var board = new Board();
            var knight = new Knight(Player.White);
            board.AddPiece(Square.At(5, 5), knight);
            var moves = knight.GetAvailableMoves(board).ToList();
            
            moves.Count.Should().Be(8);
            moves.Should().Contain(Square.At(3, 4));
            moves.Should().Contain(Square.At(4, 3));
            
            moves.Should().Contain(Square.At(3, 6));
            moves.Should().Contain(Square.At(4, 7));
            
            moves.Should().Contain(Square.At(6, 7));
            moves.Should().Contain(Square.At(7, 6));
            
            moves.Should().Contain(Square.At(7, 4));
            moves.Should().Contain(Square.At(6, 3));
        }
        
        [Test]
        public void KnightBlockedByFriendlyPieces()
        {
            var board = new Board();
            var knight = new Knight(Player.White);
            board.AddPiece(Square.At(5, 5), knight);
            var friendlyPiece1 = new Pawn(Player.White);
            board.AddPiece(Square.At(3, 4), friendlyPiece1);
            var friendlyPiece2 = new Pawn(Player.White);
            board.AddPiece(Square.At(5, 4), friendlyPiece2);
            var moves = knight.GetAvailableMoves(board).ToList();
            
            moves.Count.Should().Be(7);
            moves.Should().NotContain(Square.At(3, 4));
            moves.Should().Contain(Square.At(4, 3));
            
            moves.Should().Contain(Square.At(3, 6));
            moves.Should().Contain(Square.At(4, 7));
            
            moves.Should().Contain(Square.At(6, 7));
            moves.Should().Contain(Square.At(7, 6));
            
            moves.Should().Contain(Square.At(7, 4));
            moves.Should().Contain(Square.At(6, 3));
        }
        
        [Test]
        public void KnightCanCaptureOpposingPieces()
        {
            var board = new Board();
            var knight = new Knight(Player.White);
            board.AddPiece(Square.At(5, 5), knight);
            var opposingPiece = new Pawn(Player.Black);
            board.AddPiece(Square.At(3, 4), opposingPiece);
            var moves = knight.GetAvailableMoves(board).ToList();
            
            moves.Count.Should().Be(8);
            moves.Should().Contain(Square.At(3, 4));
            moves.Should().Contain(Square.At(4, 3));
            
            moves.Should().Contain(Square.At(3, 6));
            moves.Should().Contain(Square.At(4, 7));
            
            moves.Should().Contain(Square.At(6, 7));
            moves.Should().Contain(Square.At(7, 6));
            
            moves.Should().Contain(Square.At(7, 4));
            moves.Should().Contain(Square.At(6, 3));
        }
    }
}