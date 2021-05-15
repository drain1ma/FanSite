using Fan_Website.Infrastructure;
using Fan_Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fan_Website.Service
{
    public class ApplicationUserService : IApplicationUser
    {
        private readonly AppDbContext context; 

        public ApplicationUserService(AppDbContext ctx)
        {
            context = ctx; 
        }
        public IEnumerable<ApplicationUser> GetAll()
        {
            return context.ApplicationUsers; 
        }

        public ApplicationUser GetById(string id)
        {
            return GetAll().FirstOrDefault(user => user.Id == id); 
        }

        public async Task UpdateUserRating(string userId, Type type)
        {
            var user = GetById(userId);
            user.Rating = CalculateUserRating(type, user.Rating);
            await context.SaveChangesAsync(); 
        }

        private int CalculateUserRating(Type type, int userRating)
        {
            var inc = 0;

            if (type == typeof(Post))
            {
                inc = 1;
            }

            if (type == typeof(PostReply))
            {
                inc = 3;
            }
            if (type == typeof(Screenshot))
            {
                inc = 2;
            }
            if (type == typeof(Forum))
            {
                inc = 2; 
            }

            return userRating + inc; 
        }

        public async Task SetProfileImage(string id, Uri uri)
        {
            var user = GetById(id);
            user.ImagePath = uri.AbsoluteUri;
            context.Update(user);
            await context.SaveChangesAsync(); 
        }

        public IEnumerable<ApplicationUser> GetLatestUsers(int n)
        {
            return GetAll().OrderByDescending(user => user.MemberSince).Take(n);
        }
    }
}
