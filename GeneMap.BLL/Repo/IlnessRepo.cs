using GeneMap.BLL.Data.Dto;
using GeneMap.BLL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneMap.BLL.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GeneMap.BLL.Repo
{
    public class IlnessRepo
    {
        private readonly PatientDataContext _patientDataContext;
        public IlnessRepo(PatientDataContext patientDataContext)
        {
            _patientDataContext = patientDataContext;
        }

        public async Task<IlnessDto> Add(IlnessDto ilnessDto, CancellationToken cancellation)
        {
            var ilness = new Ilness
            {
                IlnessName = ilnessDto.IlnessName,
                DiseaseStage = ilnessDto.DiseaseStage,
            };

            _patientDataContext.Ilnesses.Add(ilness);
            if (await _patientDataContext.SaveChangesAsync(cancellation) > 0)
            {
                return ilnessDto;
            }


            return null;
        }

        public async Task<IlnessDto> Update(int id, IlnessDto ilnessDto, CancellationToken cancellationToken)
        {
            var result = _patientDataContext.Ilnesses.FirstOrDefault(x => x.IlnessId == id);
            if (result != null)
            {
                result.IlnessName = ilnessDto.IlnessName;
                result.DiseaseStage = ilnessDto.DiseaseStage;

                _patientDataContext.Ilnesses.Update(result);
                await _patientDataContext.SaveChangesAsync(cancellationToken);
            }
            return ilnessDto;
        }

        public async Task<IlnessDto> GetById(int id, CancellationToken cancellationToken)
        {
            var result = await _patientDataContext.Ilnesses.FindAsync(id);
            var patientDto = new IlnessDto
            {
                IlnessName = result.IlnessName,
                DiseaseStage = result.DiseaseStage,
            };
            return patientDto;

        }

        public async Task<List<IlnessDto>> List(CancellationToken cancellationToken)
        {
            var patient = await _patientDataContext.Ilnesses.Select(x => new IlnessDto
            {
                IlnessName = x.IlnessName,
                DiseaseStage = x.DiseaseStage,
            }).ToListAsync(cancellationToken);
            return patient;
        }

        public async Task<int> Delete(int id, CancellationToken cancellationToken)
        {
            var result = await _patientDataContext.Ilnesses.FindAsync(id);
            if (result != null)
            {
                _patientDataContext.Remove(result);
                await _patientDataContext.SaveChangesAsync(cancellationToken);
            }
            return id;
        }


    }
}
