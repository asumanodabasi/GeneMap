using GeneMap.BLL.Data.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneMap.BLL.Data.Dto
{
    public class PatientDto
    {
        public int PatientId { get; set; }
        public int NationalIdentity { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Complaints { get; set; }
        public int IllnessId { get; set; }
        public ICollection<Ilness> Ilness { get; set; }
        public string Symptoms { get; set; }
        public DateOnly? PatientStartDate { get; set; }
        public DateOnly? PatientEndDate { get; set; }
        public bool DiseaseStatus { get; set; }
        public ICollection<PatientPatientRelative> PatientRelative { get; set; } = new List<PatientPatientRelative>();
    }
}
