using GeneMap.BLL.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneMap.BLL.Data.Dto
{
    public class PatientRelativeDto
    {
        public int PatientRelativeId { get; set; }
        public int Degree { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int IllnessId { get; set; }
        public Ilness Ilness { get; set; }
        public ICollection<PatientPatientRelative> Patients { get; set; } = new List<PatientPatientRelative>();
    }
}
