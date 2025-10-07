namespace project.Contracts.User
{
    public class CreateUserRequest
    {
        public int IDПользователя { get; set; }
        public int IDРоли { get; set; }
        public string Логин { get; set; } = null!;
        public string Пароль { get; set; } = null!;
        public string АдресЭлектроннойПочты { get; set; } = null!;
        public DateTime ДатаРождения { get; set; }
    }
}
