using MegaCasting.DBlib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Validation;
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
		/// <summary>
		/// Collection
		/// </summary>
		private ObservableCollection<Metier> _Metiers;

		private Metier _SelectedMetier;
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
		public ObservableCollection<Client> Clients
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
		public ObservableCollection<Contrat> Contrats
		{
			get { return _Contrats; }
			set { _Contrats = value; }
		}
		/// <summary>
		/// Obtient ou définit le contrat sélectionné
		/// </summary>
		public Contrat SelectedContrat
		{
			get { return _SelectedContrat; }
			set { _SelectedContrat = value; }
		}
		/// <summary>
		/// Obtient ou définit la collection des metiers
		/// </summary>
		public ObservableCollection<Metier> Metiers
		{
			get { return _Metiers; }
			set { _Metiers = value; }
		}
		/// <summary>
		/// Obtient ou définit le metier selectionne
		/// </summary>
		public Metier SelectedMetier
		{
			get { return _SelectedMetier; }
			set { _SelectedMetier = value; }
		}
		#endregion
		#region Construteur
		public ViewModelAddOffer(MegaCastingEntities entities)
			: base(entities)
		{
			this.Entities.Offres.ToList();
			this.Offres = this.Entities.Offres.Local;
			this.OffreClients = this.Entities.OffreClients.Local;
			this.Entities.Villes.ToList();
			this.Villes = this.Entities.Villes.Local;
			this.Entities.Clients.ToList();
			this.Clients = this.Entities.Clients.Local;
			this.Entities.Contrats.ToList();
			this.Contrats = this.Entities.Contrats.Local;
			this.Entities.Metiers.ToList();
			this.Metiers = this.Entities.Metiers.Local;
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
		/// <param name="date">Date de début de l'offre</param>
		/// <param name="desProfil">Description du profil pour le postulant</param>
		/// <param name="desPoste">Description de l'offre</param>
		/// <param name="desCoord">Coordonnée de l'offre</param>
		/// <param name="duree">Durée de l'offre</param>
		/// <param name="nbPoste">Nombre de poste pour l'offre</param>
		/// </summary>
		public void AddOffre(string intitule, string date,  string nbPoste, string desProfil, string desPoste, string desCoord, string duree)
		{
			bool dateOffre = DateTime.TryParse(date, out DateTime dateTime);
			bool nombrePoste = Int32.TryParse(nbPoste, out int nmbrePoste);
			if (SelectedClient is null)
			{
				MessageBox.Show("Aucun client selectionné");
			}
			else if (SelectedContrat is null)
			{
				MessageBox.Show("Aucun contrat selectionné");
			}
			else if (SelectedVille is null)
			{
				MessageBox.Show("Aucun Ville selectionné");
			}
			else if (SelectedMetier is null)
			{
				MessageBox.Show("Aucun Métier selectionné");
			}
			else
			{
				Offre offre = new Offre();
				OffreClient offreClient = new OffreClient();
				try
				{
					offre.Intitule = intitule;
					offre.IdentifiantContrat = SelectedContrat.Identifiant;
					offre.Localisation = SelectedVille.Identifiant;
					offre.NbPostes = nmbrePoste;
					offre.DescriptionPoste = desPoste;
					offre.DescriptionProfil = desProfil;
					offre.DureeDiffusion = duree;
					offre.EstValide = true;
					offre.DateDebut = dateTime;
					offre.Coordonnées = desCoord;
					offre.DateAjout = DateTime.Now;
					offre.IdentifiantMetier = SelectedMetier.Identifiant;
					this.Offres.Add(offre);
					offreClient.IdentifiantClient = SelectedClient.Identifiant;
					offreClient.IdentifiantOffre = offre.Identifiant;
					this.SaveChanges();
					MessageBox.Show("Offre ajoutée");
				}
				catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
				{
					MessageBox.Show(ex.InnerException.InnerException.Message.Replace(Environment.NewLine+"La transaction s'est terminée dans le déclencheur. Le traitement a été abandonné.", ""));
					this.Offres.Remove(offre);
					this.OffreClients.Remove(offreClient);
				}
				catch (System.Data.Entity.Validation.DbEntityValidationException deve)
				{
					foreach (DbEntityValidationResult error in deve.EntityValidationErrors)
					{
						foreach (DbValidationError item in error.ValidationErrors)
						{
							MessageBox.Show(item.PropertyName + " : " + item.ErrorMessage);
						}
					}
					this.Offres.Remove(offre);
					this.OffreClients.Remove(offreClient);
				}
			}
		}
		#endregion

	}
}
