using Cinema_Klimov.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

            foreach (Cinema cinema in MainWindow.connection.Cinemas.ToList())
            {
                tbCinema.Items.Add(cinema.Title);
            }

            if (this.Poster != null)
            {
                btn.Content = "Изменить";
                lb.Content = "Изменение афиши";
                tbFilmPoster.Text = poster.Film;
                tbPricePoster.Text = poster.Price.ToString();
                tbDateCinema.Text = poster.Time.ToString("dd.MM.yyyy");
                tbTimeCinema.Text = poster.Time.ToString("HH:mm");
                tbCinema.SelectedItem = MainWindow.connection.Cinemas.ToList().Where(x => x.Id == poster.IdCinema).First().Title;
            }
        }

        private void ToPoster(object sender, RoutedEventArgs e)
        {
            MainWindow.Init.frame.Navigate(new Pages.PosterPg());
        }

        private void AddPoster(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbFilmPoster.Text))
            {
                MessageBox.Show("Введите название фильма!");
            }
            else if (string.IsNullOrEmpty(tbPricePoster.Text) || !int.TryParse(tbPricePoster.Text, out int price) || price < 0)
            {
                MessageBox.Show("Введите корректную цену (целое число больше 0)!");
            }
            else if (tbDateCinema.SelectedDate == null)
            {
                MessageBox.Show("Выберите дату!");
            }
            else if (string.IsNullOrEmpty(tbTimeCinema.Text) || !Regex.IsMatch(tbTimeCinema.Text, @"^([01]?\d|2[0-3]):[0-5]\d$"))
            {
                MessageBox.Show("Введите время! Пример: 00:00");
            }
            else if (tbCinema.SelectedItem == null)
            {
                MessageBox.Show("Выберите кинотеатр!");
            }
            else
            {
                if (this.Poster == null)
                {
                    this.Poster = new Poster();
                    MainWindow.connection.Add(this.Poster);
                }

                this.Poster.Film = tbFilmPoster.Text;
                this.Poster.Price = Convert.ToInt32(tbPricePoster.Text);

                var time = tbTimeCinema.Text.Split(':');
                DateTime date = (DateTime)tbDateCinema.SelectedDate;
                date = date.Add(new TimeSpan(Convert.ToInt32(time[0]), Convert.ToInt32(time[1]), 0));

                this.Poster.Time = date;

                this.Poster.IdCinema = MainWindow.connection.Cinemas.ToList()[tbCinema.SelectedIndex].Id;

                MessageBox.Show("Сохранено!");
                MainWindow.connection.SaveChanges();

                ToPoster(null, null);
            }
        }
    }
}
