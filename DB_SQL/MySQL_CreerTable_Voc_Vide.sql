#------------------------------------------------------------
#        Script MySQL.
#------------------------------------------------------------


#------------------------------------------------------------
# Table: VOCABULAIRE
#------------------------------------------------------------

CREATE TABLE VOCABULAIRE(
        VO_id      int (11) Auto_increment  NOT NULL ,
        VO_fr_nom  Varchar (50) ,
        VO_fr_desc Varchar (150) ,
        VO_de_nom  Varchar (50) ,
        VO_de_desc Varchar (150) ,
        VO_en_nom  Varchar (50) ,
        VO_en_desc Varchar (150) ,
        VO_it_nom  Varchar (50) ,
        VO_it_desc Varchar (150) ,
        VO_es_nom  Varchar (50) ,
        VO_es_desc Varchar (150) ,
        PRIMARY KEY (VO_id )
)ENGINE=InnoDB;