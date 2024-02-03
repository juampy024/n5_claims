using N5_API.Project.Base.Enumeraciones;
using N5_API.Project.Base.Utiles;
using System;


namespace N5_API.Project.Base.DTOs
{
    public class ErrorApi
    {
        public ErrorApi()
        {
            this.Description = string.Empty;
            this.ErrorCode = default(int);
        }

        public ErrorApi(eCodigoErrorAPI errorCode, string description)
        {
            this.Description = description;
            this.ErrorCode = Convert.ToInt32(errorCode);
        }

        public ErrorApi(eCodigoErrorAPI errorCode)
        {
            this.Description = FuncionesUtiles.GetEnumDescription(errorCode); ;
            this.ErrorCode = Convert.ToInt32(errorCode);
        }

        public int ErrorCode { get; set; }

        public string Description { get; set; }
    }
}
