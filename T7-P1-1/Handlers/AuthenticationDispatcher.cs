using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using T7_P1_1.Filters.Authentication;

namespace T7_P1_1.Handlers
{
    public class AuthenticationDispatcher : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {

            AuthenticationHeaderValue authentication = request.Headers.Authorization;
            if (authentication != null && authentication.Scheme == "Basic")
            {
                string[] authData = Encoding.ASCII.GetString(Convert.FromBase64String(authentication.Parameter)).Split(':');
                request.GetRequestContext().Principal = StaticUserManager.AuthenticateUser(authData[0], authData[1]);
            }

            HttpResponseMessage response = await base.SendAsync(request, cancellationToken);
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                response.Headers.Add("WWW-Authenticate", "Basic");
            }

            return response;
        }
    }

}