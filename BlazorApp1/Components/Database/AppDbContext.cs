﻿using Microsoft.EntityFrameworkCore;
using BlazorApp1.Components.Class;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using BlazorApp1.Components.Pages;
namespace BlazorApp1.Components.Database
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<Product> Products { get; set; }
        public DbSet<Negotiation> Negotiations { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");
                entity.HasKey(e => e.Id);  
                entity.Property(e => e.Id)
                      .HasColumnName("id") 
                      .ValueGeneratedOnAdd() 
                      .IsRequired();
                entity.Property(e => e.Title).HasColumnName("title").HasMaxLength(100).IsRequired();
                entity.Property(e => e.Price).HasColumnName("price").IsRequired();
            });
            modelBuilder.Entity<Negotiation>(entity =>
            {
                entity.ToTable("negotiations");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                      .HasColumnName("id")
                      .ValueGeneratedOnAdd()
                      .IsRequired();

                entity.Property(e => e.ProductId)
                      .HasColumnName("productid")
                      .IsRequired();

                entity.Property(e => e.Price)
                      .HasColumnName("price")
                      .IsRequired();

                entity.Property(e => e.EndDate)
                      .HasColumnName("enddate")
                      .IsRequired();
                entity.Property(e => e.isAccepted)
                      .HasColumnName("isaccepted");
            });

            base.OnModelCreating(modelBuilder);
        }


    }

}
