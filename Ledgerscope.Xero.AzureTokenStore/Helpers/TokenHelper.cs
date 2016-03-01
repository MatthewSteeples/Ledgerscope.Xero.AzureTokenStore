using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xero.Api.Infrastructure.Interfaces;
using Xero.Api.Infrastructure.OAuth;

namespace Ledgerscope.Xero.AzureTokenStore.Helpers
{
    static class TokenHelper
    {
        public static void CopyFrom(this Token dest, IToken src)
        {
            dest.UserId = src.UserId;
            dest.OrganisationId = src.OrganisationId;
            dest.ConsumerKey = src.ConsumerKey;
            dest.ConsumerSecret = src.ConsumerSecret;
            dest.TokenKey = src.TokenKey;
            dest.TokenSecret = src.TokenSecret;
            dest.Session = src.Session;
            dest.ExpiresAt = src.ExpiresAt;
            dest.SessionExpiresAt = src.SessionExpiresAt;
        }
    }
}
