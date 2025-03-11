
namespace GFN_Anwesenheitsrechner.Web.Lists
{
    public class PresenceList
    {
        public int UserID { get; set; }  
        public DateTime Date { get; set; }
        public bool HomeOffice { get; set; }
        public DateTime LoginTime { get; set; }
        public DateTime LogoutTime { get; set; }
        public DateTime? CorrectionLogin { get; set; }  // Nullable in case no correction is made
        public DateTime? CorrectionLogout { get; set; } // Nullable in case no correction is made

        // Constructor to initialize presence
        public PresenceList(DateTime date, bool homeOffice, DateTime loginTime, DateTime logoutTime, DateTime? correctionLogin = null, DateTime? correctionLogout = null)
        {
            Date = date;
            HomeOffice = homeOffice;
            LoginTime = loginTime;
            LogoutTime = logoutTime;
            CorrectionLogin = correctionLogin;
            CorrectionLogout = correctionLogout;
        }
        public override string ToString()
        {
            return $"Date: {Date.ToShortDateString()}, Home Office: {HomeOffice}, Login Time: {LoginTime.ToShortTimeString()}, " +
                   $"Logout Time: {LogoutTime.ToShortTimeString()}, Correction Login: {CorrectionLogin?.ToShortTimeString() ?? "N/A"}, " +
                   $"Correction Logout: {CorrectionLogout?.ToShortTimeString() ?? "N/A"}";
        }
    }
}
