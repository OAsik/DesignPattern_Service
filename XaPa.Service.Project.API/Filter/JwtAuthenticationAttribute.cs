using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;

namespace XaPa.Service.Project.API.Filter
{
    public static class HttpAuthenticationChallengeContextExtensions
    {
        public static void ChallengeWith(this HttpAuthenticationChallengeContext context, string scheme)
        {
            ChallengeWith(context, new AuthenticationHeaderValue(scheme));
        }

        public static void ChallengeWith(this HttpAuthenticationChallengeContext context, string scheme, string parameter)
        {
            ChallengeWith(context, new AuthenticationHeaderValue(scheme, parameter));
        }

        public static void ChallengeWith(this HttpAuthenticationChallengeContext context, AuthenticationHeaderValue challenge)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            context.Result = new AddChallengeOnUnauthorizedResult(challenge, context.Result);
        }
    }

    public abstract class JwtAuthenticationAttribute : Attribute, IAuthenticationFilter
    {
        public string Realm { get; set; }

        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            HttpRequestMessage request = context.Request;
            AuthenticationHeaderValue authorization = request.Headers.Authorization;

            if (authorization == null)
            {
                return;
            }

            if (authorization.Scheme != "Basic")
            {
                return;
            }

            if (String.IsNullOrEmpty(authorization.Parameter))
            {
                context.ErrorResult = new AuthenticationFailureResult("Missing Credentials", request);
                return;
            }

            byte[] credentialBytes;

            string parameter = authorization.Parameter;

            string[] converted = parameter.Split('.');

            string correctedConverted = converted[1].Replace("_", "/").Replace("-", "+") + new string('=', (4 - converted[1].Length % 4) % 4);

            credentialBytes = Convert.FromBase64String(correctedConverted);

            Encoding encoding = Encoding.UTF8;
            encoding = (Encoding)encoding.Clone();
            encoding.DecoderFallback = DecoderFallback.ExceptionFallback;

            string decodedCredentials;

            try
            {
                decodedCredentials = encoding.GetString(credentialBytes);
            }
            catch (Exception)
            {
                return;
            }

            if (String.IsNullOrEmpty(decodedCredentials))
            {
                return;
            }

            int colonIndex = decodedCredentials.IndexOf(':');

            if (colonIndex == -1)
            {
                return;
            }

            string[] colonArray = decodedCredentials.Split('"');
            string email = colonArray[3];
            string password = colonArray[7];

            Tuple<string, string> emailAndPassword = new Tuple<string, string>(email, password);

            if (emailAndPassword == null)
            {
                context.ErrorResult = new AuthenticationFailureResult("Invalid Credentials", request);
            }

            string extractedEmail = emailAndPassword.Item1;
            string extractedpassword = emailAndPassword.Item2;

            IPrincipal principal;

            try
            {
                principal = await AuthenticateAsync(extractedEmail, extractedpassword, cancellationToken);
            }
            catch (Exception ex)
            {
                return;
            }

            if (principal == null)
            {
                context.ErrorResult = new AuthenticationFailureResult("Invalid email or password", request);
            }
            else
            {
                context.Principal = principal;
            }
        }

        protected abstract Task<IPrincipal> AuthenticateAsync(string email, string password, CancellationToken cancellationToken);

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            var challenge = new AuthenticationHeaderValue("Basic");
            context.Result = new AddChallengeOnUnauthorizedResult(challenge, context.Result);
            return Task.FromResult(0);
        }

        private void Challenge(HttpAuthenticationChallengeContext context)
        {
            string parameter;

            if (String.IsNullOrEmpty(Realm))
            {
                parameter = null;
            }
            else
            {
                parameter = "realm=\"" + Realm + "\"";
            }

            context.ChallengeWith("Basic", parameter);
        }

        public virtual bool AllowMultiple
        {
            get { return false; }
        }
    }
}