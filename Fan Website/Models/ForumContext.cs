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
        public DbSet<Forum> Forums { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Forum>().HasData(
                new Forum
                {
                    ForumId = 1,
                    PostTitle = "Final Fantasy IX",
                    UserName = "mattdrain98",
                    Description = "A place to talk about Final Fantasy IX", 
                    CreatedOn = DateTime.Now
                });
        }
    }
}
