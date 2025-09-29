using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class ФорматыФайлов
{
    public int Idформата { get; set; }

    public string Название { get; set; } = null!;

    public virtual ICollection<ИспользованиеФорматов> ИспользованиеФорматовs { get; set; } = new List<ИспользованиеФорматов>();
}
