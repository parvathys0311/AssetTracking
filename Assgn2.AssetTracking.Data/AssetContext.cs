using Assgn2.AssetTracking.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace Assgn2.AssetTracking.Data
{
    public class AssetContext : DbContext
    {
        public AssetContext() : base() { }

        public DbSet<Asset> Assets { get; set; }
        public DbSet<AssetType> AssetTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Connection string
            optionsBuilder.UseSqlServer(@"Server=localhost;
                                          Database=AssetTracker;
                                          Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed data created here
            modelBuilder.Entity<AssetType>().HasData(
                new AssetType { Id = 1, Name = "Computer" },
                new AssetType { Id = 2, Name = "Monitor" },
                new AssetType { Id = 3, Name = "Phone" }
                );

            modelBuilder.Entity<Asset>().HasData(
                new Asset
                {
                    Id = 1,
                    TagNumber = "x0Asst",
                    AssetTypeId = 1,
                    Manufacturer = "Dell",
                    Model = "D3D 3D3",
                    Description = "2 in 1 Laptop",
                    SerialNumber = "xx0303Dellxx"
                },
                new Asset
                {
                    Id = 2,
                    TagNumber = "x25Asst",
                    AssetTypeId = 2,
                    Manufacturer = "Acer",
                    Model = "AAA 111",
                    Description = "Gaming monitor",
                    SerialNumber = "tt2020Acertt"
                },
                new Asset
                {
                    Id = 3,
                    TagNumber = "x42Asst",
                    AssetTypeId = 3,
                    Manufacturer = "Polycom",
                    Model = "P30 P30",
                    Description = "6.4 inch Smart Phone",
                    SerialNumber = "ss1342Polycomss"
                },
                new Asset
                {
                    Id = 4,
                    TagNumber = "x76Asst",
                    AssetTypeId = 1,
                    Manufacturer = "HP",
                    Model = "HP1 101",
                    Description = "HP Chromebook 13",
                    SerialNumber = "mn2000HPmn"
                },
                new Asset
                {
                    Id = 5,
                    TagNumber = "x14Asst",
                    AssetTypeId = 3,
                    Manufacturer = "Cisco",
                    Model = "876 CIS",
                    Description = "Touch Screen All-In-One",
                    SerialNumber = "aa1987Ciscoaa"
                }
                );

        }
    }
}
