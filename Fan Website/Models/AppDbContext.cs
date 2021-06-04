using Fan_Website.Models;
using Fan_Website.Models.Follow;
using Fan_Website.Models.ProfileComment;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fan_Website
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
          : base(options)
        { }
        public DbSet<ApplicationUser> ApplicationUsers { get; set;  }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Forum> Forums { get; set; }
        public DbSet<Screenshot> Screenshots { get; set; }
        public DbSet<PostReply> Replies { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Follow> Follows { get; set; }
        public DbSet<ProfileComment> ProfileComments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>().HasMany(user => user.ProfileComments).WithOne(comment => comment.OtherUser);
            modelBuilder.Entity<ApplicationUser>().HasMany(user => user.Follows).WithOne(follow => follow.Following);
             modelBuilder.Entity<ApplicationUser>().HasMany(user => user.Followings).WithOne(follow => follow.Follower);
        }
    }
}
