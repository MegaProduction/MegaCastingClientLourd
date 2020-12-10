using MegaCasting.DBlib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MegaCasting.WPF.ViewModel
{
    class ViewModelContrat : ViewModelBase
    {

        #region Attributes
        /// <summary>
        /// Collection de contrat
        /// </summary>
        private ObservableCollection<Contrat> _Contrat;
        /// <summary>
        /// COntrat Sélectionné
        /// </summary>
        private Contrat _SelectedContrat;
        /// <summary>
        /// Collection d'offre
        /// </summary>
        private ObservableCollection<Offre> _Offres;

        #endregion
        #region Properties
        /// <summary>
        /// Obtient ou définit la collection de contrat
        /// </summary>
        public ObservableCollection<Contrat> Contrats
        {
            get { return _Contrat; }
            set { _Contrat = value; }
        }
        /// <summary>
        /// Obtient ou définit le contrat sélectionné
        /// </summary>
        public Contrat SelectedContrat
        {
            get { return _SelectedContrat; }
            set { _SelectedContrat = value; }
        }
        /// <summary>
        /// Obtient ou définit la collection d'offre
        /// </summary>
        public ObservableCollection<Offre> Offres
        {
            get { return _Offres; }
            set { _Offres = value; }
        }
        #endregion
        #region Construteur
        public ViewModelContrat(MegaCastingEntities entities) : base(entities)
        {
            this.Entities.Contrats.ToList();
            this.Contrats = this.Entities.Contrats.Local;
            this.Entities.Offres.ToList();
            this.Offres = this.Entities.Offres.Local;
        }
        #endregion
        #region Method
        /// <summary>
        /// Sauvegarde les changements
        /// </summary>
        public void SaveChanges()
        {
            this.Entities.SaveChanges();
        }
        /// <summary>
        /// Ajoute un contrat
        /// </summary>
        /// <param name="name">Nom du contrat à ajouter</param>
        public void AddContrat(string name)
        {
            if (!this.Entities.Contrats.Any(contrat => contrat.Libelle == name))
            {
                Contrat contrat = new Contrat();
                contrat.Libelle = name;
                try
                {
                    Contrats.Add(contrat);
                    this.SaveChanges();
                    MessageBox.Show("Contrat ajouté");
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException)
                {
                    Contrats.Remove(contrat);
                    MessageBox.Show("Une erreur c\'est produite lors de la saisie");
                }
            }
            else
            {
                MessageBox.Show("Ce contrat existe déjà");
            }
        }
        /// <summary>
        /// Supprime le contrat sélectionné
        /// </summary>
        public void DeleteContrat()
        {
            //Vérification si on a le droit de supprimer
            if (!Offres.Any(offre => offre.IdentifiantContrat == SelectedContrat.Identifiant))
            {
                this.Contrats.Remove(SelectedContrat);
                this.SaveChanges();
                MessageBox.Show("Contrat supprimée");
            }
            else
            { 
                MessageBox.Show("Ce contrat est utilisé dans une offre");
            }       
        }
        public void UpdateContrat()
        {
            try
            {
                this.SaveChanges();
                MessageBox.Show("Nom du contrat éditer");
            }
            catch (DbUpdateException)
            {
                //Permet de reload la liste des contracts
                Entities.ChangeTracker.Entries().Where(entry => entry.State == System.Data.Entity.EntityState.Modified).ToList().ForEach(e => e.Reload());
                MessageBox.Show("Impossible d'éditer le nom du contrat sélectionné");
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException)
            {
      
                Entities.ChangeTracker.Entries().Where(entry => entry.State == System.Data.Entity.EntityState.Modified).ToList().ForEach(e => e.Reload());
                MessageBox.Show("Nom du contrat trop grand : le maximun est de 50 caractère ");
            }
        }
        #endregion
    }
}
