using AutoMapper;
using blog.core.Models;
using blog.website.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blog.website.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Post, PostDTO>();
            CreateMap<User, UserDTO>();

            CreateMap<PostDTO, Post>();
            CreateMap<PostDTO, Post>();

            CreateMap<SavePostDTO, Post>();
            CreateMap<SaveUserDTO, User>();
        }
    }
}
