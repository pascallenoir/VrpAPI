//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VrpAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class VRP_RELATION_ETS
    {
        public string CODE_VRP { get; set; }
        public string BANQUE_CODE_BCEAO { get; set; }
        public string CODE_ORG { get; set; }
        public string CODE_TYPE_RELATION { get; set; }
        public string OBSERVATION_REL { get; set; }
    
        public virtual BANQUE_VRP BANQUE_VRP { get; set; }
        public virtual ORGAN_ETS_BANCAIRE ORGAN_ETS_BANCAIRE { get; set; }
        public virtual TYPE_RELATION_VRP TYPE_RELATION_VRP { get; set; }
    }
}
