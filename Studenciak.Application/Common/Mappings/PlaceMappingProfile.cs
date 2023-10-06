using Application.Common.Models;
using AutoMapper;
using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Common.Mappings;

public class PlaceMappingProfile : Profile
{
    public PlaceMappingProfile()
    {
        CreateMap<Place, PlaceDto>()
            .ForMember(m => m.Name, c => c.MapFrom(s => s.Name))
            .ForMember(m => m.Location, c => c.MapFrom(s => new Location()
            {
                Latitude = s.Location.Latitude,
                Longitude = s.Location.Longitude
            }))
            .ForMember(m => m.Type, c => c.MapFrom(s => s.Type))
            .ForMember(m => m.FoodType, c => c.MapFrom(s => s.FoodType))
            .ForMember(m => m.Rating, c => c.MapFrom(s => s.Rating))
            .ForMember(m => m.CreatedAt, c => c.MapFrom(s => s.CreatedAt))
            .ForMember(m => m.UpdatedAt, c => c.MapFrom(s => s.UpdatedAt));
    }
    
}