using AutoMapper;
using ForumTask.Models;
using ForumTask.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumTask.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDTO, User>().ReverseMap();
            CreateMap<PostDTO, Post>().ReverseMap();
        }
    }
}
