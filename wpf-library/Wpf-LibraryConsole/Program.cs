using System;
using Wpf_library.Domain.Models;
using Wpf_library.Domain.Services;
using Wpf_library.EntityFramework;
using Wpf_library.EntityFramework.Services;

namespace Wpf_library.ConsoleTest
{
    class Program
    {
        static  void Main(string[] args)
        {
            UserDataService<Manager> memberService = new UserDataService<Manager>(new WpfLibraryDbContextFactory());
                
       

        }
    }
}
