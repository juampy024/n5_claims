using System;

using System.ComponentModel;

namespace N5_API.Project.Base.Enumeraciones
{
    public enum eCodigoStatus
    {
        [Description("OK")]
        OK = 200,

        [Description("Recurso Creado")]
        RECURSO_CREADO = 201,

        [Description("Recurso Actualizado (Aceptado)")]
        RECURSO_ACTUALIZADO = 202,

        [Description("Peticion incorrecta, verifique los valores enviados")]
        SOLICITUD_INCORRECTA = 400,

        [Description("Acceso Prohibido")]
        ACCESO_PROHIBIDO = 401,

        [Description("Recurso No Encontrado")]
        RECURSO_NO_ENCONTRADO = 404,

        [Description("Error al Modificar")]
        ERROR_AL_MODIFICAR = 415,

        [Description("Error en el servidor")]
        ERROR_EN_EL_SERVIDOR = 500
    }
}
