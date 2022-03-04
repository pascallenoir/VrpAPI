using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VrpAPI.Models;

namespace VrpAPI.DTOs
{
    public class EtsbancaireVM
    {
        public string BANQUE_CODE_BCEAO { get; set; }
        public string PAYS_CODE { get; set; }
        public string UserId { get; set; }
        public string BANQUE_NOM { get; set; }
        public string BANQUE_SIGLE { get; set; }
        public Nullable<System.DateTime> BANQUE_DATE_SUSP { get; set; }
        public string BANQUE_CLE_BCEAO { get; set; }
        public string BANQUE_CODE_REMET { get; set; }
        public string CODE_FORMULE { get; set; }
        public Nullable<decimal> BANQUE_SDEVMT { get; set; }
        public string BANQUE_B_F { get; set; }
        public string ETCIV_MATRICULE { get; set; }
        public Nullable<System.DateTime> DATE_CREATION { get; set; }
        public Nullable<System.DateTime> DATE_MODIF { get; set; }

        public AspNetUser AspNetUser { get; set; }
        public PAYS_NATIONAL PAYS_NATIONAL { get; set; }
        public ICollection<ORGAN_ETS_BANCAIRE> ORGAN_ETS_BANCAIRE { get; set; }
    }
}