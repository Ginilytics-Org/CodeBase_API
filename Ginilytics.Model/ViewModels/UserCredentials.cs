using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ginilytics.Model.ViewModels
{
    public class UserCredentials
    {
        [Required]
        public string userName { get; set; }

        [Required]
        public string password { get; set; }
    }

    public class RefreshCredentials
    {
        [Required]
        public string jwtToken { get; set; }

        [Required]
        public string refreshToken { get; set; }
    }

    public class RefreshTokenAuthenticate
    {
        public string userName { get; set; }
        public string refreshToken { get; set; }
        public DateTime refreshTokenExpiryTime { get; set; }
    }
}
