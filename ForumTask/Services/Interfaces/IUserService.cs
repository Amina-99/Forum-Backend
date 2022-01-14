using ForumTask.Models;
using ForumTask.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumTask.Services.Interfaces
{
    public interface IUserService
    {
        Task<PageResult<UserDTO>> GetUsersFromDb(int page, int pagesize = 6);
    }
}
