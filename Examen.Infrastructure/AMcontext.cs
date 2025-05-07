using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examen.ApplicationCore.Domain;
using Examen.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Examen.Infrastructure
{
    internal class AMcontext :DbContext
    {
        public DbSet<Laboratoire> Laboratoires{ get; set; }
        public DbSet<Infrimier> Infirmiers { get; set; }
        public DbSet <Patient> Patients { get; set; }
        public DbSet<Analyse> Analse{ get; set; }
        
        public DbSet<Bilan>Bilans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //appel 
            modelBuilder.ApplyConfiguration(new BilanConfiguration());
            modelBuilder.Entity<Laboratoire>()
                .Property(L=>L.Localisation)
                .HasColumnName("AdresseLabo")
                .HasMaxLength(50);


        }

       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
            Initial Catalog=LaboRuqaiaSabta;Integrated Security=true");
            base.OnConfiguring(optionsBuilder);
        }

    }
}
