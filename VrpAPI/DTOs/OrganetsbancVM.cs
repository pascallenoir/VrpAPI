using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VrpAPI.Models;

namespace VrpAPI.DTOs
{
    public class OrganetsbancVM
    {
        public string BANQUE_CODE_BCEAO { get; set; }
        public string CODE_ORG { get; set; }
        public string NOM { get; set; }
        public string PRENOMS { get; set; }
        public string ETCIV_MATRICULE { get; set; }
        public string E_MAIL1 { get; set; }
        public string E_MAIL2 { get; set; }
        public string TEL1 { get; set; }
        public string TEL2 { get; set; }
        public string ADR_POST1 { get; set; }
        public string ADR_POST2 { get; set; }
        public string ADR_GEO1 { get; set; }
        public string ADR_GEO2 { get; set; }
        public Nullable<System.DateTime> DATE_CREATION { get; set; }
        public Nullable<System.DateTime> DATE_MODIF { get; set; }

        public ETS_BANCAIRE ETS_BANCAIRE { get; set; }
        public ORGANIGRAMME ORGANIGRAMME { get; set; }
        public ICollection<VRP_RELATION_ETS> VRP_RELATION_ETS { get; set; }
    }
}