using GFN_Anwesenheitsrechner.Web.Lists;

namespace GFN_Anwesenheitsrechner.Web.Extensions
{
    public class PresenecManager
    {
        public PresenceList GetPresence(string presenceItem, int userID)
        {
            var parts = presenceItem.Split([' '], StringSplitOptions.RemoveEmptyEntries);

            // Date parsing 
            string date = parts[0];

            // Check if it's HomeOffice (🏠) or office (🏢)
            bool homeOffice = parts[1] == "🏠";

            // Login time 
            string loginTime = parts[2];

            // Logout time 
            string logoutTime = parts[3];

            // Corrected Login time 
            string correctionLogin = parts[4];

            // Corrected Logout time 
            string correctionLogout = parts[5];

            // Add the record to the list
            return new PresenceList
            {
                UserID = userID,
                Date = date,
                HomeOffice = homeOffice,
                LoginTime = loginTime,
                LogoutTime = logoutTime,
                CorrectionLogin = correctionLogin,
                CorrectionLogout = correctionLogout
            };
        }

    }
}
