using System;
using System.Net;

namespace AmarothLauncher.Core
{
    /// <summary>
    /// WebClient with changeable Timeout.
    /// </summary>
    public class AmWebClient : WebClient
    {
        // Timeout in miliseconds.
        public int Timeout { get; set; }

        /// <summary>
        /// Creates a new WebClient with default 60s timeout.
        /// </summary>
        public AmWebClient() : this(60000) { }

        /// <summary>
        /// Creates a new WebClient with given timeout in miliseconds.
        /// </summary>
        /// <param name="timeout"></param>
        public AmWebClient(int timeout)
        {
            Timeout = timeout;
        }

        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = base.GetWebRequest(address);
            if (request != null)
            {
                request.Timeout = this.Timeout;
            }
            return request;
        }
    }
}