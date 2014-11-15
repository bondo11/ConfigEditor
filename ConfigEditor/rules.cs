using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConfigEditor
{
    public class rules
    {
        public int id { get; set; }
        public string Folder { get; set; }
        /*public List<matches> MatchSet { get; set; }*/

        public static bool IsValidPath(string path)
        {
            try
            {
                Regex driveCheck = new Regex(@"^[a-zA-Z]:\\$");
                if (path == null || !driveCheck.IsMatch(path.Substring(0, 3)))
                {
                    return false;
                }
                string strTheseAreInvalidFileNameChars = new string(Path.GetInvalidPathChars());
                strTheseAreInvalidFileNameChars += @":/?*" + "\"";
                Regex containsABadCharacter = new Regex("[" + Regex.Escape(strTheseAreInvalidFileNameChars) + "]");
                if (containsABadCharacter.IsMatch(path.Substring(3, path.Length - 3)))
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
