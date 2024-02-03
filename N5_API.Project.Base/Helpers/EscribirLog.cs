using Microsoft.AspNetCore.Mvc;
using N5_API.Project.Base.DTOs;
using N5_API.Project.Base.Utiles;
using System;

namespace N5_API.Project.Base.Helpers
{
    public class EscribirLog
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public EscribirLog()
        {

        }

        public static void Info(string nombreServicio, string mensaje)
        {
            log.Info(MensajeLog.ObtenerMensajeLog(nombreServicio, mensaje));
        }

        public static void Error(string nombreServicio, string mensaje)
        {
            log.Error(MensajeLog.ObtenerMensajeLog(nombreServicio, mensaje));
        }

        public static void Debug(string nombreServicio, string mensaje)
        {
            log.Debug(MensajeLog.ObtenerMensajeLog(nombreServicio, mensaje));
        }

        public static void Info(ControllerBase objControler, string mensaje)
        {
            log.Info(MensajeLog.ObtenerMensajeLog(objControler, mensaje));
        }
        public static void Error(ControllerBase objControler, string mensaje)
        {
            log.Error(MensajeLog.ObtenerMensajeLog(objControler, mensaje));
        }

        public static void Debug(ControllerBase objControler, string mensaje)
        {
            log.Debug(MensajeLog.ObtenerMensajeLog(objControler, mensaje));
        }
        public static void Info(ControllerBase objControler, string mensaje, object InputEntrada)
        {
            log.Info(MensajeLog.ObtenerMensajeLog(objControler, mensaje, InputEntrada));
        }

        public static void  Error(string nombreServicio, Exception exception)
        {
            log.Error(MensajeLog.ObtenerMensajeExcepcion(nombreServicio, exception));
        }
        
        public static void Error(ControllerBase objControler, string mensaje, object InputEntrada)
        {
            log.Error(MensajeLog.ObtenerMensajeLog(objControler, mensaje, InputEntrada));
        }

        public static void Debug(ControllerBase objControler, string mensaje, object InputEntrada)
        {
            log.Debug(MensajeLog.ObtenerMensajeLog(objControler, mensaje, InputEntrada));
        }

        public static void Info(ControllerBase objControler, ResponseAPI response)
        {
            log.Info(MensajeLog.ObtenerMensajeLog(objControler,response));
        }


        public static void Info(string nombreServicio, string mensaje, ResponseAPI response)
        {
            log.Info(MensajeLog.ObtenerMensajeLog(nombreServicio, mensaje, response));
        }

        public static void Error(string nombreServicio, string mensaje, ResponseAPI response)
        {
            log.Error(MensajeLog.ObtenerMensajeLog(nombreServicio, mensaje, response));
        }

        public static void Error(ControllerBase objControler, ResponseAPI response)
        {
            log.Error(MensajeLog.ObtenerMensajeLog(objControler, response));
        }

        public static void Debug(ControllerBase objControler, ResponseAPI response)
        {
            log.Debug(MensajeLog.ObtenerMensajeLog(objControler, response));
        }
 
    }
}
