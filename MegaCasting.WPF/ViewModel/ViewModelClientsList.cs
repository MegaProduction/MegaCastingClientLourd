using MegaCasting.DBlib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCasting.WPF.ViewModel
{
    public class ViewModelClientsList : ViewModelBase
    {
		#region Attrributes
		/// <summary>
		/// Collection des clients
		/// </summary>
		private ObservableCollection<Client> _Clients;
		/// <summary>
		/// 
		/// </summary>
		private Client _SelectedClient;
		#endregion
		#region Properties
		/// <summary>
		/// Obtient ou définit la collection des clients
		/// </summary>
		public ObservableCollection<Client> Clients
		{
			get { return _Clients; }
			set { _Clients = value; }
		}

		/// <summary>
		/// Obtient ou définit le client sélectionné
		/// </summary>
		public Client SelectedClient
		{
			get { return _SelectedClient; }
			set { _SelectedClient = value; }
		}
		#endregion
		public ViewModelClientsList(MegaCastingEntities entities)
			: base(entities)
		{
			this.Clients = new ObservableCollection<Client>();
			foreach (Client client in this.Entities.Clients)
			{
				this.Clients.Add(client);
			}
		}
	}
}
