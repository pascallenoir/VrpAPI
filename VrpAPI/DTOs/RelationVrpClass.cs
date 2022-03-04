using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VrpAPI.DTOs
{
    public class RelationVrpClass
    {
        public string Code_vrp { get; set; }
        public string Nom_vrp { get; set; }
        public string Banque_code_bceao { get; set; }
        public string Banque_nom { get; set; }
        public string Code_org { get; set; }
        public string Libelle { get; set; }
        public string Code_type_relation { get; set; }
        public string Libelle_relation { get; set; }
        public string Observation_rel { get; set; }
    }
}