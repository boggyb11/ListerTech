using ListerTechTest.Data.DTO.Patient.Requests;
using ListerTechTest.Data.Interfaces;
using ListerTechTest.Data.Models.Patient.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ListerTechTest.Controllers
{
    public class PatientController : BaseController
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddPatient(AddPatientRequest request)
        {
            var result = _patientService.AddPatient(request);

            if (result.Succeeded)
                return Ok(result.Content);

            return BadRequest(result.Error);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult EditPatient(EditPatientRequest request)
        {
            var result = _patientService.EditPatient(request);

            if (result.Succeeded)
                return Ok();

            return BadRequest(result.Error);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AdmitPatient(AdmitPatientRequest request)
        {
            var result = _patientService.AdmitPatient(request);

            if (result.Succeeded)
                return Ok();

            return BadRequest(result.Error);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DischargePatient(DischargePatientRequest request)
        {
            var result = _patientService.DischargePatient(request);

            if (result.Succeeded)
                return Ok();

            return BadRequest(result.Error);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetActivePatients()
        {
            var result = _patientService.GetActivePatients();

            if (result.Succeeded)
                return Ok(result.Content);

            return BadRequest(result.Error);
        }


    }
}
