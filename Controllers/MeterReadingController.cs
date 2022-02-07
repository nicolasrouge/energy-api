using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetEnsekTechChallenge.Dtos.MeterReading;
using dotnetEnsekTechChallenge.Models;
using dotnetEnsekTechChallenge.Services.MeterReading;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace dotnetEnsekTechChallenge.Controllers
{
    [ApiController]
    [Route("meter-reading-uploads")]
    public class MeterReadingController : ControllerBase
    {
        public IMeterReadingService _meterReadingService;

        public MeterReadingController(IMeterReadingService meterReadingService)
        {
            _meterReadingService = meterReadingService;
            
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetMeterReadingDto>>>> GetList(){
            return Ok(await _meterReadingService.GetAllMeterReadings());
        }

        [HttpPost("Add")]
        public async Task<ActionResult<ServiceResponse<List<Account>>>> AddAccount(AddMeterReadingDto meterReading){
            /*if(!(meterReading.MeterReadingDateTime.GetType() == typeof(DateTime))){
                throw new Exception("MeterReadingDateTime must be a date");
            }*/
            return Ok(await _meterReadingService.AddMeterReading(meterReading));
        }
    }
}