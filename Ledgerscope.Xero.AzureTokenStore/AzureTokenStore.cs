using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ledgerscope.AzureUtils;
using Xero.Api.Infrastructure.Interfaces;

namespace Ledgerscope.Xero.AzureTokenStore
{
    public class AzureTokenStore : ITokenStore
    {
        private readonly IBulkAtsFactory<XeroTokenAdapter> _tokenFactory;

        public AzureTokenStore(IAzureHelper azureHelper)
            : this(new BulkAtsFactory<XeroTokenAdapter>(new BulkAtsLoader<XeroTokenAdapter>(azureHelper), azureHelper))
        {

        }

        public AzureTokenStore(IBulkAtsFactory<XeroTokenAdapter> tokenFactory)
        {
            _tokenFactory = tokenFactory;
        }

        public IToken Find(string user)
        {
            return _tokenFactory.Loader.GetByPK(user).FirstOrDefault()?.Value;
        }

        public void Add(IToken token)
        {
            var xeroToken = new XeroToken(token);
            using (var tokenSaver = _tokenFactory.Saver)
            {
                tokenSaver.AddItem(new XeroTokenAdapter(xeroToken));
                tokenSaver.Flush();
            }
            _tokenFactory.Loader.ClearCache();
        }

        public void Delete(IToken token)
        {
            var loader = _tokenFactory.Loader;
            var aToken = loader.GetByPKRK(token.UserId, token.OrganisationId ?? "");
            using (var tokenSaver = _tokenFactory.Saver)
                tokenSaver.DeleteItem(aToken);

            loader.ClearCache();
        }
    }
}
