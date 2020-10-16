using PrPatients.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrPatients.Logic
{
    public interface IPatientsLogic
    {
        Task<IEnumerable<PatientViewModel>> GetAllCovidInfectedPatients();
        Task<IEnumerable<PatientViewModel>> GetAllPatients();
        Task<bool> AddNewPatient(PatientViewModel model);
    }
}