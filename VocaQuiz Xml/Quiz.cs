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
//  Date : 02.07.2015
//  Maj : 14.08.2015
//
//  Classe permettant de gérer le quiz
//  -------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocaQuiz
{
    /// <summary>
    /// Permet d'indiquer dans quel mode le quiz est configuré
    /// </summary>
    public enum QuizMode { NORMAL, CHRONO};

    /// <summary>
    /// Classe permettant de gérer le quiz
    /// </summary>
    public class Quiz
    {
        private GestionnaireVoc gestVoc;            // Gestionnaire de vocabulaire
        private Random genAlea = null;              // Générateur de nombre aléatoire

        private QuizMode mode = QuizMode.NORMAL;    // Indique le mode du quiz (par défaut : normal)
        private int nombreMots = 0;                 // Nombre de mots pour une séquence (Mode normal)
        private int temps = 0;                      // Temps en secondes pour une séquence (Mode chrono)

        private string langueOrigine = null;        // Langue d'origine
        private string langueTrad = null;           // Langue de traduction
        private Mot motTeste = null;                // Mot testé
        private Mot traduction = null;              // Traduction du mot
        List<Mot> listeMotsLangueOrigine = null;    // Liste de mots dans la langue d'origine qui ont des traductions

        private int cptReponses = 0;            // Nombre de réponses entrées
        private int tempsPasse = 0;             // Indique le temps passé en secondes durant la séquence
        private int nbreRepCorrectes = 0;       // Nombre de réponses correctes
        private int nbreRepFausses = 0;         // Nombre de réponses fausses
        private int pourcentageRepJustes = 0;   // Pourcentage de réponses justes

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Quiz(GestionnaireVoc gestVoc)
        {
            // Sauvegarde le gestionnaire de vocabulaire
            this.gestVoc = gestVoc;

            // Créer un nouveau générateur de nombre aléatoire
            genAlea = new Random();
        }

        /// <summary>
        /// Permet d'initialiser les champs nécessaire à une nouvelle séquence
        /// </summary>
        public void Initialiser()
        {
            // Remet à zéro les statistiques et les compteurs
            cptReponses = 0;
            tempsPasse = 0;
            nbreRepCorrectes = 0;
            nbreRepFausses = 0;
            pourcentageRepJustes = 0;
        }

        /// <summary>
        /// Permet de savoir si le vocabulaire des deux langues est existant
        /// </summary>
        /// <returns>Validité du vocabulaire des deux langues</returns>
        public bool VerifierValiditeVocs()
        {
            bool resultat = false;

            // Obtient les mots qui ont des traductions pour la langue choisie
            listeMotsLangueOrigine = gestVoc.ObtenirMotsAvecTraductionsExistantes(langueOrigine, langueTrad);

            // Vérifie que la liste ne soit pas vide
            resultat = listeMotsLangueOrigine.Count != 0;

            // Retourne le résultat
            return resultat;
        }

        /// <summary>
        /// Permet d'obtenir un mot aléatoire
        /// </summary>
        /// <returns>Mot choisi aléatoirement</returns>
        public void ChoisirMotAleatoire()
        {
            int indexGenere = 0;                        // Index généré
            int nombreMotsListe = 0;                    // Nombre de mots contenu dans la liste            

            // Obtient le nombre de mots contenu dans la liste
            nombreMotsListe = listeMotsLangueOrigine.Count;

            // Génère un index aléatoire
            indexGenere = genAlea.Next(0, nombreMotsListe);

            // Obtient le mot à traduire
            motTeste = listeMotsLangueOrigine[indexGenere];
        }

        /// <summary>
        /// Permet de vérifier la traduction d'un mot
        /// </summary>
        /// <param name="repTraduction">Réponse donnée par l'utilisateur</param>
        /// <returns>Résultat de la vérification</returns>
        public bool VerifierTraduction(string repTraduction)
        {
            bool repCorrecte = false;   // Indique si la traduction est correcte

            // Obtient la traduction réelle du mot
            traduction = gestVoc.ObtenirTraduction(motTeste, langueTrad);

            // Vérifie que la traduction est correcte
            repCorrecte = repTraduction == traduction.Nom;

            // Incérmente le nombre de réponses
            cptReponses++;

            // Incrémente le nombre de réponses correctes ou fausses
            if (repCorrecte)
                nbreRepCorrectes++;
            else
                nbreRepFausses++;

            // Retourne la résultat de la vérification
            return repCorrecte;
        }

        /// <summary>
        /// Permet de calculer le pourcentage de réponses justes
        /// </summary>
        /// <returns>Pourcentage de réussite</returns>
        public int CalculerPourcentageRepJustes()
        {
            // Envoie une erreur si le nombre de mots est à 0
            if (nombreMots == 0)
                throw new DivideByZeroException("Division par 0 !");

            // Retourne le résultat du calcul
            return pourcentageRepJustes = (100 * nbreRepCorrectes) / nombreMots;
        }

        /// <summary>
        /// Permet d'obtenir le gestionnaire de voc
        /// </summary>
        public GestionnaireVoc GestVoc
        {
            get { return gestVoc; }
            set { gestVoc = value; }
        }

        /// <summary>
        /// Permet d'obtenir ou de modifier le mode
        /// </summary>
        public QuizMode Mode
        {
            get { return mode; }
            set { mode = value; }
        }

        /// <summary>
        /// Permet d'obtenir ou de modifier le nombre de mots  de la séquence
        /// </summary>
        public int NombreMots
        {
            get { return nombreMots; }
            set { nombreMots = value; }
        }

        /// <summary>
        ///  Permet d'obtenir ou de modifier le temps de la séquence
        /// </summary>
        public int Temps
        {
            get { return temps; }
            set { temps = value; }
        }

        /// <summary>
        /// Permet d'obtenir ou de modifier la langue d'origine
        /// </summary>
        public string LangueOrigine
        {
            get { return langueOrigine; }
            set { langueOrigine = value; }
        }

        /// <summary>
        /// Permet d'obtenir ou de modifier la langue de traduction
        /// </summary>
        public string LangueTrad
        {
            get { return langueTrad; }
            set { langueTrad = value; }
        }

        /// <summary>
        /// Permet d'obtenir le mot testé
        /// </summary>
        public Mot MotTeste
        {
            get { return motTeste; }
        }

        /// <summary>
        /// Permet d'obtenir la traduction
        /// </summary>
        public Mot Traduction
        {
            get { return traduction; }
        }

        /// <summary>
        /// Permet d'obtenir le compteur de mots
        /// </summary>
        public int CptReponses
        {
            get { return cptReponses; }
            set { cptReponses = value; }
        }

        /// <summary>
        /// Permet d'obtenir ou de modifier le temps passé
        /// </summary>
        public int TempsPasse
        {
            get { return tempsPasse; }
            set { tempsPasse = value; }
        }

        /// <summary>
        /// Permet d'obtenir le nombre de réponses correctes
        /// </summary>
        public int NbreRepCorrectes
        {
            get { return nbreRepCorrectes; }
        }

        /// <summary>
        /// Permet d'obtenir le nombre de réponses fausses
        /// </summary>
        public int NbreRepFausses
        {
            get { return nbreRepFausses; }
        }
    }
}
