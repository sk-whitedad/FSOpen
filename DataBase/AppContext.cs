using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FishingSizes
{
    public class AppContext : DbContext
    {
        public DbSet<CoordinatesForm> CoordForms => Set<CoordinatesForm>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Brocker> Brockers => Set<Brocker>();
        public DbSet<Print> Prints => Set<Print>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=DBfishsize.db");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasAlternateKey(u => u.Name);
            modelBuilder.Entity<Print>().HasIndex(u => u.Ticker);
            modelBuilder.Entity<CoordinatesForm>().Property(u => u.Coord_X).HasDefaultValue(100);//значение по умолчанию
            modelBuilder.Entity<CoordinatesForm>().Property(u => u.Coord_Y).HasDefaultValue(100);//значение по умолчанию
        }
    }

 
}
