using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingSizes
{
    public class CoordinatesForm
    {
        public int Id { get; set; }
        public string? FormName { get; set; }
        public int Coord_X { get; set; }
        public int Coord_Y { get; set; }
        public int Widht { get; set; }
        public int Hight { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
