using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections;
using System.Collections.Specialized;

namespace HotelBooking.IO
{
    static class Encryp
    {
        public static void ConfigurationSection(string Section, string Protect = "RsaProtectedConfigurationProvider")
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ConfigurationSection section = config.GetSection(Section);

            if (section != null)
            {
                if (!section.IsReadOnly())
                {
                    if (!section.SectionInformation.IsProtected)
                    {
                        if (!section.ElementInformation.IsLocked)
                        {
                            section.SectionInformation.ProtectSection(Protect);
                            section.SectionInformation.ForceSave = true;
                            config.Save(ConfigurationSaveMode.Full);
                            Console.WriteLine("Section {0} is now protected by {1}",
                                section.SectionInformation.Name.ToString(),
                                section.SectionInformation.ProtectionProvider.Name.ToString());
                        }
                    }
                }
            }
        }
    }
}
