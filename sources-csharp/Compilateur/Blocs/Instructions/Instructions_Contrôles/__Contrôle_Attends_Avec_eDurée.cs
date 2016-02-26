
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
public	class	__Contrôle_Attends_Avec_eDurée : __Instruction {

	/*
	 * Membres
	 */
    protected	int __durée;



	/*
	 * Propriétés surchargeant la classe mère Instruction.
     */
	public	override	int		nombreDeSéquence { get { return 2; } }

    public	override	String	conditionDePassageALInstructionSuivante {
    get {
        return "__chrono[" + UIDDuSéquenceur + "]>=" + (__durée * 100);
    }
    }



	/*
	 * Propriétés
     */
	public	int	durée{
	get { return __durée; }
	set {
		__durée = value;
		if ( __durée < 0 ) {			
			__durée = 0;
			Compilateur.AfficheUnMessageDInformation( Compilateur.Message(0x0003) );
		}
		if ( __durée > 60 ) {			
			__durée = 60;
			Compilateur.AfficheUnMessageDInformation( Compilateur.Message(0x0004) );
		}
	}
	}



	/*
	 * Constructeur
	 */
    public	__Contrôle_Attends_Avec_eDurée( int _UID, XmlNode _XMLDuBloc, __Bloc _blocPrécédent, __GroupeDInstructions _groupe, int _durée ) : base( _UID, _XMLDuBloc, _blocPrécédent, _groupe ) {

        // Initialisation des membres
        // --------------------------

        durée = _durée;


        // Code d'initialisation
        // ---------------------
        __codeDInitialisation = "__chrono[" + UIDDuSéquenceur + "]=0";


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

