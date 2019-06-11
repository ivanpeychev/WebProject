using HTTP.Sessions.Contracts;
using System.Collections.Concurrent;

namespace HTTP.Sessions
{
    public class HttpSessionStorage
    {
        public const string SessionCookieKey = "SID";

        private static readonly ConcurrentDictionary<string, IHttpSession> sessions =
            new ConcurrentDictionary<string, IHttpSession>();

        public static IHttpSession GetSession(string id)
        {
            return sessions.GetOrAdd(id, _ => new HttpSession(id));
        }
    }
}
