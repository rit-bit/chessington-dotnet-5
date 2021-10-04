using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Media.Imaging;
using Chessington.GameEngine;
using Chessington.UI.Caliburn.Micro;
using Chessington.UI.Factories;
using Chessington.UI.Notifications;
using Chessington.UI.Properties;

namespace Chessington.UI.ViewModels
{
    public class SquareViewModel : INotifyPropertyChanged, 
        IHandle<PiecesMoved>, 
        IHandle<PieceSelected>, 
        IHandle<ValidMovesUpdated>, 
        IHandle<SelectionCleared>
    {
        private bool _selected;
        private bool _validMovementTarget;
        private BitmapImage _image;

        public SquareViewModel(Square square)
        {
            this.Location = square;
            ChessingtonServices.EventAggregator.Subscribe(this);
        }

        public Square Location { get; }

        public SquareViewModel Self => this;

        public bool Selected
        {
            get => _selected;
            set
            {
                if (value.Equals(_selected)) return;
                _selected = value;
                OnPropertyChanged();
                OnPropertyChanged("Self");
            }
        }

        public bool ValidMovementTarget
        {
            get => _validMovementTarget;
            set
            {
                if (value.Equals(_validMovementTarget)) return;
                _validMovementTarget = value;
                OnPropertyChanged();
                OnPropertyChanged("Self");
            }
        }

        public BitmapImage Image
        {
            get => _image;
            set
            {
                if (Equals(value, _image)) return;
                _image = value;
                OnPropertyChanged();
                OnPropertyChanged("Self");
            }
        }

        public void Handle(PieceSelected notification)
        {
            Selected = notification.Square.Equals(Location);
        }

        public void Handle(PiecesMoved notification)
        {
            var currentPiece = notification.Board.GetPiece(Location);

            if (currentPiece == null)
            {
                Image = null;
                return;
            }

            Image = PieceImageFactory.GetImage(currentPiece);
        }

        public void Handle(ValidMovesUpdated message)
        {
            ValidMovementTarget = message.Moves.Contains(Location);
        }
        
        public void Handle(SelectionCleared message)
        {
            Selected = false;
            ValidMovementTarget = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}