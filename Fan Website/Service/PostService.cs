using Fan_Website.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fan_Website.Service
{
    public class PostService: IPost 
    {
        private readonly AppDbContext context;

        public PostService(AppDbContext ctx)
        {
            context = ctx;
        }

        public async Task Add(Post post)
        {
            context.Add(post);
            await context.SaveChangesAsync(); 
        }

        public Task AddReply(PostReply reply)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditPostContent(int id, string newContent)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetAll()
        {
            return context.Posts
                .Include(post => post.User)
                .Include(post => post.Replies).ThenInclude(post => post.User)
                .Include(post => post.Forum); 
        }

        public Post GetById(int id)
        {
            return context.Posts.Where(post => post.PostId == id)
                .Include(post => post.User)
                .Include(post => post.Replies).ThenInclude(reply => reply.User)
                .Include(post => post.Forum)
                .First(); 
        }

        public IEnumerable<Post> GetFilteredPosts(Forum forum, string searchQuery)
        {
            return string.IsNullOrEmpty(searchQuery) ? forum.Posts : 
                forum.Posts.Where(post => post.Title.ToLower().Contains(searchQuery) || post.Content.ToLower().Contains(searchQuery) || post.Content.Contains(searchQuery) || post.Title.Contains(searchQuery)); 
        }

        public IEnumerable<Post> GetLatestPosts(int n)
        {
            return GetAll().OrderByDescending(post => post.CreatedOn).Take(n); 
        }

        public IEnumerable<Post> GetPostsByForum(int id)
        {
            return context.Forums.Where(forum => forum.ForumId == id).First().Posts; 
        }
    }
}
