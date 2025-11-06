namespace project.Contracts.Files
{
    public class GetFilesResponse
    {
        public int Idфайла { get; set; }
        public string НазваниеФайла { get; set; } = null!;
        public long Idформата { get; set; }
    }
}
