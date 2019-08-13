/*
____   ____                               .__        
\   \ /   /___   ____ _____    ________ __|__|_______
 \   Y   /  _ \_/ ___\\__  \  / ____/  |  \  \___   /
  \     (  <_> )  \___ / __ \< <_|  |  |  /  |/    / 
   \___/ \____/ \___  >____  /\__   |____/|__/_____ \
                    \/     \/    |__|              \/
*/
//  --------------------------------------------------------------------------
//  Auteur : Fleury Malik
//  Date : 01.07.2015
//  Maj : 01.07.2015
//
//  Classe permettant de regrouper les informations d'un mot dans une langue;
//  Nom, définition et langue
//  -------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocaQuiz
{
    /// <summary>
    /// Structure contenant les éléments d'un mot
    /// </summary>
    public class Mot
    {
        private int idUnique;       // Id unique du mot
        private string nom;         // Nom du mot
        private string definition;  // Définition du mot
        private string langue;      // Langue du mot

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Mot()
        {
        }

        /// <summary>
        /// Constructeur surchargé permettant de définir un mot sans sa définition
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="langue"></param>
        public Mot(string nom, string langue)
        {
            this.nom = nom;
            this.langue = langue;
        }

        /// <summary>
        /// Constructeur surchargé permettant de définir le nom et la définition sans la langue
        /// </summary>
        /// <param name="nom">Nom du mot</param>
        /// <param name="definition">Définition du mot</param>
        /*public Mot(string nom, string definition)
        {
        }*/

        /// <summary>
        /// Constructeur surchargé permettant de définir un nouveau mot
        /// </summary>
        /// <param name="nom">Nom du mot</param>
        /// <param name="definition">Définition du mot</param>
        /// <param name="langue">Langue du mot</param>
        public Mot(string nom, string definition, string langue)
        {
            this.nom = nom;
            this.definition = definition;
            this.langue = langue;
        }

        /// <summary>
        /// Constructeur surchargé permettant de définir un nouveau mot avec son id
        /// </summary>
        /// <param name="id">Id unique</param>
        /// <param name="nom">Nom du mot</param>
        /// <param name="definition">Définition du mot</param>
        /// <param name="langue">Langue du mot</param>
        public Mot(int id, string nom, string definition, string langue)
        {
            this.idUnique = id;
            this.nom = nom;
            this.definition = definition;
            this.langue = langue;
        }

        /// <summary>
        /// Permet d'afficher le nom du mot
        /// </summary>
        /// <returns>Nom du mot</returns>
        public override string ToString()
        {
            return nom;
        }

        /// <summary>
        /// Permet d'obtenir ou de modifier l'id
        /// </summary>
        public int IdUnique
        {
            get { return idUnique;}
            set { idUnique = value;}
        }

        /// <summary>
        /// Permet d'obtenir ou de modifier le nom du mot
        /// </summary>
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        /// <summary>
        /// Permet d'obtenir ou de modifier la définition du mot
        /// </summary>
        public string Definition
        {
            get { return definition; }
            set { definition = value; }
        }

        /// <summary>
        /// Permet d'obtenir ou de modifier la langue du mot
        /// </summary>
        public string Langue
        {
            get { return langue; }
            set { langue = value; }
        }
    }
}
