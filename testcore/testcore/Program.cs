using System;
using System.Reflection;
using System.Security;
using System.Security.AccessControl;
using Microsoft.Win32;
namespace testcore
{
    class Program
    {
        public static void Main()
        {

            // Create a RegistryKey, which will access the HKEY_LOCAL_MACHINE 
            // key in the registry of this machine. 




            // RegistryKey rk = Registry.LocalMachine.OpenSubKey("SOFTWARE", true);
            // AddKey(rk);
            // DeleteKey(rk);
            //PrintKeys(rk);
            Console.ReadLine();
        }
        static void AddKeyAndRule(RegistryKey rkey)
        {
            RegistryKey pk = rkey.CreateSubKey("наименование компании");
            RegistryKey helloKey = rkey.OpenSubKey("наименование компании", true);
            RegistryKey helloKeyss = helloKey.CreateSubKey("наименование продукта");
            RegistryKey subHelloKey = helloKey.OpenSubKey("наименование продукта", true);
            subHelloKey.SetValue("URL", "localhost");

            string user = Environment.UserDomainName + "\\" + Environment.UserName;
            RegistrySecurity rs = new RegistrySecurity();

            rs.AddAccessRule(new RegistryAccessRule(user,
                RegistryRights.ReadKey,
                InheritanceFlags.None,
                PropagationFlags.None,
                AccessControlType.Allow));
            subHelloKey.SetAccessControl(rs);

            subHelloKey.Close();
            helloKeyss.Close();
            helloKey.Close();
            pk.Close();

        }
        static void DeleteKey(RegistryKey rkey)
        {
            RegistryKey rs = rkey.OpenSubKey("наименование компании", true);
            rs.DeleteSubKey("наименование продукта");
            rkey.DeleteSubKey("наименование компании");
        }
        static void PrintKeys(RegistryKey rkey)
        {

            // Retrieve all the subkeys for the specified key. 
            String[] names = rkey.GetSubKeyNames();

            int icount = 0;

            Console.WriteLine("Subkeys of " + rkey.Name);
            Console.WriteLine("-----------------------------------------------");

            // Print the contents of the array to the console. 
            foreach (String s in names)
            {
                Console.WriteLine(s);

                // The following code puts a limit on the number 
                // of keys displayed.  Comment it out to print the 
                // complete list. 
                icount++;
                if (icount >= 10)
                    break;
            }
        }
    }
}