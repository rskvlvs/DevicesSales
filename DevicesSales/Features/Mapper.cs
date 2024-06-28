using AutoMapper;
using DevicesSales.Features.DtoModels;
using DevicesSalesStorage.Models;

namespace DevicesSales.Features
{
    public class Mapper : Profile 
    {
        public Mapper()
        {
            CreateMap<SaleDto, Sale>().ReverseMap();

            CreateMap<ClientDto,  Client>().ReverseMap();
        }
    }
}
