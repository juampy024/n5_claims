
namespace N5_API.Project.Base.Utiles
{
    public class ValidarTipoMime
    {
        public static bool IsValid(string TipoMime)
        {
            if (string.IsNullOrWhiteSpace(TipoMime))
                return false;

            if (string.IsNullOrEmpty(TipoMime))
                return false;

            try
            {
                bool blnValorRetorno = false;

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
            catch (Exception)
            {
                return false;
            }
        }
    }
}
