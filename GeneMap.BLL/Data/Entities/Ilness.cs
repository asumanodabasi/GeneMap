namespace GeneMap.BLL.Data.Entities
{
    public class Ilness
    {
        public int IlnessId { get; set; }
        public string IlnessName { get; set; }
        public int DiseaseStage { get; set; }
        public ICollection<Patient> Patients { get; set; } = new List<Patient>();
    }
}
