namespace project.Contracts.Settings
{
    public class GetSettingsResponse
    {
        public int Idнастроек { get; set; }
        public int Idпользователя { get; set; }
        public string Язык { get; set; } = null!;
        public int Уведомления { get; set; }
    }
}
