
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
public	class	Sons_JoueUneNote_SELNote : __Sons_JoueUneFréquence_AvecDurée {

    /*
	 * Constructeur
	 *
	 * Paramètres du contructeur
	 * int		_note			Note qui doit être jouée
	 * float	_durée			Temps de maintient de la note (en seconde)
	 *
	 */
    public	Sons_JoueUneNote_SELNote( int _UID, XmlNode _XMLDuBloc, __Bloc _blocPrécédent, __GroupeDInstructions _groupe, int _durée ) : base( _UID, _XMLDuBloc, _blocPrécédent, _groupe, 0, 0 ) {

		// Déclarations
        // ------------
        String nomDeLAttribut;


		// Initialisations
        // ---------------
		
		__durée = __SONS.CalculLaDuréeDUneNote( _durée );


        // Traitements
        // -----------

        // Analyse du Block d'instruction
        foreach (XmlNode XMLDUnNoeudFils in _XMLDuBloc.ChildNodes) {

            nomDeLAttribut = "";
            if (XMLDUnNoeudFils.Attributes["name"] != null)
                nomDeLAttribut = XMLDUnNoeudFils.Attributes["name"].Value;

            switch (nomDeLAttribut) {
            case "Note":

                switch (XMLDUnNoeudFils.InnerText) {
                case "DO3":
					__fréquence = __SONS.CalculLaFréquenceDUneNote( (int)__SONS.NOTES.DO_3 );
                    break;
                case "RE3":
					__fréquence = __SONS.CalculLaFréquenceDUneNote( (int)__SONS.NOTES.RÉ_3 );
                    break;
                case "MI3":
					__fréquence = __SONS.CalculLaFréquenceDUneNote( (int)__SONS.NOTES.MI_3 );
                    break;
                case "FA3":
					__fréquence = __SONS.CalculLaFréquenceDUneNote( (int)__SONS.NOTES.FA_3 );
                    break;
                case "SOL3":
					__fréquence = __SONS.CalculLaFréquenceDUneNote( (int)__SONS.NOTES.SOL_3 );
                    break;
                case "LA3":
					__fréquence = __SONS.CalculLaFréquenceDUneNote( (int)__SONS.NOTES.LA_3 );
                    break;
                case "SI3":
					__fréquence = __SONS.CalculLaFréquenceDUneNote( (int)__SONS.NOTES.SI_3 );
                    break;
                case "DO4":
					__fréquence = __SONS.CalculLaFréquenceDUneNote( (int)__SONS.NOTES.DO_4 );
                    break;
                case "RE4":
					__fréquence = __SONS.CalculLaFréquenceDUneNote( (int)__SONS.NOTES.RÉ_4 );
                    break;
                case "MI4":
					__fréquence = __SONS.CalculLaFréquenceDUneNote( (int)__SONS.NOTES.MI_4 );
                    break;
                case "FA4":
					__fréquence = __SONS.CalculLaFréquenceDUneNote( (int)__SONS.NOTES.FA_4 );
                    break;
                case "SOL4":
					__fréquence = __SONS.CalculLaFréquenceDUneNote( (int)__SONS.NOTES.SOL_4 );
                    break;
                case "LA4":
					__fréquence = __SONS.CalculLaFréquenceDUneNote( (int)__SONS.NOTES.LA_4 );
                    break;
                case "SI4":
					__fréquence = __SONS.CalculLaFréquenceDUneNote( (int)__SONS.NOTES.SI_4 );
                    break;				
				}
                break;

            }

        }


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

