using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCastingsV2.Console
{
    class Category
    {
		/// <summary>
		/// Nom de la catégorie
		/// </summary>
		private string _Name;
		/// <summary>
		/// Obtient ou défini le nom de la catégorie
		/// </summary>
		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}

	}
}
