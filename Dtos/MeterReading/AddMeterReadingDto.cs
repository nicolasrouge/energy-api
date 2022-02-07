using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetEnsekTechChallenge.Dtos.MeterReading
{
    public class AddMeterReadingDto
    {
        public int AccountId { get; set; }
        public string? MeterReadingDateTime { get; set; }
        public int MeterReadValue { get; set; }
    }
}