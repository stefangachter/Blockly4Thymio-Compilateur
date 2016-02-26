
/*
 * __Lumières_AllumeLesLEDs
 * ------------------------
 *
 * Allume les LEDs de Thymio,
 * avec le choix des LEDs et la couleur choisie.
 *
 * Niveau de l'instruction : Découverte
 * 
 */


using 	System;
using 	System.Xml;



namespace Blockly4Thymio {
public class __Lumières_AllumeLesLEDs : __Instruction {

	/*
	 * Membres
	 */
	protected	int __couleur;
	protected	int __led;



	/*
	 * Propriétés surchargeant la classe mère Instruction.
     */
	public	override	int		nombreDeSéquence { get { return 1; } }

	public	override	String	codeDeTraitement{ get { return __LED.code( __led, __couleur ); } }



	/*
	 * Constructeur
	 */
	public	__Lumières_AllumeLesLEDs( int _UID, XmlNode _XMLDuBloc, __Bloc _blocPrécédent, __GroupeDInstructions _groupe, int _led, int _couleur ) : base( _UID, _XMLDuBloc, _blocPrécédent, _groupe ) {

		// Initialisation des membres
		// --------------------------

		__couleur = _couleur;
		__led = _led;


		// Taille de l'instruction
		// -----------------------

		// Par défaut : 1


		// Code d'initialisation
		// ---------------------

		// Aucun


		// Code de traitement
		// ------------------

		// Surchargé dans la classe		


		// Code de fin
		// -----------

		// Aucun



		// Condition de passage à l'instruction suivante
		// ---------------------------------------------

		// Aucune

	}


}
}

