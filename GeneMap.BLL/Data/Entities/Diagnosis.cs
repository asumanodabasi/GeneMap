using System.ComponentModel.DataAnnotations.Schema;

namespace GeneMap.BLL.Data.Entities
{
    public class Diagnosis
    {
        public int DiagnosisId { get; set; }
        public int PatientId { get; set; }
        public int IlnessId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateOnly? DiagnosisDate { get; set; }

        [ForeignKey(nameof(IlnessId))]
        public Ilness Ilness { get; set; }

        [ForeignKey(nameof(PatientId))]
        public Patient Patient { get; set; }
    }
}
