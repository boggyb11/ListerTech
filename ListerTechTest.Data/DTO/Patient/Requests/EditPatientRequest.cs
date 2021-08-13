using ListerTechTest.Data.Models;
using System;

namespace ListerTechTest.Data.DTO.Patient.Requests
{
    public class EditPatientRequest
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Gender Gender { get; set; }
    }
}
