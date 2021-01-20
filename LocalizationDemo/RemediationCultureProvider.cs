using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace LocalizationDemo
{
    public class RemediationCultureProvider : RequestCultureProvider
    {
        public override async Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
        {
            await Task.Yield();

            if (!httpContext.Request.Cookies.ContainsKey("language"))
            {
                // check if user is authenticated or not. If not set default language
                var cultureInfoToSet = GetRequestCultureById(2);

                CookieOptions cookieOptions = new CookieOptions();
                cookieOptions.Expires = new DateTimeOffset(DateTime.Now.AddDays(30));
                httpContext.Response.Cookies.Append("language", cultureInfoToSet.Name, cookieOptions);

                if (cultureInfoToSet != null)
                {
                    return new ProviderCultureResult(cultureInfoToSet.Name);
                }
            }
            else
            {
                string language = httpContext.Request.Cookies["language"];
                if (!string.IsNullOrEmpty(language))
                {
                    return new ProviderCultureResult(language);
                }
            }

            return null;
        }

        private CultureInfo GetRequestCultureById(int clientId)
        {
            CultureInfo cultureInfo = null;

            if (clientId == 1)
            {
                cultureInfo = new CultureInfo("da-DK");
            }
            else if (clientId == 2)
            {
                cultureInfo = new CultureInfo("en-GB");
            }
            else if (clientId == 3)
            {
                cultureInfo = new CultureInfo("en-US");
            }
            return cultureInfo;
        }
    }
}