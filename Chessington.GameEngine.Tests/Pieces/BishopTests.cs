using System.Linq;
using Chessington.GameEngine.Pieces;
using FluentAssertions;
using NUnit.Framework;

namespace Chessington.GameEngine.Tests.Pieces
{
    [TestFixture]
    public class BishopTests
    {
        [Test]
        public void BishopCanMoveOn1Diagonal()
        {
            var board = new Board();
            var bishop = new Bishop(Player.Black);
            board.AddPiece(Square.At(0, 0), bishop);
            var moves = bishop.GetAvailableMoves(board).ToList();

            moves.Count.Should().Be(7);
            for (var i = 1; i < 8; i++)
            {
                moves.Should().Contain(Square.At(i, i));
            }
        }
        
        [Test]
        public void BishopCanMoveOn4Diagonals()
        {
            var board = new Board();
            var bishop = new Bishop(Player.Black);
            board.AddPiece(Square.At(4, 2), bishop);
            var moves = bishop.GetAvailableMoves(board).ToList();

            moves.Count.Should().Be(11);
            moves.Should().Contain(Square.At(0, 6));
            moves.Should().Contain(Square.At(1, 5));
            moves.Should().Contain(Square.At(2, 0));
            moves.Should().Contain(Square.At(2, 4));
            moves.Should().Contain(Square.At(3, 1));
            moves.Should().Contain(Square.At(3, 3));
            moves.Should().Contain(Square.At(5, 1));
            moves.Should().Contain(Square.At(5, 3));
            moves.Should().Contain(Square.At(6, 0));
            moves.Should().Contain(Square.At(6, 4));
            moves.Should().Contain(Square.At(7, 5));
        }
        
        [Test]
        public void BishopIsBlockedByFriendlyPiece()
        {
            var board = new Board();
            var bishop = new Bishop(Player.Black);
            board.AddPiece(Square.At(1, 4), bishop);
            var friendlyPawn = new Pawn(Player.Black);
            board.AddPiece(Square.At(3, 2), friendlyPawn);
            var moves = bishop.GetAvailableMoves(board).ToList();

            moves.Count.Should().Be(6);
            moves.Should().NotContain(Square.At(3, 2));
            moves.Should().NotContain(Square.At(4, 1));
        }
        
        [Test]
        public void BishopCanTakeOpposingPiece()
        {
            var board = new Board();
            var bishop = new Bishop(Player.White);
            board.AddPiece(Square.At(1, 4), bishop);
            var friendlyPawn = new Pawn(Player.Black);
            board.AddPiece(Square.At(3, 2), friendlyPawn);
            var moves = bishop.GetAvailableMoves(board).ToList();

            moves.Count.Should().Be(7);
            moves.Should().Contain(Square.At(3, 2));
            moves.Should().NotContain(Square.At(4, 1));
        }
    }
}