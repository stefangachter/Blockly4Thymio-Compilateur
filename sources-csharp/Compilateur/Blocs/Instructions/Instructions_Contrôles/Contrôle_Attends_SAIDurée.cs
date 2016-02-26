
/*
 * __Contrôle_Attends_AvecDurée
 * ----------------------------
 *
 * Fait une pause dans le programme,
 * pendant un temps saisi (en seconde)
 *
 */


using 	System;
using 	System.Globalization;
using 	System.Xml;



namespace	Blockly4Thymio {
public	class	Contrôle_Attends_SAIDurée : __Contrôle_Attends_Avec_eDurée {

	/*
	 * Constructeur
	 */
	public	Contrôle_Attends_SAIDurée( int _UID, XmlNode _XMLDuBloc, __Bloc _blocPrécédent, __GroupeDInstructions _groupe ) : base( _UID, _XMLDuBloc, _blocPrécédent, _groupe, 0 ) {

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

            case "Durée" :				
				__durée = Int32.Parse( XMLDUnNoeudFils.InnerText );
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

		// Dans la classe mère
	
	}
	

}
}

