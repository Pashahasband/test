using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace RegeditWindowsService
{
    [RunInstaller(true)]
    public partial class InstallerRegeditService : System.Configuration.Install.Installer
    {
        ServiceInstaller serviceInstaller;
        ServiceProcessInstaller processInstaller;
        public InstallerRegeditService()
        {
            InitializeComponent();
            serviceInstaller = new ServiceInstaller();
            processInstaller = new ServiceProcessInstaller();

            processInstaller.Account = ServiceAccount.LocalSystem;
            serviceInstaller.StartType = ServiceStartMode.Automatic;
            serviceInstaller.DisplayName = "RegistrEditService";
            serviceInstaller.ServiceName = "RegeditService";
            Installers.Add(processInstaller);
            Installers.Add(serviceInstaller);
        }
    }
}
