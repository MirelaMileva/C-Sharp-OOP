using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Telephony.Contracts;
using Telephony.Exceptions;

namespace Telephony.Models
{
    public class StationaryPhone : ICallable
    {
        public string Call(string phoneNumber)
        {
            if (!phoneNumber.All(ch => char.IsDigit(ch)))
            {
                throw new InvalidNumberException();
            }
            return $"Dialing... {phoneNumber}";
        }
    }
}
