using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GeneralStoreMVC.Data.Entities;
using GeneralStoreMVC.Models.ProductModels;

namespace GeneralStoreMVC.Models.AutoMap;

public class ProductMapProfile : Profile
{
    public ProductMapProfile()
    {
        CreateMap<ProductEntity, ProductDetail>();
        CreateMap<ProductEntity, ProductIndex>();
        CreateMap<ProductEntity, ProductEdit>();

        CreateMap<ProductCreate, ProductEntity>();
        CreateMap<ProductEdit, ProductEntity>();
    }
}
