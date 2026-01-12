using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Cinema_Klimov.Models;
using Microsoft.EntityFrameworkCore;

namespace Cinema_Klimov.Classes
{
    public class DbConnection : DbContext
    {
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Poster> Posters { get; set; }

        public DbConnection()
        {
            try
            {
                Database.EnsureCreated();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;port=3307;database=club_cinema;uid=root;pwd=;", new MySqlServerVersion(new Version(8, 0, 11)));
        }
    }
}
