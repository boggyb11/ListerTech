using System;

namespace ListerTechTest.Data.DTO.Patient.Requests
{
    public class AdmitPatientRequest
    {
        public Guid PatientId { get; set; }

        public DateTime AdmitDate { get; set; }

        public string Notes { get; set; }

        public int? WardId { get; set; }
    }
}
