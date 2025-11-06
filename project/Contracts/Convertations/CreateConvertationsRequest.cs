namespace project.Contracts.Convertations
{
    public class CreateConvertationsRequest
    {
        public int Idконвертации { get; set; }
        public int IdвходногоФайла { get; set; }
        public int IdвыходногоФайла { get; set; }
        public long? IdпараметровКонвертации { get; set; }
        public DateTime ДатаКонвертации { get; set; }
    }
}
