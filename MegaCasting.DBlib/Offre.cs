//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MegaCasting.DBlib
{
    using System;
    using System.Collections.Generic;
    
    public partial class Offre
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Offre()
        {
            this.OffreClients = new HashSet<OffreClient>();
            this.Postules = new HashSet<Postule>();
        }
    
        public int Identifiant { get; set; }
        public string Intitule { get; set; }
        public int Reference { get; set; }
        public System.DateTime DateDebut { get; set; }
        public string DureeDiffusion { get; set; }
        public int NbPostes { get; set; }
        public int Localisation { get; set; }
        public string DescriptionPoste { get; set; }
        public string DescriptionProfil { get; set; }
        public string Coordonnées { get; set; }
        public bool EstValide { get; set; }
        public int IdentifiantContrat { get; set; }
        public Nullable<System.DateTime> DateAjout { get; set; }
        public int IdentifiantMetier { get; set; }
    
        public virtual Contrat Contrat { get; set; }
        public virtual Ville Ville { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OffreClient> OffreClients { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Postule> Postules { get; set; }
        public virtual Metier Metier { get; set; }
    }
}
