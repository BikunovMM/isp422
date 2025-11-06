namespace project.Contracts.Files
{
    public class CreateFilesRequest
    {
        public int Idфайла { get; set; }
        public string НазваниеФайла { get; set; } = null!;
        public long Idформата { get; set; }
    }
}
