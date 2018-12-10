using System.Linq;
using AgroEX.API.Dtos;
using AgroEX.API.Models;
using AutoMapper;

namespace AgroEX.API.Helpers
{
     public class AutoMapperProfiles:Profile
     {    
        public AutoMapperProfiles()
        {
            CreateMap<Product,ProductForList>()
            .ForMember(dest => dest.PhotoUrl, opt => {
                opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsAvailable).Url);
            });           
            CreateMap<Product, ProductForDetail>()
            .ForMember(dest => dest.PhotoUrl, opt => {
                opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsAvailable).Url);
            });
            
            CreateMap<Photo, PhotosForDetail>();

        }
    }
}