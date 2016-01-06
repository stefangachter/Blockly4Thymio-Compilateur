
/*
 * __Mouvement_Tourne_AvecAngle
 * ----------------------------
 *
 * Le robot tourne sur lui même,
 * de l'angle demandé.
 * 
 * Niveau de l'instruction : Facile
 * 
 */



using System;
using System.Xml;



namespace	Blockly4Thymio {
public	class	__Mouvement_Tourne_AvecAngle : __Instruction {

    /*
     * Membres
     */
    private		int	__angle;      // Distance en centimètres
    
	protected	int __sens;       // Sens de déplacement


	/*
	 * Propriétés
     */
	public	int	angle {
	get { return __angle; }
	set {
		__angle = value;
		if ( __angle < 0 ) {
			__angle = 0;
			Compilateur.AfficheUnMessageDInformation( Compilateur.Message(0x0007) );
		}
		if ( __angle > 360 ) {
			__angle = 360;
			Compilateur.AfficheUnMessageDInformation( Compilateur.Message(0x0008) );
		}
	}
	}

	

	/*
	 * Propriétés surchargeant la classe mère Instruction.
     */
	public	override	int		nombreDeSéquence { get { return 2; } }

	public	override	String	codeDInitialisation {
    get {
        String code;

        code = "";
        switch (__sens) {
        case (int)__MOTEUR.TOURNE_A_DROITE:
            code = "motor.left.target=" + __MOTEUR.VITESSE_NORMALE + " motor.right.target=-" + __MOTEUR.VITESSE_NORMALE;
            break;
        case (int)__MOTEUR.TOURNE_A_GAUCHE:
            code = "motor.left.target=-" + __MOTEUR.VITESSE_NORMALE + " motor.right.target=" + __MOTEUR.VITESSE_NORMALE;
            break;
        }

        return code;
    }
    }

    public	override	String	conditionDePassageALInstructionSuivante {
    get {
        String code;

        code = "";
		switch( __sens ) {				
		case (int)__MOTEUR.TOURNE_A_DROITE :
			code = "__odo.degre==-" + __angle;
			break;
		case (int)__MOTEUR.TOURNE_A_GAUCHE :
			code = "__odo.degre==" + __angle;
			break;
		}

		return code;
    }
    }



    /*
     * Constructeur
     */
    public	__Mouvement_Tourne_AvecAngle( int _UID, XmlNode _XMLDuBloc, __Bloc _blocPrécédent, __GroupeDInstructions _groupe, int _sens, int _angle ) : base( _UID, _XMLDuBloc, _blocPrécédent, _groupe ) {

        // Initialisation des membres
        // --------------------------        
        __sens = _sens;

		angle = _angle;


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

