using ListerTechTest.Data.DTO.Patient.Results;
using ListerTechTest.Data.DTO.Ward.Requests;
using ListerTechTest.Data.DTO.Ward.Results;
using ListerTechTest.Data.Models.Common;
using System.Collections.Generic;

namespace ListerTechTest.Data.Interfaces
{
    public interface IWardService
    {
        CommandResult<int> AddWard(AddWardRequest request);
        CommandResult<List<PatientResult>> GetActiveWardPatients(int wardId);
        CommandResult<List<WardResult>> GetWards();
    }
}
