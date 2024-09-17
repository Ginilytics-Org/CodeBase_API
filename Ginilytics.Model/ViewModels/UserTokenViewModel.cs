using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ginilytics.Model.ViewModels
{
    public class UserTokenViewModel
    {
        [Required]
        [StringLength(50)]
        public string userName { get; set; }
        
        [Required]
        [StringLength(200)]
        public string refreshToken { get; set; }
        [Required]
        public DateTime refreshTokenExpiryTime { get; set; }
    }
}
