using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Klimov.Models
{
    public class Poster
    {
        [Key]
        public int Id { get; set; }
        public string Film { get; set; }
        public DateTime Time { get; set; }
        public int Price { get; set; }
        public int IdCinema { get; set; }
    }
}
