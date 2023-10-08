using Application.Common.Mappings;
using AutoMapper;
using Domain;

namespace Application.AppUsers.Queries.GetUserDetails
{
    public class UserDetailsVm : IMapWith<AppUser>
    {
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public int Age { get; set; }
        public string? Email { get; set; }
        public IList<string>? Roles { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AppUser, UserDetailsVm>()
                .ForMember(vm => vm.Id,
                    opt => opt.MapFrom(user => user.Id))
                .ForMember(vm => vm.DisplayName,
                    opt => opt.MapFrom(user => user.DisplayName))
                .ForMember(vm => vm.Age,
                    opt => opt.MapFrom(user => user.Age))
                .ForMember(vm => vm.Email,
                    opt => opt.MapFrom(user => user.Email))
                .ForMember(vm => vm.Roles,
                    opt => opt.MapFrom(user => user.Roles));
        }
    }
}
