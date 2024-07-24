using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GeneralStoreMVC.Data.Entities;
using GeneralStoreMVC.Models.TransactionModels;

namespace GeneralStoreMVC.Models.AutoMap;
public class TransactionMapProfile : Profile
{
    public TransactionMapProfile()
    {
        CreateMap<TransactionEntity, TransactionDetail>();
        CreateMap<TransactionEntity, TransactionIndex>();
        CreateMap<TransactionEntity, TransactionEdit>();
        CreateMap<TransactionEntity, TransactionForCustomerDetail>()
        .ForMember(dest => dest.TransactionTotal, opt => opt.MapFrom(src =>
            src.Quantity * src.Product.Price));

        CreateMap<TransactionCreate, TransactionEntity>();
        CreateMap<TransactionEdit, TransactionEntity>();
    }
}