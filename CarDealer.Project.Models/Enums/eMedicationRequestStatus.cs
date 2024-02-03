using System.ComponentModel;

namespace N5_API.Project.Models
{
    public enum eMedicationRequestStatus
    {
        [Description("Pendiente en validación")]
        PendingInValidation = 1,
        [Description("Rechazada en validación")]
        RejectedInValidation = 2,
        [Description("Cancelada")]
        Canceled = 3,
        [Description("Validada")]
        Validated = 4,
        
        [Description("Pendiente en preparación")]
        PendingInPreparation = 5,
        [Description("Rechazada en preparación")]
        RejectedInPreparation = 6,
        [Description("Preparada")]
        Prepared = 7,


        [Description("Pendiente en entrega")]
        PendingInDelivery = 8,
        [Description("Rechazada en entrega")]
        RejectedInDelivery = 9,
        [Description("Validada en entrega")]
        ValidatedInDelivery = 10,
        [Description("Entregada")]
        Delivered = 11
    }
}
