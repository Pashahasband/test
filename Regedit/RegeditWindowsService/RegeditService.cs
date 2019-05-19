using Regedit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace RegeditWindowsService
{
    public partial class RegeditService : ServiceBase
    {
        public RegeditService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            RegeditHelper.SetRegistryKeyValue("URL", "localhost");
        }

        protected override void OnStop()
        {
        }
    }
}
