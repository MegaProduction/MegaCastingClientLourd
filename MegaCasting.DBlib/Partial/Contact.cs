using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCasting.DBlib
{
    public partial class Contact
    {
        public string FullName => this.Prenom + " " + this.Nom;
    }
}
