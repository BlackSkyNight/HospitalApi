using Microsoft.AspNetCore.Mvc;
using PrPatients.Logic;
using PrPatients.Model;
using System.Threading.Tasks;

namespace PrPatients.Controllers
{
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientsLogic _patientsLogic;

        public PatientsController(IPatientsLogic patientsLogic)
        {
            this._patientsLogic = patientsLogic;
        }

        [HttpGet]
        [Route("Patients/All")]
        public async Task<IActionResult> GetAllPatients()
        {
            var results = await _patientsLogic.GetAllPatients();

            return Ok(results);
        }

        [HttpGet]
        [Route("Patients/AllCovidInfected")]
        public async Task<IActionResult> GetAllCovidInfectedPatients()
        {
            var results = await _patientsLogic.GetAllCovidInfectedPatients();

            return Ok(results);
        }

        [HttpPost]
        [Route("Patients/New")]
        public async Task<IActionResult> AddNewPatient(PatientViewModel model)
        {
            var result = await _patientsLogic.AddNewPatient(model);

            return Ok(new { success = result}); 
        }
    }
}
