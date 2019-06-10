using HTTP.Sessions.Contracts;
using System;
using System.Collections.Generic;

namespace HTTP.Sessions
{
    public class HttpSession : IHttpSession
    {
        private readonly IDictionary<string, object> parameters;
        public string Id { get; }
        public HttpSession(string id)
        {
            this.parameters = new Dictionary<string, object>();
            this.Id = id;
        }
        public void AddParameter(string key, object parameter)
        {
            if (this.ContainsParameter(key))
            {
                throw new ArgumentNullException();
            }

            this.parameters[key] = parameter;
        }

        public void ClearParameters()
        {
            this.parameters.Clear();
        }

        public bool ContainsParameter(string key)
        {
            return this.parameters.ContainsKey(key);
        }

        public object GetParameter(string key)
        {
            if (string.IsNullOrEmpty(key)
            {
                throw new ArgumentNullException();
            }

            if (!this.ContainsParameter(key))
            {
                return null;
            }

            return this.parameters[key];
        }
    }
}
