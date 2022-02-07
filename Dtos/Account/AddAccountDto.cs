using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetEnsekTechChallenge.Models;
using dotnetEnsekTechChallenge.Dtos.MeterReading;

namespace dotnetEnsekTechChallenge.Dtos.Account
{
    public class AddAccountDto
    {
        public string? FirstName { get; set; } = "TestFirstName";
        public string? LastName { get; set; } = "TestLastName";
    }
}