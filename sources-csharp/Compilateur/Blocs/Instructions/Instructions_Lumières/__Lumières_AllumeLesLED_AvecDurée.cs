
/*
 * __Lumières_AllumeLesLED_AvecDurée
 * ---------------------------------
 *
 * Allume une ou toute les LEDs,
 * à la couleur demandée (entier long),
 * pendant un temps donné (en seconde)
 *
 */


using 	System;
using 	System.Xml;



namespace	Blockly4Thymio {
public	class	__Lumières_AllumeLesLED_AvecDurée : __Instruction {

    /*
	 * Membres
	 */
    protected	int		__couleur;
    protected	int		__led;

    protected	float	__durée;



	/*
	 * Propriétés surchargeant la classe mère Instruction.
     */
	public	override	int		nombreDeSéquence { get { return 2; } }

	public	override	String	codeDInitialisation {
        get { return __LED.code( __led, __couleur ) + " __chrono[" + UIDDuSéquenceur + "]=0"; }
    }

    public	override	String	conditionDePassageALInstructionSuivante {
        get { return "__chrono[" + UIDDuSéquenceur + "]>=" + (int)(__durée * 100); }
    }

    public	override	String	codeDeFin {
        get { return __LED.code( __led, 0 ); }
    }



	/*
	 * Propriétés
     */
	public	float	durée{
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
	public	__Lumières_AllumeLesLED_AvecDurée( int _UID, XmlNode _XMLDuBloc, __Bloc _blocPrécédent, __GroupeDInstructions _groupe, int _led, int _couleur, float _durée ) : base( _UID, _XMLDuBloc, _blocPrécédent, _groupe ) {

        // Initialisation des membres
        // --------------------------

        __couleur = _couleur;
        __led = _led;

        durée = _durée;



        // Code d'initialisation
        // ---------------------

        // Surchargé dans la classe


        // Code de traitement
        // ------------------

        __codeDeTraitement = "__chrono[" + UIDDuSéquenceur + "]+=1";


        // Code de fin
        // -----------

        // Surchargé dans la classe


        // Condition de passage à l'instruction suivante
        // ---------------------------------------------

        // Surchargé dans la classe

	}


}
}

