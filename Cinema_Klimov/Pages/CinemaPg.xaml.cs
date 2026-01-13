using Cinema_Klimov.Elements;
using Microsoft.EntityFrameworkCore.Diagnostics;
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
    /// Логика взаимодействия для CinemaPg.xaml
    /// </summary>
    public partial class CinemaPg : Page
    {
        public CinemaPg()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            parentCinema.Children.Clear();

            var cinema = MainWindow.connection.Cinemas.ToList();

            foreach (var c in cinema)
            {
                var itemCinema = new CinemaEl();
                parentCinema.Children.Add(itemCinema);
            }
        }

        private void AddCinema(object sender, RoutedEventArgs e)
        {
            MainWindow.Init.frame.Navigate(new Pages.EditAddCinema());
        }

        private void ToPosters(object sender, RoutedEventArgs e)
        {
            MainWindow.Init.frame.Navigate(new Pages.PosterPg());
        }
    }
}
