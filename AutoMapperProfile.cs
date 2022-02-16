using AutoMapper;
using CQRS_With_MeditR_Demo.DTO;
using CQRS_With_MeditR_Demo.Model;

namespace CQRS_With_MeditR_Demo
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, GetProductDTO>();
        }
    }
}
