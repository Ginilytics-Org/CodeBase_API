using System;
using System.Collections.Generic;
using System.Text;

namespace Ginilytics.Common.CustomExceptions
{
    public class InternalValidationException : Exception
    {
        public InternalValidationException(string message) : base(String.Format("{0}", message))
        {

        }
    }
}
