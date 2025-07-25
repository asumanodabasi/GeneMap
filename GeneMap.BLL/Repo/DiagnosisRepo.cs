﻿using GeneMap.BLL.Data;
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
    public class DiagnosisRepo
    {
        private readonly PatientDataContext _patientDataContext;
        public DiagnosisRepo(PatientDataContext patientDataContext)
        {
            _patientDataContext = patientDataContext;
        }
        public async Task<DiagnosisDto> Add(DiagnosisDto diagnosisDto, CancellationToken cancellation)
        {
            var diagnosis = new Diagnosis
            {
                Name = diagnosisDto.Name,
                Description = diagnosisDto.Description,
                DiagnosisDate = diagnosisDto.DiagnosisDate,
                PatientId = diagnosisDto.PatientId,
                IlnessId = diagnosisDto.IlnessId,
            };
            
            _patientDataContext.Diagnosiss.Add(diagnosis);
            var info = new PatientIlness
            {
                IlnessId = diagnosisDto.IlnessId,
                PatientId = diagnosisDto.PatientId,
            };
            _patientDataContext.PatientIlnesses.Add(info);
            if (await _patientDataContext.SaveChangesAsync(cancellation) > 0)
            {
                return diagnosisDto;
            }


            return null;
        }

        public async Task<DiagnosisDto> Update(int id, DiagnosisDto diagnosisDto, CancellationToken cancellationToken)
        {
            var result = _patientDataContext.Diagnosiss.FirstOrDefault(x => x.DiagnosisId == id);
            if (result != null)
            {
             
                result.DiagnosisId = id;
                result.IlnessId = diagnosisDto.IlnessId;
                result.Name = diagnosisDto.Name;

                _patientDataContext.Diagnosiss.Update(result);
                await _patientDataContext.SaveChangesAsync(cancellationToken);
            }
            return diagnosisDto;
        }

        public async Task<DiagnosisDto> GetById(int id, CancellationToken cancellationToken)
        {
            var result = await _patientDataContext.Diagnosiss.FindAsync(id);
            var diagnosisDto = new DiagnosisDto
            {
                DiagnosisId = id,
                Name = result.Name,
               IlnessId = result.IlnessId,
                DiagnosisDate = result.DiagnosisDate,
                PatientId = result.PatientId,
                Description = result.Description
            };
            return diagnosisDto;

        }

        public async Task<List<DiagnosisDto>> List(CancellationToken cancellationToken)
        {
            var diagno = await _patientDataContext.Diagnosiss.Select(x => new DiagnosisDto
            {
                Name = x.Name,
                Description = x.Description,
                DiagnosisDate = x.DiagnosisDate,
                PatientId = x.PatientId,
                IlnessId= x.IlnessId,
                DiagnosisId = x.DiagnosisId
             
            }).ToListAsync(cancellationToken);
            return diagno;
        }

        public async Task<int> Delete(int id, CancellationToken cancellationToken)
        {
            var result = await _patientDataContext.Diagnosiss.FindAsync(id);
            if (result != null)
            {
                _patientDataContext.Remove(result);
                await _patientDataContext.SaveChangesAsync(cancellationToken);
            }
            return id;
        }

        

    }
}
