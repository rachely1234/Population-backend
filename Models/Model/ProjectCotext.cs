using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Model
{
    public class ProjectCotext:DbContext
    {
        

        public ProjectCotext(DbContextOptions<ProjectCotext> options) : base(options)
        {

        }

     
   
        public DbSet<Population> Populations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Population>()
                .HasIndex(p => p.Name)
                .IsUnique();
        }








    }
}
