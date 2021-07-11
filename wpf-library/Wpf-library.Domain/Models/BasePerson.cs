using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_library.Domain.Models
{
    public abstract class BasePerson : BaseEntity
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool isLoggedIn { get; set; }
        public long Balance { get; set; }
        public long Id { get; set; }
    }
}
