namespace GeneMap.BLL.Data.Entities
{
    public class PatientRelative
    {
        public int PatientRelativeId { get; set; }
        public int Degree { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public ICollection<Patient> Patients { get; set; } = new List<Patient>();
    }
}
