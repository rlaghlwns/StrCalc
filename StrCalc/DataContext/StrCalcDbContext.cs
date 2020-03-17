using Microsoft.EntityFrameworkCore;
using StrCalc.Models;

namespace StrCalc.DataContext
{
    public class StrCalcDbContext : DbContext
    {

        public DbSet<Member> Members { get; set; }
        public DbSet<Performance> MPfmc { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=StrCalcDb;User ID=sa;Password=rlaghlwns~");
            base.OnConfiguring(optionsBuilder);
        }

    }
}
