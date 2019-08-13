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
//  Date : 30.06.2015
//  Maj : 02.07.2015
//
//  Classe abstraite permettant de définir les méthodes à redéfinir dans les
//  classes héritières
//  --------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocaQuiz
{
    public abstract class GestionnaireVoc
    {
        protected List<string> listeLangues = new List<string>();   // Liste des langues disponibles

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public GestionnaireVoc()
        {
        }

        /// <summary>
        /// Permet d'accéder au vocabulaire en indiquant un nom de table ou de fichier
        /// </summary>
        /// <param name="fichierTable">Nom du fichier ou de la table à consulter</param>
        public abstract void AccederVoc(string fichierTable);

        /// <summary>
        /// Permet de créer un nouveau mot dans n'importe quelle langue
        /// </summary>
        /// <param name="nouveauMot">Nouveaut mot à créer</param>
        /// <returns>Retourne l'id du mot créé</returns>
        public abstract int CreerMot(Mot nouveauMot);

        /// <summary>
        /// Permet de modifier un mot existant
        /// </summary>
        /// <param name="motAModifier">Mot à modifier</param>
        /// <param name="motModifie">Mot avec les caractéristiques modifiées</param>
        /// <returns>Mot modifié</returns>
        public abstract Mot ModifierMot(Mot motAModifier, Mot motModifie);

        /// <summary>
        /// Permet de supprimer un mot
        /// </summary>
        /// <param name="motASupp">Mot à supprimer</param>
        public abstract void SupprimerMot(Mot motASupp);

        /// <summary>
        /// Permet d'ajouter une traduction à un mot dans une langue
        /// </summary>
        /// <param name="motATraduire">Mot à traduire</param>
        /// <param name="Traduction">Traduction du mot</param>
        public abstract void AjouterTraduction(Mot motATraduire, Mot Traduction);

        /// <summary>
        /// Permet d'effacer une traduction pour un mot
        /// </summary>
        /// <param name="traductionASupp">Traduction à supprimer</param>
        public abstract void EffacerTraduction(Mot traductionASupp);

        /// <summary>
        /// Permet d'obtenir une traduction d'un mot
        /// </summary>
        /// <param name="motATraduire">Mot à traduire</param>
        /// <param name="langueTraduction">Langue dans laquelle traduire</param>
        /// <returns>Mot traduit</returns>
        public abstract Mot ObtenirTraduction(Mot motATraduire, string langueTraduction);

        /// <summary>
        /// Permet d'obtenir tous les mots d'une langue
        /// </summary>
        /// <param name="langue">Langue des mots à obtenir</param>
        /// <returns>Liste de mots dans une langue</returns>
        public abstract List<Mot> ObtenirTousMotsDansUneLangue(string langue);

        /// <summary>
        /// Permet d'obtenir toutes les traductions d'un mot
        /// </summary>
        /// <param name="motATraduire">Mot à traduire</param>
        /// <returns>Liste de toutes les traductions d'un mot</returns>
        public abstract List<Mot> ObtenirToutesTraductions(Mot motATraduire);

        /// <summary>
        /// Permet d'obtenir le nombre total de mot
        /// </summary>
        /// <returns>Nombre de mots</returns>
        public abstract int ObtenirNombreMots();

        /// <summary>
        /// Permet de chercher un mot par l'index
        /// </summary>
        /// <param name="index">Index d'une liste, d'un tableau</param>
        /// <param name="langue">Langue du mot</param>
        /// <returns>Mot correspondant à l'index</returns>
        public abstract Mot ChercherMotParIndex(int index, string langue);

        /// <summary>
        /// Permet de sauvegarder les informations
        /// </summary>
        public abstract void SauvegarderVoc();

        /// <summary>
        /// Permet d'obtenir la liste de mots ayant des traductions
        /// </summary>
        /// <param name="langue">Langue d'origine</param>
        /// <param name="langueTrad">Langue de traduction</param>
        /// <returns>Liste de mots ayant des traduction</returns>
        public abstract List<Mot> ObtenirMotsAvecTraductionsExistantes(string langue, string langueTraduction);

        /// <summary>
        /// Permet d'obtenir l'abréviation d'une langue
        /// </summary>
        /// <param name="langue">Nom de la langue</param>
        /// <returns>Abréviation de la langue</returns>
        public string ObtenirAbreviationLangue(string langue)
        {
            string abreviationLangue;   // Contient l'abréviation de la langue

            // Prend les deux premières lettres de la langue
            abreviationLangue = langue.Substring(0, 2);

            // Modifie les caractères en minuscule
            abreviationLangue = abreviationLangue.ToLower();

            // Retourne l'abréviation de la langue
            return abreviationLangue;
        }

        /// <summary>
        ///  Permet d'obtenir les langues
        /// </summary>
        /// <returns></returns>
        public List<string> ListeLangues
        {
            get { return listeLangues; }
        }
    }
}
