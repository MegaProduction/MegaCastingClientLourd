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
    class ViewModelEditOffer : ViewModelBase
    {
        #region Attributes
        /// <summary>
        /// Collection d'offre 
        /// </summary>
        private ObservableCollection<Offre> _Offres;
        /// <summary>
        /// Collection des villes
        /// </summary>
        private ObservableCollection<Ville> _Villes;
        /// <summary>
        /// Collection des contrats
        /// </summary>
        private ObservableCollection<Contrat> _Contrats;
        /// <summary>
        /// Offre sélectionnée
        /// </summary>
        private Offre _SelectedOffre;
        #endregion
        #region Properties
        /// <summary>
        /// Obtient ou définit la collection d'offre
        /// </summary>
        public ObservableCollection<Offre> Offres
        {
            get { return _Offres; }
            set { _Offres = value; }
        }
        /// <summary>
        /// Obtient ou définit la collection des villes
        /// </summary>
        public ObservableCollection<Ville> Villes
        {
            get { return _Villes; }
            set { _Villes = value; }
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
        /// Obtient ou définit l'offre sélectionnée
        /// </summary>
        public Offre SelectedOffre
        {
            get { return _SelectedOffre; }
            set { _SelectedOffre = value; }
        }

        #endregion
        #region Construteur
        /// <summary>
        /// Constructeur de l'édition des offres
        /// </summary>
        /// <param name="entities"></param>
        public ViewModelEditOffer(MegaCastingEntities entities) : base(entities)
        {
            this.Entities.Offres.ToList();
            this.Offres = this.Entities.Offres.Local;
            this.Entities.Villes.ToList();
            this.Villes = this.Entities.Villes.Local;
            this.Entities.Contrats.ToList();
            this.Contrats = this.Entities.Contrats.Local;
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
        /// Edit l'offre sélectionné
        /// </summary>
        public void EditOffer()
        {
            this.SaveChanges();
        }
        /// <summary>
        /// Vérifie si le champs est vide, null ou composé unique d'espace blanc
        /// </summary>
        /// <param name="input">champs a check si : vide, null ou se compose unique d'espace blanc</param>
        /// <returns></returns>
        public bool CheckName(string input)
        {
            bool result = false;
            if (!string.IsNullOrWhiteSpace(input))
            {
                result = true;
            }
            return result;
        }
        #endregion

    }
}
