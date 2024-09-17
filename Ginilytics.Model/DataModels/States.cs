using System;
using System.Collections.Generic;
using System.Text;

namespace Ginilytics.Model.DataModels
{
    public class States : BaseModel
    {
        public int id { get; set; }
        public string stateName { get; set; }
        public string shortName { get; set; }
    }
}
