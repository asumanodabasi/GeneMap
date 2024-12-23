using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneMap.BLL.Data.Entities
{
    public class AppUserRole: IdentityUserRole<Guid>
    {
        //public Guid RoleId {  get; set; }   
        //public Guid UserId {  get; set; }
    }
}
