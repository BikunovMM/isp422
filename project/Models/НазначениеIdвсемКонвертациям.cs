using System;
using System.Collections.Generic;

namespace project.Models;

public partial class НазначениеIdвсемКонвертациям
{
    public DateOnly ДатаКонвертации { get; set; }

    public int Idпользователя { get; set; }

    public int Idконвертации { get; set; }
}
