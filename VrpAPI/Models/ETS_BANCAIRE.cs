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
    
    public partial class ETS_BANCAIRE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ETS_BANCAIRE()
        {
            this.ORGAN_ETS_BANCAIRE = new HashSet<ORGAN_ETS_BANCAIRE>();
        }
    
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
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual PAYS_NATIONAL PAYS_NATIONAL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORGAN_ETS_BANCAIRE> ORGAN_ETS_BANCAIRE { get; set; }
    }
}
