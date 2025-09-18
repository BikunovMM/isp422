using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Пользователи
{
    public int Idпользователя { get; set; }

    public int Idроли { get; set; }

    public string Логин { get; set; } = null!;

    public string Пароль { get; set; } = null!;

    public string? АдресЭлектроннойПочты { get; set; }

    public DateOnly ДатаРегистрации { get; set; }

    public virtual Роли IdролиNavigation { get; set; } = null!;

    public virtual ICollection<ИспользованиеФорматов> ИспользованиеФорматовs { get; set; } = new List<ИспользованиеФорматов>();

    public virtual ICollection<ИсторияКонвертаций> ИсторияКонвертацийs { get; set; } = new List<ИсторияКонвертаций>();

    public virtual ICollection<Настройки> Настройкиs { get; set; } = new List<Настройки>();
}
