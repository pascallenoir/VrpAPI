using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VrpAPI.Models;

namespace VrpAPI.DTOs
{
    public class TypreletsVM
    {
        public string CODE_TYPE_RELATION { get; set; }
        public string UserId { get; set; }
        public string LIBELLE_RELATION { get; set; }
        public Nullable<System.DateTime> DATE_CREATION { get; set; }
        public Nullable<System.DateTime> DATE_MODIF { get; set; }

        public AspNetUser AspNetUser { get; set; }
        public ICollection<VRP_RELATION_ETS> VRP_RELATION_ETS { get; set; }
    }
}