
/*
 * Classe __SONS
 * -------------
 *
 * Pour la déclaration des constantes
 * et des fonctions des sons
 *
 */


using 	System;



public 		class 	__SONS {

	/*
	 * Constantes
	 */

	public enum DUREE {
		CROCHE = 0,
		NOIRE,
		BLANCHE
	}

	public enum NOTES {
		AUCUNE	= 0,
		DO_3, RÉ_3, MI_3, FA_3, SOL_3, LA_3, SI_3,
		DO_4, RÉ_4, MI_4, FA_4, SOL_4, LA_4, SI_4
	}

    public enum SON {
        PAS_DE_SON			=  -1,
        BONJOUR				=   0,
        HO					=   1,
        QUOI				=   2,
        JE_SUIS_PAS_CONTENT	=   3,
        SIRÈNE_DES_POMPIERS	= 100
    }


	/*
	 * Méthodes statiques
	 */
	/// <summary>
	/// Calcul la fréquence (en hertz) d'une note.
	/// </summary>
	/// <param name="_note"></param>
	/// <returns></returns>
	public	static	int	CalculLaFréquenceDUneNote( int _note ) {

		// Déclarations
		int	fréquence;


		// Initialisations
		fréquence = 0;


		// Traitements
		switch( _note ) {
		case (int)NOTES.DO_3 :	fréquence = 261; break;
		case (int)NOTES.RÉ_3 :	fréquence = 294; break;
		case (int)NOTES.MI_3 :	fréquence = 330; break;
		case (int)NOTES.FA_3 :	fréquence = 349; break;
		case (int)NOTES.SOL_3 :	fréquence = 392; break;
		case (int)NOTES.LA_3 :	fréquence = 440; break;
		case (int)NOTES.SI_3 :	fréquence = 494; break;
		case (int)NOTES.DO_4 :	fréquence = 522; break;		// 523->522, note corrigée le 08.02.16
		case (int)NOTES.RÉ_4 :	fréquence = 586; break;		// 587->586, note corrigée le 08.02.16 
		case (int)NOTES.MI_4 :	fréquence = 659; break;
		case (int)NOTES.FA_4 :	fréquence = 698; break;		// 699->698, note corrigée le 08.02.16
		case (int)NOTES.SOL_4 :	fréquence = 784; break;
		case (int)NOTES.LA_4 :	fréquence = 880; break;
		case (int)NOTES.SI_4 :	fréquence = 988; break;
		}


		// Fin
		return fréquence;

	}

	/// <summary>
	/// Calcul la durée (en seconde) d'une note
	/// </summary>
	/// <param name="_note"></param>
	/// <returns></returns>
	public	static	float	CalculLaDuréeDUneNote( int _note )
	{

		// Déclarations
		float durée;


		// Initialisations
		durée = 0;


		// Traitements
		switch( _note ) {
		case (int)DUREE.CROCHE :	durée = 0.25f; break;
		case (int)DUREE.NOIRE :		durée = 0.50f; break;
		case (int)DUREE.BLANCHE :	durée = 1.00f; break;
		}


		// Fin
		return durée;

	}
}

