using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using credit_approval.Models;
using credit_approval.DataTransferObjects;

namespace credit_approval
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserForCreationDto, User>();
        }
    }
}
