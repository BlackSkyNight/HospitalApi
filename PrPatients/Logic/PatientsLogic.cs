using DAL;
using Entities;
using PrPatients.Helpers;
using PrPatients.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrPatients.Logic
{
    public class PatientsLogic : IPatientsLogic
    {
        private readonly IRepository<Patient> _repository;

        public PatientsLogic(IRepository<Patient> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PatientViewModel>> GetAllPatients()
        {
            var patients = await _repository.GetManyAsync();

            return patients.Data
                .Select(Mapper.CreatePatientViewModelFrom);
        }

        public async Task<IEnumerable<PatientViewModel>> GetAllCovidInfectedPatients()
        {
            var patients = await _repository.GetManyAsync(x => x.TestCovid.HasValue);

            return patients.Data
                .Select(Mapper.CreatePatientViewModelFrom);
        }

        public async Task<bool> AddNewPatient(PatientViewModel model) 
        {
            var patient = await _repository.AddAsync(Mapper.CreatePatientEntityFrom(model));

            return patient.Status;
        }
    }
}
