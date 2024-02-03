using System;

using System.ComponentModel;


namespace N5_API.Project.Base.Enumeraciones
{
    public enum eCodigoErrorAPI
    {
        [Description("Operación OK")]
        OPERACION_OK = 0,

        [Description("No se puede realizar operacion ya que el recurso no existe")]
        RECURSO_NO_ENCONTRADO = 1,

        [Description("Error en los parametros solicitados, verifique el request")]
        CAMPO_SOLICITADO_NO_EXISTE = 2,

        [Description("Datos enviados no cumplen con las validaciones, verifique el request")]
        VALIDACION_DATO = 3,

        [Description("No se puede realizar operación, ya que un valor enviado no existe en BD")]
        INTEGRIDAD_DATOS = 4,

        [Description("Error en el servidor")]
        EXCEPCION_NO_CONTROLADA = 5,

        [Description("No es posible realizar la acción")]
        OPERACION_NO_PERMITIDA = 6,

        [Description("Error al actualizar")]
        ERROR_AL_ACTUALIZAR = 7

    }
}
