using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using N5_API.Project.Base.DTOs;

namespace N5_API.Project.Base.Utiles
{
    public class MensajeLog
    {


        public static string ObtenerMensajeLog(string nombreServicio, string mensaje)
        {
            string fechaISO8601 = DateTime.Now.ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz");         
            return "[" + fechaISO8601 + "]" + "[" + nombreServicio + "]" + mensaje;
        }

        public static string ObtenerMensajeLog(ControllerBase objControler, string mensaje)
        {
            string fechaISO8601 = DateTime.Now.ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz");
            string nombreServicio = objControler.HttpContext.Request.Path;           
            return "[" + fechaISO8601 + "]" + "[" + nombreServicio + "]" + mensaje;                      
        }
        public static string ObtenerMensajeLog(ControllerBase objControler, string mensaje, object InputEntrada)
        {
            string fechaISO8601 = DateTime.Now.ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz");
            string nombreServicio = objControler.HttpContext.Request.Path;
            string parametroEntrada = JsonSerializer.Serialize(InputEntrada);
            return "[" + fechaISO8601 + "]" + "[" + nombreServicio + "]" + "[" + mensaje + "][" + parametroEntrada + "]";
        }

        public static string ObtenerMensajeLog(ControllerBase objControler, ResponseAPI response)
        {
            string fechaISO8601 = DateTime.Now.ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz");
            string nombreServicio = objControler.HttpContext.Request.Path;           

            string mensaje = "Response -> Status:" + response.Status + " Description:" + response.Description;
            if (response.ID != null && response.ID != default(int))
                mensaje += " ID:" + response.ID;

            if(response.Data!=null)
                mensaje+="\n Response=" + JsonSerializer.Serialize(response.Data);

            if (response.Error != null)
            {
                foreach (ErrorApi errorApi in response.Error)
                    mensaje += "\nCode:" + errorApi.ErrorCode + " Description" + errorApi.Description;
            }
            return "[" + fechaISO8601 + "]" + "[" + nombreServicio + "]" + mensaje;
        }


        public static string ObtenerMensajeExcepcion(string nombreServicio,  Exception ex)
        {

            string mensajeError ="Error message: " + ex.Message;
            if (ex.InnerException != null)
            {
                mensajeError +=  "\n" + " Inner exception: " + ex.InnerException.Message;
            }
            mensajeError += "\n" + " Stack trace: " + ex.StackTrace;           
            string fechaISO8601 = DateTime.Now.ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz");            
            return "[" + fechaISO8601 + "]" + "[" + nombreServicio + "]" + mensajeError;
        }

        public static string ObtenerMensajeLog(string nombreServicio, string mensaje, ResponseAPI response)
        {
           
            string fechaISO8601 = DateTime.Now.ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz");
           

            mensaje += "Response -> Status:" + response.Status + " Description:" + response.Description;
            if (response.ID != null && response.ID != default(int))
                mensaje += " ID:" + response.ID;

            if (response.Data != null)
                mensaje += "\n Response=" + JsonSerializer.Serialize(response.Data);

            if (response.Error != null)
            {
                foreach (ErrorApi errorApi in response.Error)
                    mensaje += "\nCode:" + errorApi.ErrorCode + " Description" + errorApi.Description;
            }
            return "[" + fechaISO8601 + "]" + "[" + nombreServicio + "]" + mensaje;
        }       

    }

}
