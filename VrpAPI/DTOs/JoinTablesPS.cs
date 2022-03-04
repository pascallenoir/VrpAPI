using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VrpAPI.DTOs
{
    public class JoinTablesPS
    {
        public string Code_vrp { get; set; }
        public string Nom_vrp { get; set; }
        public string Banque_code_vrp { get; set; }
        public string Banque_nom { get; set; }
    }
}