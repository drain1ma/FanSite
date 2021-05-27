﻿using Fan_Website.Models;
using Fan_Website.Models.Follow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fan_Website.Infrastructure
{
    public interface IApplicationUser
    {
        ApplicationUser GetById(string id);
        IEnumerable<ApplicationUser> GetAll();
        Task SetProfileImage(string id, Uri uri);
        Task UpdateUserRating(string id, Type type);
        IEnumerable<ApplicationUser> GetLatestUsers(int n);
        IEnumerable<Follow> GetFollowing(string id); 
    }
}
