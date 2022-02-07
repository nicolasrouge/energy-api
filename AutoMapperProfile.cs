using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnetEnsekTechChallenge.Dtos.Account;
using dotnetEnsekTechChallenge.Dtos.MeterReading;
using dotnetEnsekTechChallenge.Models;

namespace dotnetEnsekTechChallenge
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile(){
            CreateMap<Account, GetAccountDto>();
            CreateMap<AddAccountDto, Account>();
            CreateMap<MeterReading, GetMeterReadingDto>();
            CreateMap<AddMeterReadingDto, MeterReading>().ForMember(dest => dest.MeterReadValue, 
                opt => opt.MapFrom(src => src.MeterReadValue.ToString("00000")));;
        }
    }
}