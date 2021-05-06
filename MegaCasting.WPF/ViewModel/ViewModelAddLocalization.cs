using MegaCasting.DBlib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MegaCasting.WPF.ViewModel
{
    class ViewModelAddLocalization : ViewModelBase
    {     
        #region Attributes
        /// <summary>
        /// Collection de pays
        /// </summary>
        private ObservableCollection<Pay> _Pays;
        /// <summary>
        /// Collection de villes
        /// </summary>
        private ObservableCollection<Ville> _Villes;
        /// <summary>
        /// Pays sélectionné
        /// </summary>
        private Pay _SelectedPays;
        /// <summary>
        /// Collection d'erreur
        /// </summary>
        private ObservableCollection<Erreur> _Erreur;
        #endregion
        #region Properties
        /// <summary>
        /// Obtient ou définit la collection de pays
        /// </summary>
        public ObservableCollection<Pay> Pays
        {
            get { return _Pays; }
            set { _Pays = value; }
        }
        /// <summary>
        /// Obtient ou définit la collection de villes
        /// </summary>
        public ObservableCollection<Ville> Villes
        {
            get { return _Villes; }
            set { _Villes = value; }
        }
        /// <summary>
        /// Obtient ou définit le pays sélectionné
        /// </summary>
        public Pay SelectedPays
        {
            get { return _SelectedPays; }
            set { _SelectedPays = value; }
        }
        /// <summary>
        /// Obtient ou definit la collection d'erreur
        /// </summary>
        public ObservableCollection<Erreur> Erreur
        {
            get { return _Erreur; }
            set { _Erreur = value; }
        }
        #endregion
        #region Constructor
        public ViewModelAddLocalization(MegaCastingEntities entities)
            :base(entities)
        {
            this.Entities.Pays.ToList();
            this.Pays = this.Entities.Pays.Local;
            this.Entities.Villes.ToList();
            this.Villes = this.Entities.Villes.Local;
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
        /// Ajoute un pays
        /// </summary>
        /// <param name="pays"></param>
        public void AddCountry(string pays)
        {
            if (!this.Entities.Pays.Any(country => country.Libelle == pays))
            {
                Pay pay = new Pay();
                Erreur erreur = Erreur.Where(error => error.CodeErreur == "CO20000001").First();
                try
                {
                    pay.Libelle = pays;
                    this.Pays.Add(pay);
                    this.SaveChanges();
                    Affichebox(erreur.MessageFR);
                }
                catch(DbUpdateException due)
                {
                    MessageBox.Show(due.InnerException.InnerException.Message.Replace(Environment.NewLine + "La transaction s'est terminée dans le déclencheur. Le traitement a été abandonné.", ""));
                }
                catch(DbEntityValidationException deve)
                {
                    foreach (DbEntityValidationResult error in deve.EntityValidationErrors)
                    {
                        foreach (DbValidationError item in error.ValidationErrors)
                        {
                            Affichebox(item.PropertyName + " : " + item.ErrorMessage);
                        }
                    }
                    Entities.Pays.Remove(pay);
                }

            }
            else
            {
                Erreur erreur = Erreur.Where(error => error.CodeErreur == "CO20000002").First();
                Affichebox(erreur.MessageFR, erreur.CodeErreur, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// Ajoute une ville
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="codePostal"></param>
        /// <param name="identifiantPays"></param>
        public void AddCity(string nom, string codePostal)
        {
            if (!this.Entities.Villes.Any(ville => ville.CodePostal == codePostal))
            {
                Erreur erreur = Erreur.Where(error => error.CodeErreur == "CI00000001").First();
                Ville ville = new Ville();
                try
                { 
                    ville.Libelle = nom;
                    ville.CodePostal = codePostal.ToUpper();
                    ville.IdentifiantPays = SelectedPays.Identifiant;
                    this.Villes.Add(ville);
                    this.SaveChanges();
                    Affichebox(erreur.MessageFR, erreur.CodeErreur, MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (DbUpdateException due)
                {
                    MessageBox.Show(due.InnerException.InnerException.Message.Replace(Environment.NewLine + "La transaction s'est terminée dans le déclencheur. Le traitement a été abandonné.", ""));
                    Entities.Villes.Remove(ville);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message + Environment.NewLine + ex.Data + Environment.NewLine + ex.Source + Environment.NewLine + ex.StackTrace);
                }
            }
            else
            {
                Erreur erreur = Erreur.Where(error => error.CodeErreur == "CI00000001").First();
                Affichebox(erreur.MessageFR, erreur.CodeErreur, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion
    }
}
