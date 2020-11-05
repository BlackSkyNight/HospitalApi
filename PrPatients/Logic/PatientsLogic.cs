using DAL;
using Entities;
using PrPatients.Helpers;
using PrPatients.Model;
using ServiceBusSender;
using ServiceBusSender.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrPatients.Logic
{
    public class PatientsLogic : IPatientsLogic
    {
        private readonly IRepository<Patient> _repository;
        private readonly IBusSender _busSender;

        public PatientsLogic(IRepository<Patient> repository, IBusSender busSender)
        {
            _repository = repository;
            _busSender = busSender;
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

            if (patient.Status)
                await SendCovidNotificion(patient.Data);

            return patient.Status;
        }

        private async Task SendCovidNotificion(IPatient patient)
        {
            if (!string.IsNullOrWhiteSpace(patient?.EmailAddress))
            {
                await _busSender.SendMessage(MessagePayloadFactory.Create(MessageType.CovidNotification, patient.EmailAddress));
            }
        }
    }
}
