﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ledgerscope.AzureUtils;
using Xero.Api.Infrastructure.Interfaces;
using Xero.Api.Infrastructure.OAuth;

namespace Ledgerscope.Xero.AzureTokenStore
{
    public class XeroTokenAdapter : EntityAdapter<Token>
    {
        public XeroTokenAdapter()
        {
        }

        public XeroTokenAdapter(Token token) : base(token)
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
