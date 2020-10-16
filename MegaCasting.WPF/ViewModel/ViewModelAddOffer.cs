using MegaCasting.DBlib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCasting.WPF.ViewModel
{
    class ViewModelAddOffer : ViewModelBase
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

        #region Constructors
        public ViewModelAddOffer(MegaCastingEntities entities)
			: base(entities)
		{
			this.Offres = new ObservableCollection<Offre>();
			foreach (Offre offre in this.Entities.Offres)
			{
				this.Offres.Add(offre);
			}
		}
		#endregion

		#region Methods
		public void SaveChanges()
		{
			this.Entities.SaveChanges();
		}

		/// <summary>
		/// Ajoute une nouvelle offre
		/// </summary>
		public void AddOffer()
		{
			if (this.Entities.Offres.Any(type => type.Intitule == "Nouvelle offre"))
			{
				Offre offre = new Offre();
				offre.Intitule = "Nouvelle offre";

				this.Offres.Add(offre);
				this.SaveChanges();
				this.SelectedOffre = offre;
			}
		}
		#endregion

	}
}
