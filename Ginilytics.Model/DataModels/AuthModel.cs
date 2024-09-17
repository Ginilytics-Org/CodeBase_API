using Ginilytics.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ginilytics.Model.DataModels
{
    public class AuthModel
    {
        public int id { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string email { get; set; }
        public string lastName { get; set; }
        public List<Role> userRoles { get; set; }
        public string refreshToken { get; set; }
        public DateTime refreshTokenExpiryTime { get; set; }
    }
    public class refreshStaffToken
    {
        public int staffId { get; set; }
        public string refreshToken { get; set; }
        public DateTime refreshTokenExpiryTime { get; set; }
    }
    public class RereshTokenDataModel
    {
        public int staffId { get; set; }
        public string refreshToken { get; set; }
    }
}
