using AutoMapper;
using SignalR.DtoLayer.AboutDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
	public class AboutMapping : Profile
	{
        public AboutMapping()
        {
             CreateMap<About, ResultAboutDto>().ReverseMap();
             CreateMap<About, CreateAbotDto>().ReverseMap();
             CreateMap<About, UpdateAboutDto>().ReverseMap();
             CreateMap<About, GetAboutDto>().ReverseMap();
        }
    }
}
