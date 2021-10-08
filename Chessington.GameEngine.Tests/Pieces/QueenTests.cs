using System.Linq;
using Chessington.GameEngine.Pieces;
using FluentAssertions;
using NUnit.Framework;

namespace Chessington.GameEngine.Tests.Pieces
{
    [TestFixture]
    public class QueenTests
    {
        [Test]
        public void QueenCanMoveIn4Directions()
        {
            var board = new Board();
            var queen = new Queen(Player.Black);
            board.AddPiece(Square.At(5, 1), queen);
            var moves = queen.GetAvailableMoves(board).ToList();

            moves.Count.Should().Be(23);
            moves.Should().Contain(Square.At(0, 1));
            moves.Should().Contain(Square.At(0, 6));
            moves.Should().Contain(Square.At(1, 1));
            moves.Should().Contain(Square.At(1, 5));
            moves.Should().Contain(Square.At(2, 1));
            moves.Should().Contain(Square.At(2, 4));
            moves.Should().Contain(Square.At(3, 1));
            moves.Should().Contain(Square.At(3, 3));
            moves.Should().Contain(Square.At(4, 0));
            moves.Should().Contain(Square.At(4, 1));
            moves.Should().Contain(Square.At(4, 2));
            moves.Should().Contain(Square.At(5, 0));
            moves.Should().Contain(Square.At(5, 2));
            moves.Should().Contain(Square.At(5, 3));
            moves.Should().Contain(Square.At(5, 4));
            moves.Should().Contain(Square.At(5, 5));
            moves.Should().Contain(Square.At(5, 6));
            moves.Should().Contain(Square.At(5, 7));
            moves.Should().Contain(Square.At(6, 0));
            moves.Should().Contain(Square.At(6, 1));
            moves.Should().Contain(Square.At(6, 2));
            moves.Should().Contain(Square.At(7, 1));
            moves.Should().Contain(Square.At(7, 3));
        }
        
        [Test]
        public void QueenBlockedByFriendlyPieces()
        {
            var board = new Board();
            var queen = new Queen(Player.Black);
            board.AddPiece(Square.At(5, 1), queen);
            var friendlyPiece1 = new Pawn(Player.Black);
            board.AddPiece(Square.At(2, 4), friendlyPiece1);
            var friendlyPiece2 = new Pawn(Player.Black);
            board.AddPiece(Square.At(5, 4), friendlyPiece2);
            var moves = queen.GetAvailableMoves(board).ToList();

            moves.Count.Should().Be(16);
            moves.Should().Contain(Square.At(0, 1));
            moves.Should().Contain(Square.At(1, 1));
            moves.Should().Contain(Square.At(2, 1));
            moves.Should().Contain(Square.At(3, 1));
            moves.Should().Contain(Square.At(3, 3));
            moves.Should().Contain(Square.At(4, 0));
            moves.Should().Contain(Square.At(4, 1));
            moves.Should().Contain(Square.At(4, 2));
            moves.Should().Contain(Square.At(5, 0));
            moves.Should().Contain(Square.At(5, 2));
            moves.Should().Contain(Square.At(5, 3));
            moves.Should().Contain(Square.At(6, 0));
            moves.Should().Contain(Square.At(6, 1));
            moves.Should().Contain(Square.At(6, 2));
            moves.Should().Contain(Square.At(7, 1));
            moves.Should().Contain(Square.At(7, 3));
        }
        
        [Test]
        public void QueenCaptureOpposingPiece()
        {
            var board = new Board();
            var queen = new Queen(Player.Black);
            board.AddPiece(Square.At(5, 1), queen);
            var friendlyPiece1 = new Pawn(Player.Black);
            board.AddPiece(Square.At(2, 4), friendlyPiece1);
            var friendlyPiece2 = new Pawn(Player.White);
            board.AddPiece(Square.At(5, 4), friendlyPiece2);
            var moves = queen.GetAvailableMoves(board).ToList();

            moves.Count.Should().Be(16);
            moves.Should().Contain(Square.At(0, 1));
            moves.Should().Contain(Square.At(1, 1));
            moves.Should().Contain(Square.At(2, 1));
            moves.Should().Contain(Square.At(3, 1));
            moves.Should().Contain(Square.At(3, 3));
            moves.Should().Contain(Square.At(4, 0));
            moves.Should().Contain(Square.At(4, 1));
            moves.Should().Contain(Square.At(4, 2));
            moves.Should().Contain(Square.At(5, 0));
            moves.Should().Contain(Square.At(5, 2));
            moves.Should().Contain(Square.At(5, 3));
            moves.Should().Contain(Square.At(5, 4));
            moves.Should().Contain(Square.At(6, 0));
            moves.Should().Contain(Square.At(6, 1));
            moves.Should().Contain(Square.At(6, 2));
            moves.Should().Contain(Square.At(7, 1));
            moves.Should().Contain(Square.At(7, 3));
        }
    }
}