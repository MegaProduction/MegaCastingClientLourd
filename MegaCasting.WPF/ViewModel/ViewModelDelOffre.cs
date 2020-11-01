using MegaCasting.DBlib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCasting.WPF.ViewModel
{
    class ViewModelDelOffre : ViewModelBase
    {
		#region Attributs
		/// <summary>
		/// Collection des offres
		/// </summary>
		private ObservableCollection<Offre> _Offres;
		/// <summary>
		/// Offre sélectionnée
		/// </summary>
		private Offre _SelectedOffres;
		#endregion
		#region Properties
		/// <summary>
		/// Obtient ou définit la collection d'offre
		/// </summary>
		public ObservableCollection<Offre> Offres
		{
			get { return _Offres; }
			set { _Offres = value; }
		}

		/// <summary>
		/// Obtient ou définit l'offre sélectionnée
		/// </summary>
		public Offre SelectedOffre
		{
			get { return _SelectedOffres; }
			set { _SelectedOffres = value; }
		}
		#endregion
		#region Construteur
		public ViewModelDelOffre(MegaCastingEntities entities)
			: base(entities)
		{
			this.Entities.Offres.ToList();
			this.Offres = this.Entities.Offres.Local;
		}
		#endregion
		#region Method
		/// <summary>
		/// Sauvegarde les modifications 
		/// </summary>
		public void SaveChanges()
		{
			this.Entities.SaveChanges();
		}
		public void DeleteOffre()
		{
			//Vérification si on a le droit de supprimer

			//Suppression de l'élément
			this.Offres.Remove(SelectedOffre);
			this.SaveChanges();
		}
		#endregion

	}
}
