using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VrpAPI.Models;

namespace VrpAPI.DTOs
{
    public class PaysVM
    {
        public string PAYS_CODE { get; set; }
        public string PAYS_NOM { get; set; }
        public string UserId { get; set; }

        public AspNetUser AspNetUser { get; set; }
        public ICollection<ETS_BANCAIRE> ETS_BANCAIRE { get; set; }

    }
}