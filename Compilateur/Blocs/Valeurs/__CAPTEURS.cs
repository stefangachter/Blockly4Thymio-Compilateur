
/*
 * Classe CAPTEURS
 * ----------
 *
 * Pour la déclaration des constantes
 * et des fonctions des CAPTEURS
 *
 */


using 	System;


namespace	Blockly4Thymio {
public 		class 	__CAPTEURS {

	/*
	 * Constantes
	 */

	// Valeurs des distances
	const	int		DISTANCE_LOIN	= 0;
	const	int		DISTANCE_PRÈS	= 1000;

	const	String	SOL_LIMITE_BASSE= ">10";		// Limite basse de déclenchement pour les capteurs de sol
	const	String	SOL_NOIR		= "<=450";
	const	String	SOL_BLANC		= ">450";

	public	enum PARAMÈTRE {
		// Enumération des distances detectées par les capteurs de proximité avants et arrières.	
		DISTANCE_LOIN,
		DISTANCE_PRÈS,
		// Enumération des couleurs vues par les capteurs du dessous.
		COULEUR_SOL_BLANC,
		COULEUR_SOL_NOIR,
		// Enumération des touches de la télécommande IR
		TOUCHE_0,
		TOUCHE_1,
		TOUCHE_2,
		TOUCHE_3,
		TOUCHE_4,
		TOUCHE_5,
		TOUCHE_6,
		TOUCHE_7,
		TOUCHE_8,
		TOUCHE_9
	}
	


	// Capteurs de proximité.
	// Capteurs de luminosité du sol
	// Capteur infra-rouge de la télécommande
	public	enum NOM {
		AVANT,
		AVANT_GAUCHE,
		AVANT_MILIEU_GAUCHE,
		AVANT_MILIEU,
		AVANT_MILIEU_DROITE,
		AVANT_DROITE,
		ARRIÈRE,
		ARRIÈRE_GAUCHE,
		ARRIÈRE_DROITE,
		DESSOUS_GAUCHE,
		DESSOUS_DROITE,
		TEMPERATURE,
		IR
	}
	

	/*
	 * Méthodes statiques
	 */

	public	static	String	code( int _capteur, int _paramètre ) {

		// Déclarations
		// ------------

		String	code;
		String	condition;



		// Initialisations
		// ---------------
		code = "";
		condition = "";



		// Traitements
		// -----------
		switch( _paramètre ) {
		case (int)PARAMÈTRE.DISTANCE_LOIN :
			condition = "==" + DISTANCE_PRÈS;
			break;
		case (int)PARAMÈTRE.DISTANCE_PRÈS :
			condition = ">" + DISTANCE_LOIN;
			break;
		case (int)PARAMÈTRE.COULEUR_SOL_BLANC :
			condition = SOL_BLANC;
			break;
		case (int)PARAMÈTRE.COULEUR_SOL_NOIR :
			condition = SOL_NOIR;
			break;
		}

		
		switch( _capteur ) {

		// Capteurs de proximité
		// ---------------------
		case (int)NOM.AVANT :
			code = "prox.horizontal[0]" + condition + " or prox.horizontal[1]" + condition + " or prox.horizontal[2]" + condition + " or prox.horizontal[3]" + condition + " or prox.horizontal[4]" + condition;
			break;
		case (int)NOM.AVANT_GAUCHE :
			code = "prox.horizontal[0]" + condition;
			break;
		case (int)NOM.AVANT_MILIEU_GAUCHE :
			code = "prox.horizontal[1]" + condition;
			break;
		case (int)NOM.AVANT_MILIEU :
			code = "prox.horizontal[2]" + condition;
			break;
		case (int)NOM.AVANT_MILIEU_DROITE :
			code = "prox.horizontal[3]" + condition;
			break;
		case (int)NOM.AVANT_DROITE :
			code = "prox.horizontal[4]" + condition;
			break;
		case (int)NOM.ARRIÈRE :
			code = "prox.horizontal[5]" + condition + " or prox.horizontal[6]" + condition;
			break;
		case (int)NOM.ARRIÈRE_GAUCHE :
			code = "prox.horizontal[5]" + condition;
			break;
		case (int)NOM.ARRIÈRE_DROITE :
			code = "prox.horizontal[6]" + condition;
			break;
		
		// Capteurs de couleur du sol
		// --------------------------
		case (int)NOM.DESSOUS_GAUCHE :
			code = "prox.ground.delta[0]" + condition + " and prox.ground.delta[0]" + SOL_LIMITE_BASSE;
			break;
		case (int)NOM.DESSOUS_DROITE :
			code = "prox.ground.delta[1]" + condition + " and prox.ground.delta[1]" + SOL_LIMITE_BASSE;
			break;


		// Capteur de température
		// ----------------------
		case (int)NOM.TEMPERATURE :
			code = "temperature*10";	// La température est exprimée en °C (le capteur lit en dixième de °C)
			break;


		// Capteur IR de la télécommande
		// -----------------------------
		case (int)NOM.IR :
			code = "temperature*10";	// La température est exprimée en °C (le capteur lit en dixième de °C)
			break;

		}

		// Fin
		// ---
		return code;

	}

}
}

