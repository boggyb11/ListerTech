using AutoMapper;
using ListerTechTest.Data.CoreModels;
using ListerTechTest.Data.Data;
using ListerTechTest.Data.DTO.Patient.Requests;
using ListerTechTest.Data.DTO.Patient.Results;
using ListerTechTest.Data.Interfaces;
using ListerTechTest.Data.MappingProfiles;
using ListerTechTest.Data.Models.Common;
using ListerTechTest.Data.Models.Patient.Requests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListerTechTest.Data.Services
{
    public class PatientService : IPatientService
    {
        private readonly DataContext _context;
        private readonly MapperConfiguration Config = new(cfg => cfg.AddProfile<DataProfile>());

        public PatientService(DataContext context)
        {
            _context = context;
        }

        public CommandResult<Guid> AddPatient(AddPatientRequest request)
        {
            var patient = Config.CreateMapper().Map(request, new Patient());
            _context.Patients.Add(patient);
            _context.SaveChanges();

            return CommandResult<Guid>.Success(patient.Id);
        }

        public QueryResult AdmitPatient(AdmitPatientRequest request)
        {
            var patient = _context.Patients.Include(x => x.Spells).FirstOrDefault(x => x.Id == request.PatientId);
            if (patient == null) return QueryResult.Failure("Patient not found");

            var hasActiveSpell = patient.Spells?.Any(x => x.Active);
            if (hasActiveSpell == true) return QueryResult.Failure("Patient already has an active spell");

            var spell = new Spell()
            {
                AdmitDate = request.AdmitDate,
                Notes = request.Notes,
                Patient = patient,
                PatientId = patient.Id,
                Active = true
            };

            if (request.WardId != null)
            {
                var ward = _context.Wards.FirstOrDefault(x => x.Id == request.WardId);
                if (ward == null) return QueryResult.Failure("Ward not found");

                spell.Ward = ward;
                spell.WardId = ward.WardId;
            }

            _context.Spells.Add(spell);
            _context.SaveChanges();

            return QueryResult.Success();
        }

        public QueryResult DischargePatient(DischargePatientRequest request)
        {
            var patient = _context.Patients
                .Include(x => x.Spells)
                .FirstOrDefault(x => x.Id == request.PatientId);
            if (patient == null) return QueryResult.Failure("Patient not found");

            var activeSpell = patient.Spells?.FirstOrDefault(x => x.Active);
            if (activeSpell == null) return QueryResult.Failure("No active spell found");

            activeSpell.DischargeDate = request.DischargeDate;
            activeSpell.Active = false;
            activeSpell.Notes = request.Notes;

            _context.Spells.Update(activeSpell);
            _context.SaveChanges();

            return QueryResult.Success();
        }

        public QueryResult EditPatient(EditPatientRequest request)
        {
            var existingPatient = _context.Patients.FirstOrDefault(x => x.Id == request.Id);
            if (existingPatient == null) return QueryResult.Failure("Patient not found");

            Config.CreateMapper().Map(request, existingPatient);

            _context.Patients.Update(existingPatient);
            _context.SaveChanges();

            return QueryResult.Success();
        }

        public CommandResult<List<PatientResult>> GetActivePatients()
        {
            var activePatients = _context.Patients.Where(x => x.Spells.Any(x => x.Active));
            var patientResults = Config.CreateMapper().Map(activePatients, new List<PatientResult>());

            return CommandResult<List<PatientResult>>.Success(patientResults);
        }
    }
}
