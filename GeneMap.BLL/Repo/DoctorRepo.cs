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
    public class DoctorRepo
    {

        private readonly PatientDataContext _patientDataContext;

        public DoctorRepo(PatientDataContext patientDataContext)
        {
            _patientDataContext = patientDataContext;
        }
        public async Task<DoctorDto> Add(DoctorDto doctorDto, CancellationToken cancellation)
        {
            var doctor = new Doctor
            {
                Name = doctorDto.Name,
                Lastname = doctorDto.Lastname,
                NationalIdentity = doctorDto.NationalIdentity,
                Degree = doctorDto.Degree
            };

            _patientDataContext.Doctors.Add(doctor);
            if (await _patientDataContext.SaveChangesAsync(cancellation) > 0)
            {
                return doctorDto;
            }


            return null;
        }

        public async Task<DoctorDto> Update(int id, DoctorDto doctorDto, CancellationToken cancellationToken)
        {
            var result = _patientDataContext.Doctors.FirstOrDefault(x => x.DoctorId == id);
            if (result != null)
            {
                result.Lastname = doctorDto.Lastname;
                result.Degree = doctorDto.Degree;
                
                _patientDataContext.Doctors.Update(result);
                await _patientDataContext.SaveChangesAsync(cancellationToken);
            }
            return doctorDto;
        }

        public async Task<DoctorDto> GetById(int id, CancellationToken cancellationToken)
        {
            var result = await _patientDataContext.Doctors.FindAsync(id);
            var doctorDto = new DoctorDto
            {
              Degree=result.Degree,
              Lastname=result.Lastname,
              DoctorId=id,
              Name=result.Name,
              NationalIdentity = result.NationalIdentity
            };
            return doctorDto;

        }

        public async Task<List<DoctorDto>> List(CancellationToken cancellationToken)
        {
            var doctor = await _patientDataContext.Doctors.Select(x => new DoctorDto
            {
                Name = x.Name,
                NationalIdentity = x.NationalIdentity,
                Lastname = x.Lastname,
                Degree = x.Degree,
                DoctorId = x.DoctorId
            }).ToListAsync(cancellationToken);
            return doctor;
        }

        public async Task<int> Delete(int id, CancellationToken cancellationToken)
        {
            var result = await _patientDataContext.Doctors.FindAsync(id);
            if (result != null)
            {
                _patientDataContext.Remove(result);
                await _patientDataContext.SaveChangesAsync(cancellationToken);
            }
            return id;
        }

    }
}
