using Application.Common.Models;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Mappings
{
    public class PlaceMappingProfile : Profile
    {
        public PlaceMappingProfile()
        {
            CreateMap<Place, PlaceDto>();
            CreateMap<CreatePlaceDto, Place>();
        }
    }
}