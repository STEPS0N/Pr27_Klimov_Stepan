using System.Windows;
using Cinema_Klimov.Classes;

namespace Cinema_Klimov
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static DbConnection connection = new DbConnection();
        public static MainWindow Init;
        public MainWindow()
        {
            InitializeComponent();
            Init = this;

            Init.frame.Navigate(new Pages.PosterPg());
        }
    }
}