using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using N5_API.Project.Base.Helpers.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;

namespace N5_API.Project.Base.Utiles
{
    public class FuncionesUtiles
    {
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        [ServiceFilter(typeof(ActionFilter))]
        public static string Encriptar(string strAEncriptar)
        {
            if (string.IsNullOrEmpty(strAEncriptar)) return string.Empty;

            try
            {
                //Plain Text to be encrypted
                byte[] PlainText = System.Text.Encoding.Unicode.GetBytes(strAEncriptar);

                StringBuilder sb = new StringBuilder();
                sb.Append("RayenSalud");

                StringBuilder _sbSalt = new StringBuilder();
                for (int i = 0; i < 8; i++)
                {
                    _sbSalt.Append("," + sb.Length.ToString());
                }
                byte[] Salt = Encoding.ASCII.GetBytes(_sbSalt.ToString());

                Rfc2898DeriveBytes pwdGen = new Rfc2898DeriveBytes(sb.ToString(), Salt, 10000);
                RijndaelManaged _RijndaelManaged = new RijndaelManaged
                {
                    BlockSize = 128
                };

                byte[] key = pwdGen.GetBytes(_RijndaelManaged.KeySize / 8);
                byte[] iv = pwdGen.GetBytes(_RijndaelManaged.BlockSize / 8);

                _RijndaelManaged.Key = key;
                _RijndaelManaged.IV = iv;

                byte[] cipherText2 = null;
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, _RijndaelManaged.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(PlainText, 0, PlainText.Length);
                    }

                    cipherText2 = ms.ToArray();
                }

                iv = null;
                key = null;
                _RijndaelManaged = null;
                pwdGen = null;
                Salt = null;
                _sbSalt = null;
                sb = null;
                PlainText = null;

                var claveEcnriptada = Convert.ToBase64String(cipherText2);

                return claveEcnriptada;
            }
            catch (Exception ex)
            {
                _ = ex;
                return "Ha ocurrido un error el intentar Encriptar";
            }
        }

        public static string Desencriptar(string strEncriptado)
        {
            if (String.IsNullOrEmpty(strEncriptado)) return string.Empty;

            try
            {
                byte[] cipherText2 = Convert.FromBase64String(strEncriptado);

                StringBuilder sb = new StringBuilder();
                sb.Append("RayenSalud");

                StringBuilder _sbSalt = new StringBuilder();
                for (int i = 0; i < 8; i++)
                {
                    _sbSalt.Append("," + sb.Length.ToString());
                }
                byte[] Salt = Encoding.ASCII.GetBytes(_sbSalt.ToString());

                Rfc2898DeriveBytes pwdGen = new Rfc2898DeriveBytes(sb.ToString(), Salt, 10000);
                RijndaelManaged _RijndaelManaged = new RijndaelManaged
                {
                    BlockSize = 128
                };

                byte[] key = pwdGen.GetBytes(_RijndaelManaged.KeySize / 8);
                byte[] iv = pwdGen.GetBytes(_RijndaelManaged.BlockSize / 8);

                _RijndaelManaged.Key = key;
                _RijndaelManaged.IV = iv;

                byte[] plainText2 = null;
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, _RijndaelManaged.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherText2, 0, cipherText2.Length);
                    }

                    plainText2 = ms.ToArray();
                }

                iv = null;
                key = null;
                _RijndaelManaged = null;
                pwdGen = null;
                Salt = null;
                _sbSalt = null;
                sb = null;
                cipherText2 = null;

                return System.Text.Encoding.Unicode.GetString(plainText2);
            }
            catch (Exception ex)
            {
                _ = ex.Message;
                return "Ha ocurrido un error el intentar Desencriptar";
            }
        }

        public static string GetIPAddress()
        {
            string IP;
            try
            {
                IP = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList.GetValue(5).ToString();
            }
            catch (Exception)
            {

                IP = "127.0.0.1";
            }

            return IP;
        }

        public static string GenerarClaveAlfaNum(int longClave)
        {
            Random random = new Random();
            string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            char letra;
            int longitud = caracteres.Length;
            string claveAleatoria = string.Empty;
            for (int i = 0; i < longClave; i++)
            {
                letra = caracteres[random.Next(longitud)];
                claveAleatoria += letra.ToString();
            }
            return claveAleatoria;
        }

        public static string ReemplazaTagHtml(string body, Dictionary<string, string> tags)
        {
            if (String.IsNullOrEmpty(body) || tags == null) return string.Empty;

            StringBuilder sb = new StringBuilder(body);
            foreach (KeyValuePair<string, string> entry in tags)
            {

                sb.Replace(entry.Key, entry.Value);
            }
            string bodyFormateado = sb.ToString();
            return bodyFormateado;
        }

        public static string FormatearRutBaseDatos(string rut)
        {
            return rut.Replace(".", "").Replace("-", "").PadLeft(10, ' ');
        }

        public static string FormatearRutConGuion(string rut)
        {
            if (rut.Contains("-"))
                rut = rut.Replace("-", "");

            string rutSinDV = rut.Substring(0, rut.Length - 1);
            string rutConDV = rut.Replace(rutSinDV, rutSinDV + "-");

            return rutConDV.Trim();
        }

        public static string ActualizaListaResp(char[] arrListaResp, int intPosicion, string strValor)
        {
            string NuevoValorListaResp = string.Empty;

            for (int x = 0; x <= 23; x++)
            {
                if (x == intPosicion - 1)
                    NuevoValorListaResp += strValor;
                else
                    NuevoValorListaResp += arrListaResp[x];
            }

            return NuevoValorListaResp;
        }

        public static void SaveFileBase64(byte[] Base64File, string FolderPath, string outputImgFilename)
        {
            string strArchivo = Convert.ToBase64String(Base64File);

            if (!System.IO.Directory.Exists(FolderPath))
            {
                System.IO.Directory.CreateDirectory(FolderPath);
            }

            System.IO.File.WriteAllBytes(System.IO.Path.Combine(FolderPath, outputImgFilename), Convert.FromBase64String(strArchivo));
        }

        public static bool ValidaTipoMime(string TipoMime)
        {
            bool blnValorRetorno;

            switch (TipoMime)
            {
                case "audio /aac":
                    {
                        blnValorRetorno = true;
                        break;
                    }
                case "application/x-abiword":
                    {
                        blnValorRetorno = true;
                        break;
                    }
                case "application/octet-stream":
                    {
                        blnValorRetorno = true;
                        break;
                    }
                case "video/x-msvideo":
                    {
                        blnValorRetorno = true;
                        break;
                    }
                case "application/vnd.amazon.ebook":
                    {
                        blnValorRetorno = true;
                        break;
                    }
                case "application/x-bzip":
                    {
                        blnValorRetorno = true;
                        break;
                    }
                case "application/x-bzip2":
                    {
                        blnValorRetorno = true;
                        break;
                    }
                case "application/x-csh":
                    {
                        blnValorRetorno = true;
                        break;
                    }
                case "text/css":
                    {
                        blnValorRetorno = true;
                        break;
                    }
                case "text/csv":
                    {
                        blnValorRetorno = true;
                        break;
                    }
                case "application/msword":
                    {
                        blnValorRetorno = true;
                        break;
                    }
                case "application/epub+zip":
                    {
                        blnValorRetorno = true;
                        break;
                    }
                case "image/gif":
                    {
                        blnValorRetorno = true;
                        break;
                    }
                case "text/html":
                    {
                        blnValorRetorno = true;
                        break;
                    }
                case "image/x-icon":
                    {
                        blnValorRetorno = true;
                        break;
                    }
                case "text/calendar":
                    {
                        blnValorRetorno = true;
                        break;
                    }
                case "application/java-archive":
                    {
                        blnValorRetorno = true;
                        break;
                    }
                case "image/jpeg":
                    {
                        blnValorRetorno = true;
                        break;
                    }
                case "application/javascript":
                    {
                        blnValorRetorno = true;
                        break;
                    }
                case "application/json":
                    {
                        blnValorRetorno = true;
                        break;
                    }
                case "audio/midi":
                    {
                        blnValorRetorno = true;
                        break;
                    }
                case "video/mpeg":
                    {
                        blnValorRetorno = true;
                        break;
                    }
                case "application/vnd.apple.installer+xml":
                    {
                        blnValorRetorno = true;
                        break;
                    }
                case "application/vnd.oasis.opendocument.presentation":
                    {
                        blnValorRetorno = true;
                        break;
                    }
                case "application/vnd.oasis.opendocument.spreadsheet":
                    {
                        blnValorRetorno = true;
                        break;
                    }
                case "application/vnd.oasis.opendocument.text":
                    {
                        blnValorRetorno = true;
                        break;
                    }
                case "audio/ogg":
                    {
                        blnValorRetorno = true;
                        break;
                    }
                case "video/ogg":
                    {
                        blnValorRetorno = true;
                        break;
                    }
                case "application/ogg":
                    {
                        blnValorRetorno = true;
                        break;
                    }
                case "application/pdf":
                    {
                        blnValorRetorno = true;
                        break;
                    }
                case "application/vnd.ms-powerpoint":
                    {
                        blnValorRetorno = true;
                        break;
                    }
                case "application/x-rar-compressed":
                    {
                        blnValorRetorno = true;
                        break;
                    }
                case "application/rtf":
                    {
                        blnValorRetorno = true;
                        break;
                    }
                case "application/x-sh":
                    {
                        blnValorRetorno = true;
                        break;
                    }
                case "image/svg+xml":
                    {
                        blnValorRetorno = true;
                        break;
                    }
                case "application/x-shockwave-flash":
                    {
                        blnValorRetorno = true;
                        break;
                    }
                case "application/x-tar":
                    {
                        blnValorRetorno = true;
                        break;
                    }
                case "image/tiff":
                    {
                        blnValorRetorno = true;
                        break;
                    }
                case "font/ttf":
                    {
                        blnValorRetorno = true;
                        break;
                    }
                case "application/vnd.visio":
                    {
                        blnValorRetorno = true;
                        break;
                    }
                case "audio/x-wav":
                    {
                        blnValorRetorno = true;
                        break;
                    }
                case "audio/webm":
                    {
                        blnValorRetorno = true;
                        break;
                    }
                case "video/webm":
                    {
                        blnValorRetorno = true;
                        break;
                    }
                case "image/webp":
                    {
                        blnValorRetorno = true;
                        break;
                    }
                case "font/woff":
                    {
                        blnValorRetorno = true;
                        break;
                    }
                case "font/woff2":
                    {
                        blnValorRetorno = true;
                        break;
                    }
                case "application/xhtml+xml":
                    {
                        blnValorRetorno = true;
                        break;
                    }
                case "application/vnd.ms-excel":
                    {
                        blnValorRetorno = true;
                        break;
                    }
                case "application/xml":
                    {
                        blnValorRetorno = true;
                        break;
                    }
                case "application/vnd.mozilla.xul+xml":
                    {
                        blnValorRetorno = true;
                        break;
                    }
                case "application / zip":
                    {
                        blnValorRetorno = true;
                        break;
                    }
                case "video/3gpp":
                    {
                        blnValorRetorno = true;
                        break;
                    }
                case "audio/3gpp if it doesn't contain video":
                    {
                        blnValorRetorno = true;
                        break;
                    }
                case "video/3gpp2":
                    {
                        blnValorRetorno = true;
                        break;
                    }
                case "audio/3gpp2 if it doesn't contain video":
                    {
                        blnValorRetorno = true;
                        break;
                    }
                case "application/x-7z-compressed":
                    {
                        blnValorRetorno = true;
                        break;
                    }
                default:
                    {
                        blnValorRetorno = false;
                        break;
                    }
            }

            return blnValorRetorno;
        }

        public static string TruncarCadena(string value, int maxLength)
        {
            return value.Length <= maxLength ? value.Trim() : value.Substring(0, maxLength).Trim();
        }

        public static T QueryStringParser<T>(string queryString)
        {
            //StatusIds=2&StatusIds=5 || StatusIds="[2,5]"
            //var dict = HttpUtility.ParseQueryString(queryString, UTF8Encoding.Default);
            //string json = JsonConvert.SerializeObject(dict.Cast<dynamic>().ToDictionary(k => k, v => dict[v]));
            //var otroalgo = JsonConvert.DeserializeObject<T>(json);






            var filter = QueryHelpers.ParseNullableQuery(queryString);

        

            var json2 = JsonConvert.SerializeObject(filter);
            var algo = JsonConvert.DeserializeObject<T>(json2);

            return JsonConvert.DeserializeObject<T>(json2);



        }

        public static string FormatFullName(string firstGivenName, string nextGivenName, string firstFamilyName, string secondFamilyName)
        {
            StringBuilder sB = new StringBuilder();
            if (firstGivenName?.Length > 0)
                sB.Append(firstGivenName);
            if(nextGivenName?.Length > 0)
                sB.Append(string.Format(" {0}", nextGivenName));
            if (firstFamilyName?.Length > 0)
                sB.Append(string.Format(" {0}", firstFamilyName));
            if (secondFamilyName?.Length > 0)
                sB.Append(string.Format(" {0}", secondFamilyName));
            return sB.ToString();
        }
    }
}
