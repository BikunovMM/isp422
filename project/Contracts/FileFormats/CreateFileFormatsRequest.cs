namespace project.Contracts.FileFormats
{
    public class CreateFileFormatsRequest
    {
        public int Idформата { get; set; }
        public string Название { get; set; } = null!;
    }
}
