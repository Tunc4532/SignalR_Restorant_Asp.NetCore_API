using AutoMapper;
using SignalR.DtoLayer.CatagoryDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
	public class CatagoryMapping : Profile
	{
        public CatagoryMapping()
        {
            CreateMap<Catagory, ResultCatagoryDto>().ReverseMap();
            CreateMap<Catagory, AddCatagoryDto>().ReverseMap();
            CreateMap<Catagory, GetCatagoryDto>().ReverseMap();
            CreateMap<Catagory, UpdateCatagoryDto>().ReverseMap();
        }
    }
}
