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
    public class PostService : IPostService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public PostService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<PostDTO>> GetUserFromDb(int id)
        {
            var posts = await _context.Post.Where(p => p.UserId == id).ToListAsync();
            var mappedPosts = _mapper.Map<IEnumerable<Post>, IEnumerable<PostDTO>>(posts);
            return mappedPosts;

        }
    }
}
