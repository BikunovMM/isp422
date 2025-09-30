using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Роли
{
    public int Idроли { get; set; }

    public string Название { get; set; } = null!;

    public virtual ICollection<Пользователи> Пользователиs { get; set; } = new List<Пользователи>();
}
