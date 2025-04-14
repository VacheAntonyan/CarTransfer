namespace CarTransfer.Models
{
    public class User
    {
            public int UserId { get; set; }
            public string Username { get; set; }
            public byte[] PasswordHash { get; set; }
            public byte[] Salt { get; set; }
    }
}
