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
			this.OffreClients = this.Entities.OffreClients.Local;

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
		/// <param name="intitule">Nom de l'offre</param>
		/// <param name="identifiantVille">Identifiant de la ville</param>
		/// <param name="identifiantContrat">Identifiant du contrat</param>
		/// <param name="identifiantClient">Identifiant du client</param>
		/// <param name="date">Date de début de l'offre</param>
		/// <param name="desProfil">Description du profil pour le postulant</param>
		/// <param name="desPoste">Description de l'offre</param>
		/// <param name="desCoord">Coordonnée de l'offre</param>
		/// <param name="duree">Durée de l'offre</param>
		/// <param name="nbPoste">Nombre de poste pour l'offre</param>

		/// </summary>
		public void AddOffre(string intitule, string identifiantVille, string identifiantContrat, string date, string identifiantClient, string nbPoste, string desProfil, string desPoste, string desCoord, string duree)
		{
			bool contrat = Int32.TryParse(identifiantContrat, out int idContrat);
			bool ville = Int32.TryParse(identifiantVille, out int idVille);
			bool client = Int32.TryParse(identifiantClient, out int idClient);
			bool dateOffre = DateTime.TryParse(date, out DateTime dateTime);
			bool nombrePoste = Int32.TryParse(nbPoste, out int nmbrePoste);
			//Vérifier si l'offre existe pas
			if (!this.Entities.Offres.Any(offres => offres.Intitule == intitule))
			{
				if (VerifOffre(intitule, ville, contrat, client, dateOffre, desPoste, desProfil, desCoord, duree, nombrePoste))
				{
					Offre offre = new Offre();
					offre.Intitule = intitule;
					offre.IdentifiantContrat = idContrat;
					offre.Localisation = idVille;
					offre.NbPostes = nmbrePoste;
					offre.DescriptionPoste = desPoste;
					offre.DescriptionProfil = desProfil;
					offre.DureeDiffusion = duree;
					offre.EstValide = true;
					offre.DateDebut = dateTime;
					offre.Reference = offre.Identifiant;
					offre.Coordonnées = desCoord;
					this.Offres.Add(offre);
					OffreClient offreClient = new OffreClient();
					offreClient.IdentifiantClient = idClient;
					offreClient.IdentifiantOffre = offre.Identifiant;
					this.OffreClients.Add(offreClient);
					this.SaveChanges();
					MessageBox.Show("Offre ajoutée");
				}
				else
				{
					MessageBox.Show("Une erreur s'est produite lors de la saisie");
				}
			}
			else
			{
				MessageBox.Show("Une offre porte déjà ce nom");
			}
		}

		/// <summary>
		/// Vérifie si touts les champs sont bon sinon retourne faux si un des champs est faux
		/// </summary>
		/// <param name="intitule">Nom de l'offre</param>
		/// <param name="ville">Identifiant de la ville</param>
		/// <param name="contrat">Identifiant du contrat</param>
		/// <param name="client">Identifiant du client</param>
		/// <param name="date">Date de début de l'offre</param>
		/// <param name="desProfil">Description du profil pour le postulant</param>
		/// <param name="desPoste">Description de l'offre</param>
		/// <param name="desCoord">Coordonnée de l'offre</param>
		/// <param name="duree">Durée de l'offre</param>
		/// <param name="nombrePoste">Nombre de poste pour l'offre</param>
		/// <returns>Booléen</returns>
		public bool VerifOffre(string intitule, bool ville, bool contrat, bool client, bool date, string desProfil, string desPoste, string desCoord, string duree, bool nombrePoste)
		{
			bool returnValid = false;
			if (string.IsNullOrWhiteSpace(intitule) != true && string.IsNullOrWhiteSpace(desProfil) != true && string.IsNullOrWhiteSpace(desPoste) != true && string.IsNullOrWhiteSpace(desCoord) != true && string.IsNullOrWhiteSpace(duree) != true && ville && client && contrat && date && nombrePoste)
			{
				returnValid = true;
			}
			return returnValid;
		}
		#endregion
	}
}
