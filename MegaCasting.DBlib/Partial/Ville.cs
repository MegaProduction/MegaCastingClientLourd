using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCasting.DBlib
{
    public partial class Ville
    {
        public string Adresse => this.Libelle + ", " + this.CodePostal + ", " + this.Pay.Libelle;
    }
}
