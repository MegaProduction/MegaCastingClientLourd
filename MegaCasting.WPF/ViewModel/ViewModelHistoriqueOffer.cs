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
		/// <summary>
		/// 
		/// </summary>
		private Offre _SelectedOffre;
		/// <summary>
		/// 
		/// </summary>
		private ObservableCollection<OffreClient> _OffresClients;
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
		/// <summary>
		/// Obtient ou défini l'offre sélectionné
		/// </summary>
		public Offre SelectedOffre
		{
			get { return _SelectedOffre; }
			set { _SelectedOffre = value; }
		}

		public ObservableCollection<OffreClient> OffreClients
		{
			get { return _OffresClients; }
			set { _OffresClients = value; }
		}
		#endregion

		#region Construteur
		public ViewModelHistoriqueOffer(MegaCastingEntities entities)
			: base(entities)
		{
			this.Entities.Offres.ToList();
			this.Offres = this.Entities.Offres.Local;
			this.Entities.OffreClients.ToList();
			this.OffreClients = this.Entities.OffreClients.Local;
		}
		#endregion

	}
}
