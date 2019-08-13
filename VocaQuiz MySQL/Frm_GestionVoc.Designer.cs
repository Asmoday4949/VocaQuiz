namespace VocaQuiz
{
    partial class Frm_GestionVoc
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_langue = new System.Windows.Forms.Label();
            this.cb_langues = new System.Windows.Forms.ComboBox();
            this.lb_mots = new System.Windows.Forms.ListBox();
            this.lb_traductions = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_definition = new System.Windows.Forms.Label();
            this.tb_definition_trad = new System.Windows.Forms.TextBox();
            this.tb_nom_trad = new System.Windows.Forms.TextBox();
            this.cb_langues_trad = new System.Windows.Forms.ComboBox();
            this.lbl_traduction = new System.Windows.Forms.Label();
            this.lbl_definition_mot = new System.Windows.Forms.Label();
            this.tb_definition_mot = new System.Windows.Forms.TextBox();
            this.tb_nom_mot = new System.Windows.Forms.TextBox();
            this.lbl_mot = new System.Windows.Forms.Label();
            this.btn_ok = new System.Windows.Forms.Button();
            this.pnl_vocabulaire = new System.Windows.Forms.Panel();
            this.lbl_vocabulaire = new System.Windows.Forms.Label();
            this.lbl_modif_mot = new System.Windows.Forms.Label();
            this.pnl_traduction = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_modif_trad = new System.Windows.Forms.Button();
            this.btn_supp_trad = new System.Windows.Forms.Button();
            this.btn_ajout_trad = new System.Windows.Forms.Button();
            this.btn_modif_mot = new System.Windows.Forms.Button();
            this.btn_supp_mot = new System.Windows.Forms.Button();
            this.btn_ajout_mot = new System.Windows.Forms.Button();
            this.pb_fleche = new System.Windows.Forms.PictureBox();
            this.pnl_vocabulaire.SuspendLayout();
            this.pnl_traduction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_fleche)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_langue
            // 
            this.lbl_langue.AutoSize = true;
            this.lbl_langue.Location = new System.Drawing.Point(20, 33);
            this.lbl_langue.Name = "lbl_langue";
            this.lbl_langue.Size = new System.Drawing.Size(43, 13);
            this.lbl_langue.TabIndex = 10;
            this.lbl_langue.Text = "Langue";
            // 
            // cb_langues
            // 
            this.cb_langues.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_langues.FormattingEnabled = true;
            this.cb_langues.Location = new System.Drawing.Point(23, 50);
            this.cb_langues.Name = "cb_langues";
            this.cb_langues.Size = new System.Drawing.Size(166, 21);
            this.cb_langues.TabIndex = 9;
            this.cb_langues.SelectedIndexChanged += new System.EventHandler(this.cb_langues_SelectedIndexChanged);
            // 
            // lb_mots
            // 
            this.lb_mots.FormattingEnabled = true;
            this.lb_mots.Location = new System.Drawing.Point(23, 98);
            this.lb_mots.Name = "lb_mots";
            this.lb_mots.Size = new System.Drawing.Size(168, 160);
            this.lb_mots.Sorted = true;
            this.lb_mots.TabIndex = 15;
            this.lb_mots.SelectedIndexChanged += new System.EventHandler(this.lb_mots_SelectedIndexChanged);
            // 
            // lb_traductions
            // 
            this.lb_traductions.FormattingEnabled = true;
            this.lb_traductions.Location = new System.Drawing.Point(20, 98);
            this.lb_traductions.Name = "lb_traductions";
            this.lb_traductions.Size = new System.Drawing.Size(169, 160);
            this.lb_traductions.Sorted = true;
            this.lb_traductions.TabIndex = 16;
            this.lb_traductions.SelectedIndexChanged += new System.EventHandler(this.lb_traductions_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Mots";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Traductions pour le mot sélectionné";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 456);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 38;
            this.label7.Text = "Langue";
            // 
            // lbl_definition
            // 
            this.lbl_definition.AutoSize = true;
            this.lbl_definition.Location = new System.Drawing.Point(17, 353);
            this.lbl_definition.Name = "lbl_definition";
            this.lbl_definition.Size = new System.Drawing.Size(51, 13);
            this.lbl_definition.TabIndex = 36;
            this.lbl_definition.Text = "Définition";
            // 
            // tb_definition_trad
            // 
            this.tb_definition_trad.Location = new System.Drawing.Point(20, 369);
            this.tb_definition_trad.Multiline = true;
            this.tb_definition_trad.Name = "tb_definition_trad";
            this.tb_definition_trad.Size = new System.Drawing.Size(169, 76);
            this.tb_definition_trad.TabIndex = 35;
            // 
            // tb_nom_trad
            // 
            this.tb_nom_trad.Location = new System.Drawing.Point(20, 320);
            this.tb_nom_trad.Name = "tb_nom_trad";
            this.tb_nom_trad.Size = new System.Drawing.Size(169, 20);
            this.tb_nom_trad.TabIndex = 32;
            // 
            // cb_langues_trad
            // 
            this.cb_langues_trad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_langues_trad.FormattingEnabled = true;
            this.cb_langues_trad.Location = new System.Drawing.Point(20, 472);
            this.cb_langues_trad.Name = "cb_langues_trad";
            this.cb_langues_trad.Size = new System.Drawing.Size(169, 21);
            this.cb_langues_trad.TabIndex = 37;
            // 
            // lbl_traduction
            // 
            this.lbl_traduction.AutoSize = true;
            this.lbl_traduction.Location = new System.Drawing.Point(17, 304);
            this.lbl_traduction.Name = "lbl_traduction";
            this.lbl_traduction.Size = new System.Drawing.Size(58, 13);
            this.lbl_traduction.TabIndex = 39;
            this.lbl_traduction.Text = "Traduction";
            // 
            // lbl_definition_mot
            // 
            this.lbl_definition_mot.AutoSize = true;
            this.lbl_definition_mot.Location = new System.Drawing.Point(20, 355);
            this.lbl_definition_mot.Name = "lbl_definition_mot";
            this.lbl_definition_mot.Size = new System.Drawing.Size(51, 13);
            this.lbl_definition_mot.TabIndex = 44;
            this.lbl_definition_mot.Text = "Définition";
            // 
            // tb_definition_mot
            // 
            this.tb_definition_mot.Location = new System.Drawing.Point(23, 371);
            this.tb_definition_mot.Multiline = true;
            this.tb_definition_mot.Name = "tb_definition_mot";
            this.tb_definition_mot.Size = new System.Drawing.Size(169, 76);
            this.tb_definition_mot.TabIndex = 43;
            // 
            // tb_nom_mot
            // 
            this.tb_nom_mot.Location = new System.Drawing.Point(23, 322);
            this.tb_nom_mot.Name = "tb_nom_mot";
            this.tb_nom_mot.Size = new System.Drawing.Size(166, 20);
            this.tb_nom_mot.TabIndex = 40;
            // 
            // lbl_mot
            // 
            this.lbl_mot.AutoSize = true;
            this.lbl_mot.Location = new System.Drawing.Point(20, 306);
            this.lbl_mot.Name = "lbl_mot";
            this.lbl_mot.Size = new System.Drawing.Size(25, 13);
            this.lbl_mot.TabIndex = 45;
            this.lbl_mot.Text = "Mot";
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(9, 569);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(475, 23);
            this.btn_ok.TabIndex = 46;
            this.btn_ok.Text = "Ok";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // pnl_vocabulaire
            // 
            this.pnl_vocabulaire.BackColor = System.Drawing.Color.White;
            this.pnl_vocabulaire.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_vocabulaire.Controls.Add(this.lbl_modif_mot);
            this.pnl_vocabulaire.Controls.Add(this.lbl_vocabulaire);
            this.pnl_vocabulaire.Controls.Add(this.btn_modif_mot);
            this.pnl_vocabulaire.Controls.Add(this.lb_mots);
            this.pnl_vocabulaire.Controls.Add(this.cb_langues);
            this.pnl_vocabulaire.Controls.Add(this.btn_supp_mot);
            this.pnl_vocabulaire.Controls.Add(this.lbl_langue);
            this.pnl_vocabulaire.Controls.Add(this.label2);
            this.pnl_vocabulaire.Controls.Add(this.tb_definition_mot);
            this.pnl_vocabulaire.Controls.Add(this.btn_ajout_mot);
            this.pnl_vocabulaire.Controls.Add(this.lbl_definition_mot);
            this.pnl_vocabulaire.Controls.Add(this.lbl_mot);
            this.pnl_vocabulaire.Controls.Add(this.tb_nom_mot);
            this.pnl_vocabulaire.Location = new System.Drawing.Point(12, 9);
            this.pnl_vocabulaire.Name = "pnl_vocabulaire";
            this.pnl_vocabulaire.Size = new System.Drawing.Size(211, 554);
            this.pnl_vocabulaire.TabIndex = 58;
            // 
            // lbl_vocabulaire
            // 
            this.lbl_vocabulaire.BackColor = System.Drawing.Color.SteelBlue;
            this.lbl_vocabulaire.Font = new System.Drawing.Font("Comic Sans MS", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_vocabulaire.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_vocabulaire.Location = new System.Drawing.Point(0, 0);
            this.lbl_vocabulaire.Name = "lbl_vocabulaire";
            this.lbl_vocabulaire.Size = new System.Drawing.Size(210, 28);
            this.lbl_vocabulaire.TabIndex = 0;
            this.lbl_vocabulaire.Text = "Vocabulaire";
            this.lbl_vocabulaire.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_modif_mot
            // 
            this.lbl_modif_mot.BackColor = System.Drawing.Color.SteelBlue;
            this.lbl_modif_mot.Font = new System.Drawing.Font("Comic Sans MS", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_modif_mot.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_modif_mot.Location = new System.Drawing.Point(0, 270);
            this.lbl_modif_mot.Name = "lbl_modif_mot";
            this.lbl_modif_mot.Size = new System.Drawing.Size(210, 28);
            this.lbl_modif_mot.TabIndex = 58;
            this.lbl_modif_mot.Text = "Gestion de mot";
            this.lbl_modif_mot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnl_traduction
            // 
            this.pnl_traduction.BackColor = System.Drawing.Color.White;
            this.pnl_traduction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_traduction.Controls.Add(this.label1);
            this.pnl_traduction.Controls.Add(this.label4);
            this.pnl_traduction.Controls.Add(this.btn_modif_trad);
            this.pnl_traduction.Controls.Add(this.label7);
            this.pnl_traduction.Controls.Add(this.lb_traductions);
            this.pnl_traduction.Controls.Add(this.btn_supp_trad);
            this.pnl_traduction.Controls.Add(this.label3);
            this.pnl_traduction.Controls.Add(this.btn_ajout_trad);
            this.pnl_traduction.Controls.Add(this.tb_definition_trad);
            this.pnl_traduction.Controls.Add(this.cb_langues_trad);
            this.pnl_traduction.Controls.Add(this.lbl_traduction);
            this.pnl_traduction.Controls.Add(this.tb_nom_trad);
            this.pnl_traduction.Controls.Add(this.lbl_definition);
            this.pnl_traduction.Location = new System.Drawing.Point(273, 9);
            this.pnl_traduction.Name = "pnl_traduction";
            this.pnl_traduction.Size = new System.Drawing.Size(211, 554);
            this.pnl_traduction.TabIndex = 59;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(0, 270);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 28);
            this.label1.TabIndex = 58;
            this.label1.Text = "Gestion de traduction";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.SteelBlue;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(210, 28);
            this.label4.TabIndex = 0;
            this.label4.Text = "Traductions";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_modif_trad
            // 
            this.btn_modif_trad.Image = global::VocaQuiz.Properties.Resources.Modifier;
            this.btn_modif_trad.Location = new System.Drawing.Point(103, 506);
            this.btn_modif_trad.Name = "btn_modif_trad";
            this.btn_modif_trad.Size = new System.Drawing.Size(40, 40);
            this.btn_modif_trad.TabIndex = 54;
            this.btn_modif_trad.UseVisualStyleBackColor = true;
            this.btn_modif_trad.Click += new System.EventHandler(this.btn_modif_trad_Click);
            // 
            // btn_supp_trad
            // 
            this.btn_supp_trad.Image = global::VocaQuiz.Properties.Resources.Supprimer;
            this.btn_supp_trad.Location = new System.Drawing.Point(149, 506);
            this.btn_supp_trad.Name = "btn_supp_trad";
            this.btn_supp_trad.Size = new System.Drawing.Size(40, 40);
            this.btn_supp_trad.TabIndex = 53;
            this.btn_supp_trad.UseVisualStyleBackColor = true;
            this.btn_supp_trad.Click += new System.EventHandler(this.btn_supp_trad_Click);
            // 
            // btn_ajout_trad
            // 
            this.btn_ajout_trad.Image = global::VocaQuiz.Properties.Resources.Ajouter;
            this.btn_ajout_trad.Location = new System.Drawing.Point(57, 506);
            this.btn_ajout_trad.Name = "btn_ajout_trad";
            this.btn_ajout_trad.Size = new System.Drawing.Size(40, 40);
            this.btn_ajout_trad.TabIndex = 52;
            this.btn_ajout_trad.UseVisualStyleBackColor = true;
            this.btn_ajout_trad.Click += new System.EventHandler(this.btn_ajout_trad_Click);
            // 
            // btn_modif_mot
            // 
            this.btn_modif_mot.Image = global::VocaQuiz.Properties.Resources.Modifier;
            this.btn_modif_mot.Location = new System.Drawing.Point(106, 458);
            this.btn_modif_mot.Name = "btn_modif_mot";
            this.btn_modif_mot.Size = new System.Drawing.Size(40, 40);
            this.btn_modif_mot.TabIndex = 57;
            this.btn_modif_mot.UseVisualStyleBackColor = true;
            this.btn_modif_mot.Click += new System.EventHandler(this.btn_modif_mot_Click);
            // 
            // btn_supp_mot
            // 
            this.btn_supp_mot.Image = global::VocaQuiz.Properties.Resources.Supprimer;
            this.btn_supp_mot.Location = new System.Drawing.Point(152, 458);
            this.btn_supp_mot.Name = "btn_supp_mot";
            this.btn_supp_mot.Size = new System.Drawing.Size(40, 40);
            this.btn_supp_mot.TabIndex = 56;
            this.btn_supp_mot.UseVisualStyleBackColor = true;
            this.btn_supp_mot.Click += new System.EventHandler(this.btn_supp_mot_Click);
            // 
            // btn_ajout_mot
            // 
            this.btn_ajout_mot.Image = global::VocaQuiz.Properties.Resources.Ajouter;
            this.btn_ajout_mot.Location = new System.Drawing.Point(60, 458);
            this.btn_ajout_mot.Name = "btn_ajout_mot";
            this.btn_ajout_mot.Size = new System.Drawing.Size(40, 40);
            this.btn_ajout_mot.TabIndex = 55;
            this.btn_ajout_mot.UseVisualStyleBackColor = true;
            this.btn_ajout_mot.Click += new System.EventHandler(this.btn_ajout_mot_Click);
            // 
            // pb_fleche
            // 
            this.pb_fleche.Image = global::VocaQuiz.Properties.Resources.fleche_bleue_droite;
            this.pb_fleche.Location = new System.Drawing.Point(229, 168);
            this.pb_fleche.Name = "pb_fleche";
            this.pb_fleche.Size = new System.Drawing.Size(38, 44);
            this.pb_fleche.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_fleche.TabIndex = 60;
            this.pb_fleche.TabStop = false;
            // 
            // Frm_GestionVoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 598);
            this.Controls.Add(this.pb_fleche);
            this.Controls.Add(this.pnl_traduction);
            this.Controls.Add(this.pnl_vocabulaire);
            this.Controls.Add(this.btn_ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Frm_GestionVoc";
            this.Text = "Gestionnaire de vocabulaire";
            this.pnl_vocabulaire.ResumeLayout(false);
            this.pnl_vocabulaire.PerformLayout();
            this.pnl_traduction.ResumeLayout(false);
            this.pnl_traduction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_fleche)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_langue;
        private System.Windows.Forms.ComboBox cb_langues;
        private System.Windows.Forms.ListBox lb_mots;
        private System.Windows.Forms.ListBox lb_traductions;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_definition;
        private System.Windows.Forms.TextBox tb_definition_trad;
        private System.Windows.Forms.TextBox tb_nom_trad;
        private System.Windows.Forms.ComboBox cb_langues_trad;
        private System.Windows.Forms.Label lbl_traduction;
        private System.Windows.Forms.Label lbl_definition_mot;
        private System.Windows.Forms.TextBox tb_definition_mot;
        private System.Windows.Forms.TextBox tb_nom_mot;
        private System.Windows.Forms.Label lbl_mot;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_modif_trad;
        private System.Windows.Forms.Button btn_supp_trad;
        private System.Windows.Forms.Button btn_ajout_trad;
        private System.Windows.Forms.Button btn_modif_mot;
        private System.Windows.Forms.Button btn_supp_mot;
        private System.Windows.Forms.Button btn_ajout_mot;
        private System.Windows.Forms.Panel pnl_vocabulaire;
        private System.Windows.Forms.Label lbl_vocabulaire;
        private System.Windows.Forms.Label lbl_modif_mot;
        private System.Windows.Forms.Panel pnl_traduction;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pb_fleche;


    }
}