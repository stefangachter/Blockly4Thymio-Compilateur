

using System;
using System.Xml;



namespace	Blockly4Thymio {
public	class	__GroupeDInstructions_Boucle : __GroupeDInstructions {

	/*
	 * Membres
	 */
	/// <summary>
	/// Code d'action éxécuté à chaque boucle, au début du groupe
	/// </summary>
	protected	String	__codeDActionEnDébut;				// Séquence #2 du groupe
	/// <summary>
	/// Code d'action éxécuté à chaque boucle, à la fin du groupe
	/// </summary>
	protected	String	__codeDActionEnFin;					// Séquence #3 du groupe
	protected	String	__codeDInitialisation;				// Séquence #1 du groupe
    protected	String	__conditionDeSortie;				// Séquence #3 du groupe



	/*
	 * Propriétés virtuelles
     */
	virtual	public	String	codeDActionEnDébut { get { return __codeDActionEnDébut; } }

	virtual	public	String	codeDInitialisation { get { return __codeDInitialisation; } }

	virtual	public	String	conditionDeSortie { get { return __conditionDeSortie; } }

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


		// Initialisations
		// ---------------
		code ="";


		// Traitements
		// -----------
			
		// Séquences de début de groupe
		// ----------------------------
		if ( Compilateur.afficherLesCommentaires ) { code += "\n# Instruction Blockly (UID " + __UID + ") = DEBUT " + __nomDansBlockly + "\n"; }
						
		
		// Séquence d'initialisation.
		if ( codeDInitialisation != "" ) {
			// Il y a un code d'initialisation,
			// une séquence est ajoutée en début de groupe pour cette initialisation.
			code += "if __sequenceur[" + __UIDDuSéquenceur + "]==" + __UID + " then\n";
			code += "  " + codeDInitialisation;
			code += "  __sequenceur[" + __UIDDuSéquenceur + "]=" + UIDDeLaSéquenceDeBoucle + "\n";
			code += "end\n";
		} 		
		// Séquence de boucle
		code += "if __sequenceur[" + __UIDDuSéquenceur + "]==" + UIDDeLaSéquenceDeBoucle + " then\n";
		if ( codeDActionEnDébut != "" )
			code += "  " + codeDActionEnDébut + "\n";
		code += "  __sequenceur[" + __UIDDuSéquenceur + "]=" + UIDDuPremierBloc + "\n";
		code += "end\n";
		
		
		// Blocs internes
		// --------------
		if ( blocsInternes != null )
			code += blocsInternes.codePourLeSéquenceur;
		
		
		// Séquence de fin du groupe
		// -------------------------
		if ( Compilateur.afficherLesCommentaires ) { code += "\n# Instruction Blockly (UID " + __UID + ") = FIN " + __nomDansBlockly + "\n"; }
			
		code += "if __sequenceur[" + __UIDDuSéquenceur + "]==" + UIDDeFin + " then\n";
		if ( __codeDActionEnFin != "" )
			code += "  " + __codeDActionEnFin + "\n";
		if ( __conditionDeSortie == "" ) {
			// Il y a pas de condition de sortie du groupe,
			// le séquenceur boucle sur la séquence de boucle.
			code += "  __sequenceur[" + __UIDDuSéquenceur + "]=" + UIDDeLaSéquenceDeBoucle + "\n";
		} else {
			// Il y a une de condition de sortie du groupe,
			// elle est testée pour sortir
			code += "  if " + __conditionDeSortie + " then\n";
			// La condition est vrai, le séquenceur sort du groupe.
			code += "    __sequenceur[" + __UIDDuSéquenceur + "]=" + UIDDuBlocSuivant + "\n";
			code += "  else\n";
			// La condition est fausse, le séquenceur boucle sur la séquence de boucle.
			code += "    __sequenceur[" + __UIDDuSéquenceur + "]=" + UIDDeLaSéquenceDeBoucle + "\n";
			code += "  end\n";
		}
		code += "end\n";


		// Ajoute le bloc suivant
		if ( blocSuivant != null ) { code += blocSuivant.codePourLeSéquenceur; }


		// Fin
		// ---

		return code;

	}
	}




		
	/// <summary>
	/// UID de la séquence sur laquelle boucle le groupe.
	/// </summary>
	public	int	UIDDeLaSéquenceDeBoucle {
	get {
		if ( codeDInitialisation == "" ) {
			// Il n'y a pas de séquence d'initialisation,
			// la boucle est faite sur l'UID de la première séquence du groupe
			return __UID;
		} else {
			// Il y a une séquence d'initialisation,
			// la boucle est faite sur l'UID de la deuxième séquence du groupe
			return __UID+1;
		}
	}
	}



	/*
     * Constructeur
     */
	public	__GroupeDInstructions_Boucle( int _UID, XmlNode _XMLDuBloc, __Bloc _blocPrécédent, __GroupeDInstructions _groupe ) : base( _UID, _XMLDuBloc, _blocPrécédent, _groupe ) {

		__codeDActionEnDébut	= "";
		__codeDActionEnFin		= "";
		__codeDInitialisation	= "";
		__conditionDeSortie		= "";

	}


}
}

