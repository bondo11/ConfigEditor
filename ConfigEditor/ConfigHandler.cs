using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigEditor
{
    public static class ConfigHandler
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
                user = ConfigurationManager.AppSettings["password"];
            }
            return password;
        }
        /*
        public static bool IsValidPath(string path)
        {
            try
            {
                Regex driveCheck = new Regex(@"^[a-zA-Z]:\\$");
                if (path == null || !driveCheck.IsMatch(path.Substring(0, 3)))
                {
                    logWriter.Write("Path: " + path + " did not pass the driveCheck");
                    return false;
                }
                string strTheseAreInvalidFileNameChars = new string(Path.GetInvalidPathChars());
                strTheseAreInvalidFileNameChars += @":/?*" + "\"";
                Regex containsABadCharacter = new Regex("[" + Regex.Escape(strTheseAreInvalidFileNameChars) + "]");
                if (containsABadCharacter.IsMatch(path.Substring(3, path.Length - 3)))
                {
                    logWriter.Write("Path: " + path + " contains invalid characters");
                    return false;
                }
            }
            catch (Exception e) {
                logWriter.Write(Environment.NewLine + "error: " + e + Environment.NewLine);
                return false;
            }
            
            return true;
        }*/
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
                ConfigurationManager.AppSettings["user"] = User;
                user = User;
        }
        public static void setPassword(string newPassword)
        {
            ConfigurationManager.AppSettings["password"] = newPassword;
            password = newPassword;
        }

    }
}
