namespace GFN_Anwesenheitsrechner.Web.Extensions
{
    public static class CookieHelper
    {
        public static void SetCookie(HttpContext context, string key, int userID, string username, int? expireTime = null)
        {
            // Combine UserID and Username into a single string
            string value = $"{userID}|{username}"; // Using a delimiter like | to separate the values

            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = false, // Set to true if using HTTPS
                SameSite = SameSiteMode.Strict
            };

            if (expireTime.HasValue)
            {
                cookieOptions.Expires = DateTime.UtcNow.AddMinutes(expireTime.Value);
            }

            // Append the combined value to the cookie
            context.Response.Cookies.Append(key, value, cookieOptions);
        }

        public static (int UserID, string Username) GetCookie(HttpContext context, string key)
        {
            // Retrieve the cookie value
            var cookieValue = context.Request.Cookies[key];

            if (cookieValue != null)
            {
                // Split the combined value back into UserID and Username
                var parts = cookieValue.Split('|');
                if (parts.Length == 2 && int.TryParse(parts[0], out int userID))
                {
                    return (userID, parts[1]);
                }
            }

            // Return default values if the cookie is not found or is invalid
            return (0, "Guest");
        }

        public static void DeleteCookie(HttpContext context, string key)
        {
            context.Response.Cookies.Delete(key);
        }
    }
}
