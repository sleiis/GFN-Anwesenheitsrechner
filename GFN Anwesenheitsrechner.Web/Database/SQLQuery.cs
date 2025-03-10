namespace GFN_Anwesenheitsrechner.Web.Database
{
    public class SQLQuery
    {
        public string CREATE_USER { get { return "INSERT INTO `users` (username, password) VALUES (@Username, @Password)"; } }
        public string COUNT_USERS { get { return ""; } }
        public string GET_USER_BY_ID { get { return ""; } }
        public string VERIFIED_USER { get { return ""; } }
        public string GET_PRESENCE_BY_USERID { get { return ""; } }
        public string INSERT_PRESENCE { get { return ""; } }
        public string DELETE_PRESENCE { get { return ""; } }
        public string UPDATE_PRESENCE { get { return ""; } }

    }
}
