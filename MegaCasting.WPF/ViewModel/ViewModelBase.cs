using MegaCasting.DBlib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MegaCasting.WPF.ViewModel
{
    /// <summary>
    /// Class ViewModelBase viewModel de base pour le contexte de l'application
    /// </summary>
    public class ViewModelBase
    {
        #region Attributes

        /// <summary>
        /// Contexte de l'application
        /// </summary>
        private MegaCastingEntities _Entities;

        #endregion
        #region Properties
        /// <summary>
        /// Obtient ou défini le contexte de l'application
        /// </summary>
        public MegaCastingEntities Entities
        {
            get { return _Entities; }
            set { _Entities = value; }
        }

        #endregion

        #region Contructeur
        /// <summary>
        /// Constructeur de base 
        /// </summary>
        /// <param name="entities">Contexte de l'application</param>
        public ViewModelBase(MegaCastingEntities entities)
        {
            this.Entities = entities;
        }
        #endregion
        #region Method
        /// <summary>
        /// Affiche une MessageBox avec le message
        /// </summary>
        /// <param name="message">message a afficher</param>
        public void Affichebox(string message)
        {
            MessageBox.Show(message);
        }
        /// <summary>
        /// Affiche une MessageBox avec le message et un code
        /// </summary>
        /// <param name="message">message a affiche</param>
        /// <param name="code">code a affiche</param>
        public void Affichebox(string message, string code)
        {
            MessageBox.Show(message, code);
        }
        /// <summary>
        /// Affiche une MessageBox avec le message, un code et un type de boutton
        /// </summary>
        /// <param name="message">message a affiche</param>
        /// <param name="code">code a affiche</param>
        /// <param name="button">type de boutton du messageBox</param>
        public void Affichebox(string message, string code, MessageBoxButton button)
        {
            MessageBox.Show(message, code, button);
        }
        /// <summary>
        /// Affiche une MessageBox avec le message, un code, un type de boutton et un type d'image
        /// </summary>
        /// <param name="message">message a affiche</param>
        /// <param name="code">code a affiche</param>
        /// <param name="button">type de boutton du messageBox</param>
        /// <param name="image">type d'image du messageBox</param>
        public void Affichebox(string message, string code, MessageBoxButton button, MessageBoxImage image)
        {
            MessageBox.Show(message, code, button, image);
        }
        #endregion
    }
}
