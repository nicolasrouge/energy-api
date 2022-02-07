using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetEnsekTechChallenge.Models
{
    public class Account
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public int AccountId { get; set; }
        public string? FirstName { get; set; } = "TestFirstName";
        public string? LastName { get; set; } = "TestLastName";
        public ICollection<MeterReading>? MeterReadings {get; set;}
    }
}