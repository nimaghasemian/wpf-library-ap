using System;
using Wpf_library.Domain.Models;
using Wpf_library.Domain.Services;
using Wpf_library.EntityFramework;
using Wpf_library.EntityFramework.Services;

namespace Wpf_library.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataService<Member> memberService = new GenericDataService<Member>(new WpfLibraryDbContextFactory());
            memberService.Create(new Member()
            { Name = "GULAM",
              Email = "GULAM@GMAIL>COM",
              PhoneNumber = "22242432", 
              isLoggedIn = false,
              MemberShipDate = DateTime.Now,
              Password = "GULAM123"
            }).Wait();


        }
    }
}
