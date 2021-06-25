using BellApp.Models;
using BellApp.Models.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BellApp.Services
{
    public class DataContext : DbContext
    {
        private readonly string _databasePath;

        public DataContext(string databasePath) : base()
        {
            _databasePath = databasePath;
            //Database.EnsureDeleted();
            Database.EnsureCreated();

            if (!Users.Any())
            {
                // Seed data here
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_databasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>().HasKey(p => p.Id);
            modelBuilder.Entity<InstallationCertificate>().HasKey(p => p.Id);
            modelBuilder.Entity<riskAssessment>().HasKey(p => p.Id);
        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<InstallationCertificate> Installations { get; set; }
        public DbSet<riskAssessment> riskAssessments { get; set; }

        public async Task<List<AppUser>> GetUsers()
        {
            var users = await Users.ToListAsync();

            return users;
        }

        public async Task<InstallationCertificate> GetIncompleteInstallation()
        {
            var install = await Installations.Where(x => x.IsComplete == false).FirstOrDefaultAsync();

            return install;
        }

        public async Task<riskAssessment> GetIncompleteRiskAssesment()
        {
            var riskAss = await riskAssessments.Where(x => x.IsComplete == false).FirstOrDefaultAsync();

            return riskAss;
        }


        public async Task<bool> Login(LoginDto loginDetails)
        {
            if (loginDetails.Username == null || loginDetails.Username == string.Empty) return false;

            if (loginDetails.Password == null || loginDetails.Password == string.Empty) return false;

            var user = await Users
                .Where(x => x.Username == loginDetails.Username.Trim().ToLower())
                .SingleOrDefaultAsync();

            if (user == null) return false;

            if (user.Password != loginDetails.Password) return false;

            return true;
        }
    }
}
