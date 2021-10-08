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
    }
}