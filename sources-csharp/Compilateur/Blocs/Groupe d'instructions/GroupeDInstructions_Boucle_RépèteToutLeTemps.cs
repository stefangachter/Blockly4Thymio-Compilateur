

using 	System.Xml;



namespace	Blockly4Thymio {
public	class	GroupeDInstructions_Boucle_RépèteToutLeTemps : __GroupeDInstructions_Boucle { 
		
    /*
     * Constructeur
     */
    public	GroupeDInstructions_Boucle_RépèteToutLeTemps( int _UID, XmlNode _XMLDuBloc, __Bloc _blocPrécédent, __GroupeDInstructions _groupe ) : base( _UID, _XMLDuBloc, _blocPrécédent, _groupe ) {
	
		// Déclarations
		// ------------
		XmlNode	XMLInterne;


		// Initialisation des membres
		// --------------------------

		__nombreDeSéquenceInitiale = 2;


		// Code d'initialisation du groupe
		// -------------------------------

		// Aucun


		// Code d'action en début de boucle
		// --------------------------------

		// Aucun


		// Condition d'entrée dans le groupe
		// ---------------------------------

		// Aucune
		
		
		// Code d'action en fin de groupe
		// ------------------------------

		// Aucun
		

		// Condition de sortie dans le groupe
		// ----------------------------------

		__conditionDeSortie = "1==0";


		// Blocs internes au groupe
		// ------------------------
	
		XMLInterne = _XMLDuBloc.SelectSingleNode( "./statement" );
		if ( XMLInterne != null )
			__blocsInternes = Compilateur.AnalyseUnNoeudDInstruction( UIDDeLaSéquenceDeBoucle+1, XMLInterne.FirstChild, null, this );

		
    }


}
}

