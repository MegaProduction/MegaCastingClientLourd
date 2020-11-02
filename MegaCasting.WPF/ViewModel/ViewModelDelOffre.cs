using MegaCasting.DBlib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MegaCasting.WPF.ViewModel
{
    class ViewModelDelOffre : ViewModelBase
    {
		private ObservableCollection<Postule> _ListPostules;
		/// <summary>
		/// Obtient ou définit postule
		/// </summary>
		public ObservableCollection<Postule> ListPostules
		{
			get { return _ListPostules; }
			set { _ListPostules = value; }
		}
		private Postule _Postules;

		public Postule Postules
		{
			get { return _Postules; }
			set { _Postules = value; }
		}


		#region Attributs
		/// <summary>
		/// Collection des offres
		/// </summary>
		private ObservableCollection<Offre> _Offres;
		/// <summary>
		/// Offre sélectionnée
		/// </summary>
		private Offre _SelectedOffres;
		/// <summary>
		/// Collection d'offre lié aux client
		/// </summary>
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
			this.Entities.Postules.ToList();
			this.ListPostules = this.Entities.Postules.Local;
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
			if (ListPostules.Any(postule => postule.IdentifiantOffre == SelectedOffre.Identifiant))
			{
				MessageBox.Show("Des candidats ont postulé à cette offre");
			}
			//Suppression de l'élément
			else
			{
				this.Offres.Remove(SelectedOffre);
				this.SaveChanges();
				MessageBox.Show("Offre supprimée");
			}
		}
		#endregion
	}
}
