
/*
 * __Sons_JoueUneFréquence
 * -----------------------
 *
 * Joue une fréquence (en hertz)
 * pendant un temps donné (en seconde)
 *
 */



using 	System;
using 	System.Xml;


namespace	Blockly4Thymio {
public	class	__Sons_JoueUneFréquence_AvecDurée : __Instruction {

    /*
     * Membres
     */

    protected	int		__fréquence;

    protected	float	__durée;


	/*
	 * Propriétés surchargeant la classe mère Instruction.
     */
	public	override	int		nombreDeSéquence { get { return 2; } }

	public	override	String	codeDInitialisation {
    get {
        return "__chrono[" + UIDDuSéquenceur + "]=0 " +
                "call sound.freq(" + __fréquence + ", " + (int)(__durée * 60) + ")";
    }
    }

    public	override	String	conditionDePassageALInstructionSuivante {
    get {
        return "__chrono[" + UIDDuSéquenceur + "]>=" + (int)(__durée * 100);
    }
    }
	


	/*
	 * Constructeur
	 */
    public __Sons_JoueUneFréquence_AvecDurée(int _UID, XmlNode _XMLDuBloc, __Bloc _blocPrécédent, __GroupeDInstructions _groupe, int _fréquence, float _durée) : base(_UID, _XMLDuBloc, _blocPrécédent, _groupe) {

        // Initialisation des membres
        // --------------------------

        __durée = _durée;
        __fréquence = _fréquence;


        // Code d'initialisation
        // ---------------------

        // Surchargé dans la classe


        // Code de traitement
        // ------------------

        __codeDeTraitement = "__chrono[" + UIDDuSéquenceur + "]+=1";


        // Code de fin
        // -----------

        // Aucun


        // Condition de passage à l'instruction suivante
        // ---------------------------------------------

        // Surchargé dans la classe


	}


}
}

