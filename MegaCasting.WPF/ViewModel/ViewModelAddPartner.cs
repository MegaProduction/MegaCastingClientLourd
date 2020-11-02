using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MegaCasting.DBlib;
using System.Collections.ObjectModel;

namespace MegaCasting.WPF.ViewModel
{
    class ViewModelAddPartner : ViewModelBase
    {

		#region Attributes
		/// <summary>
		/// Collection de ville
		/// </summary>
		private ObservableCollection<Ville> _Villes;
		/// <summary>
		/// Collection de client
		/// </summary>
		private ObservableCollection<Client> _Clients;
		/// <summary>
		/// Ville sélectionnée
		/// </summary>
		private Ville _SelectedVille;
		/// <summary>
		/// Client sélectionné
		/// </summary>
		private Client _SelectedClient;
		#endregion

		#region Properties
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
		///
		#endregion

		#region Contructors
		public ViewModelAddPartner(MegaCastingEntities entities)
			:base(entities)
		{
			this.Entities.Villes.ToList();
			this.Villes = this.Entities.Villes.Local;
			this.Entities.Clients.ToList();
			this.Client = this.Entities.Clients.Local;
		}
		#endregion

		#region Methods
		/// <summary>
		/// Sauvegarde les modifications 
		/// </summary>
		public void SaveChanges()
		{
			this.Entities.SaveChanges();
		}

		/// <summary>
		/// Ajoute un partenaire (limité par le Covid)
		/// </summary>
		/// <param name="login"></param>
		/// <param name="password"></param>
		/// <param name="libelle"></param>
		/// <param name="ville"></param>
		public void AddPartner(string login, string password, string libelle, int ville)
		{
			if (!this.Entities.Clients.Any(partner => partner.Login == login))
			{
				Client clients = new Client();
				clients.Login = login;
				clients.Password = password;
				clients.Libelle = libelle;
				clients.VilleIdentifiant = ville;
				this.SaveChanges();
			}
		}

		/// <summary>
		/// Vérification des champs (faut faire gaffe aux vaches)
		/// </summary>
		/// <param name="login"></param>
		/// <param name="password"></param>
		/// <param name="libelle"></param>
		/// <param name="ville"></param>
		/// <returns></returns>
		public bool VerifPartner(string login, string password, string libelle, bool ville)
		{
			bool returnValid = false;
			if (string.IsNullOrWhiteSpace(login) != true && string.IsNullOrWhiteSpace(password) != true && string.IsNullOrWhiteSpace(libelle) != true && ville)
			{
				returnValid = true;
			}
			return returnValid;
		}
		#endregion

	}
}
