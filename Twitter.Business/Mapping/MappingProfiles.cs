using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Business.Dtos.Post;
using Twitter.Business.Dtos.User;
using Twitter.Core.Entities;

namespace Twitter.Business.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserRegisterDto, User>();
            CreateMap<User, UserDto>();
            CreateMap<IEnumerable<User>, IEnumerable<UserDto>>();

            CreateMap<PostCreateDto, Post>();

        }
    }
}
