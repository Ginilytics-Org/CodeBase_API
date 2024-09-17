using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ginilytics.Model.DataModels
{
    public class Staff : BaseModel
    {
        [Required]
        public int id { get; set; }
        [Required]
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string middleName { get; set; }
        public DateTime DOB { get; set; }
        [Required]
        public string email { get; set; }
        public string password { get; set; }
        public string userName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string phone { get; set; }
        public string mobile { get; set; }
        public string position { get; set; }
    }
}
