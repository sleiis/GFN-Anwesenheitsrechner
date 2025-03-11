namespace GFN_Anwesenheitsrechner.Web.Database
{
    public class SQLQuery
    {
        // Insert a new user
        public string CREATE_USER { get { return "INSERT INTO UsersList (Username, Password) VALUES (@Username, @Password);"; } }

        // Count total users
        public string COUNT_USERS { get { return "SELECT COUNT(*) FROM UsersList;"; } }

        // Get a user by their Username
        public string GET_USER_BY_USERNAME { get { return "SELECT * FROM UsersList WHERE Username = @Username;"; } }

        // Verify user by checking username and password
        public string VERIFIED_USER { get { return "SELECT * FROM UsersList WHERE Username = @Username AND Password = @Password;"; } }

        // Get presence records for a specific user
        public string GET_PRESENCE_BY_USERID { get { return "SELECT * FROM PresenceList WHERE UserID = @UserID;"; } }

        // Insert a new presence record
        public string INSERT_PRESENCE { get { return @"
        INSERT INTO PresenceList (UserID, Date, HomeOffice, LoginTime, LogoutTime, CorrectionLogin, CorrectionLogout) 
        VALUES (@UserID, @Date, @HomeOffice, @LoginTime, @LogoutTime, @CorrectionLogin, @CorrectionLogout);"; } }

        // Delete a presence record by ID
        public string DELETE_PRESENCE { get { return "DELETE FROM PresenceList WHERE PresenceID = @PresenceID;"; } }

        // Update an existing presence record
        public string UPDATE_PRESENCE { get { return @"
        UPDATE PresenceList 
        SET 
            Date = @Date,
            HomeOffice = @HomeOffice,
            LoginTime = @LoginTime,
            LogoutTime = @LogoutTime,
            CorrectionLogin = @CorrectionLogin,
            CorrectionLogout = @CorrectionLogout
        WHERE PresenceID = @PresenceID;"; } }
    }

}
