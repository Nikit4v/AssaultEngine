using System;
using System.Data.Entity;
using System.Numerics;
using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;


namespace AssaultEngine.Models
{
    public class SubtitleContext : DbContext
     {
         public Microsoft.EntityFrameworkCore.DbSet<Style> Styles { get; set; }
         public Microsoft.EntityFrameworkCore.DbSet<Row> Rows { get; set; }
         public Microsoft.EntityFrameworkCore.DbSet<Font> Fonts { get; set; }
         public Microsoft.EntityFrameworkCore.DbSet<Shader> Shaders { get; set; }
         public Microsoft.EntityFrameworkCore.DbSet<Material> Materials { get; set; }
         public Microsoft.EntityFrameworkCore.DbSet<Animation> Animations { get; set; }
         
         private string DbPath { get; set; }
         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
             modelBuilder.Entity<Style>();
             modelBuilder.Entity<Row>();
             modelBuilder.Entity<Font>();
             modelBuilder.Entity<Shader>();
             modelBuilder.Entity<Material>();
             modelBuilder.Entity<Animation>();
         }

         public SubtitleContext(string path)
         {
             DbPath = path;
         }
         
         protected override void OnConfiguring(DbContextOptionsBuilder options)
             => options.UseSqlite($"Data Source={DbPath}");
     }
 }