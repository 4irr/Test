using Application.Common.Mappings;
using AutoMapper;

namespace Application.AppUsers.Commands.CreateUser
{
    public class CreateUserDto : IMapWith<CreateUserCommand>
    {
        public string? DisplayName { get; set; }
        public string? UserName { get; set; }
        public int Age { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateUserDto, CreateUserCommand>()
                .ForMember(command => command.DisplayName,
                    opt => opt.MapFrom(dto => dto.DisplayName))
                .ForMember(command => command.UserName,
                    opt => opt.MapFrom(dto => dto.UserName))
                .ForMember(command => command.Age,
                    opt => opt.MapFrom(dto => dto.Age))
                .ForMember(command => command.Email,
                    opt => opt.MapFrom(dto => dto.Email))
                .ForMember(command => command.Password,
                    opt => opt.MapFrom(dto => dto.Password));
        }
    }
}
