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
		#region Attrributes
		/// <summary>
		/// Collection d'offre
		/// </summary>
		private ObservableCollection<Offre> _Offres;
		/// <summary>
		/// 
		/// </summary>
		private Offre _SelectedOffre;
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
		#endregion


		public ViewModelHistoriqueOffer(MegaCastingEntities entities)
			:base(entities)
		{
			this.Offres = new ObservableCollection<Offre>();
			foreach (Offre offre in this.Entities.Offres)
			{
				this.Offres.Add(offre);
			}
		}

	}
}
