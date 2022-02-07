using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetEnsekTechChallenge.Models
{
    public class MeterReading
    {
        public int MeterReadingId { get; set; }
        public int AccountId { get; set; }
        public DateTime MeterReadingDateTime { get; set; }
        public string? MeterReadValue { get; set; }
    }
}