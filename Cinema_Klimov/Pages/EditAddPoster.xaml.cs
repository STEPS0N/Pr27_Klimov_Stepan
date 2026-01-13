using Cinema_Klimov.Models;
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
    /// Логика взаимодействия для EditAddPoster.xaml
    /// </summary>
    public partial class EditAddPoster : Page
    {
        public Poster Poster = null;
        public EditAddPoster(Poster poster = null)
        {
            InitializeComponent();
            this.Poster = poster;
        }

        private void ToPoster(object sender, RoutedEventArgs e)
        {
            MainWindow.Init.frame.Navigate(new Pages.PosterPg());
        }

        private void AddPoster(object sender, RoutedEventArgs e)
        {

        }
    }
}
