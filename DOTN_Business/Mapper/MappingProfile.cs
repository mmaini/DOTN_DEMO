using AutoMapper;
using DOTN_DataAccess;
using DOTN_DataAccess.ViewModel;
using DOTN_Models;

namespace DOTN_Business.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<OrderHeaderDTO, OrderHeader>().ReverseMap();
            CreateMap<OrderDetailDTO, OrderDetail>().ReverseMap();
            CreateMap<OrderDTO, Order>().ReverseMap();
        }
    }
}
