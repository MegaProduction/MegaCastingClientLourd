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
		/// Collection de client
		/// </summary>
		private ObservableCollection<Client> _Clients;
		/// <summary>
		/// Collection d'offre du client
		/// </summary>
		private ObservableCollection<OffreClient> _OffreClients;
		/// <summary>
		/// Collection des contrats
		/// </summary>
		private ObservableCollection<Contrat> _Contrats;
		/// <summary>
		/// Offre sélectionnée
		/// </summary>
		private Offre _SelectedOffre;
		/// <summary>
		/// Ville sélectionnée
		/// </summary>
		private Ville _SelectedVille;
		/// <summary>
		/// Client sélectionné
		/// </summary>
		private Client _SelectedClient;
		/// <summary>
		/// Contrat sélectionné
		/// </summary>
		private Contrat _SelectedContrat;
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
		/// <summary>
		/// Obtient ou défini la collection d'offreClient
		/// </summary>
		public ObservableCollection<OffreClient> OffreClients
		{
			get { return _OffreClients; }
			set { _OffreClients = value; }
		}
		/// <summary>
		/// Obtient ou définit la collection des contrats
		/// </summary>
		public ObservableCollection<Contrat> Contrat
		{
			get { return _Contrats; }
			set { _Contrats = value; }
		}
		/// <summary>
		/// Obtient ou définit le contrat sélectionné
		/// </summary>
		public Contrat MyProperty
		{
			get { return _SelectedContrat; }
			set { _SelectedContrat = value; }
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
			this.Entities.Clients.ToList();
			this.Client = this.Entities.Clients.Local;
			this.Entities.Contrats.ToList();
			this.Contrat = this.Entities.Contrats.Local;
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
		public void AddOffre(string intitule, int ville, int identifiantContrat)
		{
			if (!this.Entities.Offres.Any(offres => offres.Intitule == intitule))
			{
				Offre offre = new Offre();
				offre.Intitule = intitule;
				offre.IdentifiantContrat = 1;
				offre.Localisation = ville;
				offre.NbPostes = 1;
				offre.IdentifiantContrat = 1;
				offre.DescriptionPoste = "iuydgfgn";
				offre.DescriptionProfil = "fdfdfdfd";
				offre.DureeDiffusion = "15";
				offre.EstValide = true;
				offre.DateDebut = DateTime.Now;
				offre.Reference = offre.Identifiant;
				offre.Coordonnées = "ici";
				this.Offres.Add(offre);
				this.SaveChanges();
			}

		}
		public void DeleteOffre()
		{
			//Vérification si on a le droit de supprimer

			//Suppression de l'élément
			this.Offres.Remove(SelectedOffre);
			this.SaveChanges();
		}
		/// <summary>
		/// Permet de vérifier si l'offre est bien remplit
		/// </summary>
		/// <param name="intitule">Nom de l'offre</param>
		/// <param name="ville">Identifiant de la ville valide ou non</param>
		/// <param name="contrat">Identifiant du contrat valide ou non</param>
		/// <param name="client">Identifiant du client valide ou non</param>
		/// <returns>Retourne true si tout les champs sont vrai sinon retourne false</returns>
		public bool VerifOffre(string intitule, bool ville, bool contrat, bool client)
		{
			bool returnValid = false;
			if (string.IsNullOrWhiteSpace(intitule) != true && ville && client && contrat)
			{
				returnValid = true;
			}
			return returnValid;
		}
		#endregion
	}
}
