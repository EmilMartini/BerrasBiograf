using AutoMapper;

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
