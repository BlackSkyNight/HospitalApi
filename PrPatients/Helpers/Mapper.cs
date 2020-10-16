using Entities;
using PrPatients.Model;

namespace PrPatients.Helpers
{
    // replace with automapper in future
    public static class Mapper
    {
        public static PatientViewModel CreatePatientViewModelFrom(IPatient patient)
            => new PatientViewModel()
            {
                Id = patient.Id,
                Age = patient.Age,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                TestCovid = patient.TestCovid,
            };

        public static Patient CreatePatientEntityFrom(PatientViewModel patient)
            => new Patient()
            {
                Age = patient.Age,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                TestCovid = patient.TestCovid,
            };
    }
}
