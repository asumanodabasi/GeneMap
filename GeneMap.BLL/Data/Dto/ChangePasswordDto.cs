using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneMap.BLL.Data.Dto
{
    public class ChangePasswordDto
    {
        public Guid Id { get; set; }
        public string CurrentPassword { get; set; }
        public string  NewPassword { get; set; }
    }
}
