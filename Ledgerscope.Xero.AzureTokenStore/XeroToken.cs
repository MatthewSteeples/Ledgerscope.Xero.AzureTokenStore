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
            CopyFrom(token);
        }

        internal void CopyFrom(IToken token)
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
        public string ConsumerKey { get; set; }
        public string ConsumerSecret { get; set; }
        public string TokenKey { get; set; }
        public string TokenSecret { get; set; }
        public string Session { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public DateTime? SessionExpiresAt { get; set; }
        public bool HasExpired { get; set; }
        public bool HasSessionExpired { get; set; }
    }
}
