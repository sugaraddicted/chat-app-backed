using System;
using System.Linq;
using AutoMapper;
using ChatApp.Api.Input;
using ChatApp.Core.DTO;
using ChatApp.Core.Entities;
using ChatApp.Core.Extensions;

namespace ChatApp.Api.Helpers
{
    public class AutoMapperProfiles : Profile 
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, MemberDto>()
                .ForMember(dest => dest.PhotoUrl,
                    opt => opt.MapFrom(src => src.Photos.FirstOrDefault(x => x.IsMain).Url))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.CalculateAge()));
            CreateMap<Photo, PhotoDto>();
            CreateMap<MemberUpdateDto, User>();
            CreateMap<RegisterInput, User>()
                .ForMember(dest =>dest.DateOfBirth,
                    opt => opt.MapFrom(src => DateTime.Parse(src.DateOfBirth.ToString()).ToUniversalTime()));
        }
    }
}
