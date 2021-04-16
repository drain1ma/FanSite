using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fan_Website.Models
{
    public class ScreenshotContext: DbContext
    {
        public ScreenshotContext(DbContextOptions<ScreenshotContext> options)
            : base(options)
        { }
        public DbSet<Screenshot> Screenshots { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Screenshot>().HasData(
                new Screenshot
                {
                    ScreenshotId = 4,
                    ScreenshotTitle = "Final Fantasy XV Chocobo",
                    ImagePath = "Final_Fantasy_XV_Chocobo-1.png",
                    ScreenshotDescription = "I finally managed to find a chocobo",
                },
                new Screenshot
                {
                    ScreenshotId = 2,
                    ScreenshotTitle = "Sephiroth from Final Fantasy VII",
                    ImagePath = "Final-Fantasy-VII-Remake-Sephiroth.png",
                    ScreenshotDescription = "This is my favorite game of all time",
                }
             );
        }

    }
 
}