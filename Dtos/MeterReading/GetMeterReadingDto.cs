using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetEnsekTechChallenge.Dtos.MeterReading
{
    public class GetMeterReadingDto
    {
        public int MeterReadingId { get; set; }
        public int AccountId { get; set; }
        public DateTime MeterReadingDateTime { get; set; }
        public int MeterReadValue { get; set; }
    }
}