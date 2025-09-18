using System;
using System.Collections.Generic;

namespace project.Models;

public partial class ДатыВсехКонвертаций
{
    public int Idпользователя { get; set; }

    public DateOnly ДатаКонвертации { get; set; }

    public long? ПорядковыйНомер { get; set; }
}
