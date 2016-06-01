

using 	System;
using 	System.Xml;



namespace		Blockly4Thymio {
public	class	__Instruction : __Bloc {

    /*
     * Membres
     */
    protected	String	__codeDeFin;
    protected	String	__codeDeTraitement;
    protected	String	__codeDInitialisation;
   	protected	String	__conditionDePassageALInstructionSuivante;




    /*
	 * Propriétés vituelles.
	 * Déclarées pour êre traitées en Override dans les classes filles
     */
    virtual public String codeDeTraitement { get { return __codeDeTraitement; } }
	
    virtual public String codeDeFin { get { return __codeDeFin; } }

    virtual public String codeDInitialisation { get { return __codeDInitialisation; } }

    virtual public String conditionDePassageALInstructionSuivante { get { return __conditionDePassageALInstructionSuivante; } }



	/*
	 * Propriétés surchargeant la classe mère __Bloc.
     */
    public override String codePourLeSéquenceur {
	get {
        // Déclarations
		// ------------
		String 					code;

		__GroupeDInstructions	groupeDuBloc;


		// Initialisations
		// ---------------
		code = "";


		// Traitements
		// -----------

		// Début de l'instruction
		if (Compilateur.afficherLesCommentaires) {
			code += "\n# Instruction Blockly (UID " + __UID + ") = " + __nomDansBlockly + "\n";
		}


		if (conditionDePassageALInstructionSuivante == "") {

			// Il n'y a pas de condition de passage au bloc suivant

			code += "if __sequenceur[" + UIDDuSéquenceur + "]==" + UID + " then\n";

			// Ajoute le code de traitement
			if (codeDeTraitement != "") {
				code += "  " + codeDeTraitement + "\n";
			}


			if (blocSuivant == null) {
					
				// Il n'y a pas de bloc suivant
				if (groupe == null) {
					// Le bloc n'est pas dans un groupe,
					// le séquenceur s'arrête.
					code += "  __sequenceur[" + UIDDuSéquenceur + "]=0\n";
				} else {
					
					// Le bloc est dans un groupe,
					// le séquenceur passe à la séquence de fin de ce groupe
					groupeDuBloc = (__GroupeDInstructions)groupe;

					switch( groupeDuBloc.type ) {
					case (int)__GroupeDInstructions.TYPE.BOUCLE :
						// Il y a une séquence de fin dans les groupes de type boucle
						code += "  __sequenceur[" + UIDDuSéquenceur + "]=" + groupeDuBloc.UIDDeFin + "\n";
						break;
					case (int)__GroupeDInstructions.TYPE.CONDITION :
						// Il n'y a pas de séquence de fin dans les groupes de type condition
						if ( groupeDuBloc.blocSuivant == null ) {
							// Pas de bloc suivant le groupe, le séquenceur s'arrête
							code += "  __sequenceur[" + UIDDuSéquenceur + "]=0\n";
						} else {
							// Il y a un bloc après le groupe, le séquenceur passe sur celui-ci
							code += "  __sequenceur[" + UIDDuSéquenceur + "]=" + groupeDuBloc.blocSuivant.UID + "\n";
						}
						break;
					}

				}

			} else {
					
				// Il y a un bloc suivant.
				// Le séquenceur passe à la séquence suivante
				code += "  __sequenceur[" + UIDDuSéquenceur + "]=" + blocSuivant.UID + "\n";

			}

			code += "end\n";

		} else {

			// Il y a une condition de passage au bloc suivant, on crée deux sous-code.

			// 1er sous-code avec le code de traitement
			// ----------------------------------------
			code += "if __sequenceur[" + UIDDuSéquenceur + "]==" + UID + " then\n";
			// Ajoute le code d'initialisation
			if ( codeDInitialisation != "" ) { code += "  " + codeDInitialisation + "\n"; }
			code += "  __sequenceur[" + UIDDuSéquenceur + "]=" + (UID + 1) + "\n";
			code += "end\n";

			// 2ème sous-code avec vérification de la condition
			// ------------------------------------------------
			code += "if __sequenceur[" + UIDDuSéquenceur + "]==" + (UID + 1) + " then\n";

			if ( codeDeTraitement != "" ) { code += "  " + codeDeTraitement + "\n"; }

			code += "  if " + conditionDePassageALInstructionSuivante + " then\n";

			// Il y a un code de fin à éxecuter si la condition est vrai
			if ( codeDeFin != "" ) { code += "    " + codeDeFin + "\n"; }

			if ( blocSuivant == null ) {
					
				// Il n'y a pas de bloc suivant
				if ( groupe == null ) {
					// Le bloc n'est pas dans un groupe,
					// le séquenceur s'arrête.
					code += "    __sequenceur[" + UIDDuSéquenceur + "]=0\n";
				} else {

					// Le bloc est dans un groupe,
					// le séquenceur passe à la séquence de fin de ce groupe
					groupeDuBloc = (__GroupeDInstructions)groupe;
					switch( groupeDuBloc.type ) {
					case (int)__GroupeDInstructions.TYPE.BOUCLE :
						// Il y a une séquence de fin dans les groupes de type boucle
						code += "  __sequenceur[" + UIDDuSéquenceur + "]=" + groupeDuBloc.UIDDeFin + "\n";
						break;
					case (int)__GroupeDInstructions.TYPE.CONDITION :
						// Il n'y a pas de séquence de fin dans les groupes de type condition
						if (groupeDuBloc.blocSuivant == null) {
							// Pas de bloc suivant le groupe, le séquenceur s'arrête
							//code += "  __sequenceur[" + UIDDuSéquenceur + "]=0\n";
							code += "  __sequenceur[" + UIDDuSéquenceur + "]=" + groupeDuBloc.UIDDeFin + "\n";
						} else {
							// Il y a un bloc après le groupe, le séquenceur passe sur celui-ci
							code += "  __sequenceur[" + UIDDuSéquenceur + "]=" + groupeDuBloc.blocSuivant.UID + "\n";
						}
						break;
					}

				
				}

			} else {
					
				// Il y a un bloc suivant.
				// Le séquenceur passe à la séquence suivante
				code += "    __sequenceur[" + UIDDuSéquenceur + "]=" + blocSuivant.UID + "\n";

			}

			code += "  end\n";
			code += "end\n";

		}
				
		// Ajoute l'instruction suivante
		if ( blocSuivant != null ) { code += blocSuivant.codePourLeSéquenceur; }



		// Fin
		// ---
		return code;

    }
    }



    /*
     * Constructeur
     */
    public	__Instruction( int _UID, XmlNode _XMLDuBloc, __Bloc _blocPrécédent, __GroupeDInstructions _groupe ) : base( _UID, _XMLDuBloc, _blocPrécédent, _groupe ) {

		// Initialisations
		// ---------------

		__codeDeFin									= "";
        __codeDeTraitement							= "";
        __codeDInitialisation						= "";
        __conditionDePassageALInstructionSuivante	= "";

    }


}
}



