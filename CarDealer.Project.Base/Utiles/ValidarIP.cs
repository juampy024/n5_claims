
using System.Text.RegularExpressions;

namespace N5_API.Project.Base.Utiles
{
    public class ValidarIP
    {
        public static bool IsValid(string strIP)
        {
            if (strIP == "::1")
                return true;

            var quads = strIP.Split('.');
            if (!(quads.Length == 4)) 
                return false;
            
            //*****

            if (string.IsNullOrEmpty(quads[0]))
                return false;

            if (!Regex.IsMatch(quads[0], @"^\d+$"))
                return false;

            if (quads[0].Length > 3)
                return false;

            //*****

            if (string.IsNullOrEmpty(quads[1]))
                return false;

            if (!Regex.IsMatch(quads[1], @"^\d+$"))
                return false;

            if (quads[1].Length > 3)
                return false;

            //*****

            if (string.IsNullOrEmpty(quads[2]))
                return false;

            if (!Regex.IsMatch(quads[2], @"^\d+$"))
                return false;

            if (quads[2].Length > 3)
                return false;

            //*******

            if (string.IsNullOrEmpty(quads[3]))
                return false;

            if (!Regex.IsMatch(quads[3], @"^\d+$"))
                return false;

            if (quads[3].Length > 3)
                return false;

            //*****

            char chrFullStop = '.';
            string[] arrOctets = strIP.Split(chrFullStop);
            
            if (arrOctets.Length != 4)
            {
                return false;
            }
            
            Int16 MAXVALUE = 255;
            Int32 temp; // Parse returns Int32
            foreach (String strOctet in arrOctets)
            {
                if (strOctet.Length > 3)
                {
                    return false;
                }

                temp = int.Parse(strOctet);
                if (temp > MAXVALUE)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
