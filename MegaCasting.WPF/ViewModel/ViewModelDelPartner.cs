using MegaCasting.DBlib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
			this.Clients.Remove(SelectedClient);
			this.SaveChanges();
		}

		public bool VerifPartner(string login)
		{
			bool returnValid = false;
			if (string.IsNullOrWhiteSpace(login) != true)
			{
				returnValid = true;
			}
			return returnValid;
		}
		#endregion

	}
}
