using ListerTechTest.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListerTechTest.Data.DTO.Patient.Results
{
    public class PatientResult
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Gender Gender { get; set; }
    }
}
