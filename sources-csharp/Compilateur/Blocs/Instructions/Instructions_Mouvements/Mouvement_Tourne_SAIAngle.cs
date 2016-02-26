
/*
 * Mouvement_Tourne_SAIAngle
 * -------------------------
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
public	class	Mouvement_Tourne_SAIAngle : __Mouvement_Tourne_AvecAngle {

    /*
     * Constructeur
     */
    public Mouvement_Tourne_SAIAngle( int _UID, XmlNode _XMLDuBloc, __Bloc _blocPrécédent, __GroupeDInstructions _groupe, int _sens ) : base( _UID, _XMLDuBloc, _blocPrécédent, _groupe, _sens, 0 ) {

        // Déclarations
        // ------------
        String nomDeLAttribut;



        // Initialisations
        // ---------------
        __sens = _sens;



        // Analyse du Bloc d'instruction
        foreach (XmlNode XMLDUnNoeudFils in _XMLDuBloc.ChildNodes) {

            nomDeLAttribut = "";
            if ( XMLDUnNoeudFils.Attributes["name"] != null )
                nomDeLAttribut = XMLDUnNoeudFils.Attributes["name"].Value;

            switch( nomDeLAttribut ) {
            case "Angle":
                angle = Int32.Parse( XMLDUnNoeudFils.InnerText );				
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

