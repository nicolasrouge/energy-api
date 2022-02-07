using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetEnsekTechChallenge.Dtos.MeterReading;
using dotnetEnsekTechChallenge.Models;

namespace dotnetEnsekTechChallenge.Services.MeterReading
{
    public interface IMeterReadingService
    {
        
        Task<ServiceResponse<List<GetMeterReadingDto>>> GetAllMeterReadings();        
        Task<ServiceResponse<List<GetMeterReadingDto>>> AddMeterReading(AddMeterReadingDto meterReading);

    }
}