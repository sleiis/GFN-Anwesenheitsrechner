namespace GFN_Anwesenheitsrechner.Web.Extensions
{
    public class PasswordManager
    {
        public bool VerifyPassword(string PasswordHash, string Password)
        {
            try
            {
                return BCrypt.Net.BCrypt.Verify(Password, PasswordHash);
            }
            catch
            {
                return false;
            }
            
        }
        public string EncryptPassword(string Password)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(Password);
            return hashedPassword;
        }

       
    }
}
