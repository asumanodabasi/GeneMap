using GeneMap.BLL.Data.Dto;
using GeneMap.BLL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneMap.BLL.Data.Entities;
using Microsoft.EntityFrameworkCore;
using GeneMap.BLL.Migrations;
using System.Threading;

namespace GeneMap.BLL.Repo
{
    public class PatientRelativeRepo
    {
        private readonly PatientDataContext _patientDataContext;

        public PatientRelativeRepo(PatientDataContext patientDataContext)
        {
            _patientDataContext = patientDataContext;
        }

        public async Task<PatientRelativeDto> Add(PatientRelativeDto patientRelativeDto, CancellationToken cancellation)
        {
            var patientRelative = new Data.Entities.PatientRelative
            {
                Name = patientRelativeDto.Name,
                Lastname = patientRelativeDto.Lastname,
                Degree = patientRelativeDto.Degree,
                PatientPatientRelative = patientRelativeDto.Patients,
            };

            _patientDataContext.PatientRelatives.Add(patientRelative);
            if (await _patientDataContext.SaveChangesAsync(cancellation) > 0)
            {
                return patientRelativeDto;
            }


            return null;
        }
        public async Task<PatientRelativeDto> GetById(int id, CancellationToken cancellationToken)
        {
            var result = await _patientDataContext.PatientRelatives.FindAsync(id);
            var patientRelativeDto = new PatientRelativeDto
            {
                Lastname = result.Lastname,
                Name = result.Name,
                Degree = result.Degree,
                Patients = result.PatientPatientRelative,
                PatientRelativeId = result.PatientRelativeId
            };
            return patientRelativeDto;

        }

     
        public async Task<List<PatientRelativeDto>> List(CancellationToken cancellationToken)
        {
            var patientRelative = await _patientDataContext.PatientRelatives.Select(x => new PatientRelativeDto
            {
                Name = x.Name,
                PatientRelativeId = x.PatientRelativeId,
                Lastname = x.Lastname,
                Degree = x.Degree,
                Patients = x.PatientPatientRelative
            }).ToListAsync(cancellationToken);
            return patientRelative;
        }

        public async Task<int> Delete(int id, CancellationToken cancellationToken)
        {
            var result = await _patientDataContext.PatientRelatives.FindAsync(id);
            if (result != null)
            {
                _patientDataContext.Remove(result);
                await _patientDataContext.SaveChangesAsync(cancellationToken);
            }
            return id;
        }


        public async Task<PatientRelativeDto> Update(int id, PatientRelativeDto patientRelativeDto, CancellationToken cancellationToken)
        {
            var result = _patientDataContext.PatientRelatives.FirstOrDefault(x => x.PatientRelativeId == id);
            if (result != null)
            {
                result.Lastname = patientRelativeDto.Lastname;
                result.Name = patientRelativeDto.Name;
                result.Degree = patientRelativeDto.Degree;

                _patientDataContext.PatientRelatives.Update(result);
                await _patientDataContext.SaveChangesAsync(cancellationToken);
            }
            return patientRelativeDto;
        }

    }
}
