namespace GFN_Anwesenheitsrechner.Web.Extensions
{
    public class UserData
    {
        public string? MessageBoxString { get; set; }
        public int UserID { get; set; }
        public string? UserName { get; set; } = "Guest!";
        public string? Password { get; set; }
        public bool isLogged { get; set; }
    }
}
