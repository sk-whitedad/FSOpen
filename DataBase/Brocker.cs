using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingSizes
{
    public class Brocker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? OpenKey { get; set; }
        public string SecretKey { get; set; }
        public bool ActivateUses { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
