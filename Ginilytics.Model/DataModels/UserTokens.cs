using System;
using System.Collections.Generic;
using System.Text;

namespace Ginilytics.Model.DataModels
{
    public class UserTokens
    {
        public Int64 id { get; set; }
        public string userName { get; set; }
        public string refreshToken { get; set; }
        public DateTime refreshTokenExpiryTime { get; set; }
    }
}
