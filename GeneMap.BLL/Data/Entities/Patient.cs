using System.ComponentModel.DataAnnotations.Schema;

namespace GeneMap.BLL.Data.Entities
{
    public class Patient
    {
        public int PatientId { get; set; }
        public int NationalIdentity { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string IllnessName { get; set; }
        public string Symptoms { get; set; }
        public DateOnly? PatientStartDate { get; set; }
        public DateOnly? PatientEndDate { get; set; }
        public bool DiseaseStatus { get; set; }
        public ICollection<Doctor> Doctors { get; set; }=new List<Doctor>();
        public ICollection<PatientRelative> PatientRelatives { get; set; }=new List<PatientRelative>();
    }
}