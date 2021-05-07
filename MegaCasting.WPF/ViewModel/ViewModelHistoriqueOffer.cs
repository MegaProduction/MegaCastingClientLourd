using MegaCasting.DBlib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCasting.WPF.ViewModel
{
    class ViewModelHistoriqueOffer : ViewModelBase
    {
		#region Attributes
		/// <summary>
		/// Collection d'offre
		/// </summary>
		private ObservableCollection<Offre> _Offres;
		#endregion
		#region Properties
		/// <summary>
		/// Obtient ou défini la collection d'offre
		/// </summary>
		public ObservableCollection<Offre> Offres
		{
			get { return _Offres; }
			set { _Offres = value; }
		}
        #endregion
        #region Construteur
		/// <summary>
		/// Constructeur de l'historique des offres
		/// </summary>
		/// <param name="entities"></param>
        public ViewModelHistoriqueOffer(MegaCastingEntities entities)
			: base(entities)
		{
			this.Entities.Offres.ToList();
			this.Offres = this.Entities.Offres.Local;
		}
		#endregion
	}
}
