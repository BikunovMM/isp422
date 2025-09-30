using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class ПараметрыКонвертации
{
    public long IdпараметраКонвертации { get; set; }

    public string? Значение { get; set; }
}
