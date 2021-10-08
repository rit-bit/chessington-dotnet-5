namespace Chessington.GameEngine
{
    public enum Player
    {
        White,
        Black
    }

    internal static class PlayerMethods
    {
        public static Player Other(this Player player)
        {
            return player == Player.White ? Player.Black : Player.White;
        }
    }
}