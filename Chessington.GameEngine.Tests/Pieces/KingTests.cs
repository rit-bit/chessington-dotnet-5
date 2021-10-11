using System.Linq;
using Chessington.GameEngine.Pieces;
using FluentAssertions;
using NUnit.Framework;

namespace Chessington.GameEngine.Tests.Pieces
{
    [TestFixture]
    public class KingTests
    {
        [Test]
        public void KingBasicMovementEdgeOfBoard()
        {
            var board = new Board();
            var king = new King(Player.White);
            board.AddPiece(Square.At(0, 3), king);
            var moves = king.GetAvailableMoves(board).ToList();

            moves.Count.Should().Be(5);
        }
        
        [Test]
        public void KingBasicMovementMiddleOfBoard()
        {
            var board = new Board();
            var king = new King(Player.Black);
            board.AddPiece(Square.At(3, 4), king);
            var moves = king.GetAvailableMoves(board).ToList();

            moves.Count.Should().Be(8);
        }
        
        [Test]
        public void KingCapturingAndBlocking()
        {
            var board = new Board();
            var king = new King(Player.Black);
            board.AddPiece(Square.At(5, 0), king);
            var friendlyPiece = new Pawn(Player.Black);
            board.AddPiece(Square.At(4, 1), friendlyPiece);
            var opposingPiece = new Pawn(Player.White);
            board.AddPiece(Square.At(4, 0), opposingPiece);
            var moves = king.GetAvailableMoves(board).ToList();

            moves.Count.Should().Be(4);
            moves.Should().NotContain(Square.At(4, 1));
            
            moves.Should().Contain(Square.At(4, 0));
            moves.Should().Contain(Square.At(5, 1));
            moves.Should().Contain(Square.At(6, 1));
            moves.Should().Contain(Square.At(6, 0));
        }
        
        [Test]
        public void KingCantMoveIntoCheck()
        {
            var board = new Board();
            var king = new King(Player.Black);
            board.AddPiece(Square.At(7, 1), king);
            var opposingRook = new Rook(Player.White);
            board.AddPiece(Square.At(6, 7), opposingRook);
            var moves = king.GetAvailableMoves(board).ToList();

            moves.Count.Should().Be(2);
            moves.Should().NotContain(Square.At(6, 2));
            moves.Should().NotContain(Square.At(6, 1));
            moves.Should().NotContain(Square.At(6, 0));
            
            moves.Should().Contain(Square.At(7, 2));
            moves.Should().Contain(Square.At(7, 0));
        }

        [Test]
        public void KingCanMoveIntoLineOfFriendlyRook()
        {
            var board = new Board();
            var king = new King(Player.White);
            board.AddPiece(Square.At(7, 1), king);
            var opposingRook = new Rook(Player.White);
            board.AddPiece(Square.At(6, 7), opposingRook);
            var moves = king.GetAvailableMoves(board).ToList();

            moves.Count.Should().Be(5);
            moves.Should().Contain(Square.At(6, 2));
            moves.Should().Contain(Square.At(6, 1));
            moves.Should().Contain(Square.At(6, 0));
            moves.Should().Contain(Square.At(7, 2));
            moves.Should().Contain(Square.At(7, 0));
        }
    }
}