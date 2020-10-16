using System;

namespace Entities
{
    public interface IPatient : IEntityBase
    {
        int Age { get; set; }
        string FirstName { get; set; }
        int Id { get; set; }
        string LastName { get; set; }
        DateTime? TestCovid { get; set; }
    }
}