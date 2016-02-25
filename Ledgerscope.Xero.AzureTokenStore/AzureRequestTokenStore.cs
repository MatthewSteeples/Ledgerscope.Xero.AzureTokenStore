using Ledgerscope.AzureUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ledgerscope.Xero.AzureTokenStore
{
    public class AzureRequestTokenStore : AzureTokenStore<RequestTokenAdapter>
    {
        public AzureRequestTokenStore(IAzureHelper azureHelper)
            : this(new BulkAtsFactory<RequestTokenAdapter>(new BulkAtsLoader<RequestTokenAdapter>(azureHelper), azureHelper))
        {
        }

        public AzureRequestTokenStore(IBulkAtsFactory<RequestTokenAdapter> tokenFactory) : base(tokenFactory)
        {
        }

        protected override RequestTokenAdapter GetAdapter(XeroToken token)
        {
            return new RequestTokenAdapter(token);
        }
    }
}
