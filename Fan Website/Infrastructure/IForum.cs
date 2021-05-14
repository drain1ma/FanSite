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
        Task Delete(int id);
        Task UpdateForumTitle(int id, string newTitle);
        Task UpdateForumDescription(int id, string newDescription);
    }
}