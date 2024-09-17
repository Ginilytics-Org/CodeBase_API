using System;
using System.Collections.Generic;
using System.Text;

namespace Ginilytics.Common.Utility.Contract
{
    public interface IPasswordSecurity
    {
        string CreateHash(string password);
        bool VerifyPassword(string password, string goodHash);
    }
}
