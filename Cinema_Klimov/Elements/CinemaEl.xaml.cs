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
    /// Логика взаимодействия для CinemaEl.xaml
    /// </summary>
    public partial class CinemaEl : UserControl
    {
        public Cinema Cinema;
        public CinemaPg CinemaPg;

        public CinemaEl(Cinema cinema, CinemaPg cinemaPg)
        {
            InitializeComponent();
            this.Cinema = cinema;
            this.CinemaPg = cinemaPg;

            titleCinema.Content = cinema.Title;
            hallsCinema.Content = $"Количество залов: {cinema.Halls}";
            placesCinema.Content = $"Количество мест: {cinema.Places}";
        }

        private void EditCinema(object sender, RoutedEventArgs e)
        {
            MainWindow.Init.frame.Navigate(new Pages.EditAddCinema(Cinema));
        }

        private void DeleteCinema(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить кинотеатр! (Также будут удалены афиши в этом кинотеатре)", "Уведомление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    MainWindow.connection.Remove(Cinema);
                    MainWindow.connection.SaveChanges();

                    var posters = MainWindow.connection.Posters.ToList().Where(x => x.IdCinema == this.Cinema.Id);

                    if (posters.Any())
                    {
                        MainWindow.connection.Remove(posters);
                        MainWindow.connection.SaveChanges();
                    }

                    CinemaPg.parentCinema.Children.Remove(this);

                    MessageBox.Show("Удаление завершено!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении {ex.Message}", "Ошибка");
                }
            }
        }
    }
}
