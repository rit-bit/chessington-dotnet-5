using System.Linq;
using Chessington.GameEngine.Pieces;
using FluentAssertions;
using NUnit.Framework;

namespace Chessington.GameEngine.Tests.Pieces
{
    [TestFixture]
    public class RookTests
    {
        [Test]
        public void RookCanMoveOn1Diagonal()
        {
            var board = new Board();
            var rook = new Rook(Player.White);
            board.AddPiece(Square.At(0, 0), rook);
            var moves = rook.GetAvailableMoves(board).ToList();

            moves.Count.Should().Be(14);
            for (var i = 1; i < 8; i++)
            {
                moves.Should().Contain(Square.At(0, i));
                moves.Should().Contain(Square.At(i, 0));
            }
        }
        
        [Test]
        public void RookCanMoveIn4Directions()
        {
            var board = new Board();
            var rook = new Rook(Player.Black);
            board.AddPiece(Square.At(5, 2), rook);
            var moves = rook.GetAvailableMoves(board).ToList();

            moves.Count.Should().Be(14);
            moves.Should().Contain(Square.At(0, 2));
            moves.Should().Contain(Square.At(1, 2));
            moves.Should().Contain(Square.At(2, 2));
            moves.Should().Contain(Square.At(3, 2));
            moves.Should().Contain(Square.At(4, 2));
            moves.Should().Contain(Square.At(5, 0));
            moves.Should().Contain(Square.At(5, 1));
            moves.Should().Contain(Square.At(5, 3));
            moves.Should().Contain(Square.At(5, 4));
            moves.Should().Contain(Square.At(5, 5));
            moves.Should().Contain(Square.At(5, 6));
            moves.Should().Contain(Square.At(5, 7));
            moves.Should().Contain(Square.At(6, 4));
            moves.Should().Contain(Square.At(7, 5));
        }
        
        [Test]
        public void RookIsBlockedByFriendlyPiece()
        {
            var board = new Board();
            var rook = new Rook(Player.White);
            board.AddPiece(Square.At(1, 4), rook);
            var friendlyPawn = new Pawn(Player.White);
            board.AddPiece(Square.At(1, 1), friendlyPawn);
            var moves = rook.GetAvailableMoves(board).ToList();

            moves.Count.Should().Be(12);
            moves.Should().NotContain(Square.At(1, 0));
            moves.Should().NotContain(Square.At(1, 1));
        }
        
        [Test]
        public void RookCanTakeOpposingPiece()
        {
            var board = new Board();
            var rook = new Rook(Player.White);
            board.AddPiece(Square.At(1, 4), rook);
            var friendlyPawn = new Pawn(Player.Black);
            board.AddPiece(Square.At(1, 1), friendlyPawn);
            var moves = rook.GetAvailableMoves(board).ToList();

            moves.Count.Should().Be(12);
            moves.Should().NotContain(Square.At(1, 0));
            moves.Should().Contain(Square.At(1, 1));
        }
    }
}