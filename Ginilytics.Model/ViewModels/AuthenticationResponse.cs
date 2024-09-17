using System;
using System.Collections.Generic;
using System.Text;

namespace Ginilytics.Model.ViewModels
{
    public class AuthenticationResponse
    {
        public string jwtToken { get; set; }
        public string refreshToken { get; set; }
    }
}
