using System;
using System.IO;
using System.Text.Json;
using AltV.BlipSystem.Structure;
using AltV.Net;
using Microsoft.EntityFrameworkCore;

namespace AltV.BlipSystem.Behaviour
{
    public class BlipContext : DbContext
    {
        #region Fields
        private DatabaseConfig DatabaseConfig { get; set; }
        public virtual DbSet<Blip> Blips { get; set; }
        #endregion

        #region Constructors
        public BlipContext() {}

        public BlipContext(DbContextOptions<BlipContext> options) : base(options) {}
        #endregion

        #region Methods
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) 
                return;

            DatabaseConfig = GetDatabaseConfig();
            switch (DatabaseConfig.Type)
            {
                case "postgres":
                    optionsBuilder.UseNpgsql($"Host={DatabaseConfig.Host};" +
                                             $"Port={DatabaseConfig.Port};Username={DatabaseConfig.User};" +
                                             $"Password={DatabaseConfig.Password};Database={DatabaseConfig.Database}");
                    optionsBuilder.EnableSensitiveDataLogging();
                    return;
                case "mysql":
                    var serverVersion = new MySqlServerVersion(new Version(8, 0, 21));
                    optionsBuilder.UseMySql($"server={DatabaseConfig.Host};" +
                                            $"port={DatabaseConfig.Port};user={DatabaseConfig.User};" +
                                            $"password={DatabaseConfig.Password};database={DatabaseConfig.Database}", serverVersion);
                    optionsBuilder.EnableSensitiveDataLogging();
                    return;
                default:
                    return;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blip>(entity =>
            {
                entity.ToTable("blips", DatabaseConfig.Schema);
                entity.HasKey(e => e.Id).HasName("id");
                entity.HasIndex(e => e.Id).HasDatabaseName("id");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.Type).HasColumnName("type");
                entity.Property(e => e.Color).HasColumnName("color");
                entity.Property(e => e.PosX).HasColumnName("pos_x");
                entity.Property(e => e.PosY).HasColumnName("pos_y");
                entity.Property(e => e.PosZ).HasColumnName("pos_z");
                entity.Property(e => e.Scale).HasColumnName("scale");
                entity.Property(e => e.ShortRange).HasColumnName("short_range");
            });
        }

        private DatabaseConfig GetDatabaseConfig()
        {
            DatabaseConfig databaseConfig = null;

            try
            {
                databaseConfig = JsonSerializer.Deserialize<DatabaseConfig>(File.ReadAllText("DatabaseConfig.json"));
            }
            catch (FileNotFoundException e)
            {
                Alt.Log($"{e}");
                throw;
            }
            catch (FileLoadException e)
            {
                Alt.Log($"{e}");
                throw;
            }
            catch (JsonException e)
            {
                Alt.Log($"{e}");
                throw;
            }

            return databaseConfig;
        }
        #endregion

    }
}