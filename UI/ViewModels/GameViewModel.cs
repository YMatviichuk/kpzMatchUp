using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GameBin;

namespace UI.ViewModels
{
    class GameViewModel
    {
        public ObservableCollection<Card> Cards { get; set; }
        private Board Board { get; set; }

        public ICommand OpenContexMenuCommand { get; set; }
        public ICommand CloseContextMenuCommand { get; set; }
        public ICommand OpenSaveWindowCommand { get; private set; }
        public ICommand SaveGameCommand { get; private set; }
        public Command OpenMainMenuCommand { get; set; }
        
        public GameViewModel()
        {
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

            OpenSaveWindowCommand = new ParameterizedCommand((object arg) =>
            {
                var elements = arg as object[];
                //((UIElement)elements[0]).Visibility = Visibility.Collapsed;
                ((UIElement)elements[0]).Visibility = Visibility.Visible;
            });

            SaveGameCommand = new ParameterizedCommand((object arg) =>
            {
                //var elements = arg as object[];
                //string name = @"C:\projects\univer\KPZ_5\KPZ_5\bin\Debug\Saves\" + elements[1];
                //SaveManager.Save(name, Map);
                //((UIElement)elements[0]).Visibility = Visibility.Collapsed;
            });

            Board = GameFacade.CreateGame(GameType.Simple, 6, 6);
            Cards = new ObservableCollection<Card>(Board.cards.Cast<Card>().ToList());
        }
    }
}
