using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.Authorization;
using System.Security.Principal;
using Web_api_tour.Data;

namespace Web_api_tour.Filter
{
    public static class Auth
    {
        public static int levelTrust(string role)
        {
            for (int i = 0; i < Users.LeverTrust.Count; i++)
            {
                if (Users.LeverTrust[i] == role)
                    return i;
            }
            return Users.LeverTrust.Count;
        }

        public static Stream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

    }
}

