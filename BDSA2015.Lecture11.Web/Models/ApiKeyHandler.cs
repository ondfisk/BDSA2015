using System;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Web.Configuration;
using System.Collections.Generic;

namespace BDSA2015.Lecture11.Web.Models
{
    /// <summary>
    /// Basic API request authentication based on validating a key in request headers.
    /// The handler will check for a provided X-Api-Key header in requests and validate that the key matches the expected key.
    /// If the key is not valid, HTTP 403 Forbidden is returned to the client.
    /// </summary>
    public class ApiKeyHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            if (!IsValidKey(request))
            {
                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }

            return base.SendAsync(request, cancellationToken);
        }

        private bool IsValidKey(HttpRequestMessage request)
        {
            var key = GetKey(request);

            var expectedKey = WebConfigurationManager.AppSettings["X-Api-Key"];

            return string.Equals(key, expectedKey, StringComparison.InvariantCulture);
        }

        private string GetKey(HttpRequestMessage request)
        {
            IEnumerable<string> keys;
            if (request.Headers.TryGetValues("X-Api-Key", out keys))
            {
                return keys.First();
            }
            return request.GetQueryNameValuePairs().FirstOrDefault(t => t.Key == "key").Value;
        }
    }
}
