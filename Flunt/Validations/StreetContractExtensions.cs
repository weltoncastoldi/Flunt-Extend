using Flunt.Validations.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flunt.Validations
{
    public static partial class ContractExtensions
    {
        public static Contract IsCep(this Contract contract, string value, string property, string message)
        {
            if (string.IsNullOrEmpty(value) || !new Cep().Validate(value))
            {
                contract.AddNotification(property, message);
            }

            return contract;
        }
    }
}
