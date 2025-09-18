using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class ДатыВсехКонвертаций
{
    public int Idпользователя { get; set; }

    public DateOnly ДатаКонвертации { get; set; }

    public long? ПорядковыйНомер { get; set; }
}
