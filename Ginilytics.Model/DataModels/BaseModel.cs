using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Ginilytics.Model.DataModels
{
    public class BaseModel
    {
        public Boolean isActive { get; set; }

        public DateTime utcDateCreated { get; set; }

        public int createdBy { get; set; }

        public DateTime utcDateModified { get; set; }

        public int modifiedBy { get; set; }

        public DateTime utcDateDeleted { get; set; }

        public int deletedby { get; set; }
    }
}
