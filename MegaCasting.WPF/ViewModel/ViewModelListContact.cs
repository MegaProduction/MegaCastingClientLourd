using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MegaCasting.DBlib;

namespace MegaCasting.WPF.ViewModel
{
    class ViewModelListContact : ViewModelBase
    {
        #region Attributes
        /// <summary>
        /// Collection de Contact
        /// </summary>
        private ObservableCollection<Contact> _Contact;
        /// <summary>
        /// Contact sélectionné
        /// </summary>
        private Contact _SelectedContact;
        #endregion
        #region Properties
        /// <summary>
        /// Obtient ou définit la collection de Contact
        /// </summary>
        public ObservableCollection<Contact> Contacts
        {
            get { return _Contact; }
            set { _Contact = value; }
        }
        /// <summary>
        /// Obtient ou définit le contact sélectionné
        /// </summary>
        public Contact SelectedContact
        {
            get { return _SelectedContact; }
            set { _SelectedContact = value; }
        }
        #endregion
        #region Construtor
        /// <summary>
        /// Constructeur de la liste de contacts
        /// </summary>
        /// <param name="entities"></param>
        public ViewModelListContact(MegaCastingEntities entities) : base(entities)
        {
            this.Entities.Contacts.ToList();
            this.Contacts = this.Entities.Contacts.Local;
        }
        #endregion
    }
}
