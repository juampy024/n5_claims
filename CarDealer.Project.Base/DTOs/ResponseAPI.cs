

using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using N5_API.Project.Base.Enumeraciones;
using N5_API.Project.Base.Helpers;
using N5_API.Project.Base.Utiles;
using System;
using System.Collections.Generic;


namespace N5_API.Project.Base.DTOs
{
    public class ResponseAPI
    {


        public ResponseAPI(eCodigoStatus status, Object data)
        {
            this.Status = Convert.ToInt32(status);
            this.Description = FuncionesUtiles.GetEnumDescription(status);
            this.Data = data;
          
            this.Error = null;
        }

        public ResponseAPI(eCodigoStatus status, string nombreServicio, ModelStateDictionary modelState)
        {
            this.Status = Convert.ToInt32(status);
            this.Description = FuncionesUtiles.GetEnumDescription(status);
            this.Data = null;
            this.Error = new List<ErrorApi>();
            EscribirLog.Info(nombreServicio, "InvalidModelStateResponseFactory"); 
            foreach (var keyModelStatePair in modelState)
            {
                var key = keyModelStatePair.Key;
                var errors = keyModelStatePair.Value.Errors;
                if (errors != null && errors.Count > 0)
                {
                    if (errors.Count == 1)
                    {
                        var errorMessage = GetErrorMessage(errors[0]);
                        this.Error.Add(new ErrorApi(eCodigoErrorAPI.VALIDACION_DATO,  errorMessage));
                        EscribirLog.Info(nombreServicio, errorMessage); 
                    }
                    else
                    {
                        var errorMessages = new string[errors.Count];
                        for (var i = 0; i < errors.Count; i++)
                        {
                            errorMessages[i] = GetErrorMessage(errors[i]);
                            this.Error.Add(new ErrorApi(eCodigoErrorAPI.VALIDACION_DATO, errorMessages[i]));
                            EscribirLog.Info(nombreServicio, errorMessages[i]);
                        }
                        
                    }
                }
            }
        }


        

        public ResponseAPI(eCodigoStatus status, int id, Object data)
        {
            this.Status = Convert.ToInt32(status);
            this.Description = FuncionesUtiles.GetEnumDescription(status);
            this.Data = data;
            this.ID = id;
 
            this.Error = null;
        }

        public ResponseAPI(eCodigoStatus status)
        {
            this.Status = Convert.ToInt32(status);
            this.Description = FuncionesUtiles.GetEnumDescription(status);
 
            this.Data = null;
            Error = new List<ErrorApi>();
            eCodigoErrorAPI codErrorApi = eCodigoErrorAPI.OPERACION_OK;

            switch (status)
            {
                case eCodigoStatus.OK:
                case eCodigoStatus.RECURSO_CREADO:
                    codErrorApi = eCodigoErrorAPI.OPERACION_OK;
                    break;
                case eCodigoStatus.SOLICITUD_INCORRECTA:
                    codErrorApi = eCodigoErrorAPI.VALIDACION_DATO;
                    break;
                case eCodigoStatus.ACCESO_PROHIBIDO:
                    codErrorApi = eCodigoErrorAPI.OPERACION_NO_PERMITIDA;
                    break;
                case eCodigoStatus.RECURSO_NO_ENCONTRADO:
                    codErrorApi = eCodigoErrorAPI.RECURSO_NO_ENCONTRADO;
                    break;
                case eCodigoStatus.ERROR_AL_MODIFICAR:
                    codErrorApi = eCodigoErrorAPI.ERROR_AL_ACTUALIZAR;
                    break;
                case eCodigoStatus.ERROR_EN_EL_SERVIDOR:
                default:
                    codErrorApi = eCodigoErrorAPI.EXCEPCION_NO_CONTROLADA;
                    break;
            }
           ;
            Error.Add(new ErrorApi(codErrorApi, FuncionesUtiles.GetEnumDescription(codErrorApi)));
        }

        public ResponseAPI(eCodigoStatus status, List<ErrorApi> errors)
        {
            this.Status = Convert.ToInt32(status);
            this.Description = FuncionesUtiles.GetEnumDescription(status);
 
            this.Data = null;
            this.Error = errors;
        }

 
        public int Status { get; }
        public string Description { get; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]

        
        public int? ID { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Object Data { get; }



        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<ErrorApi> Error { get; }


        string GetErrorMessage(ModelError error)
        {
            return string.IsNullOrEmpty(error.ErrorMessage) ?"The input was not valid." :error.ErrorMessage;
        }

    }
}
