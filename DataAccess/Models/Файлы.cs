using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Файлы
{
    public int Idфайла { get; set; }

    public string НазваниеФайла { get; set; } = null!;

    public virtual ICollection<Конвертации> КонвертацииIdвходногоФайлаNavigations { get; set; } = new List<Конвертации>();

    public virtual ICollection<Конвертации> КонвертацииIdвыходногоФайлаNavigations { get; set; } = new List<Конвертации>();
}
