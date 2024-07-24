using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GeneralStoreMVC.Data.Entities;
using GeneralStoreMVC.Models.CustomerModels;

namespace GeneralStoreMVC.Models.AutoMap;

public class CustomerMapProfile : Profile
{
    public CustomerMapProfile()
    {
        CreateMap<CustomerEntity, CustomerDetail>();
        CreateMap<CustomerEntity, CustomerIndex>();
        CreateMap<CustomerEntity, CustomerEdit>();

        CreateMap<CustomerCreate, CustomerEntity>();
        CreateMap<CustomerEdit, CustomerEntity>();
    }
}
