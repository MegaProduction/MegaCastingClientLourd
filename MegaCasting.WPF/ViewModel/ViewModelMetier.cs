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
    class ViewModelMetier : ViewModelBase
    {
        private ObservableCollection<Erreur> _Erreurs;

        public ObservableCollection<Erreur> Erreurs
        {
            get { return _Erreurs; }
            set { _Erreurs = value; }
        }

        #region Attributes
        /// <summary>
        /// Collection de Metier
        /// </summary>
        private ObservableCollection<Metier> _Metier;
        /// <summary>
        /// Metier Sélectionné
        /// </summary>
        private Metier _SelectedMetier;
        /// <summary>
        /// Collection d'offre
        /// </summary>
        private ObservableCollection<Domaine> _Domaines;
        private Domaine _SelectedDomaine;




        #endregion
        #region Properties
        /// <summary>
        /// Obtient ou définit la collection de Metier
        /// </summary>
        public ObservableCollection<Metier> Metiers
        {
            get { return _Metier; }
            set { _Metier = value; }
        }
        /// <summary>
        /// Obtient ou définit le Metier sélectionné
        /// </summary>
        public Metier SelectedMetier
        {
            get { return _SelectedMetier; }
            set { _SelectedMetier = value; }
        }
        /// <summary>
        /// Obtient ou définit la collection d'offre
        /// </summary>
        public ObservableCollection<Domaine> Domaines
        {
            get { return _Domaines; }
            set { _Domaines = value; }
        }
        public Domaine SelectedDomaine
        {
            get { return _SelectedDomaine; }
            set { _SelectedDomaine = value; }
        }
        #endregion
        #region Construteur
        public ViewModelMetier(MegaCastingEntities entities) : base(entities)
        {
            this.Entities.Metiers.ToList();
            this.Metiers = this.Entities.Metiers.Local;
            this.Entities.Domaines.ToList();
            this.Domaines = this.Entities.Domaines.Local;
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
        /// Ajoute un Metier
        /// </summary>
        /// <param name="name">Nom du Metier à ajouter</param>
        public void AddMetier(string name, string fiche)
        {
                Metier metier = new Metier();
                try
                {
                    metier.Libelle = name;
                    metier.Fiche = fiche;
                    metier.IdentifiantDomaine = SelectedDomaine.Identifiant;
                    Metiers.Add(metier);
                    this.SaveChanges();
                    MessageBox.Show("Métier ajouté");

                }
                catch (DbUpdateException dbue)
                {
                    MessageBox.Show(dbue.InnerException.InnerException.Message.Replace(Environment.NewLine + "La transaction s'est terminée dans le déclencheur. Le traitement a été abandonné.", ""));
                    Metiers.Remove(metier);
                }
        }
        /// <summary>
        /// Supprime le Metier sélectionné
        /// </summary>
        public void DeleteMetier()
        {
            if (SelectedMetier != null)
            {
                try
                {
                    //Vérification si on a le droit de supprimer
                    //if (!Metiers.Any(domaine => domaine.IdentifiantDomaine == SelectedMetier.Identifiant))
                    //{
                        this.Metiers.Remove(SelectedMetier);
                        this.SaveChanges();
                        MessageBox.Show("Métier supprimé");
                //    }
                //    else
                //    {
                //        MessageBox.Show("Ce métier est utilisé");
                //    }
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
                MessageBox.Show("Aucun métier sélectionné");
            }
        }
        public void UpdateMetier()
        {
            try
            {
                this.SaveChanges();
                MessageBox.Show("Métier édité");
            }
            catch (DbUpdateException)
            {
                //Permet de reload la liste des contracts
                Entities.ChangeTracker.Entries().Where(entry => entry.State == System.Data.Entity.EntityState.Modified).ToList().ForEach(e => e.Reload());
                MessageBox.Show("Impossible d'éditer le métier sélectionné");
            }
            catch (DbEntityValidationException deve)
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
