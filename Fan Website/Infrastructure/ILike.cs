using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fan_Website.Infrastructure
{
    interface ILike
    {
        Task UpdatePostLikes(int id);
        Like GetById(int id); 
    }
}
