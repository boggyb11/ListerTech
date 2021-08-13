using AutoMapper;
using ListerTechTest.Data.CoreModels;
using ListerTechTest.Data.DTO.Patient.Requests;
using ListerTechTest.Data.DTO.Patient.Results;
using ListerTechTest.Data.DTO.Ward.Requests;
using ListerTechTest.Data.DTO.Ward.Results;
using ListerTechTest.Data.Models.Patient.Requests;
using System.Collections.Generic;

namespace ListerTechTest.Data.MappingProfiles
{
    public class DataProfile : Profile
    {
        public DataProfile()
        {
            CreateMap<Patient, AddPatientRequest>().ReverseMap();
            CreateMap<Patient, EditPatientRequest>().ReverseMap();
            CreateMap<Patient, PatientResult>().ReverseMap();
            CreateMap<Ward, AddWardRequest>().ReverseMap();
            CreateMap<Ward, WardResult>().ReverseMap();
        }
    }
}
