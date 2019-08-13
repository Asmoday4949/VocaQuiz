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
//  Maj : 19.08.2015
//
//  Classe permettant de gérer les composants graphiques du gestionnaire de
//  voc.
//  -------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VocaQuiz
{
    public partial class Frm_GestionVoc : Form
    {
        private GestionnaireVoc gestVoc;     // Permet d'obtenir/gérer le vocabulaire dans la base de données

        /// <summary>
        /// Constructeur surchargé permettant de passer le gestionnaire de vocabulaire
        /// </summary>
        /// <param name="gestVoc">Gestionnaire de vocabulaire</param>
        public Frm_GestionVoc(GestionnaireVoc gestVoc)
        {
            // Paramètres les composants graphiques
            InitializeComponent();

            // Ajoute les langues pour les mots et les traduction
            foreach (string langue in gestVoc.ListeLangues)
            {
                cb_langues.Items.Add(langue);
                cb_langues_trad.Items.Add(langue);
            }

            // Obtient la référence du gestionnaire
            this.gestVoc = gestVoc;
        }

        /// <summary>
        /// Met à jour la liste de mots selon la langue
        /// </summary>
        /// <param name="sender">Composant qui a envoyé l'événemenet</param>
        /// <param name="e">Information sur l'événement</param>
        private void cb_langues_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Mot> listeMots = new List<Mot>();  // Liste de mots dans une langue
            string langue = null;                   // Langue sélectionnée

            // Efface la liste de mots dans le composant
            lb_mots.Items.Clear();

            // Efface la liste de traduction
            lb_traductions.Items.Clear();

            // Efface les informations d'un mot
            tb_nom_mot.Text = "";
            tb_definition_mot.Text = "";

            // Efface les informations d'une traduction
            tb_nom_trad.Text = "";
            tb_definition_trad.Text = "";
            cb_langues_trad.Text = "";

            // Obtient la langue sélectionnée
            langue = cb_langues.Text;

            // Obtient les mots dans la langue
            listeMots = gestVoc.ObtenirTousMotsDansUneLangue(langue);

            // Affiche la liste de mots
            foreach (Mot mot in listeMots)
                if (mot.Nom != "")
                    lb_mots.Items.Add(mot);
        }

        /// <summary>
        /// Permet d'afficher les traductions d'un mot
        /// </summary>
        /// <param name="sender">Composant qui a envoyé l'événemenet</param>
        /// <param name="e">Information sur l'événement</param>
        private void lb_mots_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Mot> listeTraductions = new List<Mot>();   // Liste des traductions d'un mot
            Mot mot;                                        // Mot sélectionné dans la liste
            string langue;                                  // Langue sélectionnée

            // Efface la liste de traductions
            lb_traductions.Items.Clear();

            // Efface les informations d'une traduction
            tb_nom_trad.Text = "";
            tb_definition_trad.Text = "";
            cb_langues_trad.Text = "";

            if (lb_mots.SelectedIndex != -1)
            {
                // Obtient le mot sélectionné
                mot = (Mot)lb_mots.SelectedItem;

                // Obtient la langue sélectionnée
                langue = (string)cb_langues.SelectedItem;

                // Obtient la liste des traductions pour le mot sélectionné
                listeTraductions = gestVoc.ObtenirToutesTraductions(mot);

                // Affiche les traductions
                foreach (Mot traduction in listeTraductions)
                    if (traduction.Nom != "")
                        lb_traductions.Items.Add(traduction);

                // Affiche le nom, la définition et la langue
                tb_nom_mot.Text = mot.Nom;
                tb_definition_mot.Text = mot.Definition;
            }
        }

        /// <summary>
        /// Permet d'afficher les informations d'une traduction
        /// </summary>
        /// <param name="sender">Composant qui a envoyé l'événemenet</param>
        /// <param name="e">Information sur l'événement</param>
        private void lb_traductions_SelectedIndexChanged(object sender, EventArgs e)
        {
            Mot traduction = null;         // Traduction sélectionnée dans la liste

            // Vérifie que l'index est valide
            if (lb_traductions.SelectedIndex != -1)
            {
                // Obtient la traduction dans la liste
                traduction = (Mot)lb_traductions.SelectedItem;

                // Affiche les informations de la traduction
                tb_nom_trad.Text = traduction.Nom;
                tb_definition_trad.Text = traduction.Definition;
                cb_langues_trad.Text = traduction.Langue;
            }
        }

        /// <summary>
        /// Permet d'ajouter un nouveau mot dans une langue
        /// </summary>
        /// <param name="sender">Composant qui a envoyé l'événemenet</param>
        /// <param name="e">Information sur l'événement</param>
        private void btn_ajout_mot_Click(object sender, EventArgs e)
        {
            Mot nouveauMot = new Mot();     // Nouveau mot
            int indexNouveauMot = 0;        // Index du nouveau mot dans la liste

            try
            {
                // Obtient les informations du nouveau mot
                nouveauMot.Nom = tb_nom_mot.Text;
                nouveauMot.Definition = tb_definition_mot.Text;
                nouveauMot.Langue = cb_langues.Text;

                // Crée le nouveau mot
                nouveauMot.IdUnique = gestVoc.CreerMot(nouveauMot);

                // Ajoute le nouveau mot dans la liste
                indexNouveauMot = lb_mots.Items.Add(nouveauMot);

                // Sélectionne le mot ajouté
                lb_mots.SelectedIndex = indexNouveauMot;
            }
            catch(Exception exc)
            {
                // Affiche un message d'erreur
                MessageBox.Show(exc.Message, "Erreur!", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Permet de supprimer le mot et ses traductions
        /// </summary>
        /// <param name="sender">Composant qui a envoyé l'événemenet</param>
        /// <param name="e">Information sur l'événement</param>
        private void btn_supp_mot_Click(object sender, EventArgs e)
        {
            Mot motASupp = null;        // Mot à supprimer

            try
            {
                // Obtient le mot de la liste
                motASupp = (Mot)lb_mots.SelectedItem;

                // Sélectionne le mot en dessus
                if (lb_traductions.SelectedIndex > 0)
                    lb_traductions.SelectedIndex--;
                else
                    lb_traductions.SelectedIndex = -1;

                // Supprime le mot de la liste
                lb_mots.Items.Remove(motASupp);

                // Supprime le mot dans le gestionnaire
                gestVoc.SupprimerMot(motASupp);

                // Efface les informations du mot
                tb_nom_mot.Text = "";
                tb_definition_mot.Text = "";
            }
            catch (Exception exc)
            {
                // Affiche un message d'erreur
                MessageBox.Show(exc.Message, "Erreur!", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Ajouter une traduction à un mot
        /// </summary>
        /// <param name="sender">Composant qui a envoyé l'événemenet</param>
        /// <param name="e">Information sur l'événement</param>
        private void btn_ajout_trad_Click(object sender, EventArgs e)
        {
            Mot mot = new Mot();            // Mot sélectionné
            Mot traduction = new Mot();     // Nouvelle traduction
            int indexNouvelleTrad = 0;      // Index de la nouvelle traduction dans la liste

            try
            {
                // Obtient le mot sélectionné
                mot = (Mot)lb_mots.SelectedItem;

                // Obtient les informations de la nouvelle traduction
                traduction.Nom = tb_nom_trad.Text;
                traduction.Definition = tb_definition_trad.Text;
                traduction.Langue = cb_langues_trad.Text;

                // Ajoute la traduction au mot
                gestVoc.AjouterTraduction(mot, traduction);

                // Ajoute le nouveau mot dans la liste
                indexNouvelleTrad = lb_traductions.Items.Add(traduction);
                
                // Sélectionne le mot ajouté
                lb_traductions.SelectedIndex = indexNouvelleTrad;

                // Efface les informations de la traduction
                tb_nom_trad.Text = "";
                tb_definition_trad.Text = "";
                cb_langues_trad.Text = "";
            }
            catch (Exception exc)
            {
                // Affiche un message d'erreur
                MessageBox.Show(exc.Message, "Erreur!", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Permet de supprimer une traduction
        /// </summary>
        /// <param name="sender">Composant qui a envoyé l'événemenet</param>
        /// <param name="e">Information sur l'événement</param>
        private void btn_supp_trad_Click(object sender, EventArgs e)
        {
            Mot traductionASupp = null;        // Traduction à supprimer

            try
            {
                // Obtient le mot de la liste
                traductionASupp = (Mot)lb_traductions.SelectedItem;

                // Sélectionne le mot en dessus
                if (lb_traductions.SelectedIndex > 0)
                    lb_traductions.SelectedIndex--;
                else
                    lb_traductions.SelectedIndex = -1;

                // Supprime le mot de la liste
                lb_traductions.Items.Remove(traductionASupp);

                // Efface la traduction dans le fichier XML
                gestVoc.EffacerTraduction(traductionASupp);

                // Efface les informations affichée
                tb_nom_trad.Text = "";
                tb_definition_trad.Text = "";
                cb_langues_trad.Text = "";
            }
            catch (Exception exc)
            {
                // Affiche un message d'erreur
                MessageBox.Show(exc.Message, "Erreur!", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Permet de modifier le mot sélectionné
        /// </summary>
        /// <param name="sender">Composant qui a envoyé l'événemenet</param>
        /// <param name="e">Information sur l'événement</param>
        private void btn_modif_mot_Click(object sender, EventArgs e)
        {
            Mot motAModifier = null;    // Mot devant être modifié
            Mot motModifie = null;      // Mot avec les informations modifiées
            int indexSelectionne = 0;   // Index de la sélection 

            // Obtient le mot à modifier
            motAModifier = (Mot)lb_mots.SelectedItem;

            // Créé le mot modifié avec les nouvelles informations
            motModifie = new Mot();
            motModifie.IdUnique = motAModifier.IdUnique;
            motModifie.Nom = tb_nom_mot.Text;
            motModifie.Definition = tb_definition_mot.Text;
            motModifie.Langue = motAModifier.Langue;

            // Enlève le mot de la liste
            lb_mots.Items.Remove(motAModifier);

            // Modifie le mot dans le fichier XML
            motModifie = gestVoc.ModifierMot(motAModifier, motModifie);

            // Ajoute le mot modifié dans la liste
            indexSelectionne = lb_mots.Items.Add(motModifie);

            // Sélectionne le mot
            lb_mots.SelectedIndex = indexSelectionne;
        }

        /// <summary>
        /// Permet de modifier la traduction sélectionnée
        /// </summary>
        /// <param name="sender">Composant qui a envoyé l'événemenet</param>
        /// <param name="e">Information sur l'événement</param>
        private void btn_modif_trad_Click(object sender, EventArgs e)
        {
            Mot tradAModifier = null;    // Traduction devant être modifié
            Mot tradModifie = null;      // Traduction avec les informations modifiées
            int indexSelectionne = 0;   // Index de la sélection 

            // Obtient le mot à modifier
            tradAModifier = (Mot)lb_traductions.SelectedItem;

            // Créé le mot modifié avec les nouvelles informations
            tradModifie = new Mot();
            tradModifie.IdUnique = tradAModifier.IdUnique;
            tradModifie.Nom = tb_nom_trad.Text;
            tradModifie.Definition = tb_definition_trad.Text;
            tradModifie.Langue = cb_langues_trad.Text;

            // Enlève le mot de la liste
            lb_traductions.Items.Remove(tradAModifier);

            // Modifie le mot dans le fichier XML
            tradModifie = gestVoc.ModifierMot(tradAModifier, tradModifie);

            // Ajoute le mot modifié dans la liste
            indexSelectionne = lb_traductions.Items.Add(tradModifie);

            // Sélectionne le mot
            lb_traductions.SelectedIndex = indexSelectionne;
        }

        /// <summary>
        /// Permet de sauvegarder les mots/traductions et fermer la fenêtre de gestion du vocabulaire
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ok_Click(object sender, EventArgs e)
        {
            // Sauvegarde les données et quitte la fenêtre de gestion de voc
            gestVoc.SauvegarderVoc();
            this.Close();
        }
    }
}
