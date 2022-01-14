using ForumTask.Models;
using ForumTask.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumTask.Services.Interfaces
{
    public interface IPostClientService
    {
        Task GetPosts();
    }
}
