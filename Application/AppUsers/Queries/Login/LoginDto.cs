using Application.AppUsers.Queries.Login;
using Application.Common.Mappings;
using AutoMapper;

namespace Application.AppUsers.Queries.Login
{
    public class LoginDto : IMapWith<LoginQuery>
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<LoginDto, LoginQuery>()
                .ForMember(query => query.UserName,
                    opt => opt.MapFrom(dto => dto.UserName))
                .ForMember(query => query.Password,
                    opt => opt.MapFrom(dto => dto.Password));
        }
    }
}
