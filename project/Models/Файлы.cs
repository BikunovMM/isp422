using System;
using System.Collections.Generic;

namespace project.Models;

public partial class Файлы
{
    public int Idфайла { get; set; }

    public string НазваниеФайла { get; set; } = null!;

    public long Idформата { get; set; }

    public virtual ICollection<Конвертации> КонвертацииIdвходногоФайлаNavigations { get; set; } = new List<Конвертации>();

    public virtual ICollection<Конвертации> КонвертацииIdвыходногоФайлаNavigations { get; set; } = new List<Конвертации>();
}
