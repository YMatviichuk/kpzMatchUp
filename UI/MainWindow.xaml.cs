using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //SimpleBoard board;
        //int rows = 5;
        //int cols = 6;

        //public MainWindow()
        //{
        //    InitializeComponent();


        //    board = SimpleBoard.Instance;
        //    board.InitBoard(rows, cols);

        //    for (int i = 0; i < rows; i++)
        //    {
        //        for (int j = 0; j < cols; j++)
        //        {
        //            Button MyControl1 = new Button();
        //            MyControl1.Content = "Down"; ;
        //            MyControl1.Name = (i*cols + j).ToString();
                    
        //            Grid.SetColumn(MyControl1, j);
        //            Grid.SetRow(MyControl1, i);
        //            gridMain.Children.Add(MyControl1);

        //            MyControl1.Click += Button_Click;
        //        }

        //    }
        //}
        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    Button b = (Button)sender;
        //    var index = Convert.ToInt32(b.Name);

        //    var result = board.cardUp(index / cols, index % cols);


        //}

    }
}
