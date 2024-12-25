using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneMap.BLL.Data.Entities
{
    public class PatientIlness
    {
        public int IlnessId { get; set; }
        public int PatientId { get; set; }

        [ForeignKey(nameof(PatientId))]
        public Patient Patient { get; set; }

        [ForeignKey(nameof(IlnessId))]
        public Ilness Ilness { get; set; }


    }
}
