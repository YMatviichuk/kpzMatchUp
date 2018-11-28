using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GameBin;
using UI.Services;
using UI.Views;

namespace UI.ViewModels
{
    class MainMenuViewModel
    {
        public ICommand ExitCommand { get; set; } = new Command(() => App.Current.Shutdown());
        public ICommand NewGameCommand { get; set; }
        public ICommand OpenLoadGameWindowCommand { get; private set; }
        public ICommand LoadGameCommand { get; private set; }
        public Page Page { get; set; }
        public List<Save> Saves { get; set; }

        public MainMenuViewModel()
        {
            NewGameCommand = new Command(() =>
            {
                App.Current.MainWindow.Content = new Game();
            });

            OpenLoadGameWindowCommand = new ParameterizedCommand(async (arg) =>
            {
                Saves = await SaveManager.GetSaveList(1);
                var childs = ((Grid)arg).Children;
                childs.Clear();
                childs.Add(new Load());
            });

            LoadGameCommand = new ParameterizedCommand(async (arg) =>
            {
                var dataGrid = (((StackPanel)((Grid)Page.Content).Children[0]).Children[0] as DataGrid);
                var id = ((Save)dataGrid.Items[dataGrid.SelectedIndex]).Id;
                var memento = await SaveManager.LoadGame(id);

                var board = GameFacade.CreateGame(GameType.Simple, memento.col, memento.row);
                board.RestoreState(memento);

                var gamePage = new Game();
                gamePage.DataContext = new GameViewModel(board);
                ((Window)Page.Parent).Content = gamePage;
            });
        }
    }

    class Save
    {
        public int Id { get; set; }
        public string PlayerName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string SaveName { get; set; }
    }

    class ParameterizedCommand : ICommand
    {
        private Action<object> _action;

        public event EventHandler CanExecuteChanged;

        public ParameterizedCommand(Action<object> action)
        {
            _action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action?.Invoke(parameter);
        }
    }


    class Command : ICommand
    {
        private Action _action;

        public event EventHandler CanExecuteChanged;

        public Command(Action action)
        {
            _action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action?.Invoke();
        }
    }
}
