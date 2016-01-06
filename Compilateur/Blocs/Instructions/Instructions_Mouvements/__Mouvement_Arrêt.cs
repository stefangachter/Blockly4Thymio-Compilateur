
/*
 * __Mouvement_Arrêt
 * -----------------
 *
 * Le robot s'arrête.
 *
 * Niveau de l'instruction : Découverte
 * 
 */

using 	System.Xml;



namespace   Blockly4Thymio {
public	class   __Mouvement_Arrêt : __Instruction {

	/*
	 * Propriétés surchargeant la classe mère Instruction.
     */
	public	override	int		nombreDeSéquence { get { return 1; } }



	/*
	 * Constructeur
	 */
	public	__Mouvement_Arrêt( int _UID, XmlNode _XMLDuBloc, __Bloc _blocPrécédent, __GroupeDInstructions _groupe ) : base( _UID, _XMLDuBloc, _blocPrécédent, _groupe ) {

        // Code d'initialisation
        // ---------------------

        // Aucun


        // Code de traitement
        // ------------------

        __codeDeTraitement = "callsub __ArreteLesMoteurs";


        // Code de fin
        // -----------

        // Aucun


        // Condition de passage à l'instruction suivante
        // ---------------------------------------------

        // Aucun

    }


}
}

