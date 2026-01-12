using System.Windows;
using Cinema_Klimov.Classes;

namespace Cinema_Klimov
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public DbConnection connection = new DbConnection();
        public MainWindow Init;
        public MainWindow(MainWindow init)
        {
            InitializeComponent();
            this.Init = init;

        }
    }
}