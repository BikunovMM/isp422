namespace project.Contracts.Convertations
{
    public class GetConvertationsResponse
    {
        public int Idконвертации { get; set; }
        public int IdвходногоФайла { get; set; }
        public int IdвыходногоФайла { get; set; }
        public long? IdпараметровКонвертации { get; set; }
        public DateOnly ДатаКонвертации { get; set; }
    }
}
