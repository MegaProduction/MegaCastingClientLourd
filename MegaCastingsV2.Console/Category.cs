using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCastingsV2.APV1
{
    class Category
    {


		#region Attributes
		/// <summary>
		/// Nom de la catégorie
		/// </summary>
		private string _Name;
		#endregion
		#region Proprieties
		/// <summary>
		/// Obtient ou défini le nom de la catégorie
		/// </summary>
		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}
		#endregion
		#region Cosntrutor
		/// <summary>
		/// Construteur d'une catégorie de bière
		/// </summary>
		/// <param name="name">Nom de la catégorie</param>
		public Category(string name)
		{
			this.Name = name;
		}
		#endregion
	}
}
