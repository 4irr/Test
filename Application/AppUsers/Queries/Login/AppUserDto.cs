using Application.Common.Mappings;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AppUsers.Queries.Login
{
    public class AppUserDto : IMapWith<AppUser>
    {
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public int Age { get; set; }
        public string? Email { get; set; }
        public string? Token { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<AppUser, AppUserDto>()
                .ForMember(dto => dto.Id,
                    opt => opt.MapFrom(user => user.Id))
                .ForMember(dto => dto.DisplayName,
                    opt => opt.MapFrom(user => user.DisplayName))
                .ForMember(dto => dto.Age,
                    opt => opt.MapFrom(user => user.Age))
                .ForMember(dto => dto.Email,
                    opt => opt.MapFrom(user => user.Email))
                .ForMember(dto => dto.Token,
                    opt => opt.MapFrom(user => user.Token));
        }
    }
}
