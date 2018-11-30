using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GameBin;
using UI.Annotations;
using UI.Services;
using UI.Views;

namespace UI.ViewModels
{
    class GameViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Card> Cards
        {
            get => _cards;
            set
            {
                _cards = value;
                OnPropertyChanged(nameof(Cards));
            } }
        private ObservableCollection<Card> _cards { get; set; }

        private Board _board;
        public Board Board
        {
            get => _board;
            set
            {
                _board = value;
                Cards = new ObservableCollection<Card>(value.cards.Cast<Card>().ToList());
            }
        }

        private Timer _stateTimer;

        public int Score
        {
            get => _score;
            set
            {
                _score = value;
                OnPropertyChanged(nameof(Score));
            }
        }
        private int _score = 0;

        private Visibility _isShowWinScreen = Visibility.Collapsed;

        public Visibility IsShowWinScreen
        {
            get => _isShowWinScreen;
            set
            {
                _isShowWinScreen = value;
                OnPropertyChanged(nameof(IsShowWinScreen));
            }
        }

        public TimeSpan Time 
        {
            get => _time;
            set
            {
                _time = value;
                OnPropertyChanged(nameof(Time));
            }
        }
        private TimeSpan _time = TimeSpan.Zero;

        private readonly System.Windows.Threading.DispatcherTimer dispatcherTimer;

        public ICommand OpenContexMenuCommand { get; set; }
        public ICommand CloseContextMenuCommand { get; set; }
        public ICommand ClickOnCardCommand { get; set; }
        public ICommand OpenSaveWindowCommand { get; private set; }
        public ICommand SaveGameCommand { get; private set; }
        public Command OpenMainMenuCommand { get; set; }

        void timerTick(object sender, EventArgs e)
        {
            Time += TimeSpan.FromSeconds(1);
        }

        public GameViewModel()
        {
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += timerTick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();

            OpenContexMenuCommand = new ParameterizedCommand((object arg) =>
            {
                ((UIElement)arg).Visibility = Visibility.Visible;
            });

            OpenMainMenuCommand = new Command(() =>
            {
                var mainMenu = new MainMenu();
                App.Current.MainWindow.Content = mainMenu;
            });

            CloseContextMenuCommand = new ParameterizedCommand((object arg) =>
            {
                ((UIElement)arg).Visibility = Visibility.Collapsed;
            });

            ClickOnCardCommand = new ParameterizedCommand((object arg) =>
            {
                var card = (Card) arg;
                var index = Cards.IndexOf(card);
                Board.cardUp(index / 6, index % 6);
                Cards = new ObservableCollection<Card>(Board.cards.Cast<Card>().ToList());
                if (Cards.All(x => x.isUp))
                {
                    IsShowWinScreen = Visibility.Visible;
                }
                Score += 10;
            });

            OpenSaveWindowCommand = new ParameterizedCommand((object arg) =>
            {
                var elements = arg as object[];
                ((UIElement)elements[0]).Visibility = Visibility.Visible;
            });

            SaveGameCommand = new ParameterizedCommand((object arg) =>
            {
                var elements = arg as object[];
                string name = elements[1].ToString();
                SaveManager.SaveGame(1, Board.SaveState(), name);
                ((UIElement)elements[0]).Visibility = Visibility.Collapsed;
            });

            Board = GameFacade.CreateGame(GameType.Simple, 6, 6);
            Cards = new ObservableCollection<Card>(Board.cards.Cast<Card>().ToList());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
