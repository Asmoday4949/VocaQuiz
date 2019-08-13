/*------------------------------------------------------------
*        Script SQLSERVER 
------------------------------------------------------------*/


/*------------------------------------------------------------
-- Table: VOCABULAIRE
------------------------------------------------------------*/
CREATE TABLE VOCABULAIRE(
	VO_id      INT IDENTITY (1,1) NOT NULL ,
	VO_fr_nom  VARCHAR (50)  ,
	VO_fr_desc VARCHAR (150)  ,
	VO_de_nom  VARCHAR (50)  ,
	VO_de_desc VARCHAR (150)  ,
	VO_en_nom  VARCHAR (50)  ,
	VO_en_desc VARCHAR (150)  ,
	VO_it_nom  VARCHAR (50)  ,
	VO_it_desc VARCHAR (150)  ,
	VO_es_nom  VARCHAR (50)  ,
	VO_es_desc VARCHAR (150)  ,
	CONSTRAINT prk_constraint_VOCABULAIRE PRIMARY KEY NONCLUSTERED (VO_id)
);

SET IDENTITY_INSERT vocabulaire OFF
