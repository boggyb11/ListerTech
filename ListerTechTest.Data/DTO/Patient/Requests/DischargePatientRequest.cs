using System;

namespace ListerTechTest.Data.DTO.Patient.Requests
{
    public class DischargePatientRequest
    {
        public Guid PatientId { get; set; }

        public DateTime DischargeDate { get; set; }

        public string Notes { get; set; }

    }
}
