using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Permissions;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;

namespace FixMyDNS
{
    class FixMyDNS
    {
        public static void Main(string[] args)
        {
            /**
             * FixMyDNS needs administrator privileges.
             * If the program wasn't launched with admin privileges,
             * restart it asking for admin permissions.
             */
            WindowsPrincipal pricipal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            bool hasAdministrativeRight = pricipal.IsInRole(WindowsBuiltInRole.Administrator);
            if (!hasAdministrativeRight)
            {
                // relaunch the application with admin rights
                string fileName = Assembly.GetExecutingAssembly().Location;
                ProcessStartInfo processInfo = new ProcessStartInfo();
                processInfo.Verb = "runas";
                processInfo.FileName = fileName;

                try
                {
                    Process.Start(processInfo);
                }
                catch (Win32Exception)
                {
                    MessageBox.Show("FixMyDNS needs to run with administrator privileges to change the DNS server.\nPlease restart FixMyDNS and approve the request for admin privileges!", "FixMyDNS",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }

            /**
             * For each network interface #0..#25 try to set the DNS server to 1.1.1.1
             */
            for (int i = 0; i < 25; i++)
            {
                Process cmd = new Process();
                cmd.StartInfo.FileName = "netsh.exe";
                cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                cmd.StartInfo.Arguments = "interface ip set dns " + i + " static 1.1.1.1 both";
                cmd.Start();
            }

            /**
             * Show confirmation message
             */
            MessageBox.Show("Your DNS servers have been set to CloudFlare DNS (1.1.1.1)", "FixMyDNS", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
