
/*
 * __Contrôle_Attends_AvecDurée
 * ----------------------------
 *
 * Fait une pause dans le programme,
 * pendant un temps donné (en seconde)
 *
 */



using 	System;
using 	System.Xml;


namespace	Blockly4Thymio {
public	class	__Contrôle_Attends_Avec_cDurée : __Instruction {

	/*
	 * Membres
	 */
    protected	String __durée;



	/*
	 * Propriétés surchargeant la classe mère Instruction.
     */
	public	override	int		nombreDeSéquence { get { return 2; } }

    public	override	String	codeDInitialisation {
    get {
        return "__chrono[" + UIDDuSéquenceur + "]=100*" + __durée;
    }
    }



	/*
	 * Propriétés
     */
	public	String	durée {
	get { return __durée; }
	set { __durée = value; }
	}



	/*
	 * Constructeur
	 */
    public	__Contrôle_Attends_Avec_cDurée( int _UID, XmlNode _XMLDuBloc, __Bloc _blocPrécédent, __GroupeDInstructions _groupe, String _durée ) : base( _UID, _XMLDuBloc, _blocPrécédent, _groupe ) {

        // Initialisation des membres
        // --------------------------

        durée = _durée;


        // Code d'initialisation
        // ---------------------
        // Surchargé dans la classe


        // Code de traitement
        // ------------------
        __codeDeTraitement = "__chrono[" + UIDDuSéquenceur + "]-=1";


        // Code de fin
        // -----------

        // Aucun


        // Condition de passage à l'instruction suivante
        // ---------------------------------------------
		__conditionDePassageALInstructionSuivante = "__chrono[" + UIDDuSéquenceur + "]<=0";

    }


}
}

