using Ledgerscope.AzureUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xero.Api.Infrastructure.OAuth;

namespace Ledgerscope.Xero.AzureTokenStore
{
    public class AzureAccessTokenStore : AzureTokenStore<XeroTokenAdapter>
    {
        public AzureAccessTokenStore(IAzureHelper azureHelper)
            : this(new BulkAtsFactory<XeroTokenAdapter>(new BulkAtsLoader<XeroTokenAdapter>(azureHelper), azureHelper))
        {
        }

        public AzureAccessTokenStore(IBulkAtsFactory<XeroTokenAdapter> tokenFactory) : base(tokenFactory)
        {
        }

        protected override XeroTokenAdapter GetAdapter(Token token)
        {
            return new XeroTokenAdapter(token);
        }
    }
}
