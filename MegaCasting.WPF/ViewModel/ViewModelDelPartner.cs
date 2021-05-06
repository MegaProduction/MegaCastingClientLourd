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

namespace MegaCasting.WPF.ViewModel
{
    class ViewModelDelPartner : ViewModelBase
    {

		#region Attributes
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
		///
		#endregion

		#region Constructors

		public ViewModelDelPartner(MegaCastingEntities entities)
			:base(entities)
		{
			this.Entities.Clients.ToList();
			this.Clients = this.Entities.Clients.Local;
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

		public void DelPartner()
		{
			if (SelectedClient != null)
			{
				try
				{
					this.Clients.Remove(SelectedClient);
					this.SaveChanges();
					MessageBox.Show("Client supprimé");
				}
				catch (DbUpdateException due)
				{
					MessageBox.Show(due.InnerException.InnerException.Message.Replace(Environment.NewLine + "La transaction s'est terminée dans le déclencheur. Le traitement a été abandonné.", ""));
				}
				catch (DbEntityValidationException deve)
				{
					foreach (DbEntityValidationResult error in deve.EntityValidationErrors)
					{
						foreach (DbValidationError item in error.ValidationErrors)
						{
							MessageBox.Show(item.PropertyName + " : " + item.ErrorMessage);
						}
					}
				}
			}
			else
			{
				MessageBox.Show("Aucun client sélectionné");
			}
		}
		#endregion

	}
}
