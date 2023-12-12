using System.Reflection;
using Core.Persistence.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Contexts;

public class BaseDbContext : DbContext
{
    protected IConfiguration Configuration { get; set; }

    public DbSet<Brand> Brands { get; set; }
    public DbSet<Model> Models { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Fuel> Fuels { get; set; }
    public DbSet<Transmission> Transmissions { get; set; }


    public BaseDbContext(DbContextOptions contextOptions, IConfiguration configuration) : base(contextOptions)
    {
        Configuration = configuration;
        Database.Migrate();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Fuel>().HasData(
            new Fuel()
            {
                Id = Guid.Parse("9f39e21d-2df4-4b5b-abc1-c4d1d3c37588"),
                Name = "Gasoline",
                CreatedDate = DateTime.UtcNow
            },
            new Fuel()
            {
                Id = Guid.Parse("7e57d004-2b97-0e7a-b45f-5387362902d2"),
                Name = "Diesel",
                CreatedDate = DateTime.UtcNow
            },
            new Fuel()
            {
                Id = Guid.Parse("5fa1c428-304a-4016-9ab2-99560626e1ce"),
                Name = "LPG",
                CreatedDate = DateTime.UtcNow
            },
            new Fuel()
            {
                Id = Guid.Parse("4e6e6f6b-2d6f-4e6e-6f6b-2d6f4e6e6f6b"),
                Name = "Electric",
                CreatedDate = DateTime.UtcNow
            }
        );


        modelBuilder.Entity<Transmission>().HasData(
            new Transmission()
            {
                Id = Guid.Parse("2ae251cf-354e-4c6a-b808-9fb7805b71d3"),
                Name = "Manual",
                CreatedDate = DateTime.UtcNow
            },
            new Transmission()
            {
                Id = Guid.Parse("9799d776-2a92-4771-a73d-19a381f73cef"),
                Name = "Automatic",
                CreatedDate = DateTime.UtcNow
            },
            new Transmission()
            {
                Id = Guid.Parse("bd2bb9e7-9f5a-442a-a24d-97bc98f4205f"),
                Name = "Semi-Automatic",
                CreatedDate = DateTime.UtcNow
            });

        modelBuilder.Entity<Brand>().HasData(
            new Brand()
            {
                Id = Guid.Parse("fa9c7d42-b6cf-43d5-9651-e8c2266e30fa"),
                Name = "Audi",
                CreatedDate = DateTime.UtcNow
            },
            new Brand()
            {
                Id = Guid.Parse("a358155a-234c-4525-b33c-de1ea21c1469"),
                Name = "BMW",
                CreatedDate = DateTime.UtcNow
            },
            new Brand()
            {
                Id = Guid.Parse("1caa83b0-b32c-4e94-8e12-03b19fe584bf"),
                Name = "Mercedes",
                CreatedDate = DateTime.UtcNow
            },
            new Brand()
            {
                Id = Guid.Parse("c5450178-921a-46c6-b236-b0e4787604e6"),
                Name = "Volkswagen",
                CreatedDate = DateTime.UtcNow
            },
            new Brand()
            {
                Id = Guid.Parse("c62c12fe-5b4b-436f-b2cc-3a8ce337c054"),
                Name = "Ford",
                CreatedDate = DateTime.UtcNow
            },
            new Brand()
            {
                Id = Guid.Parse("5929393a-5518-4097-95f7-2b36c3852ba9"),
                Name = "Opel",
                CreatedDate = DateTime.UtcNow
            },
            new Brand()
            {
                Id = Guid.Parse("32495789-b924-4c2b-8d1f-5a5a7d9b8873"),
                Name = "Renault",
                CreatedDate = DateTime.UtcNow
            },
            new Brand()
            {
                Id = Guid.Parse("20dd0a38-b7fb-4dc1-aa1e-957854a10ad5"),
                Name = "Peugeot",
                CreatedDate = DateTime.UtcNow
            },
            new Brand()
            {
                Id = Guid.Parse("96c517b6-dfac-4eb6-b29e-5c9c7b875bb2"),
                Name = "Fiat",
                CreatedDate = DateTime.UtcNow
            },
            new Brand()
            {
                Id = Guid.Parse("47f065d2-d009-40fa-a096-bde4b754aee2"),
                Name = "Skoda",
                CreatedDate = DateTime.UtcNow
            }
        );

        modelBuilder.Entity<Model>().HasData(
            new Model()
            {
                Id = Guid.Parse("655ee34e-d40c-488a-a730-cdbc9e7938e3"),
                BrandId = Guid.Parse("fa9c7d42-b6cf-43d5-9651-e8c2266e30fa"),
                TransmissionId = Guid.Parse("2ae251cf-354e-4c6a-b808-9fb7805b71d3"),
                FuelId = Guid.Parse("7e57d004-2b97-0e7a-b45f-5387362902d2"),
                Name = "A3",
                DailyPrice = 1500,
                ImageUrl = "images/audi-a3.jpg",
                CreatedDate = DateTime.UtcNow
            },
            new Model()
            {
                Id = Guid.Parse("622de90a-9b2f-416f-b355-a2db8700b6a6"),
                BrandId = Guid.Parse("a358155a-234c-4525-b33c-de1ea21c1469"),
                TransmissionId = Guid.Parse("2ae251cf-354e-4c6a-b808-9fb7805b71d3"),
                FuelId = Guid.Parse("7e57d004-2b97-0e7a-b45f-5387362902d2"),
                Name = "3 Series",
                DailyPrice = 1450,
                ImageUrl = "images/bmw-3-series.jpg",
                CreatedDate = DateTime.UtcNow
            },
            new Model()
            {
                Id = Guid.Parse("8aa08cdc-6cb5-4279-a521-7201f7ee8f45"),
                BrandId = Guid.Parse("1caa83b0-b32c-4e94-8e12-03b19fe584bf"),
                TransmissionId = Guid.Parse("9799d776-2a92-4771-a73d-19a381f73cef"),
                FuelId = Guid.Parse("5fa1c428-304a-4016-9ab2-99560626e1ce"),
                Name = "C Class",
                DailyPrice = 1600,
                ImageUrl = "images/mercedes-c-class.jpg",
                CreatedDate = DateTime.UtcNow
            },
            new Model()
            {
                Id = Guid.Parse("a6b40c9a-2b3d-4dbf-993b-483fb7a855f3"),
                BrandId = Guid.Parse("c5450178-921a-46c6-b236-b0e4787604e6"),
                TransmissionId = Guid.Parse("9799d776-2a92-4771-a73d-19a381f73cef"),
                FuelId = Guid.Parse("9f39e21d-2df4-4b5b-abc1-c4d1d3c37588"),
                Name = "Golf",
                DailyPrice = 1200,
                ImageUrl = "images/volkswagen-golf.jpg",
                CreatedDate = DateTime.UtcNow
            },
            new Model()
            {
                Id = Guid.Parse("47664e1a-3811-4d49-a4e2-85f5db020882"),
                BrandId = Guid.Parse("c62c12fe-5b4b-436f-b2cc-3a8ce337c054"),
                TransmissionId = Guid.Parse("9799d776-2a92-4771-a73d-19a381f73cef"),
                FuelId = Guid.Parse("9f39e21d-2df4-4b5b-abc1-c4d1d3c37588"),
                Name = "Focus",
                DailyPrice = 1100,
                ImageUrl = "images/ford-focus.jpg",
                CreatedDate = DateTime.UtcNow
            }
        );

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
