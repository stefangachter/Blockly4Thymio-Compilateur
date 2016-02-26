
using 	System;
using 	System.Xml;


namespace	Blockly4Thymio {
public	class	__GroupeDInstructions : __Bloc {

	/*
	 * Membres
	 */
	protected	__Bloc	__blocsInternes;



    /*
     * Constructeur
     */
    public	__GroupeDInstructions( int _UID, XmlNode _XMLDuBloc, __Bloc _blocPrécédent, __GroupeDInstructions _groupe ) : base( _UID, _XMLDuBloc, _blocPrécédent, _groupe ) {

		// Initialisations
		// ---------------

		__blocsInternes = null;

	}



	/*
	 * Propriétés
     */
	
	/// <summary>
	/// UID de la dernière séquence du groupe.
	/// </summary>
	public	int	UIDDeFin {
	get {
		__Bloc	dernierBloc;

		if ( __blocsInternes == null ) {
			// Il n'y a pas de bloc internes,
			// l'UID de la dernière séquence du groupe est calculé ici			
			return __UID + __nombreDeSéquenceInitiale -1;
		} else {
			// L'UID de la dernière séquence du groupe est calculé
			// par le dernier bloc du groupe.
			dernierBloc = __blocsInternes.DernierBlocsSuivant();	
			return dernierBloc.UID + dernierBloc.nombreDeSéquence;
		}
	}
	}


	/// <summary>
	/// Dans un groupe d'instructions, l'UIDDuBlocSuivant est
	/// l'UID du bloc qui est en dessous du groupe.
	/// </summary>
	public	int	UIDDuBlocSuivant {
    get {
		if ( blocSuivant == null ) {
			// Il n'y a pas de bloc suivant,
			if ( __groupe == null ) {
				// Et on est pas dans un autre groupe,
				// le séquenceur va s'arrêter.
				return 0;
			} else {
				// Et on est dans un autre groupe,
				// le séquenceur passe à la séquence de fin de cette autre boucle.
				return __groupe.UIDDeFin;
			}
		} else
			return blocSuivant.UID;
	}
	}


	/// <summary>
	/// UID du premier bloc interne du groupe.
	/// Ou UID de la séquence de fin du groupe.
	/// </summary>
	public	int	UIDDuPremierBloc {
	get {
		if ( __blocsInternes == null ) {
			// Il n'y a pas de blocs internes au groupe,
			// on passe à l'UID de fin
			return UIDDeFin;
		} else
			return __blocsInternes.UID;
	}
	}


}
}


