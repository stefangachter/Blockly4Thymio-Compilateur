
/*
 * Classe __MOTEUR
 * ---------------
 *
 * Pour la déclaration des constantes.
 *
 */


using 	System;



public 		class 	__MOTEUR {

    /*
	 * Constantes
	 */

    // Côté
    public  const   int TOURNE_PAS			= 0;
    public  const   int TOURNE_A_GAUCHE		= 1;
    public  const   int TOURNE_A_DROITE		= 2;

    // Sens
    public	const	int	SENS_AUCUN			= 0;
	public	const	int	SENS_EN_AVANT		= 1;
	public	const	int	SENS_EN_ARRIERE		= 2;

	// Vitesses
	public	const	int	VITESSE_NULLE 		=   0;
	public	const	int	VITESSE_LENTE		=  50;
	public	const	int	VITESSE_NORMALE		= 250;
	public	const	int	VITESSE_RAPIDE		= 350;



	/*
	 * Méthodes statiques
	 */
	
	public	static	String	codeDeTraitement( int _sens, int _vitesse ) {

		// Déclarations
		// ------------
		String	code;


		// Initialisations
		// ---------------
		code = "";


		// Contrôles
		// ---------
		_vitesse = contrôleDeLaVitesse( _vitesse );


		// Traitements
		// -----------
		switch( _sens ) {
		case (int)SENS_EN_AVANT :
			code = "motor.left.target=" + _vitesse + " motor.right.target=" + _vitesse;
			break;
		case (int)SENS_EN_ARRIERE :
			code = "motor.left.target=-" + _vitesse + " motor.right.target=-" + _vitesse;
			break;
		}


		// Fin
		// ---
		return code;

	}

	public	static	int		contrôleDeLaVitesse( int _vitesse ) {
		if ( _vitesse < -500 ) _vitesse = -500;
		if ( _vitesse >  500 ) _vitesse =  500;
		return _vitesse;
	}

}

