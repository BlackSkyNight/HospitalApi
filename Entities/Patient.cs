using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Patient : IPatient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime? TestCovid { get; set; }
    }
}
