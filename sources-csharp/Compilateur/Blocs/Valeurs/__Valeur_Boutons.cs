
/*
 * __Valeur_Boutons
 * ----------------
 *
 * Retourne l'état des boutons.
 * 
 */


using 	System;
using 	System.Xml;



namespace Blockly4Thymio {
public class __Valeur_Boutons : __Valeurs {


	/*
	 * Constructeur
	 */
	public	__Valeur_Boutons( int _UID, XmlNode _XMLDuBloc, __Bloc _blocPrécédent, __GroupeDInstructions _groupe, int _bouton ) : base( _UID, _XMLDuBloc, _blocPrécédent, _groupe ) {

		// Initialisation des membres
		// --------------------------

		__code = __BOUTONS.code( _bouton );

	}


}
}

