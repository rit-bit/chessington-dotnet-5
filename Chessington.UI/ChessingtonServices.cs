using Chessington.UI.Caliburn.Micro;

namespace Chessington.UI
{
    /// <summary>
    /// Simple Singleton wrapper for any common application services.
    /// 
    /// We should use this until we transition to Dependency Injection.
    /// </summary>
    public static class ChessingtonServices
    {
        private static IEventAggregator _eventAggregator;

        public static IEventAggregator EventAggregator => _eventAggregator ??= new EventAggregator();
    }
}