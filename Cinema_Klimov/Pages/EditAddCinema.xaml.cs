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
    /// Логика взаимодействия для EditAddCinema.xaml
    /// </summary>
    public partial class EditAddCinema : Page
    {
        public Cinema Cinema = null;
        public EditAddCinema(Cinema cinema = null)
        {
            InitializeComponent();
            this.Cinema = cinema;

            if (this.Cinema != null)
            {
                btn.Content = "Изменить";
                lb.Content = "Изменение кинотеатра";
                tbTitleCinema.Text = this.Cinema.Title;
                tbHallsCinema.Text = this.Cinema.Halls.ToString();
                tbPlacesCinema.Text = this.Cinema.Places.ToString();
            }
        }

        private void ToCinema(object sender, RoutedEventArgs e)
        {
            MainWindow.Init.frame.Navigate(new Pages.CinemaPg());
        }

        private void AddCinema(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbTitleCinema.Text))
            {
                MessageBox.Show("Введите название кинотеатра!");
            }
            else if (string.IsNullOrEmpty(tbHallsCinema.Text))
            {
                MessageBox.Show("Введите кол-во залов!");
            }
            else if (string.IsNullOrEmpty(tbPlacesCinema.Text))
            {
                MessageBox.Show("Введите кол-во мест в зале!");
            }
            else
            {
                if (this.Cinema == null)
                {
                    this.Cinema = new Cinema();
                    MainWindow.connection.Cinemas.Add(this.Cinema);
                }

                this.Cinema.Title = tbTitleCinema.Text;
                this.Cinema.Halls = Convert.ToInt32(tbHallsCinema.Text);
                this.Cinema.Places = Convert.ToInt32(tbPlacesCinema.Text);

                MessageBox.Show("Сохранено!");
                MainWindow.connection.SaveChanges();

                ToCinema(null, null);
            }
        }
    }
}
