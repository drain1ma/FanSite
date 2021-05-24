using Fan_Website.Models;
using Fan_Website.Models.Reply;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fan_Website.Services
{
    public interface IPost
    {
        Post GetById(int id);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetFilteredPosts(Forum forum, string searchQuery);
        IEnumerable<Post> GetFilteredPosts(string searchQuery);
        IEnumerable<Post> GetPostsByForum(int id);
        IEnumerable<Post> GetLatestPosts(int n);
        IEnumerable<Post> GetTopPosts(int likes); 
        Task Add(Post post);
        Task Delete(int id);
        Task EditPost(int id, string newContent, string newTitle);
        Task AddReply(PostReply reply);
        Task EditReply(int id, string newContent); 
        Task DeleteReply(int id);
        Task UpdatePostLikes(int likes); 
        PostReply GetReplyById(int id);
        Like GetLikeById(int id);
        Post GetAllLikes(int id);

    }
}
