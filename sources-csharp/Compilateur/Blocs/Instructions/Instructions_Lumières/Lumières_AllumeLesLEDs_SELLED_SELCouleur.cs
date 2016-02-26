
/*
 * Lumières_AllumeLesLEDs_SELLED_SELCouleur
 * ----------------------------------------
 *
 * Allume les LEDs de Thymio,
 * avec le choix des LEDs et la couleur choisie.
 * 
 * Niveau de l'instruction : Facile
 * 
 */


using 	System;
using 	System.Globalization;
using 	System.Xml;



namespace	Blockly4Thymio {
public	class	Lumières_AllumeLesLEDs_SELLED_SELCouleur : __Lumières_AllumeLesLEDs {

	/*
	 * Constructeur
	 */
	public	Lumières_AllumeLesLEDs_SELLED_SELCouleur( int _UID, XmlNode _XMLDuBloc, __Bloc _blocPrécédent, __GroupeDInstructions _groupe ) : base( _UID, _XMLDuBloc, _blocPrécédent, _groupe, __LED.AUCUNE, 0 ) {

		// Déclarations
		// ------------

		String	nomDeLAttribut;


        // Traitements
        // -----------

        // Analyse du Bloc d'instruction
        foreach (XmlNode XMLDUnNoeudFils in _XMLDuBloc.ChildNodes) {

            nomDeLAttribut = "";
            if (XMLDUnNoeudFils.Attributes["name"] != null)
                nomDeLAttribut = XMLDUnNoeudFils.Attributes["name"].Value;

            switch(nomDeLAttribut) {

            case "LED":
                switch( XMLDUnNoeudFils.InnerText ) {
				case "TOUTES_LES_LEDS" :
					__led = (int)__LED.TOUTE_LES_LEDS;
					break;
				case "LED_DU_DESSUS" :
					__led = (int)__LED.LED_DU_DESSUS;	
					break;
				case "LED_DE_GAUCHE" :
					__led = (int)__LED.LED_DE_GAUCHE;	
					break;
				case "LED_DE_DROITE" :
					__led = (int)__LED.LED_DE_DROITE;	
					break;
				}
                break;

            case "Couleur" :
				// Convertie la couleur en notation html, en entier
				__couleur = Int32.Parse(XMLDUnNoeudFils.InnerText.TrimStart('#'), NumberStyles.HexNumber);
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

