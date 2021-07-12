using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_library.Domain.Models
{
   public class BookTransaction:BaseEntity
    {
        public long Id { get; set; }
        [ForeignKey("Book")]
        public long BookID { get; set; }
        public Book RentedBook { get; set; }
        [ForeignKey("Member")]
        public long MemberId { get; set; }
        public Member RentingMember { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool RetrunStatus { get; set; }// is the transaction finished?
        

    }
}
