namespace project.Contracts.Role
{
    public class CreateRoleRequest
    {
        public int Idроли { get; set; }
        public string Название { get; set; } = null!;
    }
}
