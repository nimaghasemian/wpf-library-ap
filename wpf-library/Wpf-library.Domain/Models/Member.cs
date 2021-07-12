using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Wpf_library.Domain.Models
{
    public class Member : BasePerson
    {
        public DateTime MemberShipDate { get; set; }
        public DateTime LastPayDate { get; set; }


    }
}
