using System.Collections.Generic;

namespace Chessington.GameEngine
{
    public struct Square
    {
        public readonly int Row;
        public readonly int Col;

        public Square(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public static Square At(int row, int col)
        {
            return new Square(row, col);
        }

        public static IEnumerable<Square> All()
        {
            for (var row = 0; row < GameSettings.BoardSize; row++)
            {
                for (var col = 0; col < GameSettings.BoardSize; col++)
                {
                    yield return At(row, col);
                }
            }
        }

        public bool IsValid()
        {
            if (Row < 0 || Col < 0)
            {
                return false;
            }

            return Row < GameSettings.BoardSize && Col < GameSettings.BoardSize;
        }

        public bool Equals(Square other)
        {
            return Row == other.Row && Col == other.Col;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Square && Equals((Square)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Row * 397) ^ Col;
            }
        }

        public static bool operator ==(Square left, Square right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Square left, Square right)
        {
            return !left.Equals(right);
        }

        public override string ToString()
        {
            return string.Format("Row {0}, Col {1}", Row, Col);
        }
    }
}