//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Gestion_des_patients
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblMedecin
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblMedecin()
        {
            this.tblAdmissions = new HashSet<tblAdmission>();
        }
    
        public int IDMédecin { get; set; }
        public string nom { get; set; }
        public string prénom { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblAdmission> tblAdmissions { get; set; }

        public tblMedecin(int iDMédecin, string nom, string prénom)
        {
            IDMédecin = iDMédecin;
            this.nom = nom;
            this.prénom = prénom;
        }
    }
}
