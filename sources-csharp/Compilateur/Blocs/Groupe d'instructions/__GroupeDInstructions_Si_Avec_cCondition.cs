
using 	System;
using 	System.Xml;



namespace		Blockly4Thymio {
public	class	__GroupeDInstructions_Si_Avec_cCondition : __GroupeDInstructions_Condition {
	
    /*
     * Constructeur
     */
    public	__GroupeDInstructions_Si_Avec_cCondition( int _UID, XmlNode _XMLDuBloc, __Bloc _blocPrécédent, __GroupeDInstructions _groupe, String _conditionDEntré ) : base( _UID, _XMLDuBloc, _blocPrécédent, _groupe ) {
	
		// Déclarations
		// ------------

		String	nomDeLAttribut;

		XmlNode	XMLInterne;


		// Traitements
        // -----------

		// Initialisation des membres
		// --------------------------
		__nombreDeSéquenceInitiale = 1;


		// Condition d'entrée dans le groupe
		// ---------------------------------
		__conditionDEntré = _conditionDEntré;


        // Analyse du Bloc d'instruction
        foreach ( XmlNode XMLDUnNoeudFils in _XMLDuBloc.ChildNodes ) {

            nomDeLAttribut = "";
            if ( XMLDUnNoeudFils.Attributes["name"] != null )
                nomDeLAttribut = XMLDUnNoeudFils.Attributes["name"].Value;

            switch( nomDeLAttribut ) {
            case "Condition" :
				__conditionDEntré = Compilateur.AnalyseUnNoeudDExpression( _UID,  XMLDUnNoeudFils.FirstChild, _blocPrécédent, _groupe );
				break;
			}

		}






		

		// Blocs internes au groupe
		// ------------------------
	
		XMLInterne = _XMLDuBloc.SelectSingleNode( "./statement" );
		if ( XMLInterne != null )
			__blocsInternes = Compilateur.AnalyseUnNoeudDInstruction( _UID+1, XMLInterne.FirstChild, null, this );

		
    }


}
}


