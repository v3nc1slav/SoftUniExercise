using Microsoft.EntityFrameworkCore;
using P03_FootballBetting.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext()
        {

        }

        public FootballBettingContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=FootballBetting;Integrated Security=True;");
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerStatistic>(entity =>
            {
                entity.HasKey(sc => new { sc.PlayerId, sc.GameId });

                entity
                .HasOne(x => x.Game)
                .WithMany(x => x.PlayerStatistics)
                .HasForeignKey(x => x.GameId);

                entity
                .HasOne(x => x.Player)
                .WithMany(x => x.PlayerStatistics)
                .HasForeignKey(x => x.PlayerId);
            });

            modelBuilder.Entity<Bet>(entity =>
            {
                entity
                .HasOne(x => x.Game)
                .WithMany(x => x.Bets)
                .HasForeignKey(x => x.GameId);

                entity
                .HasOne(x => x.User)
                .WithMany(x => x.Bets)
                .HasForeignKey(x => x.UserId);
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity
                .HasOne(x => x.AwayTeam)
                .WithMany(x => x.AwayGames)
                .HasForeignKey(x => x.AwayTeamId)
                .OnDelete(DeleteBehavior.Restrict); 

                entity
                .HasOne(x => x.HomeTeam)
                .WithMany(x => x.HomeGames)
                .HasForeignKey(x => x.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.Property(e => e.IsInjured).HasDefaultValue(false);

                entity
                .HasOne(x => x.Position)
                .WithMany(x => x.Players)
                .HasForeignKey(x => x.PositionId);

                entity
                .HasOne(x => x.Team)
                .WithMany(x => x.Players)
                .HasForeignKey(x => x.TeamId);
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity
                .HasOne(x => x.Town)
                .WithMany(x => x.Teams)
                .HasForeignKey(x => x.TownId);

                entity
                .HasOne(x => x.PrimaryKitColor)
                .WithMany(x => x.PrimaryKitTeams)
                .HasForeignKey(x => x.PrimaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict); 


                entity
                .HasOne(x => x.SecondaryKitColor)
                .WithMany(x => x.SecondaryKitTeams)
                .HasForeignKey(x => x.SecondaryKitColor)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Town>(entity =>
            {
                entity
                .HasOne(x => x.Country)
                .WithMany(x => x.Towns)
                .HasForeignKey(x => x.CountryId);

            });
        }
    }
}
