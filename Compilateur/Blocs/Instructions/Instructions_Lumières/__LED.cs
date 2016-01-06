
/*
 * Classe LED
 * ----------
 *
 * Pour la déclaration des constantes
 * et des fonctions des LEDs
 *
 */


using 	System;


namespace	Blockly4Thymio {
public 		class 	__LED {

	/*
	 * Constantes
	 */

	// LEDs
	public	const	int	AUCUNE			= 0;
	public	const	int	LED_DE_GAUCHE	= 1;
	public	const	int	LED_DE_DROITE	= 2;
	public	const	int	LED_DU_DESSUS	= 3;
	public	const	int	TOUTE_LES_LEDS	= 4;

	// Composantes des couleurs
	public	const	int	COMPOSANTE_ROUGE	= 1;
	public	const	int	COMPOSANTE_VERTE	= 2;
	public	const	int	COMPOSANTE_BLEUE	= 3;



	/*
	 * Méthodes statiques
	 */
	public	static	int	CalculLaCouleur( int _couleur, int _composante ) {

		// Déclarations
		int	valeur;


		// Initialisations
		valeur = 0;


		// Traitements
		switch ( _composante) {
		case (int)COMPOSANTE_ROUGE :
			valeur = (_couleur & 0x0000ff)>>3;
			break;
		case (int)COMPOSANTE_VERTE :
			valeur = (_couleur & 0x00ff00)>>(8+3);
			break;
		case (int)COMPOSANTE_BLEUE :
			valeur = (_couleur & 0xff0000)>>(16+3);
			break;
		}


		// Fin
		return valeur;

	}


	public	static	String	code( int _led, int _couleur ) {

		// Déclarations
		// ------------

		String code;


		// Initialisations
		// ---------------
		code = "";


		// Traitements
		// -----------
		if ((_led == (int)LED_DU_DESSUS) || (_led == (int)TOUTE_LES_LEDS))
			code += "call leds.top(" + CalculLaCouleur(_couleur, (int)COMPOSANTE_BLEUE) + "," + CalculLaCouleur(_couleur, (int)COMPOSANTE_VERTE) + "," + CalculLaCouleur(_couleur, (int)COMPOSANTE_ROUGE) + ") ";

		if ((_led == (int)LED_DE_GAUCHE) || (_led == (int)TOUTE_LES_LEDS))
			code += "call leds.bottom.left(" + CalculLaCouleur(_couleur, (int)COMPOSANTE_BLEUE) + "," + CalculLaCouleur(_couleur, (int)COMPOSANTE_VERTE) + "," + CalculLaCouleur(_couleur, (int)COMPOSANTE_ROUGE) + ") ";

		if ((_led == (int)LED_DE_DROITE) || (_led == (int)TOUTE_LES_LEDS))
			code += "call leds.bottom.right(" + CalculLaCouleur(_couleur, (int)COMPOSANTE_BLEUE) + "," + CalculLaCouleur(_couleur, (int)COMPOSANTE_VERTE) + "," + CalculLaCouleur(_couleur, (int)COMPOSANTE_ROUGE) + ") ";

		code = code.Trim();


		// Fin
		// ---
		return code;

	}

}
}

