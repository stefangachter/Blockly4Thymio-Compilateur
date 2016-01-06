

using System;
using System.Xml;



namespace	Blockly4Thymio {
public	class	__GroupeDInstructions_Condition : __GroupeDInstructions {

	/*
	 * Membres
	 */
	protected	String	__conditionDEntré;



	/*
	 * Propriétés virtuelles
     */
	virtual	public	String	conditionDEntré { get { return __conditionDEntré; } }

	virtual	public	__Bloc	blocsInternes { get { return __blocsInternes; } }
	
	
	
	/*
	 * Propriétés surchargeant la classe mère Bloc.
     */
	public	override	int		nombreDeSéquence {
	get {
		// Déclarations
		int		nombre;
		__Bloc	dernierBloc;

		// Traitements
		nombre = __nombreDeSéquenceInitiale;
		if ( __blocsInternes != null ) {
			dernierBloc = blocsInternes.DernierBlocsSuivant();
			nombre += dernierBloc.UID - __blocsInternes.UID + dernierBloc.nombreDeSéquence;
		}

		// Fin
		return nombre;

	}
	}

	public	override	String	codePourLeSéquenceur {
	get {

		// Déclarations
		// ------------
		String	code;
		String	marqueur;


		// Initialisations
		// ---------------
		code ="";
		// Un marqueur de code est créer. Il sera remplacé par l'UID de l'instruction de fin de la condition
		// quand le code interne de la condition sera évalué et que l'UID de l'instruction de fin sera connue.
		marqueur = Compilateur.NouveauMarqueur();



		// Traitements
		// -----------
			
		// Séquences de début de groupe
		// ----------------------------
		if ( Compilateur.afficherLesCommentaires ) { code += "\n# Instruction Blockly (UID " + __UID + ") = DEBUT " + __nomDansBlockly + "\n"; }
						
		
		// Teste la condition d'entrée.
		code += "if __sequenceur[" + __UIDDuSéquenceur + "]==" + __UID + " then\n";
		code += "  if " + conditionDEntré  + " then\n";
		code += "    __sequenceur[" + __UIDDuSéquenceur + "]=" + UIDDuPremierBloc + "\n";
		code += "  else\n";
		code += "    __sequenceur[" + __UIDDuSéquenceur + "]=" + marqueur + "\n";
		code += "  end\n";
		code += "end\n";
		
		
		// Blocs internes
		// --------------
		
		// Ajoute les blocs internes
		if ( blocsInternes != null ) { code += blocsInternes.codePourLeSéquenceur; }
		
		// Remplace le marqueur par l'UID du bloc suivant
		if ( blocSuivant != null ) {
			// UID de l'instruction après la condition
			code = code.Replace( marqueur, "" + UIDDeFin );
		} else {
			// Il n'y a pas de bloc suivant, le séquenceur s'arrête
			code = code.Replace( marqueur, "" + UIDDuBlocSuivant );
		}


		// Séquence de fin du groupe
		// -------------------------
		if ( Compilateur.afficherLesCommentaires ) { code += "\n# Instruction Blockly (UID " + __UID + ") = FIN " + __nomDansBlockly + "\n"; }
		
		// Ajoute le bloc suivant
		if ( blocSuivant != null ) { code += blocSuivant.codePourLeSéquenceur; }


		// Fin
		// ---

		return code;

	}
	}



	/*
     * Constructeur
     */
	public	__GroupeDInstructions_Condition( int _UID, XmlNode _XMLDuBloc, __Bloc _blocPrécédent, __GroupeDInstructions _groupe ) : base( _UID, _XMLDuBloc, _blocPrécédent, _groupe ) {

		// Initialisations
		// ---------------

		__conditionDEntré = "";

		__blocsInternes = null;

	}


}
}

