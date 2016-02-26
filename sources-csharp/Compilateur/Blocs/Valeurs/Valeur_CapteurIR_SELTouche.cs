
/*
 * Valeur_CapteurIR_SELTouche
 * --------------------------
 *
 * Retourne le code pour vérifier une commande rc5.
 * 
 */


using 	System;
using 	System.Xml;



namespace Blockly4Thymio {
public class Valeur_CapteurIR_SELTouche : __Valeurs {


	/*
	 * Constructeur
	 */
	public	Valeur_CapteurIR_SELTouche( int _UID, XmlNode _XMLDuBloc, __Bloc _blocPrécédent, __GroupeDInstructions _groupe ) : base( _UID, _XMLDuBloc, _blocPrécédent, _groupe ) {

		// Déclarations
		// ------------

		String	nomDeLAttribut;



        // Traitements
        // -----------

        // Analyse du Bloc d'instruction
        foreach  (XmlNode XMLDUnNoeudFils in _XMLDuBloc ) {

            nomDeLAttribut = "";
            if (XMLDUnNoeudFils.Attributes["name"] != null)
                nomDeLAttribut = XMLDUnNoeudFils.Attributes["name"].Value;
			
            switch(nomDeLAttribut) {
			
            case "Touche":
				switch( XMLDUnNoeudFils.InnerText ) {
				case "0" :
				case "1" :
				case "2" :
				case "3" :
				case "4" :
				case "5" :
				case "6" :
				case "7" :
				case "8" :
				case "9" :
					__code = "rc5.command==" + XMLDUnNoeudFils.InnerText;
					break;
				}
                break;
				
			}

		}


	}


}
}

