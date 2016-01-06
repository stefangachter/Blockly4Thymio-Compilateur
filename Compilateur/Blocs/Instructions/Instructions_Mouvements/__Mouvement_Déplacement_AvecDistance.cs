
/*
 * __Mouvement_Déplacement_AvecDistance
 * ------------------------------------
 *
 * Fais se déplacer le robot,
 * du nombre de centimètre demandé.
 * 
 * Niveau de l'instruction : Facile
 * 
 */


using System;
using System.Xml;



namespace	Blockly4Thymio {
public	class	__Mouvement_Déplacement_AvecDistance : __Instruction {

    /*
	 * Membres
	 */
	private		int	__distance;   // Distance en centimètres
    
	protected	int	__vitesse;    // Vitesse de déplacement
    protected	int	__sens;       // Sens de déplacement



	/*
	 * Propriétés surchargeant la classe mère Instruction.
     */
	public	override	int		nombreDeSéquence { get { return 2; } }

    public	override	String	codeDInitialisation {
    get {
		// Déclarations
		String code;

		// Initialisations
        code = "";	

		// Traitement
        switch ( __sens ) {
        case (int)__MOTEUR.SENS_EN_AVANT:
            code = "motor.left.target=" + __vitesse + " motor.right.target=" + __vitesse;
            break;
        case (int)__MOTEUR.SENS_EN_ARRIERE:
            code = "motor.left.target=-" + __vitesse + " motor.right.target=-" + __vitesse;
            break;
        }

		// Fin
        return code;
    }
    }

    public	override	String	conditionDePassageALInstructionSuivante {
    get {
        String code;

        code = "";
        switch (__sens) {
        case (int)__MOTEUR.SENS_EN_AVANT:
            code = "__odo.x>" + (__distance * 50);
            break;
        case (int)__MOTEUR.SENS_EN_ARRIERE:
            code = "__odo.x<-" + (__distance * 50);
            break;
        }

        return code;
    }
    }



    /*
	 * Propriétés
     */
	public	int		distance {
	get { return __distance; }
	set {
		__distance = value;
		if ( __distance < 1 ) {
			__distance = 1;
			Compilateur.AfficheUnMessageDInformation( Compilateur.Message(0x0005) );
		}
		if ( __distance > 100 ) {
			__distance = 100;
			Compilateur.AfficheUnMessageDInformation( Compilateur.Message(0x0006) );
		}
	}
	}


	
	/*
	 * Constructeur
	 */
    public	__Mouvement_Déplacement_AvecDistance( int _UID, XmlNode _XMLDuBloc, __Bloc _blocPrécédent, __GroupeDInstructions _groupe, int _sens, int _vitesse, int _distance ) : base( _UID, _XMLDuBloc, _blocPrécédent, _groupe ) {

        // Initialisation des membres
        // --------------------------        
        __sens = _sens;
        __vitesse = __MOTEUR.contrôleDeLaVitesse( _vitesse );

		distance = _distance;


        // Code d'initialisation
        // ---------------------

        // Surchargé dans la classe


        // Code de traitement
        // ------------------

        // Aucun


        // Code de fin
        // -----------

        __codeDeFin = "callsub __ArreteLesMoteurs";


        // Condition de passage à l'instruction suivante
        // ---------------------------------------------

        // Surchargé dans la classe

    }


}
}

