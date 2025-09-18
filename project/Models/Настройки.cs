using System;
using System.Collections.Generic;

namespace project.Models;

public partial class Настройки
{
    public int Idнастроек { get; set; }

    public int Idпользователя { get; set; }

    public string Язык { get; set; } = null!;

    public int Уведомления { get; set; }

    public virtual Пользователи IdпользователяNavigation { get; set; } = null!;
}
