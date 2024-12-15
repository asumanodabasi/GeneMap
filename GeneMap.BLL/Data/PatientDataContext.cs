using GeneMap.BLL.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GeneMap.BLL.Data
{
    public class PatientDataContext:DbContext
    {
        public PatientDataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Ilness> Ilnesses { get; set; }
        public DbSet<Diagnosis> Diagnosiss { get; set; }
        public DbSet<PatientRelative> PatientRelatives { get; set; }




    }
}
