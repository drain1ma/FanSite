using Fan_Website.Infrastructure;
using Fan_Website.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fan_Website.Service
{
    public class ScreenshotService : IScreenshot
    {
        private readonly AppDbContext context; 

        public ScreenshotService(AppDbContext ctx)
        {
            context = ctx; 
        }

        public async Task Add(Screenshot screenshot)
        {
            context.Add(screenshot);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var screenshot = GetById(id);
            context.Remove(screenshot);
            await context.SaveChangesAsync();
        }

        public Task EditScreenshotContext(int id, string newContent)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Screenshot> GetAll()
        {
            return context.Screenshots.Include(screenshot => screenshot.User); 
        }

        public IEnumerable<ApplicationUser> GetAllUsers()
        {
            return context.ApplicationUsers;
        }

        public Screenshot GetById(int id)
        {
            return context.Screenshots.Where(screenshot => screenshot.ScreenshotId == id)
                .Include(screenshot => screenshot.User)
                .FirstOrDefault();
        }

        public IEnumerable<Screenshot> GetLatestScreenshots(int n)
        {
            return GetAll().OrderByDescending(screenshot => screenshot.CreatedOn).Take(n);

        }

        public ApplicationUser GetUserById(string id)
        {
            return GetAllUsers().FirstOrDefault(user => user.Id == id);
        }

        public async Task SetScreenshotImage(int id, Uri uri)
        {
            var screenshot = GetById(id);
            screenshot.ImagePath = uri.AbsoluteUri;
            context.Update(screenshot);
            await context.SaveChangesAsync();
        }
    }
}
