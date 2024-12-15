using GeneMap.BLL.Data.Entities;
using System;
using System.Collections.Generic;
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
        public string IllnessName { get; set; }
        public string Symptoms { get; set; }
        public DateOnly? PatientStartDate { get; set; }
        public DateOnly? PatientEndDate { get; set; }
        public bool DiseaseStatus { get; set; }
        public ICollection<PatientRelative> PatientRelatives { get; set; } = new List<PatientRelative>();
    }
}
