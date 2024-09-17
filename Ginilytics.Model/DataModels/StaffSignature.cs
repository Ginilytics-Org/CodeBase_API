using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ginilytics.Model.DataModels
{
    public class StaffSignature : BaseModel
    {
        [Required]
        public int id { get; set; }
        [Required]
        public int staffId { get; set; }
        public byte[] signature { get; set; }
    }
}
