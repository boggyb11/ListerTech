using System;

namespace ListerTechTest.Data.Models.Patient.Requests
{
    public class AddPatientRequest
    {
        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Gender Gender { get; set; }
    }
}
