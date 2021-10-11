using System.Collections.Generic;
using System.Windows.Documents;
using Chessington.GameEngine.Pieces;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using NUnit;

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
        
        [Test]
        public void SimpleWhiteScoreCount()
        {
            var board = A.Fake<IBoard>();
            var pieces = new List<Piece>
            {
                new Pawn(Player.White),
                new Pawn(Player.White),
                new Pawn(Player.Black)
            };
            A.CallTo(() => board.CapturedPieces).Returns(pieces);
            var calculator = new ScoreCalculator(board);
            var whiteScore = calculator.GetWhiteScore();

            whiteScore.Should().Be(2);
        }

        [Test]
        public void SimpleBlackScoreCount()
        {
            var board = A.Fake<IBoard>();
            var pieces = new List<Piece>
            {
                new Pawn(Player.White),
                new Pawn(Player.White),
                new Pawn(Player.Black)
            };
            A.CallTo(() => board.CapturedPieces).Returns(pieces);
            var calculator = new ScoreCalculator(board);
            var blackScore = calculator.GetBlackScore();

            blackScore.Should().Be(1);
        }
        
        [Test]
        public void ComplexBlackScoreCount()
        {
            var board = A.Fake<IBoard>();
            var pieces = new List<Piece>
            {
                new Pawn(Player.White),
                new Pawn(Player.White),
                new Pawn(Player.Black),
                new Bishop(Player.Black),
                new Bishop(Player.White),
                new Rook(Player.White),
                new Rook(Player.White),
                new Queen(Player.Black)
            };
            A.CallTo(() => board.CapturedPieces).Returns(pieces);
            var calculator = new ScoreCalculator(board);
            var blackScore = calculator.GetBlackScore();

            blackScore.Should().Be(17);
        }
        
        [Test]
        public void ComplexWhiteScoreCount()
        {
            var board = A.Fake<IBoard>();
            var pieces = new List<Piece>
            {
                new Pawn(Player.White),
                new Pawn(Player.White),
                new Pawn(Player.Black),
                new Bishop(Player.Black),
                new Bishop(Player.White),
                new Rook(Player.White),
                new Rook(Player.White),
                new Queen(Player.Black)
            };
            A.CallTo(() => board.CapturedPieces).Returns(pieces);
            var calculator = new ScoreCalculator(board);
            var whiteScore = calculator.GetWhiteScore();

            whiteScore.Should().Be(15);
        }
    }
}
