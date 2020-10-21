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
		#region Attributes
		/// <summary>
		/// Collection d'offre
		/// </summary>
		private ObservableCollection<Offre> _Offres;
		/// <summary>
		/// Collection de ville
		/// </summary>
		private ObservableCollection<Ville> _Villes;
		/// <summary>
		/// Offre sélectionnée
		/// </summary>
		private Offre _SelectedOffre;
		/// <summary>
		/// Ville sélectionnée
		/// </summary>
		private Ville _SelectedVille;
		/// <summary>
		/// Collection de client
		/// </summary>
		private ObservableCollection<Client> _Clients;
		/// <summary>
		/// Client sélectionné
		/// </summary>
		private Client _SelectedClient;
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
		/// Obtient ou défini l'offre sélectionnée
		/// </summary>
		public Offre SelectedOffre
		{
			get { return _SelectedOffre; }
			set { _SelectedOffre = value; }
		}
		/// <summary>
		/// Obtient ou défini la collection de ville
		/// </summary>
		public ObservableCollection<Ville> Villes
		{
			get { return _Villes; }
			set { _Villes = value; }
		}
		/// <summary>
		/// Obtient ou défini la ville sélectionnée
		/// </summary>
		public Ville SelectedVille
		{
			get { return _SelectedVille; }
			set { _SelectedVille = value; }
		}
		/// <summary>
		/// Obtient ou défini la collection des clients
		/// </summary>
		public ObservableCollection<Client> Client
		{
			get { return _Clients; }
			set { _Clients = value; }
		}
		/// <summary>
		/// Obtient ou défini le client sélectionné
		/// </summary>
		public Client SelectedClient
		{
			get { return _SelectedClient; }
			set { _SelectedClient = value; }
		}
		#endregion
		#region Construteur
		public ViewModelAddOffer(MegaCastingEntities entities) 
			: base(entities)
		{
			this.Entities.Offres.ToList();
			this.Offres = this.Entities.Offres.Local;
			this.Entities.Villes.ToList();
			this.Villes = this.Entities.Villes.Local;
			this.Entities.Clients.ToList().Select(client => client.Identifiant);
			this.Client = this.Entities.Clients.Local;
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
		/// <summary>
		/// Ajoute une offre
		/// </summary>
		public void AddOffre(string intitule, int ville, int identifiantClient)
		{
			if (!this.Entities.Offres.Any(offres => offres.Intitule == intitule))
			{
				Offre offre = new Offre();
				OffreClient offreClient = new OffreClient();
				offre.Intitule = intitule;
				offre.IdentifiantContrat = 1;
				offre.Localisation = ville;
				offre.NbPostes = 1;
				offre.IdentifiantContrat = 2;
				offre.DescriptionPoste = "iuydgfgn";
				offre.DescriptionProfil = "fdfdfdfd";
				offre.DureeDiffusion = "15";
				offre.EstValide = true;
				offre.DateDebut = DateTime.Now;
				offre.Reference = offre.Identifiant;
				offre.Coordonnées = "ici";
				offreClient.IdentifiantOffre = offre.Identifiant;
				offreClient.IdentifiantPartenaire = identifiantClient;
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
