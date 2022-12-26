using EntityFramework.Data;
using EntityFramework.Domain;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.ConsoleApp
{
    internal class Program
    {
        private static readonly FootballLeagueDbContext context = new FootballLeagueDbContext();
        static async Task Main(string[] args)
        {
            // var league = new League { Name = "Urmia League" };
            //var team = new Team { Name = "Saheli", League = league };
            // await AddTeamsWithLeague(league);
            // await context.SaveChangesAsync();
            //Console.WriteLine("Hello, World!");*/


            await QueryFilter();

            //await SimpleSelectQuery();

        }
        static async Task QueryFilter()
        {

            var leagues = await context.Leagues.Where(q => EF.Functions.Like(q.Name,"%Urmia%")).ToListAsync();
            foreach (var league in leagues)
            {
                Console.WriteLine($"{league.Id} - {league.Name}");
            }
        }
        static async Task SimpleSelectQuery()
        {
            var leagues = await context.Leagues.ToListAsync();

            foreach (var league in leagues)
            {
                Console.WriteLine($"{league.Id} - {league.Name}");
            }

        }
        static async Task AddNewTeamWithNewLeague(Team team)
        {

            await context.AddAsync(team);

        }
        static async Task AddNewLeague(League league)
        {
            await context.Leagues.AddAsync(league);
        
        }
        static async Task AddTeamsWithLeague(League league)
        {

            var teams = new List<Team>
            {
                new Team
                { 
                Name="Tiraxtor",
                League=league
                
                },
                new Team
                { 
                Name="Polad",
                League=league
                }


            };
            await context.AddRangeAsync(teams);
        }
    }
}