using AngularProjectAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularProjectAPI.Data
{
    public class NewsContext : DbContext
    {
        public NewsContext(DbContextOptions<NewsContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<ArticleStatus> ArticleStatuses { get; set; }

        public DbSet<Article> Articles { get; set; }

        public DbSet<Reactie> Reacties { get; set; }

        public DbSet<Like> Likes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<Tag>().ToTable("Tag");
            modelBuilder.Entity<ArticleStatus>().ToTable("ArticleStatus");
            modelBuilder.Entity<Article>().ToTable("Article");
            modelBuilder.Entity<Reactie>().ToTable("Reactie");
            modelBuilder.Entity<Like>().ToTable("Like");
            
        }
        

        public DbSet<AngularProjectAPI.Models.Like> Like { get; set; }
    }
}
