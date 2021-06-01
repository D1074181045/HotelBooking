using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections;
using System.Collections.Specialized;
using System.Reflection;
using System.IO;
using System.Runtime.Remoting.Channels;

namespace HotelBooking.IO
{
    static class Read_Config_Mode
    {
        private static string MyCallName;
        private static string Key = "", Value = "";

        private static void DisplayOriginal_ConfigurationSection(string s)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ConfigurationSection section = config.GetSection(s);
            Console.WriteLine(Environment.NewLine + string.Format("[INFO] {0} Configuration FilePath is {1}", MyCallName, config.FilePath));
            Console.WriteLine(string.Format("[DEBUG] {0} section is {1}", MyCallName, config.Sections));
            Console.WriteLine(string.Format("[DEBUG] {0} matching pattern is .*key=\"{1}\".*value=\"(.*)\"*, value={2}", MyCallName, Key, Value));
            Console.WriteLine(string.Format("[DEBUG] -----------------: matched configuration xml is {0}", section.SectionInformation.GetRawXml()));
        }

        public static string GetConfigurationValue(string key)
        {
            MyCallName = "GetConfigurationValue(" + key + ")";
            Key = key;
            Value = ConfigurationManager.AppSettings[key];

            DisplayOriginal_ConfigurationSection("appSettings");
            return Value;
        }

        public static string GetConfigurationUsingSection(string key)
        {
            NameValueCollection Encrypting = ConfigurationManager.GetSection("DbConnEncrypting") as NameValueCollection;

            MyCallName = "GetConfigurationUsingSection(" + key + ")";
            Key = key;
            Value = Encrypting[key];

            DisplayOriginal_ConfigurationSection("DbConnEncrypting");
            return Value;
        }

        public static string GetConfigurationUsingSectionGroup(string key)
        {
            NameValueCollection PostSetting = ConfigurationManager.GetSection("DatabaseGroup/Connections") as NameValueCollection;

            MyCallName = "GetConfigurationUsingSectionGroup(" + key + ")";
            Key = key;
            Value = PostSetting[key];

            DisplayOriginal_ConfigurationSection("DatabaseGroup/Connections");
            return Value;
        }

        public static string GetConfigurationUsingCustomClass(string key)
        {
            DbSettings DbSetting = ConfigurationManager.GetSection("DbSettings") as DbSettings;
            Dictionary<string, string> DbConnections = new Dictionary<string, string>() { { "PlainUser", DbSetting.DbConnections.PlainUser }, { "PlainPswd", DbSetting.DbConnections .PlainPswd} };

            MyCallName = "GetConfigurationUsingCustomClass(" + key + ")";
            Key = key;
            Value = DbConnections[key];

            DisplayOriginal_ConfigurationSection("DbSettings");
            return Value;
        }
    }

    public class DbConnections : ConfigurationElement
    {
        [ConfigurationProperty("PlainUser", DefaultValue = "", IsRequired = true)]
        public string PlainUser
        {
            get { return (string)this["PlainUser"]; }
            set { this["PlainUser"] = value; }
        }

        [ConfigurationProperty("PlainPswd", DefaultValue = "", IsRequired = true)]
        public string PlainPswd
        {
            get { return (string)this["PlainPswd"]; }
            set { this["PlainPswd"] = value; }
        }
    }

    public class DbSettings : ConfigurationSection
    {
        [ConfigurationProperty("DbConnections")]
        public DbConnections DbConnections
        {
            get { return (DbConnections)this["DbConnections"]; }
            set { this["DbConnections"] = value; }
        }
    }
}
