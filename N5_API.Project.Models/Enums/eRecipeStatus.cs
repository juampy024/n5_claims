using System.ComponentModel;

namespace N5_API.Project.Models
{
    public enum eRecipeStatus
    {
        [Description("Pendiente en validación")]
        PendingInValidation = 1,
        [Description("Rechazada")]
        Rejected = 2,
        [Description("Cancelada")]
        Canceled = 3,
        [Description("Pendiente en preparación")]
        PendingInPreparation = 4,
        [Description("Pendiente en entrega")]
        PendingInDelivery = 5,
        [Description("Validado en entrega")]
        ValidatedInDelivery = 6,
        [Description("Entregada")]
        Delivered = 7
    }
}
