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
        public void BishopCanMoveForwardDiagonally()
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
    }
}