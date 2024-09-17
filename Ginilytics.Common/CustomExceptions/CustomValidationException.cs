using System;
using System.Collections.Generic;
using System.Text;

namespace Ginilytics.Common.CustomExceptions
{
    public class CustomValidationException : Exception
    {
        public CustomValidationException(string message) : base(message)
        {

        }
    }
}