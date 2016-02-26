
/*
 * Lumières_AllumeToutesLesLEDs_SELCouleur
 * ---------------------------------------
 *
 * Allume toutes les LEDs de Thymio,
 * avec la couleur choisie.
 * 
 * Niveau de l'instruction : Facile
 * 
 */


using 	System;
using 	System.Globalization;
using 	System.Xml;



namespace	Blockly4Thymio {
public	class	Lumières_AllumeToutesLesLEDs_SELCouleur : __Lumières_AllumeLesLEDs {

	/*
	 * Constructeur
	 */
	public	Lumières_AllumeToutesLesLEDs_SELCouleur( int _UID, XmlNode _XMLDuBloc, __Bloc _blocPrécédent, __GroupeDInstructions _groupe ) : base( _UID, _XMLDuBloc, _blocPrécédent, _groupe, __LED.TOUTE_LES_LEDS, 0 ) {

		// Déclarations
		// ------------

		String	nomDeLAttribut;



        // Traitements
        // -----------

        // Analyse du Bloc d'instruction
        foreach ( XmlNode XMLDUnNoeudFils in _XMLDuBloc.ChildNodes ) {

            nomDeLAttribut = "";
            if (XMLDUnNoeudFils.Attributes["name"] != null)
                nomDeLAttribut = XMLDUnNoeudFils.Attributes["name"].Value;

            switch( nomDeLAttribut ) {

            case "Couleur" :
				// Convertie la couleur en notation html, en entier
				__couleur = Int32.Parse( XMLDUnNoeudFils.InnerText.TrimStart('#'), NumberStyles.HexNumber );
				break;
			
			}

		}


		// Taille de l'instruction
		// -----------------------

		// Dans la classe mère


		// Code d'initialisation
		// ---------------------

		// Aucun


		// Code de traitement
		// ------------------

		// Dans la classe mère


		// Code de fin
		// -----------

		// Aucun


		// Condition de passage à l'instruction suivante
		// ---------------------------------------------

		// Aucune
	
	}
	

}
}

