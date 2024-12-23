using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneMap.BLL.Data.Entities
{
    public class PatientPatientRelative
    {
        public int PatientId { get; set; }
        public int PatientRelativeId { get; set; }

        [ForeignKey(nameof(PatientId))]
        public Patient Patient { get; set; }

        [ForeignKey(nameof(PatientRelativeId))]
        public PatientRelative PatientRelative { get; set; }
    }
}
