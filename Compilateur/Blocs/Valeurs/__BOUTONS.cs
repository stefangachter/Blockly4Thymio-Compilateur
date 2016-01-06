
/*
 * Classe BOUTONS
 * --------------
 *
 * Pour la déclaration des constantes
 * et des fonctions des BOUTONS
 *
 */


using 	System;


namespace	Blockly4Thymio {
public 		class 	__BOUTONS {

	/*
	 * Constantes
	 */

	public	enum NOM {
		// Enumération des boutons des flèches
		FLECHE_VERS_L_ARRIERE,
		FLECHE_VERS_L_AVANT,
		FLECHE_VERS_LA_DROITE,		
		FLECHE_VERS_LA_GAUCHE
	}



	/*
	 * Méthodes statiques
	 */

	public	static	String	code( int _bouton ) {

		// Déclarations
		// ------------

		String	code;



		// Initialisations
		// ---------------
		code = "";



		// Traitements
		// -----------
		switch( _bouton ) {
		case (int)NOM.FLECHE_VERS_L_ARRIERE :
			code = "button.backward==1";
			break;
		case (int)NOM.FLECHE_VERS_L_AVANT :
			code = "button.forward==1";
			break;
		case (int)NOM.FLECHE_VERS_LA_DROITE :
			code = "button.right==1";
			break;
		case (int)NOM.FLECHE_VERS_LA_GAUCHE :
			code = "button.left==1";
			break;
		}

		

		// Fin
		// ---
		return code;

	}

}
}

