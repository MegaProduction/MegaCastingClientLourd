using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MegaCasting.DBlib;
using System.Collections.ObjectModel;
using System.Windows;
using System.Security.Policy;
using System.Security.Cryptography;

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

		static string ComputeMD5Hash(string rawData)
		{
			// Create a SHA256   
			using (MD5 md5Hash = MD5.Create())
			{
				// ComputeHash - returns byte array  
				byte[] bytes = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

				// Convert byte array to a string   
				StringBuilder builder = new StringBuilder();
				for (int i = 0; i < bytes.Length; i++)
				{
					builder.Append(bytes[i].ToString("x2"));
				}
				return builder.ToString();
			}
		}

		/// <summary>
		/// Ajoute un partenaire (limité par le Covid)
		/// </summary>
		/// <param name="login"></param>
		/// <param name="password"></param>
		/// <param name="libelle"></param>
		/// <param name="identifiantVille"></param>
		public void AddPartner(string login, string password, string libelle, string identifiantVille)
		{
			bool ville = int.TryParse(identifiantVille, out int villeId);
			if (!this.Entities.Clients.Any(partner => partner.Login == login))
			{
				Client clients = new Client();
				try
				{
					clients.Login = login;
					MD5 md5hash = MD5.Create();
					string hashedpassword = ComputeMD5Hash(password);
					clients.Password = hashedpassword;
					clients.Libelle = libelle;
					clients.VilleIdentifiant = villeId;
					this.Client.Add(clients);
					this.SaveChanges();
					MessageBox.Show("Client ajouté");
				}
				catch (Exception)
				{
					this.Client.Remove(clients);
					MessageBox.Show("Erreur lors de l'ajout");
				}
			}
			else
			{
				MessageBox.Show("Le client existe déjà");
			}
		}
		#endregion

	}
}
