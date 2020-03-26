using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BerrasBiograf
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRegistrationModel, User>().
                ForMember(u => u.UserName, option => option.MapFrom(o => o.Email));
        }
    }
}
