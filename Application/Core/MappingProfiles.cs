using Application.Activities.DTOs;
using AutoMapper;
using Domain.Entity;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Activity, Activity>();
            CreateMap<CreateActivityDto, Activity>();
        }
    }
}
