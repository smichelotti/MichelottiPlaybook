using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.IdentityModel.Claims;

namespace MichelottiPlaybook
{
    public static class Extensions
    {
        /// <summary>
        /// Greates query string using the name value collection
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static string ToQueryString(this System.Collections.Specialized.NameValueCollection collection)
        {
            return string.Join("&",
                from k in collection.AllKeys
                select string.Format(System.Globalization.CultureInfo.InvariantCulture,
                    "{0}={1}",
                    k,
                    HttpUtility.UrlEncode(collection.GetValues(k)[0])));
        }

        public static string GetValue(this ClaimCollection claims, string claimType)
        {
            var claim = claims.SingleOrDefault(x => x.ClaimType == claimType);
            return (claim == null ? null : claim.Value);
        }
    }
}