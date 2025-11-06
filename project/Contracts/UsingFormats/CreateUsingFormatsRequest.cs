namespace project.Contracts.UsingFormats
{
    public class CreateUsingFormatsRequest
    {
        public int IdиспользованияФорматов { get; set; }
        public int Idпользователя { get; set; }
        public int Idформата { get; set; }
        public int КоличествоИспользований { get; set; }
    }
}
