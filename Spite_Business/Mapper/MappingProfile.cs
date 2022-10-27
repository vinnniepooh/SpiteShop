using AutoMapper;
using Spite_DataAccess;
using Spite_DataAccess.ViewModel;
using SpiteShop_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spite_Business.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<ProductPrice, ProductPriceDTO>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailDTO>().ReverseMap();
            CreateMap<OrderHeader, OrderHeaderDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();

        }
    }
}
