using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Configuration;
using System.Reflection;
using System.IO;
using System.DirectoryServices.ActiveDirectory;
using System.DirectoryServices.AccountManagement;
using System.Security.Principal;

namespace HotelBooking
{
    static class Program
    {
        public static int Read_Config_mode = 1;
        public static bool IsAdministrator = IsAdministratorNoCache(WindowsIdentity.GetCurrent().Name);

        [DllImport("kernel32", SetLastError = true)]
        static extern bool AllocConsole();

        /// <summary>
        /// 將調用進程附加到指定進程的控制台。
        /// </summary>
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool AttachConsole(int dwProcessId);
        const int ATTACH_PARENT_PROCESS = -1;

        
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            IO.Encryp.ConfigurationSection("appSettings", "DbConn_Provider");
            IO.Encryp.ConfigurationSection("DbConnSettings", "DbConn_Provider");
            IO.Encryp.ConfigurationSection("DatabaseGroup/Connections", "DbConn_Provider");
            IO.Encryp.ConfigurationSection("DatabaseGroup/others", "DbConn_Provider");
            IO.Encryp.ConfigurationSection("DbSettings", "DbConn_Provider");

            if (args.Count<string>() > 0)
                Read_Config_mode = Convert.ToInt16(args[0]);

            if (!AttachConsole(ATTACH_PARENT_PROCESS)) //配置新控制台
                AllocConsole();

            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new HotelLogin());
        }

        private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            string resourceName = Assembly.GetExecutingAssembly().GetName().Name + "." + new AssemblyName(args.Name).Name + ".dll";
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                
                byte[] assemblyData = new byte[stream.Length];
                stream.Read(assemblyData, 0, assemblyData.Length);
                stream.Close();
                return Assembly.Load(assemblyData);
            }
        }

        private static bool IsAdministratorNoCache(string username)
        {
            PrincipalContext ctx;
            try
            {
                Domain.GetComputerDomain();
                try
                {
                    ctx = new PrincipalContext(ContextType.Domain);
                }
                catch (PrincipalServerDownException)
                {
                    // can't access domain, check local machine instead 
                    ctx = new PrincipalContext(ContextType.Machine);
                }
            }
            catch (ActiveDirectoryObjectNotFoundException)
            {
                // not in a domain
                ctx = new PrincipalContext(ContextType.Machine);
            }
            var up = UserPrincipal.FindByIdentity(ctx, username);
            if (up != null)
            {
                PrincipalSearchResult<Principal> authGroups = up.GetAuthorizationGroups();
                return authGroups.Any(principal =>
                                      principal.Sid.IsWellKnown(WellKnownSidType.BuiltinAdministratorsSid) ||
                                      principal.Sid.IsWellKnown(WellKnownSidType.AccountDomainAdminsSid) ||
                                      principal.Sid.IsWellKnown(WellKnownSidType.AccountAdministratorSid) ||
                                      principal.Sid.IsWellKnown(WellKnownSidType.AccountEnterpriseAdminsSid));
            }
            return false;
        }
    }
}
