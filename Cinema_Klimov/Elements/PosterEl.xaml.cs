using Cinema_Klimov.Models;
using Cinema_Klimov.Pages;
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

namespace Cinema_Klimov.Elements
{
    /// <summary>
    /// Логика взаимодействия для PosterEl.xaml
    /// </summary>
    public partial class PosterEl : UserControl
    {
        public Poster Poster;
        public PosterPg PosterPg;

        public PosterEl(Poster poster, PosterPg posterPg)
        {
            InitializeComponent();
            this.Poster = poster;
            this.PosterPg = posterPg;

            titlePoster.Content = poster.Film;
            timePoster.Content = $"Начало сеанса: {poster.Time.ToString("dd.MM.yyyy")} в {poster.Time.Hour.ToString()} ч. {poster.Time.Minute.ToString()} мин.";
            pricePoster.Content = $"Стоимость билета: {poster.Price} руб.";
            cinemaPoster.Content = $"({MainWindow.connection.Cinemas.ToList().Where(x => x.Id == poster.IdCinema).First().Title})";
        }

        private void EditPoster(object sender, RoutedEventArgs e)
        {
            MainWindow.Init.frame.Navigate(new Pages.EditAddPoster(Poster));
        }

        private void DeletePoster(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить афишу?", "Уведомление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    MainWindow.connection.Remove(Poster);
                    MainWindow.connection.SaveChanges();

                    PosterPg.parentPoster.Children.Remove(this);

                    MessageBox.Show("Удаление завершено!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка удаления {ex.Message}", "Ошибка");
                }
            }
        }
    }
}
