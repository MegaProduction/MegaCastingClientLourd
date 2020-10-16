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

		#region Construteur

		#endregion
		public ViewModelHistoriqueOffer(MegaCastingEntities entities)
			:base(entities)
		{
			this.Entities.Offres.ToList();
			this.Offres = this.Entities.Offres.Local;
		}
		#region Method
		/// <summary>
		/// Sauvegarde les modifications 
		/// </summary>
		public void SaveChanges()
		{
			this.Entities.SaveChanges();
		}
		/// <summary>
		/// Ajoute une offre
		/// </summary>
		public void AddOffre()
		{
			if (!this.Entities.Offres.Any(offres => offres.Intitule == "New Offre"))
			{
				Offre offre = new Offre();
				offre.Intitule = "New Offre";
				offre.IdentifiantContrat = 1;
				offre.Localisation = 1;
				offre.NbPostes = 1;
				offre.IdentifiantContrat = 2;
				offre.DescriptionPoste = "iuydgfgn";
				offre.DescriptionProfil = "fdfdfdfd";
				offre.DureeDiffusion = "15";
				offre.EstValide = true;
				offre.DateDebut = DateTime.Now;
				offre.Reference = offre.Identifiant;
				offre.Coordonnées = "ici";
				this.Offres.Add(offre);
				try
				{
					this.SaveChanges();
				}
				catch (System.Data.Entity.Validation.DbEntityValidationException ex)
				{

					throw ex;
				}
			}
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
