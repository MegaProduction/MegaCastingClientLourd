using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCasting.DBlib
{
    public partial class Offre
    {
        public string NameClient => OffreClients.Where(offre => offre.IdentifiantOffre == Identifiant).Select(offre => offre.Client.Libelle).FirstOrDefault();
        public int NumberCandidat => Postules.Where(postule => postule.IdentifiantOffre == Identifiant).Count();
    }
}
