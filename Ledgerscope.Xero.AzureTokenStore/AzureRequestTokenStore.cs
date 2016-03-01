using Ledgerscope.AzureUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xero.Api.Infrastructure.OAuth;

namespace Ledgerscope.Xero.AzureTokenStore
{
    public class AzureRequestTokenStore : AzureTokenStore<XeroRequestTokenAdapter>
    {
        public AzureRequestTokenStore(IAzureHelper azureHelper)
            : this(new BulkAtsFactory<XeroRequestTokenAdapter>(new BulkAtsLoader<XeroRequestTokenAdapter>(azureHelper), azureHelper))
        {
        }

        public AzureRequestTokenStore(IBulkAtsFactory<XeroRequestTokenAdapter> tokenFactory) : base(tokenFactory)
        {
        }

        protected override XeroRequestTokenAdapter GetAdapter(Token token)
        {
            return new XeroRequestTokenAdapter(token);
        }
    }
}
