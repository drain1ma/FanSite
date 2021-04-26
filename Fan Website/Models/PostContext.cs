using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fan_Website.Models
{
    public class PostContext: DbContext 
    {
        public PostContext(DbContextOptions<PostContext> options)
           : base(options)
        { }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Forum> Forums { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().HasData(
                new Post
                {
                    PostId = 1,
                    Title = "This is my favorite game!",
                    Content = "Like I said in the title, this is my favorite game and nothing can change my mind about that.",
                    CreatedOn = DateTimeOffset.Now,
                    UserName = "linguisticgamer98",
                    ForumId = "IX"
                }
             );

            modelBuilder.Entity<Forum>().HasData(
                    new Forum
                    {
                        ForumId = "IX",
                        PostTitle = "Final Fantasy IX", 
                        Description = "A place to discuss Final Fantasy IX!", 
                        CreatedOn = DateTimeOffset.Now,
                        UserName = "linguisticgamer98"
                    }
                 ); 
           
        }
    }
}
