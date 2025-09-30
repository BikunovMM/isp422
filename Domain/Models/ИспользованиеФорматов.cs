using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class ИспользованиеФорматов
{
    public int IdиспользованияФорматов { get; set; }

    public int Idпользователя { get; set; }

    public int Idформата { get; set; }

    public int КоличествоИспользований { get; set; }

    public virtual Пользователи IdпользователяNavigation { get; set; } = null!;

    public virtual ФорматыФайлов IdформатаNavigation { get; set; } = null!;
}
