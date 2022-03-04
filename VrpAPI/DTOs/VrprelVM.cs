using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VrpAPI.Models;

namespace VrpAPI.DTOs
{
    public class VrprelVM
    {
        public string CODE_VRP { get; set; }
        public string BANQUE_CODE_BCEAO { get; set; }
        public string CODE_ORG { get; set; }
        public string CODE_TYPE_RELATION { get; set; }
        public string OBSERVATION_REL { get; set; }
        public BANQUE_VRP BANQUE_VRP { get; set; }
        public ORGAN_ETS_BANCAIRE ORGAN_ETS_BANCAIRE { get; set; }
        public TYPE_RELATION_VRP TYPE_RELATION_VRP { get; set; }
    }
}
