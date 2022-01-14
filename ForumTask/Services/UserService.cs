using AutoMapper;
using ForumTask.Data;
using ForumTask.Models;
using ForumTask.Models.DTOs;
using ForumTask.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumTask.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public UserService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<PageResult<UserDTO>> GetUsersFromDb(int page, int pagesize = 5)
        {
            var countUsers = await _context.User.CountAsync();
            var users = await _context.User.AsNoTracking().Skip((page - 1) * pagesize).Take(pagesize).ToListAsync();
            var mappedUsers = _mapper.Map<IEnumerable<UserDTO>>(users);
            var result = new PageResult<UserDTO>
            {
                Count = countUsers,
                PageIndex = page,
                PageSize = 5,
                Items = mappedUsers.ToList()

            };
            return result;
            
        }
    }
}
