using EntityFramework.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Data
{
    public class FootballLeagueDbContext:DbContext
    {


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=FootballLeageEFCore")
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name},LogLevel.Information).EnableSensitiveDataLogging();
        }
        public DbSet<Team> Teams { get; set; }

        public DbSet<League> Leagues { get; set; }


    }
}
