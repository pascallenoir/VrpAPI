using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VrpAPI.Models;

namespace VrpAPI.DTOs
{
    public class BanquevrpVM
    {
        public string CODE_VRP { get; set; }
        public string UserId { get; set; }
        public string NOM_VRP { get; set; }
        public string PRENOM_VRP { get; set; }
        public string E_MAIL_VRP { get; set; }
        public string TEL1_VRP { get; set; }
        public string TEL2_VRP { get; set; }
        public string ADR1_VRP { get; set; }
        public string ADR2_VRP { get; set; }
        public Nullable<System.DateTime> DATE_CREATION { get; set; }
        public Nullable<System.DateTime> DATE_MODIF { get; set; }

        public AspNetUser AspNetUser { get; set; }
        public ICollection<VRP_RELATION_ETS> VRP_RELATION_ETS { get; set; }
    }
}