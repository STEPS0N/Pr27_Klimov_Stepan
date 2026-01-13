using Cinema_Klimov.Elements;
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

namespace Cinema_Klimov.Pages
{
    /// <summary>
    /// Логика взаимодействия для PosterPg.xaml
    /// </summary>
    public partial class PosterPg : Page
    {
        public PosterPg()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            parentPoster.Children.Clear();

            var poster = MainWindow.connection.Posters.ToList();

            foreach (var p in poster)
            {
                var itemPoster = new CinemaEl();
                parentPoster.Children.Add(itemPoster);
            }
        }

        private void ToCinemas(object sender, RoutedEventArgs e)
        {
            MainWindow.Init.frame.Navigate(new Pages.CinemaPg());
        }

        private void AddPoster(object sender, RoutedEventArgs e)
        {
            MainWindow.Init.frame.Navigate(new Pages.EditAddPoster());
        }
    }
}
