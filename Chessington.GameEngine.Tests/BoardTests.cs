using Chessington.GameEngine.Pieces;
using FluentAssertions;
using NUnit.Framework;

namespace Chessington.GameEngine.Tests
{
    [TestFixture]
    public class BoardTests
    {
        [Test]
        public void PawnCanBeAddedToBoard()
        {
            var board = new Board();
            var pawn = new Pawn(Player.White);
            board.AddPiece(Square.At(0, 0), pawn);

            board.GetPiece(Square.At(0, 0)).Should().BeSameAs(pawn);
        }

        [Test]
        public void PawnCanBeFoundOnBoard()
        {
            var board = new Board();
            var pawn = new Pawn(Player.White);
            var square = Square.At(6, 4);
            board.AddPiece(square, pawn);

            var location = board.FindPiece(pawn);

            location.Should().Be(square);
        }

        [Test]
        public void Square00CanBeValidated()
        {
            var board = new Board();
            var square = Square.At(0, 0);
            square.IsValid().Should().Be(true);
        }
        
        [Test]
        public void Square07CanBeValidated()
        {
            var board = new Board();
            var square = Square.At(0, 7);
            square.IsValid().Should().Be(true);
        }
        
        [Test]
        public void Square70CanBeValidated()
        {
            var board = new Board();
            var square = Square.At(7, 0);
            square.IsValid().Should().Be(true);
        }
        
        
        [Test]
        public void Square77CanBeValidated()
        {
            var board = new Board();
            var square = Square.At(7, 7);
            square.IsValid().Should().Be(true);
        }
    }
}
