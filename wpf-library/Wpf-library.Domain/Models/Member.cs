using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Wpf_library.Domain.Models
{
    public class Member : BasePerson
    {
        public ICollection<BookTransaction> bookTransactions;
        public DateTime MemberShipDate { get; set; }
        public long Balance { get; set; }
        public DateTime LastPayDate { get; set; }


    }
}
