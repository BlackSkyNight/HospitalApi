using System;
using System.ComponentModel.DataAnnotations;

namespace PrPatients.Model
{
    public class PatientViewModel
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int Age { get; set; }
        public DateTime? TestCovid { get; set; }
        public string EmailAddress { get; set; }
    }
}
