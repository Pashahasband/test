using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            RegistryKey localMachineKey = Registry.LocalMachine.OpenSubKey("SOFTWARE", true).OpenSubKey("Mozila", true).OpenSubKey("Firefox", true);
            RegistryKey helloKey = localMachineKey.CreateSubKey("HelloKey");
            helloKey.SetValue("URL", "localhost");
            helloKey.Close();

        }
    }
}
