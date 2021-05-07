using MegaCasting.DBlib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MegaCasting.WPF.ViewModel
{
    class ViewModelEditPartner : ViewModelBase
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
		/// <summary>
		/// Constructeur de l'édition des clients
		/// </summary>
		/// <param name="entities"></param>
		public ViewModelEditPartner(MegaCastingEntities entities)
			: base(entities)
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
		/// Édite un client
		/// </summary>
		/// <param name="libelle"></param>
		public void EditPartner(string libelle)
		{
			try
			{
				this.SaveChanges();
				MessageBox.Show("Client modifié.");
			}
			catch (DbUpdateException due)
			{
				Entities.ChangeTracker.Entries().Where(entry => entry.State == System.Data.Entity.EntityState.Modified).ToList().ForEach(e => e.Reload());
				MessageBox.Show(due.InnerException.InnerException.Message.Replace(Environment.NewLine + "La transaction s'est terminée dans le déclencheur. Le traitement a été abandonné.", ""));
			}
			catch (System.Data.Entity.Validation.DbEntityValidationException deve)
			{
				Entities.ChangeTracker.Entries().Where(entry => entry.State == System.Data.Entity.EntityState.Modified).ToList().ForEach(e => e.Reload());
				foreach (DbEntityValidationResult error in deve.EntityValidationErrors)
				{
					foreach (DbValidationError item in error.ValidationErrors)
					{
						MessageBox.Show(item.PropertyName + " : " + item.ErrorMessage);
					}
				}
			}
		}
		#endregion

	}
}
