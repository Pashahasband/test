using System;

namespace Regedit
{
    class Program
    {
        static void Main(string[] args)
        {
            RegeditHelper.SetRegistryKeyValue("URL", "localhost");

            Console.ReadLine();
        }
    }
}
