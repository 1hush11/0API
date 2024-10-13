namespace _0auth.DTO
{
    public class UserDTO
    {
        public int IdUser { get; set; }

        public string SurnameUser { get; set; } = null!;

        public string NameUser { get; set; } = null!;

        public string PatronymicUser { get; set; } = null!;

        public string? LoginUser { get; set; }

        public string? PasswordUser { get; set; }

        public int IdRole { get; set; }
    }
}