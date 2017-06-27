using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Configuration.Install;
using System.Linq;
using System.Threading.Tasks;

namespace CapaVisual
{
    [RunInstaller(true)]
    public partial class Instalador : System.Configuration.Install.Installer
    {
        public Instalador()
        {
            InitializeComponent();
        }

        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);
            try
            {
                string DBNAMEINPUT = Context.Parameters["DBNAMEPARAM"];
                string DBUSRINPUT = Context.Parameters["DBUSRPARAM"];
                string DBPWDINPUT = Context.Parameters["DBPWDPARAM"];

                string conStr = "server=127.0.0.1;port=3306" +
                                "; database=" + DBNAMEINPUT +
                                "; uid=" + DBUSRINPUT +
                                "; password=" + DBPWDINPUT;

                string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
                Configuration config = ConfigurationManager.OpenExeConfiguration(path);
                config.ConnectionStrings.ConnectionStrings[1].ConnectionString = conStr;
                config.Save();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public override void Commit(IDictionary savedState)
        {
            base.Commit(savedState);
        }

        public override void Rollback(IDictionary savedState)
        {
            base.Rollback(savedState);
        }

        public override void Uninstall(IDictionary savedState)
        {
            base.Uninstall(savedState);
        }
    }
}
