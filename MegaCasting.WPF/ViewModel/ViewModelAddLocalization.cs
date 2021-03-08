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
        #endregion
        #region Constructor
        public ViewModelAddLocalization(MegaCastingEntities entities)
            :base(entities)
        {
            this.Entities.Pays.ToList();
            this.Pays = this.Entities.Pays.Local;
            this.Entities.Villes.ToList();
            this.Villes = this.Entities.Villes.Local;
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
                if (VerifCountry(pays))
                {
                    Pay pay = new Pay();
                    pay.Libelle = pays;
                    this.Pays.Add(pay);
                    this.SaveChanges();
                    MessageBox.Show("Pays ajouté");
                }
                else
                {
                    MessageBox.Show("Erreur de saisie");
                }
            }
            else
            {
                MessageBox.Show("Pays déjà présent dans la base de données");
            }
        }
        /// <summary>
        /// Ajoute une ville
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="codePostal"></param>
        /// <param name="identifiantPays"></param>
        public void AddCity(string nom, string codePostal, string identifiantPays)
        {
            if (!this.Entities.Villes.Any(ville => ville.CodePostal == codePostal))
            {
            bool idPays = int.TryParse(identifiantPays, out int paysId);
                if (VerifCity(nom, codePostal, idPays))
                {
                    Ville ville = new Ville();
                    ville.Libelle = nom;
                    ville.CodePostal = codePostal.ToUpper();
                    ville.IdentifiantPays = paysId;
                    this.Villes.Add(ville);
                    this.SaveChanges();
                    MessageBox.Show("Ville ajoutée");
                }
                else
                {
                    MessageBox.Show("Erreur de saisie");
                }
            }
            else
            {
                MessageBox.Show("Ville déjà présente dans la base de données");
            }
        }
        /// <summary>
        /// Verification des champs pour le pays
        /// </summary>
        /// <param name="pays"></param>
        /// <returns></returns>
        public bool VerifCountry(string pays)
        {
            bool returnValid = false;
            if (string.IsNullOrWhiteSpace(pays) != true && pays != "Pays")
            {
                returnValid = true;
            }
            return returnValid;
        }
        /// <summary>
        /// Vérification des champs pour la ville
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="codePostal"></param>
        /// <param name="idPays"></param>
        /// <returns></returns>
        public bool VerifCity(string nom, string codePostal, bool idPays)
        {
            bool returnValid = false;
            if (string.IsNullOrWhiteSpace(nom) != true && string.IsNullOrWhiteSpace(codePostal) != true && idPays)
            {
                returnValid = true;
            }
            return returnValid;
        }
        #endregion
    }
}
