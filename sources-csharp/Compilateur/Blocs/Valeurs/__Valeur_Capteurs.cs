
/*
 * __Capteur_RetourneLEtat
 * -----------------------
 *
 * Retourne l'état des capteurs.
 * 
 */


using 	System;
using 	System.Xml;



namespace Blockly4Thymio {
public class __Valeur_Capteurs : __Valeurs {


	/*
	 * Constructeur
	 */
	public	__Valeur_Capteurs( int _UID, XmlNode _XMLDuBloc, __Bloc _blocPrécédent, __GroupeDInstructions _groupe, int _capteur, int _valeur ) : base( _UID, _XMLDuBloc, _blocPrécédent, _groupe ) {

		// Initialisation des membres
		// --------------------------

		__code = __CAPTEURS.code( _capteur, _valeur );

	}


}
}

