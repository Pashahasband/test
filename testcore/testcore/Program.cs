using System;
using Microsoft.Win32;
namespace testcore
{
    class Program
    {
        public static void Main()
        {

            // Create a RegistryKey, which will access the HKEY_LOCAL_MACHINE 
            // key in the registry of this machine. 
            RegistryKey rk = Registry.LocalMachine.OpenSubKey("SOFTWARE", true);
            RegistryKey pk = rk.CreateSubKey("наименование компании");
            RegistryKey helloKey = rk.OpenSubKey("наименование компании", true);
            RegistryKey helloKeyss = helloKey.CreateSubKey("наименование продукта");
            RegistryKey subHelloKey = helloKey.OpenSubKey("наименование продукта", true);

            subHelloKey.SetValue("URL", "localhost");
            subHelloKey.Close();
            helloKeyss.Close();
            helloKey.Close();
            pk.Close();
            
            //RegistryKey rk = Registry.LocalMachine.OpenSubKey("SOFTWARE", true);
            //rk.DeleteSubKey("наименование компании");
            // Print out the keys. 
            PrintKeys(rk);
            Console.ReadLine();
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
