using Fan_Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fan_Website.Infrastructure
{
    public interface IScreenshot
    {
        Screenshot GetById(int id);
        Task SetScreenshotImage(int id, Uri uri);
        Task Add(Screenshot screenshot);
        IEnumerable<Screenshot> GetAll(); 
        public IEnumerable<Screenshot> GetLatestScreenshots(int n); 
        IEnumerable<ApplicationUser> GetAllUsers();
        Task Delete(int id);
        Task EditScreenshotContext(int id, string newContent);
        public ApplicationUser GetUserById(string id); 
    }
}
