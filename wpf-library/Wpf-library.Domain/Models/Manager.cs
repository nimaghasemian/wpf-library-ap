using System;
using System.Collections.Generic;
using System.Text;

namespace Wpf_library.Domain.Models
{
    public class Manager:BasePerson
    {
        public long LibBalance { get { return LibBalance; } set { LibBalance = base.Balance; } }
    }
}
