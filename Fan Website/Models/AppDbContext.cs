using Fan_Website.Models;
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Account>().HasData(
                new Account
                {
                    UserId = 1,
                    Password = "Larkin71!",
                    ConfirmPassword = "Larkin71!"
                });
            modelBuilder.Entity<Post>().HasData(
                new Post
                {
                    PostId = 1,
                    Title = "This is my favorite game!",
                    Content = "Like I said in the title, this is my favorite game and nothing can change my mind about that.",
                    CreatedOn = DateTime.UtcNow,
                }
             );

            modelBuilder.Entity<Forum>().HasData(
                    new Forum
                    {
                        ForumId = 1,
                        PostTitle = "Final Fantasy IX",
                        Description = "A place to discuss Final Fantasy IX!",
                        CreatedOn = DateTime.UtcNow 
                    }
                 );
            modelBuilder.Entity<Screenshot>().HasData(
            new Screenshot
            {
                ScreenshotId = 6,
                ScreenshotTitle = "Final Fantasy XV Chocobo",
                ImagePath = "Final_Fantasy_XV_Chocobo-1.png",
                ScreenshotDescription = "I finally managed to find a chocobo",
                CreatedOn = DateTime.Now 
            },
            new Screenshot
            {
                ScreenshotId = 9,
                ScreenshotTitle = "Sephiroth from Final Fantasy VII",
                ImagePath = "Final-Fantasy-VII-Remake-Sephiroth.png",
                ScreenshotDescription = "This is my favorite game of all time",
                CreatedOn = DateTime.Now
            }
         );
        }
    }
}
