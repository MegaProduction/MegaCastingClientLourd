using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCasting.DBlib
{
    public partial class Contrat
    {
        /// <summary>
        /// Retourne le nom du contrat avec son identifiant
        /// </summary>
        public string FullName => this.Identifiant.ToString() + "  " + this.Libelle;
        /// <summary>
        /// Retourne le nombre d'offre liée au contrat
        /// </summary>
        public int NombreContrat => this.Offres.Count();
    }
}
