using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ginilytics.Common.Model
{
    public class DeleteViewModel
    {
        [Required]
        public int id { get; set; }
        public int modifiedBy { get; set; }
        public DateTime utcDateDeleted { get; set; }

    }
}
