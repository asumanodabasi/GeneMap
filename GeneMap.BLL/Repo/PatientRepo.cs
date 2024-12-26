using GeneMap.BLL.Data;
using GeneMap.BLL.Data.Dto;
using GeneMap.BLL.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneMap.BLL.Repo
{
    public class PatientRepo
    {
        private readonly PatientDataContext _patientDataContext;

        public PatientRepo(PatientDataContext patientDataContext)
        {
            _patientDataContext = patientDataContext;
        }

        public async Task<int> Add(PatientDto patientDto,CancellationToken cancellation)
        {
            Patient patient=new()
            {
                Name = patientDto.Name,
                DiseaseStatus = patientDto.DiseaseStatus,
                Complaints = patientDto.Complaints,
                Lastname = patientDto.Lastname,
                PatientEndDate = patientDto.PatientEndDate,
                PatientStartDate = patientDto.PatientStartDate,
                NationalIdentity = patientDto.NationalIdentity,
                Symptoms = patientDto.Symptoms,
            };
            
                 _patientDataContext.Patients.Add(patient);
            if (await _patientDataContext.SaveChangesAsync(cancellation) > 0)
            {
                return patientDto.PatientId;
            }


            return 0;
        }

       
        public async Task<PatientDto> GetRelatives(int patientId, CancellationToken cancellationToken)
        {
            var result = await _patientDataContext.Patients
                .Include(x => x.PatientPatientRelative)
                    .ThenInclude(pr => pr.PatientRelative).ThenInclude(x=>x.Ilness).Include(x=>x.Ilnesses)
                .FirstOrDefaultAsync(x => x.PatientId == patientId, cancellationToken);
            
            
            if (result == null) return null;

            // DTO'ya dönüştürme
            var patientDto = new PatientDto
            {
                PatientId = result.PatientId,
                NationalIdentity = result.NationalIdentity,
                Name = result.Name,
                Lastname = result.Lastname,
                Complaints = result.Complaints,
                Symptoms = result.Symptoms,
                PatientStartDate = result.PatientStartDate,
                PatientEndDate = result.PatientEndDate,
                DiseaseStatus = result.DiseaseStatus,
                Ilness=result.Ilnesses,
                PatientRelative = result.PatientPatientRelative,
    
            };
         
            return patientDto;
        }

        public async Task<PatientDto> Update(int id,PatientDto patientDto, CancellationToken cancellationToken)
        {
            var result=_patientDataContext.Patients.FirstOrDefault(x=>x.PatientId==id);
            if (result != null)
            {
                result.Symptoms= patientDto.Symptoms;
                result.DiseaseStatus= patientDto.DiseaseStatus;
                result.Complaints= patientDto.Complaints;
                
                _patientDataContext.Patients.Update(result);
                await _patientDataContext.SaveChangesAsync(cancellationToken);
            }
            return patientDto;
        }

        public async Task<PatientDto> GetById(int id,CancellationToken cancellationToken)
        {
            var result = await _patientDataContext.Patients.FindAsync(id);
            var patientDto = new PatientDto
            {
                DiseaseStatus = result.DiseaseStatus,
                Complaints = result.Complaints,
                Lastname = result.Lastname,
                Name = result.Name,
                NationalIdentity = result.NationalIdentity,
                PatientEndDate = result.PatientEndDate,
                PatientStartDate = result.PatientStartDate,
                Symptoms = result.Symptoms,
                PatientId = result.PatientId,
                Ilness=result.Ilnesses
            };
            return  patientDto;
          
        }

        public async Task<List<PatientDto>> List(CancellationToken cancellationToken)
        {
            var patient = await _patientDataContext.Patients.Select(x => new PatientDto
            {
                PatientId = x.PatientId,
                Name = x.Name,
                DiseaseStatus = x.DiseaseStatus,
                Complaints=x.Complaints,
                Lastname = x.Lastname,
                PatientEndDate = x.PatientEndDate,
                PatientStartDate = x.PatientStartDate,
                NationalIdentity = x.NationalIdentity,
                Symptoms = x.Symptoms
            }).ToListAsync(cancellationToken);
            return patient;
        }

        public async Task<int> Delete(int id,CancellationToken cancellationToken)
        {
            var result = await _patientDataContext.Patients.FindAsync(id);
            if(result!=null)
            {
                _patientDataContext.Remove(result);
               await _patientDataContext.SaveChangesAsync(cancellationToken);
            }
            return id;
        }


      
    }
}
