using GeneMap.BLL.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
namespace GeneMap.BLL.Data
{
    public class PatientDataContext : IdentityDbContext<AppUser, AppRole, Guid, IdentityUserClaim<Guid>,
        AppUserRole, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
    {
        public PatientDataContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AppUserRole>().HasKey(x => new { x.RoleId, x.UserId });
            builder.Entity<PatientPatientRelative>().HasKey(x => new { x.PatientId, x.PatientRelativeId });
            builder.Entity<PatientIlness>().HasKey(x => new { x.PatientId, x.IlnessId });
 

            builder.Ignore<IdentityUserLogin<Guid>>();
            builder.Ignore<IdentityUserToken<Guid>>();
            builder.Ignore<IdentityRoleClaim<Guid>>();
        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Ilness> Ilnesses { get; set; }
        public DbSet<Diagnosis> Diagnosiss { get; set; }
        public DbSet<PatientPatientRelative> PatientPatientRelatives { get; set; }
        public DbSet<PatientRelative> PatientRelatives { get; set; }
        public DbSet<PatientIlness> PatientIlnesses { get; set; }




    }
}
