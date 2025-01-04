using System.ComponentModel;

namespace Barbershop.Contracts.Models;

public enum OrderStatusDto
{
    [Description("Создан")]
    Created,

    [Description("Выполнен")]
    Done,

    [Description("Отменен")]
    Canceled
}