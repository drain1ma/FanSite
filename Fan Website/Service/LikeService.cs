using Fan_Website.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fan_Website.Service
{
    public class LikeService : ILike
    {

        private readonly AppDbContext context;

        public LikeService(AppDbContext ctx)
        {
            context = ctx;
        }

        public Like GetById(int id)
        {
            var like = context.Likes.Where(l => l.Id == id).FirstOrDefault(); 


            return like; 

        }

        public Task UpdatePostLikes(int id)
        {
            throw new NotImplementedException();
        }
    }
}
