using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using FirstHolidayChat.Models;

namespace FirstHolidayChat.Context
{
    public partial class FirstHolDbContext : DbContext
    {
        public FirstHolDbContext()
        {
        }

        public FirstHolDbContext(DbContextOptions<FirstHolDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<CityNightLife> CityNightLives { get; set; } = null!;
        public virtual DbSet<CityTemperature> CityTemperatures { get; set; } = null!;
        public virtual DbSet<Continent> Continents { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<HolCategory> HolCategories { get; set; } = null!;
        public virtual DbSet<Holiday> Holidays { get; set; } = null!;
        public virtual DbSet<Hotel> Hotels { get; set; } = null!;
        public virtual DbSet<LocType> LocTypes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("EFConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.HolCity)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.NightLifeId).HasColumnName("NightLifeID");

                entity.Property(e => e.TemperatureId).HasColumnName("TemperatureID");

                entity.Property(e => e.TerrainId).HasColumnName("TerrainID");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__City__CountryID__2A164134");

                entity.HasOne(d => d.NightLife)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.NightLifeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__City__NightLifeI__2CF2ADDF");

                entity.HasOne(d => d.Temperature)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.TemperatureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__City__Temperatur__2BFE89A6");

                entity.HasOne(d => d.Terrain)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.TerrainId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__City__TerrainID__2B0A656D");
            });

            modelBuilder.Entity<CityNightLife>(entity =>
            {
                entity.HasKey(e => e.NightLifeId)
                    .HasName("PK__CityNigh__E32B7F6218741B76");

                entity.ToTable("CityNightLife");

                entity.Property(e => e.NightLifeId).HasColumnName("NightLifeID");

                entity.Property(e => e.NightLifeType)
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CityTemperature>(entity =>
            {
                entity.HasKey(e => e.TemperatureId)
                    .HasName("PK__CityTemp__B8D7DAAE42F855C8");

                entity.ToTable("CityTemperature");

                entity.Property(e => e.TemperatureId).HasColumnName("TemperatureID");

                entity.Property(e => e.TemperatureRating)
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Continent>(entity =>
            {
                entity.ToTable("Continent");

                entity.Property(e => e.ContinentId).HasColumnName("ContinentID");

                entity.Property(e => e.HolContinent)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.ContinentId).HasColumnName("ContinentID");

                entity.Property(e => e.HolCountry)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.Continent)
                    .WithMany(p => p.Countries)
                    .HasForeignKey(d => d.ContinentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Country__Contine__2FCF1A8A");
            });

            modelBuilder.Entity<HolCategory>(entity =>
            {
                entity.HasKey(e => e.HolTypeId)
                    .HasName("PK__HolCateg__7B8635AE1E4449FC");

                entity.ToTable("HolCategory");

                entity.Property(e => e.HolTypeId).HasColumnName("HolTypeID");

                entity.Property(e => e.HolType)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Holiday>(entity =>
            {
                entity.ToTable("Holiday");

                entity.Property(e => e.HolidayId).HasColumnName("HolidayID");

                entity.Property(e => e.HolTypeId).HasColumnName("HolTypeID");

                entity.Property(e => e.HotelId).HasColumnName("HotelID");

                entity.HasOne(d => d.HolType)
                    .WithMany(p => p.Holidays)
                    .HasForeignKey(d => d.HolTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Holiday__HolType__2EDAF651");

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.Holidays)
                    .HasForeignKey(d => d.HotelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Holiday__HotelID__2DE6D218");
            });

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.ToTable("Hotel");

                entity.Property(e => e.HotelId).HasColumnName("HotelID");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.HolHotel)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PricePerNight).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Hotels)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Hotel__CityID__30C33EC3");
            });

            modelBuilder.Entity<LocType>(entity =>
            {
                entity.HasKey(e => e.TerrainId)
                    .HasName("PK__LocType__79EED1AFEFA1B132");

                entity.ToTable("LocType");

                entity.Property(e => e.TerrainId).HasColumnName("TerrainID");

                entity.Property(e => e.TerrainType)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<FirstHolidayChat.Models.HolidayViewModel> HolidayViewModel { get; set; }
    }
}
