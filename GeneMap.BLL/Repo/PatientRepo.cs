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

        public async Task<PatientDto> Add(PatientDto patientDto,CancellationToken cancellation)
        {
            var patient = new Patient
            {
                Name = patientDto.Name,
                DiseaseStatus = patientDto.DiseaseStatus,
                IllnessName = patientDto.IllnessName,
                Lastname = patientDto.Lastname,
                PatientEndDate = patientDto.PatientEndDate,
                PatientStartDate = patientDto.PatientStartDate,
                NationalIdentity = patientDto.NationalIdentity,
                Symptoms = patientDto.Symptoms,
                PatientRelatives = patientDto.PatientRelatives
            };
            
            var result = _patientDataContext.Patients.Add(patient);
            if (await _patientDataContext.SaveChangesAsync(cancellation) > 0)
            {
                return patientDto;
            }
            
            
            return patientDto;
        }


        public async Task<List<PatientDto>> List(CancellationToken cancellationToken)
        {
            var patient = await _patientDataContext.Patients.Select(x => new PatientDto
            {
                Name = x.Name,
                DiseaseStatus = x.DiseaseStatus,
                IllnessName = x.IllnessName,
                Lastname = x.Lastname,
                PatientEndDate = x.PatientEndDate,
                PatientStartDate = x.PatientStartDate,
                NationalIdentity = x.NationalIdentity,
                PatientRelatives = x.PatientRelatives,
                Symptoms = x.Symptoms
            }).ToListAsync(cancellationToken);
            return patient;
        }

        public async Task<int> Delete(int id,CancellationToken cancellationToken)
        {
            var result=await _patientDataContext.Patients.Where(x=>x.PatientId== id).ToListAsync(cancellationToken);
            if(result.Count>0)
            {
                _patientDataContext.Remove(result);
               await _patientDataContext.SaveChangesAsync(cancellationToken);
            }
            return 0;
        }


    }
}
