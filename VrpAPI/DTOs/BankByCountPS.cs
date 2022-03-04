using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VrpAPI.DTOs
{
    public class BankByCountPS
    {
        public string Pays_code { get; set; }
        public string Pays_nom { get; set; }
        public string Banque_code_bceao { get; set; }
        public string Banque_nom { get; set; }
        public string Banque_sigle { get; set; }
    }
}