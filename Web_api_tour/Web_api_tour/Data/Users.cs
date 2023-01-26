using System;

namespace Web_api_tour.Data
{
    public static class Users
    {
        public static List<string> LeverTrust = new List<string>();

        public static List<string> AvalaibleTables= new List<string>();

        public static List<User> users = new List<User>();

        // Соонешение Куки к Пользователю.
        public static Dictionary<string, string> Cokies = new Dictionary<string, string>();

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static bool isExistingUser(string login, string pass)
        {
            foreach (var usr in users)
            {
                if (usr.name == login && usr.password == pass)
                {
                    return true;
                }
            }
            return false;
        }
    }

    public class User
    {
        public string name { get; set; } = "";
        public string password { get; set; } = "";
    }
}
