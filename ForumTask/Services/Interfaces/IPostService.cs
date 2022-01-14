using ForumTask.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumTask.Services.Interfaces
{
    public interface IPostService
    {
        Task<IEnumerable<PostDTO>> GetUserFromDb(int id);
    }
}
