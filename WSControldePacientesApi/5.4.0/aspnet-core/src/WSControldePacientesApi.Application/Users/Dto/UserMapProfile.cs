using AutoMapper;
using WSControldePacientesApi.Authorization.Users;

namespace WSControldePacientesApi.Users.Dto
{
    public class UserMapProfile : Profile
    {
        public UserMapProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<UserDto, User>()
                .ForMember(x => x.Roles, opt => opt.Ignore())
                .ForMember(x => x.CreationTime, opt => opt.Ignore());

            CreateMap<CreateUserDto, User>();
            CreateMap<CreateUserDto, User>().ForMember(x => x.Roles, opt => opt.Ignore());

            CreateMap<User, DatosPersonalesDto>().ForMember(dpdto => dpdto.UserName, opts => opts.MapFrom(u => u.UserName))
                .ForMember(dpdto => dpdto.Name, opts => opts.MapFrom(u => u.Name))
                .ForMember(dpdto => dpdto.Surname, opts => opts.MapFrom(u => u.Surname))
                .ForMember(dpdto => dpdto.EmailAddress, opts => opts.MapFrom(u => u.EmailAddress))
                .ReverseMap();
        }
    }
}
