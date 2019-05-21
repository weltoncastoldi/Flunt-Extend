using Flunt.Validations.Document;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flunt.Validations
{
    public static partial class ContractExtensions
    {
        public static Contract IsCreditCard(this Contract contract, string value, string property, string message)
        {
            if (string.IsNullOrEmpty(value) || !new CreditCard().Validate(value))
                contract.AddNotification(property, message);
            return contract;
        }
    }
}
