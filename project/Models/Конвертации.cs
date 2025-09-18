using System;
using System.Collections.Generic;

namespace project.Models;

public partial class Конвертации
{
    public int Idконвертации { get; set; }

    public int IdвходногоФайла { get; set; }

    public int IdвыходногоФайла { get; set; }

    public long? IdпараметровКонвертации { get; set; }

    public DateOnly ДатаКонвертации { get; set; }

    public virtual Файлы IdвходногоФайлаNavigation { get; set; } = null!;

    public virtual Файлы IdвыходногоФайлаNavigation { get; set; } = null!;

    public virtual ICollection<ИсторияКонвертаций> ИсторияКонвертацийs { get; set; } = new List<ИсторияКонвертаций>();
}
