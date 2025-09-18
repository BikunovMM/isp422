using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Конвертации
{
    public int Idконвертации { get; set; }

    public int IdвходногоФайла { get; set; }

    public int IdвыходногоФайла { get; set; }

    public int IdвходногоФормата { get; set; }

    public int IdвыходногоФормата { get; set; }

    public DateOnly ДатаКонвертации { get; set; }

    public virtual Файлы IdвходногоФайлаNavigation { get; set; } = null!;

    public virtual ФорматыФайлов IdвходногоФорматаNavigation { get; set; } = null!;

    public virtual Файлы IdвыходногоФайлаNavigation { get; set; } = null!;

    public virtual ФорматыФайлов IdвыходногоФорматаNavigation { get; set; } = null!;

    public virtual ICollection<ИсторияКонвертаций> ИсторияКонвертацийs { get; set; } = new List<ИсторияКонвертаций>();
}
