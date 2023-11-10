using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using llies_Dragos_Lab2.Models;

namespace llies_Dragos_Lab2.Data
{
    public class llies_Dragos_Lab2Context : DbContext
    {
        public llies_Dragos_Lab2Context (DbContextOptions<llies_Dragos_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<llies_Dragos_Lab2.Models.Book> Book { get; set; } = default!;

        public DbSet<llies_Dragos_Lab2.Models.Publisher>? Publisher { get; set; }

        public DbSet<llies_Dragos_Lab2.Models.Author>? Author { get; set; }

        public DbSet<llies_Dragos_Lab2.Models.Category>? Category { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasOne(e => e.Borrowing)
            .WithOne(e => e.Book)
                .HasForeignKey<Borrowing>("BookID");
        }
        public DbSet<llies_Dragos_Lab2.Models.Member>? Member { get; set; }
        public DbSet<llies_Dragos_Lab2.Models.Borrowing>? Borrowing { get; set; }
    }
}
