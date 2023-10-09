using Application.Common.Mappings;
using Application.Roles.Enums;
using AutoMapper;

namespace Application.AppUsers.Commands.UpdateUser
{
    public class UpdateUserDto : IMapWith<UpdateUserCommand>
    {
        public string? DisplayName { get; set; }
        public int Age { get; set; }
        public string? Email { get; set; }
        public List<UserRoles>? Roles { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateUserDto, UpdateUserCommand>()
                .ForMember(command => command.DisplayName,
                    opt => opt.MapFrom(dto => dto.DisplayName))
                .ForMember(command => command.Age,
                    opt => opt.MapFrom(dto => dto.Age))
                .ForMember(command => command.Email,
                    opt => opt.MapFrom(dto => dto.Email))
                .ForMember(command => command.Roles,
                    opt => opt.MapFrom(dto => dto.Roles));
        }
    }
}
