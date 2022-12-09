using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingSizes
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string Password { get; set; }
        public List<CoordinatesForm> CoordForms { get; set; }
        public List<Brocker> Brockers { get; set; }
    }
}
