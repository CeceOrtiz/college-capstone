using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using D424.Models;

namespace D424.Data
{
    public class D424Context : DbContext
    {
        public D424Context (DbContextOptions<D424Context> options)
            : base(options)
        {
        }

        public DbSet<D424.Models.Floss> Floss { get; set; } = default!;
        public DbSet<D424.Models.Pattern> Pattern { get; set; } = default!;
        public DbSet<D424.Models.PatternColor> PatternColor { get; set; } = default!;
        public DbSet<D424.Models.Supply> Supply { get; set; } = default!;
        public DbSet<D424.Models.Needle> Needle { get; set; } = default!;
        public DbSet<D424.Models.Fabric> Fabric { get; set; } = default!;
        public DbSet<D424.Models.User> User { get; set; } = default!;
        public DbSet<D424.Models.UserFloss> UserFloss { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatternColor>().HasKey(pc => new { pc.PatternID, pc.FlossID });
            modelBuilder.Entity<UserFloss>().HasKey(pc => new { pc.UserID, pc.FlossID });
        }
    }
}
