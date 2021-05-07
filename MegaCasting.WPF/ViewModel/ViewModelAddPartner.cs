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
using System.Data.Entity.Validation;

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
		/// <summary>
		/// Erreur
		/// </summary>
		private ObservableCollection<Erreur> _Erreur;
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
		/// <summary>
		/// Obtient ou définit les erreurs
		/// </summary>
		public ObservableCollection<Erreur> Erreur
		{
			get { return _Erreur; }
			set { _Erreur = value; }
		}
		#endregion

		#region Contructors
		/// <summary>
		/// Constructeur de l'ajout des clients
		/// </summary>
		/// <param name="entities"></param>
		public ViewModelAddPartner(MegaCastingEntities entities)
			: base(entities)
		{
			this.Entities.Villes.ToList();
			this.Villes = this.Entities.Villes.Local;
			this.Entities.Clients.ToList();
			this.Client = this.Entities.Clients.Local;
			this.Entities.Erreurs.ToList();
			this.Erreur = this.Entities.Erreurs.Local;
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
		/// Fonction de hashage des mots de passe
		/// </summary>
		/// <param name="rawData"></param>
		/// <returns></returns>
		static string ComputeSHAHash(string rawData)
		{
			int iterations = 100000;
			byte[] salt;
			new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
			Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(rawData, salt, iterations);
			byte[] hash = rfc2898DeriveBytes.GetBytes(20);
			byte[] hashByte = new byte[36];
			Array.Copy(salt, 0, hashByte, 0, 16);
			Array.Copy(hash, 0, hashByte, 16, 20);

			string b64Hash = Convert.ToBase64String(hashByte);

			return string.Format("$MYHASH$V1${0}${1}", iterations, b64Hash);
		}

		/// <summary>
		/// Ajoute un partenaire (limité par le Covid)
		/// </summary>
		/// <param name="login"></param>
		/// <param name="password"></param>
		/// <param name="libelle"></param>
		public bool AddPartner(string login, string password, string libelle)
		{
			bool boolPartner = false;
			if (!this.Entities.Clients.Any(partner => partner.Login == login))
			{
				string hashedpassword;
				if (password != "Mot de passe")
				{
					hashedpassword = ComputeSHAHash(password);
				}
				else
				{
					hashedpassword = password;
				}
				if (SelectedVille is null)
				{
					Erreur erreur = Erreur.Where(error => error.CodeErreur == "CI00000003").First();
					Affichebox(erreur.MessageFR, erreur.CodeErreur, MessageBoxButton.OK, MessageBoxImage.Error);
				}
				else
				{
					Client clients = new Client();
					try
					{
						clients.Login = login;
						SHA512 shahash = SHA512.Create();
						clients.Password = hashedpassword.ToString();
						clients.Libelle = libelle;
						clients.VilleIdentifiant = SelectedVille.Identifiant;
						this.Client.Add(clients);
						this.SaveChanges();
						MessageBox.Show("Client ajouté");
						boolPartner = true;
					}
					catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
					{
						this.Client.Remove(clients);
						MessageBox.Show(ex.InnerException.InnerException.Message.Replace(Environment.NewLine + "La transaction s'est terminée dans le déclencheur. Le traitement a été abandonné.", ""));
					}
					catch (System.Data.Entity.Validation.DbEntityValidationException ex)
					{
						Entities.ChangeTracker.Entries().Where(entry => entry.State == System.Data.Entity.EntityState.Modified).ToList().ForEach(e => e.Reload());
						foreach (DbEntityValidationResult error in ex.EntityValidationErrors)
						{
							foreach (DbValidationError item in error.ValidationErrors)
							{
								Affichebox(item.PropertyName + " : " + item.ErrorMessage);
							}
						}
						this.Client.Remove(clients);
					}
				}
			}
			else
			{
				Erreur erreur = Erreur.Where(error => error.CodeErreur == "CLI0000002").First();
				Affichebox(erreur.MessageFR, erreur.CodeErreur, MessageBoxButton.OK, MessageBoxImage.Error);
			}
			return boolPartner;
		}
		#endregion

	}
}
