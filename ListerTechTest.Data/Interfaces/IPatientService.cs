using ListerTechTest.Data.DTO.Patient.Requests;
using ListerTechTest.Data.DTO.Patient.Results;
using ListerTechTest.Data.Models.Common;
using ListerTechTest.Data.Models.Patient.Requests;
using System;
using System.Collections.Generic;

namespace ListerTechTest.Data.Interfaces
{
    public interface IPatientService
    {
        CommandResult<Guid> AddPatient(AddPatientRequest request);
        QueryResult EditPatient(EditPatientRequest request);
        CommandResult<List<PatientResult>> GetActivePatients();
        QueryResult AdmitPatient(AdmitPatientRequest request);
        QueryResult DischargePatient(DischargePatientRequest request);
    }
}
