﻿using Fan_Website.Models;
using Fan_Website.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fan_Website.Service
{
    public class ForumService : IForum
    {
        private readonly AppDbContext context; 

        public ForumService(AppDbContext ctx)
        {
            context = ctx; 
        }
        public async Task Create(Forum forum)
        {
            context.Add(forum);
            await context.SaveChangesAsync(); 
        }

        public async Task Delete(int forumId)
        {
            var forum = GetById(forumId);
            context.Remove(forum);
            await context.SaveChangesAsync(); 
        }

        public IEnumerable<Forum> GetAll()
        {
            return context.Forums
                .Include(forum => forum.Posts); 
        }

        public Forum GetById(int id)
        {
            var forum = context.Forums
                .Where(f => f.ForumId == id)
                .Include(f => f.Posts)
                .ThenInclude(f => f.User)
                .Include(f => f.Posts)
                .ThenInclude(f => f.Replies)
                .ThenInclude(f => f.User)
                .Include(f => f.Posts)
                .ThenInclude(p => p.Forum)
                .FirstOrDefault();
            return forum;
        }

        public async Task UpdateForumDescription(int forumId, string newDescription)
        {
            var forum = GetById(forumId);
            forum.Description = newDescription;
            context.Forums.Update(forum);
            await context.SaveChangesAsync(); 
        }

        public async Task UpdateForumTitle(int forumId, string newTitle)
        {
            var forum = GetById(forumId);
            forum.PostTitle = newTitle;
            context.Forums.Update(forum);
            await context.SaveChangesAsync();
        }
    }
}
