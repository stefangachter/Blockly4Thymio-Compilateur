
/*
 * Lumières_AllumeLesLEDs_SELLED_SELCouleur_SAIDurée
 * -------------------------------------------------
 *
 * Allume les LEDs de Thymio,
 * avec le choix des LEDs, de la couleur et de la durée.
 * 
 */

using 	System;
using 	System.Globalization;
using 	System.Xml;



namespace	Blockly4Thymio {
public	class	Lumières_AllumeLesLEDs_SELLED_SELCouleur_SAIDurée : __Lumières_AllumeLesLED_AvecDurée {


	/*
	 * Constructeur
	 */
    public	Lumières_AllumeLesLEDs_SELLED_SELCouleur_SAIDurée( int _UID, XmlNode _XMLDuBloc, __Bloc _blocPrécédent, __GroupeDInstructions _groupe ) : base( _UID, _XMLDuBloc, _blocPrécédent, _groupe, (int)__LED.AUCUNE, 0, 0 ) {

        // Déclarations
        // ------------
        String	nomDeLAttribut;


		// Initialisations
		// ---------------

		
        // Traitements
        // -----------

        // Analyse du Bloc d'instruction
        foreach( XmlNode XMLDUnNoeudFils in _XMLDuBloc.ChildNodes ) {

            nomDeLAttribut = "";
            if ( XMLDUnNoeudFils.Attributes["name"] != null )
                nomDeLAttribut = XMLDUnNoeudFils.Attributes["name"].Value;

            switch( nomDeLAttribut ) {
            
			case "Couleur":
                // Convertie la couleur en notation html, en entier
                __couleur = Int32.Parse( XMLDUnNoeudFils.InnerText.TrimStart('#'), NumberStyles.HexNumber );
                break;

			case "Durée":
                __durée = Int32.Parse( XMLDUnNoeudFils.InnerText );
                break;

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

            }

        }

    }


}
}

