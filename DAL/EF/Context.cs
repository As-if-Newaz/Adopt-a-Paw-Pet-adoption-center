using DAL.EF.TableModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    internal class Context :DbContext
    {
        public DbSet<AdoptionApplication> AdoptionApplications { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<SuccessStory> SuccessStories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vaccination> Vaccinations { get; set; }

        public DbSet<Token> Tokens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pet>()
                .HasRequired(p => p.User)
                .WithMany(u => u.Pets)
                .HasForeignKey(p => p.UserId)
                .WillCascadeOnDelete(false); // Specify ON DELETE NO ACTION
        }

    }
}
