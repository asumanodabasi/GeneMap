namespace GeneMap.BLL.Data.Entities
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string NationalIdentity { get; set; }
        public string Degree { get; set;}
        public ICollection<Patient> Patients { get; set; } = new List<Patient>();


    }
}
