using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneMap.BLL.Data.Dto
{
    public class DiagnosisDto
    {
        public int DiagnosisId { get; set; }
        public int PatientId { get; set; }
        public int IlnessId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateOnly? DiagnosisDate { get; set; }
    }
}
