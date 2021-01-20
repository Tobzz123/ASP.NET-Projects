using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using assignment3.Models;

#nullable disable

namespace assignment3.Data
{
    public partial class HASCContext : DbContext
    {
        public HASCContext()
        {
        }

        public HASCContext(DbContextOptions<HASCContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Coach> Coaches { get; set; }
        public virtual DbSet<Division> Divisions { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<Referee> Referees { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public object Team { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=HASC");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coach>(entity =>
            {
                entity.ToView("coaches");

                entity.Property(e => e.AddressLine1).IsUnicode(false);

                entity.Property(e => e.AddressLine2).IsUnicode(false);

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.CoachingExperience).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.Phone).IsUnicode(false);

                entity.Property(e => e.PostalCode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ProvinceId)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UserPassword).IsUnicode(false);
            });

            modelBuilder.Entity<Division>(entity =>
            {
                entity.Property(e => e.DivisionId).ValueGeneratedNever();

                entity.Property(e => e.DivisionName).IsUnicode(false);
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.Property(e => e.GameId).ValueGeneratedNever();

                entity.Property(e => e.Field).IsUnicode(false);

                entity.Property(e => e.GameNotes).IsUnicode(false);

                entity.HasOne(d => d.AwayTeam)
                    .WithMany(p => p.GameAwayTeams)
                    .HasForeignKey(d => d.AwayTeamId)
                    .HasConstraintName("FK__games__away_team__33D4B598");

                entity.HasOne(d => d.HomeTeam)
                    .WithMany(p => p.GameHomeTeams)
                    .HasForeignKey(d => d.HomeTeamId)
                    .HasConstraintName("FK__games__home_team__32E0915F");

                entity.HasOne(d => d.Referee)
                    .WithMany(p => p.Games)
                    .HasForeignKey(d => d.RefereeId)
                    .HasConstraintName("FK__games__referee_i__34C8D9D1");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.PersonId).ValueGeneratedNever();

                entity.Property(e => e.AddressLine1).IsUnicode(false);

                entity.Property(e => e.AddressLine2).IsUnicode(false);

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.CoachingExperience).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.Phone).IsUnicode(false);

                entity.Property(e => e.PostalCode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ProvinceId)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RefereeExperience).IsUnicode(false);

                entity.Property(e => e.SkillLevel)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UserPassword).IsUnicode(false);

                entity.HasOne(d => d.Division)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.DivisionId)
                    .HasConstraintName("FK__persons__divisio__2D27B809");

                entity.HasOne(d => d.Province)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.ProvinceId)
                    .HasConstraintName("FK__persons__provinc__2E1BDC42");

                entity.HasOne(d => d.SkillLevelNavigation)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.SkillLevel)
                    .HasConstraintName("FK__persons__skill_l__2F10007B");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK__persons__team_id__300424B4");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.ToView("players");

                entity.Property(e => e.AddressLine1).IsUnicode(false);

                entity.Property(e => e.AddressLine2).IsUnicode(false);

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.Phone).IsUnicode(false);

                entity.Property(e => e.PostalCode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ProvinceId)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.SkillLevel)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UserPassword).IsUnicode(false);
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.Property(e => e.ProvinceId)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ProvinceName).IsUnicode(false);
            });

            modelBuilder.Entity<Referee>(entity =>
            {
                entity.ToView("referees");

                entity.Property(e => e.AddressLine1).IsUnicode(false);

                entity.Property(e => e.AddressLine2).IsUnicode(false);

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.Phone).IsUnicode(false);

                entity.Property(e => e.PostalCode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ProvinceId)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RefereeExperience).IsUnicode(false);

                entity.Property(e => e.UserPassword).IsUnicode(false);
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.HasKey(e => e.SkillLevel)
                    .HasName("PK__skills__4BDFF0B44F36BF63");

                entity.Property(e => e.SkillLevel)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.SkillDescription).IsUnicode(false);
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.Property(e => e.TeamId).ValueGeneratedNever();

                entity.Property(e => e.JerseyColour).IsUnicode(false);

                entity.Property(e => e.TeamName).IsUnicode(false);

                entity.HasOne(d => d.Division)
                    .WithMany(p => p.Teams)
                    .HasForeignKey(d => d.DivisionId)
                    .HasConstraintName("FK__teams__division___2A4B4B5E");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
