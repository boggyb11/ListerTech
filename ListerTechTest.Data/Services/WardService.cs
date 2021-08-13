using AutoMapper;
using ListerTechTest.Data.CoreModels;
using ListerTechTest.Data.Data;
using ListerTechTest.Data.DTO.Patient.Results;
using ListerTechTest.Data.DTO.Ward.Requests;
using ListerTechTest.Data.DTO.Ward.Results;
using ListerTechTest.Data.Interfaces;
using ListerTechTest.Data.MappingProfiles;
using ListerTechTest.Data.Models.Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ListerTechTest.Data.Services
{
    public class WardService : IWardService
    {
        private readonly DataContext _context;
        private readonly MapperConfiguration Config = new(cfg => cfg.AddProfile<DataProfile>());

        public WardService(DataContext context)
        {
            _context = context;
        }

        public CommandResult<int> AddWard(AddWardRequest request)
        {
            var existingWard = _context.Wards.FirstOrDefault(x => x.WardId == request.WardId);
            if (existingWard != null) return CommandResult<int>.Failure("Ward with Id already exists");

            var ward = Config.CreateMapper().Map(request, new Ward());
            _context.Wards.Add(ward);
            _context.SaveChanges();

            return CommandResult<int>.Success(ward.Id);
        }

        public CommandResult<List<PatientResult>> GetActiveWardPatients(int wardId)
        {
            var ward = _context.Wards
                .Include(x => x.Spells)
                .Include("Spells.Patient")
                .FirstOrDefault(x => x.Id == wardId);
            if (ward == null) return CommandResult<List<PatientResult>>.Failure("Ward not found");

            var currentSpells = ward.Spells?.Where(x => x.Active);
            var patients = currentSpells?.Select(x => x.Patient);
            var patientResults = Config.CreateMapper().Map(patients, new List<PatientResult>());

            return CommandResult<List<PatientResult>>.Success(patientResults);
        }

        public CommandResult<List<WardResult>> GetWards()
        {
            var wards = _context.Wards.ToList();
            var wardResults = Config.CreateMapper().Map(wards, new List<WardResult>());

            return CommandResult<List<WardResult>>.Success(wardResults);
        }
    }
}
