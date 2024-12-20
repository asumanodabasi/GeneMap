using GeneMap.BLL.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace GeneMap.BLL.Data
{
    public class PatientDataContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public PatientDataContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AppUserRole>().HasKey(x => new { x.RoleId, x.UserId });

            builder.Ignore<IdentityUserLogin<Guid>>();
            builder.Ignore<IdentityUserToken<Guid>>();
            builder.Ignore<IdentityUserClaim<Guid>>();
            builder.Ignore<IdentityRoleClaim<Guid>>();
            builder.Ignore<IdentityUserRole<Guid>>();
        }
        public DbSet<AppUserRole> UserRoles {  get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Ilness> Ilnesses { get; set; }
        public DbSet<Diagnosis> Diagnosiss { get; set; }
        public DbSet<PatientRelative> PatientRelatives { get; set; }

      


    }
}
