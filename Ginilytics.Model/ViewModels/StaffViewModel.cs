using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ginilytics.Model.ViewModels
{
    #region ViewModels
    public class StaffDetailViewModel
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string middleName { get; set; }
        public DateTime DOB { get; set; }
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
    public class StaffCreateViewModel
    {
        [Required]
        [StringLength(50)]
        public string firstName { get; set; }
        [Required]
        [StringLength(50)]
        public string lastName { get; set; }
        
        [StringLength(50)]
        public string middleName { get; set; } 
        public DateTime DOB { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        [StringLength(50)]
        public string password { get; set; }
        [Required]
        public string userName { get; set; }
        [StringLength(50)]
        public string address { get; set; }
        [StringLength(50)]
        public string city { get; set; }
        [StringLength(50)]
        public string state { get; set; }
        [StringLength(50)]
        public string zip { get; set; }
        [StringLength(50)]
        public string phone { get; set; }
        [StringLength(50)]
        public string mobile { get; set; }
      
        [StringLength(50)]
        public string position { get; set; }
        
    }

    public class StaffUpdateViewModel
    {
        [Required]
        public int id { get; set; }
        [Required]
        [StringLength(50)]
        public string firstName { get; set; }
        [Required]
        [StringLength(50)]
        public string lastName { get; set; }
        [Required]
        [StringLength(50)]
        public string middleName { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        [StringLength(50)]
        public string password { get; set; }      
        [Required]
        public string userName { get; set; }
        [StringLength(50)]
        public string address { get; set; }
        [StringLength(50)]
        public string city { get; set; }
        [StringLength(50)]
        public string state { get; set; }
        [StringLength(50)]
        public string zip { get; set; }
        [StringLength(50)]
        public string phone { get; set; }
        [StringLength(50)]
        public string mobile { get; set; }
        [StringLength(50)]
        public string position { get; set; }
       
    }
    public class StaffDeleteViewModel
    {
        [Required]
        public int id { get; set; }
        [Required]
        public int modifiedBy { get; set; }
    }
    #endregion
    #region DTOs
    public class StaffCreateDto
    {
        [Required]
        [StringLength(50)]
        public string firstName { get; set; }
        [Required]
        [StringLength(50)]
        public string lastName { get; set; }
        [Required]
        [StringLength(50)]
        public string middleName { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        [StringLength(50)]
        public string password { get; set; }
        
        [Required]
        public string userName { get; set; }
        [StringLength(50)]
        public string address { get; set; }
        [StringLength(50)]
        public string city { get; set; }
        [StringLength(50)]
        public string state { get; set; }
        [StringLength(50)]
        public string zip { get; set; }
        [StringLength(50)]
        public string phone { get; set; }
        [StringLength(50)]
        public string mobile { get; set; }
        [StringLength(50)]
        public string position { get; set; }
        public DateTime utcDateCreated { get; set; }
        [Required]
        public int createdBy { get; set; }
        public bool isActive { get; set; }
    }
    public class StaffUpdateDto
    {
        [Required]
        public int id { get; set; }
        [Required]
        [StringLength(50)]
        public string firstName { get; set; }
        [Required]
        [StringLength(50)]
        public string lastName { get; set; }
        [Required]
        [StringLength(50)]
        public string middleName { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        [StringLength(50)]
        public string password { get; set; }
        [Required]
        public string userName { get; set; }
        [StringLength(50)]
        public string address { get; set; }
        [StringLength(50)]
        public string city { get; set; }
        [StringLength(50)]
        public string state { get; set; }
        [StringLength(50)]
        public string zip { get; set; }
        [StringLength(50)]
        public string phone { get; set; }
        [StringLength(50)]
        public string mobile { get; set; }
        [StringLength(50)]
        public string position { get; set; }
        public DateTime utcDateModified { get; set; }
        public int modifiedBy { get; set; }
    }
    public class StaffDeleteDto
    {
        [Required]
        public int id { get; set; }
        public int modifiedBy { get; set; }
        public DateTime utcDateDeleted { get; set; }
    }
    #endregion
}
