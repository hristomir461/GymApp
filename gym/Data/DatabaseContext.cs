using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gym.Data
{
    public class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=Gym;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");
        }
        public virtual DbSet<Card> Cards { get; set; }
    }
}
