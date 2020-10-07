using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCastingsV2.APV1
{
	/// <summary>
	/// Classe d'une bière a boire
	/// </summary>
    class Beer
    {
        #region Attribut
        /// <summary>
        /// Nom de la bière
        /// </summary>
        private string _Name;

		/// <summary>
		/// Titre de la bière
		/// </summary>
		private double _Degrees;


		private Category _Category;
		#endregion
		#region Proprieties
		/// <summary>
		/// Obtient ou défini le nom la bière
		/// </summary>
		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}

		/// <summary>
		/// Obtient ou défini  le titre la bière
		/// </summary>
		public double Degrees
		{
			get { return _Degrees; }
			set { _Degrees = value; }
		}


		public Category Category
		{
			get { return _Category; }
			set { _Category = value; }
		}
		#endregion
		#region Construtor
		/// <summary>
		/// Construteur par défaut
		/// </summary>
		public Beer()
		{

		}
		/// <summary>
		/// Construteur de bière
		/// </summary>
		/// <param name="name">Nom de la bière</param>
		/// <param name="degrees">Degré d'alcool</param>
		/// <param name="category">Catégorie de la bière</param>
		public Beer(string name, double degrees, Category category)
		{
			this.Degrees = degrees;
			this.Name = name;
			this.Category = category;
		}
        #endregion
    }
}
