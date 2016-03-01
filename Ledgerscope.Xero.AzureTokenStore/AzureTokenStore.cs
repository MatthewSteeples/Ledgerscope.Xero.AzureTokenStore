using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ledgerscope.AzureUtils;
using Xero.Api.Infrastructure.Interfaces;
using Xero.Api.Infrastructure.OAuth;
using Ledgerscope.Xero.AzureTokenStore.Helpers;

namespace Ledgerscope.Xero.AzureTokenStore
{
    public abstract class AzureTokenStore<T> : ITokenStore where T : XeroTokenAdapter, new()
    {
        private readonly IBulkAtsFactory<T> _tokenFactory;

        public AzureTokenStore(IAzureHelper azureHelper)
            : this(new BulkAtsFactory<T>(new BulkAtsLoader<T>(azureHelper), azureHelper))
        {

        }

        public AzureTokenStore(IBulkAtsFactory<T> tokenFactory)
        {
            _tokenFactory = tokenFactory;
        }

        public IToken Find(string user)
        {
            return _tokenFactory.Loader.GetByPK(user).FirstOrDefault()?.Value;
        }

        public void Add(IToken token)
        {
            var xeroToken = token as Token;
            if (xeroToken == null)
            {
                xeroToken = new Token();
                xeroToken.CopyFrom(token);
            }

            using (var tokenSaver = _tokenFactory.Saver)
            {
                tokenSaver.AddItem(GetAdapter(xeroToken));
                tokenSaver.Flush();
            }
            _tokenFactory.Loader.ClearCache();
        }

        protected abstract T GetAdapter(Token token);

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
