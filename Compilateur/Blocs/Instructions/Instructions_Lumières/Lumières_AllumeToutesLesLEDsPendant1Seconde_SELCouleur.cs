
/*
 * Lumières_AllumeToutesLesLEDsPendant1Seconde_SELCouleur
 * ------------------------------------------------------
 *
 * Allume toutes les LEDs de Thymio pendant 1s,
 * avec la couleur choisie.
 *
 * Niveau de l'instruction : Découverte
 * 
 */

using 	System;
using 	System.Globalization;
using 	System.Xml;



namespace	Blockly4Thymio {
public	class	Lumières_AllumeToutesLesLEDsPendant1Seconde_SELCouleur : __Lumières_AllumeLesLED_AvecDurée {


	/*
	 * Constructeur
	 */
    public	Lumières_AllumeToutesLesLEDsPendant1Seconde_SELCouleur( int _UID, XmlNode _XMLDuBloc, __Bloc _blocPrécédent, __GroupeDInstructions _groupe ) : base( _UID, _XMLDuBloc, _blocPrécédent, _groupe, (int)__LED.TOUTE_LES_LEDS, 0, 1.0f ) {

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
            }

        }

    }


}
}

