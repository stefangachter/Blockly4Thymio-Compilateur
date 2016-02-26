
/*
 * Sons_JoueUneNote
 * ----------------
 *
 * Joue une note (DO, RE, MI, FA, SOL, LA, SI)
 * pendant un temps donné (en seconde)
 *
 */

using 	System;
using 	System.Xml;



namespace	Blockly4Thymio {
public	class	Sons_JoueUneNote : __Sons_JoueUneFréquence_AvecDurée {

    /*
	 * Constructeur
	 *
	 * Paramètres du contructeur
	 * int		_note			Note qui doit être jouée
	 * float	_durée			Temps de maintient de la note (en seconde)
	 *
	 */
    public	Sons_JoueUneNote( int _UID, XmlNode _XMLDuBloc, __Bloc _blocPrécédent, __GroupeDInstructions _groupe, int _note, float _durée ) : base( _UID, _XMLDuBloc, _blocPrécédent, _groupe, 0, _durée ) {

        // Traitements
        // -----------

        __fréquence = __SONS.CalculLaFréquenceDUneNote( _note );


        // Code d'initialisation
        // ---------------------

        // Dans la classe mère


        // Code de traitement
        // ------------------

        // Dans la classe mère


        // Code de fin
        // -----------

        // Dans la classe mère


        // Condition de passage à l'instruction suivante
        // ---------------------------------------------

        // Dans la classe mère


    }


}
}

