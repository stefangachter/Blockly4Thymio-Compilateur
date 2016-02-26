
using 	System;
using 	System.Xml;



namespace	Blockly4Thymio {
public	class	__Bloc {
	
    /*
     * Membres
     */
    protected	int						__UID;
	protected	int						__UIDDuSéquenceur;
	protected	int						__nombreDeSéquenceInitiale;

	protected	String					__nomDansBlockly;

    protected	__GroupeDInstructions	__groupe;				// Si un bloc appartient un groupe de blocs (boucles, conditions)
    
	protected	__Bloc					__blocPrécédent;		// Bloc précédent
	protected	__Bloc					__blocSuivant;			// Bloc suivant



	/*
	 * Propriétés vituelles.
	 * Déclarées pour êre traitées en Override dans les classes filles
	 */
	virtual	public	int		nombreDeSéquence { get { return __nombreDeSéquenceInitiale; } }
	
	virtual	public	int		nombreDeSéquenceInitiale { get { return __nombreDeSéquenceInitiale; } }

	virtual	public	String	codePourLeSéquenceur { get { return ""; } }
	


    /*
     * Propriétés publiques
     */
	public	int		UID { get { return __UID; } }

	public	int		UIDDuSéquenceur { get { return __UIDDuSéquenceur; } }

	public	__Bloc	blocSuivant {
	get { return __blocSuivant; }
	set { __blocSuivant = value ; }
	}

	public	__GroupeDInstructions	groupe { get { return __groupe; } }



	/*
	 * Constructeur
	 */
	public	__Bloc( int _UID, XmlNode _XMLDuBloc, __Bloc _blocPrécédent, __GroupeDInstructions _groupe ) {

		__UID = _UID;

        __nomDansBlockly = _XMLDuBloc.Attributes["type"].Value;

        __blocPrécédent = _blocPrécédent;

        __groupe = _groupe;

		if ( __blocPrécédent != null )
			__UIDDuSéquenceur = __blocPrécédent.__UIDDuSéquenceur;
		if ( __groupe != null )
			__UIDDuSéquenceur = __groupe.UIDDuSéquenceur;
		
		
    }



	/*
	 * Méthodes
	 */
	/// <summary>
	/// Sur une suite de blocs, trouve le dernier bloc
	/// </summary>
	/// <returns></returns>
	public	__Bloc	DernierBlocsSuivant() {
		if ( __blocSuivant == null )
			return this;
		else
			return __blocSuivant.DernierBlocsSuivant();
	}


}
}

