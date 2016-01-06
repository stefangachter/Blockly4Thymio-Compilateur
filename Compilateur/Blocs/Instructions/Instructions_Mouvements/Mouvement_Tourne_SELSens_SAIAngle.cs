
/*
 * Mouvement_Tourne_SELSens_SAIAngle
 * ---------------------------------
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
public	class	Mouvement_Tourne_SELSens_SAIAngle : __Mouvement_Tourne_AvecAngle {

    /*
     * Constructeur
     */
    public Mouvement_Tourne_SELSens_SAIAngle( int _UID, XmlNode _XMLDuBloc, __Bloc _blocPrécédent, __GroupeDInstructions _groupe ) : base( _UID, _XMLDuBloc, _blocPrécédent, _groupe, (int)__MOTEUR.SENS_AUCUN, 0 ) {

        // Déclarations
        // ------------
        String nomDeLAttribut;



        // Analyse du Bloc d'instruction
        foreach (XmlNode XMLDUnNoeudFils in _XMLDuBloc.ChildNodes) {

            nomDeLAttribut = "";
            if ( XMLDUnNoeudFils.Attributes["name"] != null )
                nomDeLAttribut = XMLDUnNoeudFils.Attributes["name"].Value;

            switch( nomDeLAttribut ) {
            case "Angle" :
                angle = Int32.Parse( XMLDUnNoeudFils.InnerText );
                break;

			case "Sens" :
				switch ( XMLDUnNoeudFils.InnerText ) {
                case "A_DROITE" :	__sens = (int)__MOTEUR.TOURNE_A_DROITE;	break;
                case "A_GAUCHE" :	__sens = (int)__MOTEUR.TOURNE_A_GAUCHE;	break;
                }
				break;

            }

        }


        // Code d'initialisation
        // ---------------------

        // Dans la classe mère


        // Code de traitement
        // ------------------

        // Dans la classe mère : Aucun


        // Code de fin
        // -----------

        // Dans la classe mère


        // Condition de passage à l'instruction suivante
        // ---------------------------------------------

        // Dans la classe mère

    }


}
}

