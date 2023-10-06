using Application.AppUsers.Enums;
using Application.Common.Mappings;
using AutoMapper;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Application.AppUsers.Queries.GetUserList
{
    public class GetUserListDto : IMapWith<GetUserListQuery>
    {
        public AppUserSortState SortState { get; set; } = AppUserSortState.IdAsc;
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public int? Age { get; set; }
        public string? Email { get; set; }
        [DefaultValue(1)]
        [Range(1, double.MaxValue)]
        public int Page { get; set; } = 1;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<GetUserListDto, GetUserListQuery>()
                .ForMember(query => query.SortState,
                    opt => opt.MapFrom(dto => dto.SortState))
                .ForMember(query => query.Id,
                    opt => opt.MapFrom(dto => dto.Id))
                .ForMember(query => query.DisplayName,
                    opt => opt.MapFrom(dto => dto.DisplayName))
                .ForMember(query => query.Age,
                    opt => opt.MapFrom(dto => dto.Age))
                .ForMember(query => query.Email,
                    opt => opt.MapFrom(dto => dto.Email))
                .ForMember(query => query.Page,
                    opt => opt.MapFrom(dto => dto.Page));

        }
    }
}
