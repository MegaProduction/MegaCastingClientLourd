using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCastingsV2.Console
{
	/// <summary>
	/// Classe d'une bière a boire
	/// </summary>
    class Beer
    {
		/// <summary>
		/// Nom de la bière
		/// </summary>
		private string _Name;
		/// <summary>
		/// Obtient ou défini le nom la bière
		/// </summary>
		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}
		/// <summary>
		/// Titre de la bière
		/// </summary>
		private decimal _Degrees;
		/// <summary>
		/// Obtient ou défini  le titre la bière
		/// </summary>
		public decimal Degrees
		{
			get { return _Degrees; }
			set { _Degrees = value; }
		}
		/// <summary>
		/// Construteur de bière
		/// </summary>
		/// <param name="name">Nom de la bière</param>
		/// <param name="degrees">Degré d'alcool</param>
		public Beer(string name, decimal degrees)
		{
			this.Degrees = degrees;
			this.Name = name;
		}
	}
}
