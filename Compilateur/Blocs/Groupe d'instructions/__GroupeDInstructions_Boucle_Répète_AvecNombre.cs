
using 	System;
using 	System.Xml;


namespace	Blockly4Thymio {
public	class	__GroupeDInstructions_Boucle_Répère_AvecNombre : __GroupeDInstructions_Boucle {

    /*
     * Membres
     */
    public	static	int	__compteurDeBoucle;				// Nombre de groupe d'instructions de type Boucle_Répète_AvecNombre
    
	public			int	__UIDDeBoucle;					// Identifiant du compteur de boucle dans Aseba

	private			int	__nombreDeBoucleAFaire;


	
	/*
	 * Propriétés surchargeant la classe mère __GroupeDInstructions.
     */
	public override String codeDInitialisation {
	get { return "__boucles[" + (__UIDDeBoucle-1) + "]=" + __nombreDeBoucleAFaire; }
	}
	


	/*
	 * Propriétés
     */
	public	int	nombreDeBoucleAFaire {
	get { return __nombreDeBoucleAFaire; }
	set {
		__nombreDeBoucleAFaire = value;
		// Limite le nombre de boucles
		if ( __nombreDeBoucleAFaire <= 0 ) {
			__nombreDeBoucleAFaire = 1;
			Compilateur.AfficheUnMessageDInformation( Compilateur.Message(0x0001) );
		}
		if ( __nombreDeBoucleAFaire > 100 ) {
			__nombreDeBoucleAFaire = 100;
			Compilateur.AfficheUnMessageDInformation( Compilateur.Message(0x0002) );
		}
	}
	}


    /*
     * Constructeur
     */
    public	__GroupeDInstructions_Boucle_Répère_AvecNombre( int _UID, XmlNode _XMLDuBloc, __Bloc _blocPrécédent, __GroupeDInstructions _groupe, int _nombreDeBoucleAFaire ) : base( _UID, _XMLDuBloc, _blocPrécédent, _groupe ) {
	
		// Déclarations
		// ------------
		XmlNode	XMLInterne;


		// Initialisation des membres
		// --------------------------

		__nombreDeSéquenceInitiale = 3;

		__compteurDeBoucle++;

		nombreDeBoucleAFaire = _nombreDeBoucleAFaire;

		__UIDDeBoucle = __compteurDeBoucle;


		// Code d'initialisation du groupe
		// -------------------------------

		// Surchargé dans la classe


		// Code d'action en début de boucle
		// --------------------------------

		__codeDActionEnDébut = "__boucles[" + (__UIDDeBoucle-1) + "]--";


		// Condition d'entrée dans le groupe
		// ---------------------------------

		// Aucune
		
		
		// Code d'action en fin de groupe
		// ------------------------------

		// Aucun
		

		// Condition de sortie dans le groupe
		// ----------------------------------

		__conditionDeSortie = "__boucles[" + (__UIDDeBoucle-1) + "]==0";


		// Blocs internes au groupe
		// ------------------------
	
		XMLInterne = _XMLDuBloc.SelectSingleNode( "./statement" );
		if ( XMLInterne != null )
			__blocsInternes = Compilateur.AnalyseUnNoeudDInstruction( UIDDeLaSéquenceDeBoucle+1, XMLInterne.FirstChild, null, this );

		
    }


}
}


