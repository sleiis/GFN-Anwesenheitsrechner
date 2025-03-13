
namespace GFN_Anwesenheitsrechner.Web.Lists
{
    public class PresenceList
    {
        public int PresenceID {  get; set; }    
        public int UserID { get; set; }  
        public string Date { get; set; }
        public bool HomeOffice { get; set; }
        public string LoginTime { get; set; }
        public string LogoutTime { get; set; }
        public string? CorrectionLogin { get; set; }  
        public string? CorrectionLogout { get; set; } 
        public PresenceList() { }
        // Constructor to initialize presence
        public PresenceList(int presenceID, int userID, string date, bool homeOffice, string loginTime, string logoutTime, string? correctionLogin = "--:--", string? correctionLogout = "--:--")
        {
            PresenceID = presenceID;
            UserID = userID;
            Date = date;
            HomeOffice = homeOffice;
            LoginTime = loginTime;
            LogoutTime = logoutTime;
            CorrectionLogin = correctionLogin;
            CorrectionLogout = correctionLogout;
        }
    }
}
