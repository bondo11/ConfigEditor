using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConfigEditor
{
    public static class ConfigSettings
    {
        private static string source, user, password;
        private static int port;

        public static string getSource()
        {
            if (source == null)
            {
                source = ConfigurationManager.AppSettings["source"];
            }
            return source;
        }
        public static int getPort()
        {
            if (port == 0)
            {
                try
                {
                    port = int.Parse(ConfigurationManager.AppSettings["port"]);
                }
                catch (Exception)
                {
                    return 0;
                }
            }
            return port;
        }
        public static string getUser()
        {
            if (user == null)
            {
                user = ConfigurationManager.AppSettings["user"];
            }
            return user;
        }
        public static string getPassword()
        {
            if (password == null)
            {

                PasswordEncoder pe = new PasswordEncoder();
                password = pe.DecryptWithByteArray();
            }
            return password;
        }

        public static bool IsValidPath(string path)
        {
            try
            {
                Regex driveCheck = new Regex(@"^[a-zA-Z]:\\$");
                if (path == null || !driveCheck.IsMatch(path.Substring(0, 3)))
                {
                    //logWriter.Write("Path: " + path + " did not pass the driveCheck");
                    return false;
                }
                string strTheseAreInvalidFileNameChars = new string(Path.GetInvalidPathChars());
                strTheseAreInvalidFileNameChars += @":/?*" + "\"";
                Regex containsABadCharacter = new Regex("[" + Regex.Escape(strTheseAreInvalidFileNameChars) + "]");
                if (containsABadCharacter.IsMatch(path.Substring(3, path.Length - 3)))
                {
                    //logWriter.Write("Path: " + path + " contains invalid characters");
                    return false;
                }
            }
            catch (Exception)
            {
                //logWriter.Write(Environment.NewLine + "error: " + e + Environment.NewLine);
                return false;
            }

            return true;
        }
        public static void setSource(string path)
        {
            ConfigurationManager.AppSettings["source"] = path;
            source = path;
        }
        public static void setPort(int Port)
        {
            ConfigurationManager.AppSettings["port"] = Port.ToString();
            port = Port;
        }
        public static void setUser(string User)
        {
            PasswordEncoder pe = new PasswordEncoder();
            ConfigurationManager.AppSettings["user"] = User;
            user = User;
        }
        public static void setPassword(string newPassword)
        {
            PasswordEncoder pe = new PasswordEncoder();
            ConfigurationManager.AppSettings["password"] = pe.EncryptWithByteArray(newPassword);
            password = newPassword;
        }
        public static void newConfig()
        {
            System.Text.StringBuilder sb = new StringBuilder();
            sb.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
            sb.AppendLine("<startup>");
            sb.AppendLine("<supportedRuntime version=\"v4.0\" sku=\".NETFramework,Version=v4.5\" />");
            sb.AppendLine("</startup>");
            sb.AppendLine("<configuration>");
            sb.AppendLine("<add key=\"source\" value=\"\" />");
            sb.AppendLine("<add key=\"ClientSettingsProvider.ServiceUri\" value=\"\" />");
            sb.AppendLine("</configuration>");

            string loc = System.Reflection.Assembly.GetEntryAssembly().Location;
            System.IO.File.WriteAllText(String.Concat(loc, ".config"), sb.ToString());
        }

    }
}
