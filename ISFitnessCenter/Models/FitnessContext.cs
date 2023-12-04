using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFitnessCenter.Models
{
    public class FitnessContext : DbContext
    {
        public DbSet<Zals> zals { get; set; }
        public DbSet<Adress> adresses { get; set; }
        public DbSet<Client> clients { get; set; }
        public DbSet<Schedule> schedules { get; set; }
        public DbSet<Specialtiy> specialtiys { get; set; }
        public DbSet<Specialyty_Trener> specialyty_Treners { get; set; }
        public DbSet<Time> times { get; set; }
        public DbSet<Trener> treners { get; set; }
        public DbSet<Trener_Client> trener_Clients { get; set; }
        public DbSet<Week> weeks { get; set; }
        string connectionString = "Server=DODOR\\MSSQLSERVER01;Database=efitness2;Trusted_Connection=True;TrustServerCertificate=Yes;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

}
