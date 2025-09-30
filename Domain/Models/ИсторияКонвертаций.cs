using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class ИсторияКонвертаций
{
    public int IdисторииКонвертаций { get; set; }

    public int Idпользователя { get; set; }

    public int Idконвертации { get; set; }

    public int? IdпараметровКонвертации { get; set; }

    public virtual Конвертации IdконвертацииNavigation { get; set; } = null!;

    public virtual Пользователи IdпользователяNavigation { get; set; } = null!;
}
