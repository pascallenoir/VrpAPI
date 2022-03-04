using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VrpAPI.DTOs
{
    public class LsPaysVrpIntPS
    {
        public string CODE_VRP { get; set; }
        public string NOM_VRP { get; set; }
        public string PRENOM_VRP { get; set; }
        public string E_MAIL_VRP { get; set; }
        public string TEL1_VRP { get; set; }
        public string BANQUE_CODE_BCEAO { get; set; }
        public string BANQUE_NOM { get; set; }
        public string BANQUE_SIGLE { get; set; }
        public string PAYS_CODE { get; set; }
        public string PAYS_NOM { get; set; }
    }
}