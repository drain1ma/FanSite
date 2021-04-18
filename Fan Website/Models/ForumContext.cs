using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fan_Website.Models
{
    public class ForumContext: DbContext 
    {
        public ForumContext(DbContextOptions<ForumContext> options)
            : base(options)
        { }
        public DbSet<Forum> Posts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Forum>().HasData(
                new Forum
                {
                    ForumId = 1,
                    PostTitle = "Final Fantasy IX is the best",
                    UserName = "mattdrain98",
                    Post = "The reason I believe this to be the best game is due to the character development as well as the pacing of the story as a whole. Without the characters the game would not have been nearly as good, although the story was still fantastic as well.",
                    CreatedOn = DateTime.Now
                });
        }
    }
}
