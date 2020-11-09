using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCasting.DBlib
{
    public partial class Contrat
    {
        public string FullName => this.Identifiant.ToString() + "  " + this.Libelle;
    }
}
