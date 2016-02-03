using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xero.Api.Infrastructure.Interfaces;

namespace Ledgerscope.Xero.AzureTokenStore
{
    public class XeroToken : IToken
    {
        public XeroToken()
        {
        }

        public XeroToken(IToken token)
        {
            this.UserId = token.UserId;
            this.OrganisationId = token.OrganisationId;
            this.ConsumerKey = token.ConsumerKey;
            this.ConsumerSecret = token.ConsumerSecret;
            this.TokenKey = token.TokenKey;
            this.TokenSecret = token.TokenSecret;
            this.Session = token.Session;
            this.ExpiresAt = token.ExpiresAt;
            this.SessionExpiresAt = token.SessionExpiresAt;
            this.HasExpired = token.HasExpired;
            this.HasSessionExpired = token.HasSessionExpired;
        }

        public string UserId { get; set; }
        public string OrganisationId { get; set; }
        public string ConsumerKey { get; }
        public string ConsumerSecret { get; }
        public string TokenKey { get; }
        public string TokenSecret { get; }
        public string Session { get; }
        public DateTime? ExpiresAt { get; }
        public DateTime? SessionExpiresAt { get; }
        public bool HasExpired { get; }
        public bool HasSessionExpired { get; }
    }
}
