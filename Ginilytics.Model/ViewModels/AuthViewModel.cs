using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Ginilytics.Model.ViewModels
{
    public class AuthViewModel
    {
        public int id { get; set; }
        public string userName { get; set; }
        public string token { get; set; }
        public long expireIn { get; set; }
        public string refreshToken { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string profileImagePath { get; set; }
        public List<Role> staffRoles { get; set; }
    }

    public class Role
    {
        public int Id { get; set; }
        public string roleName { get; set; }
    }

    public class Token
    {
        public string token { get; set; }
        public long tokenExpireIn { get; set; }
        public string refreshToken { get; set; }
        public long refreshTokenExpireIn { get; set; }
    }

    public class RereshTokenModel
    {

        [Required]
        public string refreshToken { get; set; }
    }
}
