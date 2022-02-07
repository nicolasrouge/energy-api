using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnetEnsekTechChallenge.Data;
using dotnetEnsekTechChallenge.Dtos.MeterReading;
using dotnetEnsekTechChallenge.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnetEnsekTechChallenge.Services.MeterReading
{
    public class MeterReadingService : IMeterReadingService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public MeterReadingService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetMeterReadingDto>>> AddMeterReading(AddMeterReadingDto meterReading)
        {
            var serviceResponse = new ServiceResponse<List<GetMeterReadingDto>>();
            Models.MeterReading newMeterReading = _mapper.Map<Models.MeterReading>(meterReading);

            //verify if the MeterReading is already saved in the DB
            var oldMeterReading = _context.MeterReadings.FirstOrDefault(p => (
                p.AccountId == newMeterReading.AccountId &&
                p.MeterReadingDateTime == newMeterReading.MeterReadingDateTime &&
                p.MeterReadValue == newMeterReading.MeterReadValue
            ));

            if(oldMeterReading is not null){
                throw new Exception("Already Saved in DB");
            }

            _context.MeterReadings.Add(newMeterReading);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.MeterReadings.Select(mr => _mapper.Map<GetMeterReadingDto>(mr)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetMeterReadingDto>>> GetAllMeterReadings()
        {
            var serviceResponse2 = new ServiceResponse<List<GetMeterReadingDto>>();
            var dbMeterReadings = await _context.MeterReadings.ToListAsync();
            serviceResponse2.Data = dbMeterReadings.Select(mr => _mapper.Map<GetMeterReadingDto>(mr)).ToList();
            return serviceResponse2;
        }
    }
}