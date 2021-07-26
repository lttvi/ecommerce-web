using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Text;

namespace Ecom.WebAPI.Handlers
{
    public class UserAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public UserAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock)
                : base(options, logger, encoder, clock)
        {
           
        }
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("Authorization header was not found.");
            else
            {
                var authenValue =AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var bytes = Convert.FromBase64String(authenValue.Parameter);
                string credentials = Encoding.UTF8.GetString(bytes);
            }
            return AuthenticateResult.Fail("Not implement yet.");
        }
    }
}
