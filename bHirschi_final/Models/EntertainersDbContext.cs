using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bHirschi_final.Models
{
    public class EntertainersDbContext : DbContext
    {
        public EntertainersDbContext(DbContextOptions<EntertainersDbContext> options) : base(options)
        {

        }

        public DbSet<Entertainer> Entertainers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entertainer>(entity =>
            {
                entity.HasKey(e => e.EntertainerID);
                entity.Property(e => e.EntertainerID).ValueGeneratedOnAdd();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
