using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VrpAPI.Models;

namespace VrpAPI.DTOs
{
    public class OrganigramVM
    {
        public string CODE_ORG { get; set; }
        public string LIBELLE { get; set; }
        public string NIVEAU { get; set; }
        public string HIERARCHIE { get; set; }
        public string UserId { get; set; }

        public AspNetUser AspNetUser { get; set; }
        public ICollection<ORGAN_ETS_BANCAIRE> ORGAN_ETS_BANCAIRE { get; set; }
    }
}