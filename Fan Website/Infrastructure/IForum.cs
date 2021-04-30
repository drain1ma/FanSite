using Fan_Website.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fan_Website.Services
{
    public interface IForum
    {
        Forum GetById(int id);
        IEnumerable<Forum> GetAll();
        Task Create(Forum forum);
        Task Delete(int forumId);
        Task UpdateForumTitle(int forumId, string newTitle);
        Task UpdateForumDescription(int forumId, string newDescription);
    }
}