using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using System.Text.Encodings.Web;
using System.Net.Http.Headers;
using System;
using System.Text;
using System.Linq;
using System.Security.Claims;
using Basic.Auth.Infrastructure;

namespace BasicAtWebApiAuthentication.Auth
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly BasicAuthDBContext _context;

        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, 
            ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock,
            BasicAuthDBContext context)
            :base(options, logger, encoder, clock)       
        {
            _context = context;
        }
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            string errorMessage;
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                errorMessage = "UnAuthorized";
                return await Task.FromResult(AuthenticateResult.Fail(errorMessage));
            } 
            else
            {
                var headerValues = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var bytes = Convert.FromBase64String(headerValues.Parameter);
                var credentials = Encoding.UTF8.GetString(bytes);
                if(!string.IsNullOrEmpty(credentials))
                {
                    string[] array = credentials.Split(":");
                    var username = array[0];
                    var Role = array[1];
                    var user = _context.Users.FirstOrDefault(v => v.UserName== username && v.Role == Role);
                    {
                        if(user == null)
                        {
                            return await Task.FromResult(AuthenticateResult.Fail("Unauthorized"));
                        }
                        var claims = new[] { new Claim(ClaimTypes.Name, username) };
                        var identity = new ClaimsIdentity(claims, Scheme.Name);
                        var principal = new ClaimsPrincipal(identity);
                        var ticket = new AuthenticationTicket(principal, Scheme.Name);
                        return await Task.FromResult( AuthenticateResult.Success(ticket));
                    }
                }
                else
                {
                    errorMessage = "Last Unauthorized";
                    return await Task.FromResult( AuthenticateResult.Fail(errorMessage));
                }

            }

        }
    }
}
