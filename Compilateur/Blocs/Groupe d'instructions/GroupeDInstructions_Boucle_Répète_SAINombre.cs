
using 	System;
using 	System.Xml;


namespace	Blockly4Thymio {
public	class	GroupeDInstructions_Boucle_Répète_SAINombre : __GroupeDInstructions_Boucle_Répère_AvecNombre {
	
    /*
     * Constructeur
     */
	// Initialise le nomber de boucle à 1, par défaut
    public	GroupeDInstructions_Boucle_Répète_SAINombre( int _UID, XmlNode _XMLDuBloc, __Bloc _blocPrécédent, __GroupeDInstructions _groupe ) : base( _UID, _XMLDuBloc, _blocPrécédent, _groupe, 1 ) {
		
		// Déclarations
		// ------------

		String	nomDeLAttribut;


		// Traitements
        // -----------

        // Analyse du Bloc d'instruction
        foreach ( XmlNode XMLDUnNoeudFils in _XMLDuBloc.ChildNodes ) {

            nomDeLAttribut = "";
            if ( XMLDUnNoeudFils.Attributes["name"] != null )
                nomDeLAttribut = XMLDUnNoeudFils.Attributes["name"].Value;

            switch( nomDeLAttribut ) {
            case "NombreDeBoucle" :
				nombreDeBoucleAFaire = Int32.Parse( XMLDUnNoeudFils.InnerText );
				break;
			}

		}


		// Code d'initialisation du groupe
		// -------------------------------

		// Surchargé dans la classe mère


		// Code d'action en début de boucle
		// --------------------------------

		// Dans la classe mère


		// Condition d'entrée dans le groupe
		// ---------------------------------

		// Aucune
		
		
		// Code d'action en fin de groupe
		// ------------------------------

		// Aucun
		

		// Condition de sortie dans le groupe
		// ----------------------------------

		// Dans la classe mère


		// Blocs internes au groupe
		// ------------------------

		// Dans la classe mère

    }


}
}

