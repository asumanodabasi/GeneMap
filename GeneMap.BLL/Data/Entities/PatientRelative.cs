using System.ComponentModel.DataAnnotations.Schema;

namespace GeneMap.BLL.Data.Entities
{
    public class PatientRelative
    {
        public int PatientRelativeId { get; set; }
        public int Degree { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int IllnessId { get; set; }
        [ForeignKey(nameof(IllnessId))]
        public Ilness Ilness { get; set; }
        public ICollection<PatientPatientRelative> PatientPatientRelative { get; set; } = new List<PatientPatientRelative>();
    }
}
