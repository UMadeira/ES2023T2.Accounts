
using Accounts.Data;
using Accounts.Data.Xml;
using Accounts.Store;
using Microsoft.EntityFrameworkCore;

namespace Accounts.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Accounts - v1.0");

            using (var context = new AccountsContext())
            {
                //context.Database.EnsureCreated();

                if (context.Organizations.Count() == 0)
                { 
                    context.Organizations.Add(CreateOrganization() );
                    context.SaveChanges();
                }

                var organization = context.Organizations
                    .Include( e => e.Users )
                    .FirstOrDefault();
                ShowOrganization( organization );
            }

            //var organization = CreateOrganization();
            //organization.Serialize("UMa2.xml");

            //var organization = Serializer.Deserialize("UMa.xml");            
            //ShowOrganization( organization );
        }

        public static Organization CreateOrganization()
        {
            var organization = new Organization() { Name = "UMa" };

            organization.Users.Add(new User { UserName = "maria",  Password = "***" });
            organization.Users.Add(new User { UserName = "manuel", Password = "***" });
            organization.Users.Add(new User { UserName = "rita",   Password = "***" });

            return organization;
        }

        public static void ShowOrganization( Organization organization )
        {
            Console.WriteLine();
            Console.WriteLine($"Organization: {organization.Name}");
            foreach ( var user in organization.Users )
            {
                Console.WriteLine($"\tUser: {user.UserName}");
            }
        }
    }
}