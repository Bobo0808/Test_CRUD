namespace VerifyEmailForgotPassword.Models
{
    public class User
    {

        public int Id { get; set; }

        public string Email { get; set; }=string.Empty;

        public byte[] PasswordHash { get; set; }=new byte[32];

        public byte[] PasswordSalt { get; set; }= new byte[32];

        public string? VerifycationToken { get; set; }

        public DateTime? VerifiedAt { get; set; }

        public string? PasswordRestToken { get; set; }

        public DateTime? ResetTokenExpries { get; set; }





    }
}
