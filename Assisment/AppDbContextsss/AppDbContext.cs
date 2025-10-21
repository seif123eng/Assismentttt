using Assisment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Assisment.AppDbContextsss
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Coach> coaches { get; set; }
        public DbSet<Player> players { get; set; }
        public DbSet<Competition> competitions { get; set; }
        public DbSet<Team> teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coach>()
                .HasOne(o => o.team)
                .WithOne(o => o.coach)
                .HasForeignKey<Team>(f => f.coachID);

            modelBuilder.Entity<Player>()
                .HasOne(o => o.team)
                .WithMany(o => o.players)
                .HasForeignKey(f => f.teamID);

            modelBuilder.Entity<Competition>()
                .HasMany(c => c.teams)
                .WithMany(t => t.competitions);

            modelBuilder.Entity<Team>().HasIndex(n => n.Name).IsUnique();

            modelBuilder.Entity<Competition>().HasData
                (
                new Competition
                {
                    Id = 1,
                    title = "World-Cup",
                    Location = "America",
                    Date = DateTime.Today,
                },
                new Competition
                {
                    Id = 2,
                    title = "Africa-Cup",
                    Location = "Morroco",
                    Date = DateTime.Today,
                },
                new Competition
                {
                    Id = 3,
                    title = "Arab-Cup",
                    Location = "Qtar",
                    Date = DateTime.Today,
                },
                new Competition
                {
                    Id = 4,
                    title = "Europe-Cup",
                    Location = "France",
                    Date = DateTime.Today,
                }
                );
            modelBuilder.Entity<Coach>().HasData
                (
                new Coach
                {
                    Id = 1,
                    Name = "Flick",
                    Specialization = "Football",
                    experience_years = 15,
                },
                new Coach
                {
                    Id = 2,
                    Name = "Maresca",
                    Specialization = "HandBall",
                    experience_years = 5,
                },
                new Coach
                {
                    Id = 3,
                    Name = "Ibrahim",
                    Specialization = "VoleyBall",
                    experience_years = 3,
                },
                new Coach
                {
                    Id = 4,
                    Name = "Ibrahim",
                    Specialization = "VoleyBall",
                    experience_years = 3,
                }
                );
        

        modelBuilder.Entity<Team>().HasData(
                new Team
                {
                    Id = 1,
                    Name = "Al-Ahly",
                    city = "Egypt",
                    coachID = 4
                },
                new Team
                {
                    Id = 2,
                    Name = "Barca",
                    city = "Spain",
                    coachID = 3
                },
                new Team
                {
                    Id = 3,
                    Name = "Liverpool",
                    city = "England",
                    coachID = 2
                },
                new Team
                {
                    Id = 4,
                    Name = "Inter",
                    city = "Italy",
                    coachID = 1
                }
                );

            modelBuilder.Entity<Player>().HasData(
                new Player
                {
                    Id = 1,
                    Full_name = "Seif_Hamdy",
                    position = "CAM",
                    age = 18,
                    teamID = 2,
                },
                new Player
                {
                    Id = 2,
                    Full_name = "Afsha",
                    position = "CM",
                    age = 30,
                    teamID = 1,
                },
                new Player
                {
                    Id = 3,
                    Full_name = "Lamyen",
                    position = "RW",
                    age = 18,
                    teamID = 3,
                },
                new Player
                {
                    Id = 4,
                    Full_name = "Vivi",
                    position = "LW",
                    age = 25,
                    teamID = 4,
                }
                );

        }
    }
}
