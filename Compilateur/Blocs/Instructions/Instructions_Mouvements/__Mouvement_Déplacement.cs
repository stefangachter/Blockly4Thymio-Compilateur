
/*
 * __Mouvement_Déplacement
 * -----------------------
 *
 * Fait se déplacer le robot.
 *
 * Niveau de l'instruction : Découverte
 * 
 */

using 	System;
using 	System.Xml;


namespace	Blockly4Thymio {
public	class	__Mouvement_Déplacement : __Instruction {

    /*
	 * Membres
	 */
    protected int __vitesse;    // Vitesse de déplacement
    protected int __sens;       // Sens de déplacememt



	/*
	 * Propriétés surchargeant la classe mère Instruction.
     */
	public	override	int		nombreDeSéquence { get { return 1; } }

    public	override	String	codeDeTraitement {
	get { return __MOTEUR.codeDeTraitement( __sens, __vitesse ); }
    }



    /*
	 * Constructeur
	 */
    public	__Mouvement_Déplacement( int _UID, XmlNode _XMLDuBloc, __Bloc _blocPrécédent, __GroupeDInstructions _groupe, int _sens, int _vitesse ) : base( _UID, _XMLDuBloc, _blocPrécédent, _groupe ) {

        // Initialisation des membres
        // --------------------------

        __vitesse = _vitesse;
        __sens = _sens;



        // Code d'initialisation
        // ---------------------

        // Aucun


        // Code de traitement
        // ------------------

        // Surchargé par la classe


        // Code de fin
        // -----------

        // Aucun


        // Condition de passage à l'instruction suivante
        // ---------------------------------------------

        // Aucun

    }


}
}

