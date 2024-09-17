using System;
using System.Collections.Generic;
using System.Text;

namespace Ginilytics.Service.Data.Model.Common
{
    public class AppSettings
    {
        public string JWTSecret { get; set; }
        public long TokenExpiryTime { get; set; }
        public long RefreshTokenExpiryTime { get; set; }
        public int HashIterationCount { get; set; }
        public int ForgotPasswordTokenValidationTime { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
