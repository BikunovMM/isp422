using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class ПараметрыКонвертации
{
    public long IdпараметраКонвертации { get; set; }

    public string? Значение { get; set; }
}
