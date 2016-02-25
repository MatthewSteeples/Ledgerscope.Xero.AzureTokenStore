using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ledgerscope.AzureUtils;
using Xero.Api.Infrastructure.Interfaces;

namespace Ledgerscope.Xero.AzureTokenStore
{
    public class XeroRequestTokenAdapter : XeroTokenAdapter
    {
        public XeroRequestTokenAdapter()
        {
        }

        public XeroRequestTokenAdapter(XeroToken token) : base(token)
        {
        }

        protected override string BuildPartitionKey()
        {
            return Value.UserId;
        }

        protected override string BuildRowKey()
        {
            return Value.OrganisationId ?? string.Empty;
        }
    }
}
