
/*
 * Mouvement_Déplacement_SELVitesse_SAIDistance
 * --------------------------------------------
 *
 * Fais se déplacer le robot,
 * du nombre de centimètre demandé, à la vitesse demandée
 * 
 * Niveau de l'instruction : Facile
 * 
 */


using 	System;
using 	System.Xml;


namespace	Blockly4Thymio {
public	class	Mouvement_Déplacement_SELVitesse_SAIDistance : __Mouvement_Déplacement_AvecDistance {

    /*
	 * Constructeur
	 */
	// La distance est initalisée à 1cm par défaut.
    public	Mouvement_Déplacement_SELVitesse_SAIDistance( int _UID, XmlNode _XMLDuBloc, __Bloc _blocPrécédent, __GroupeDInstructions _groupe, int _sens ) : base( _UID, _XMLDuBloc, _blocPrécédent, _groupe, _sens, __MOTEUR.VITESSE_NULLE, 1 ) {

        // Déclarations
        // ------------
        String nomDeLAttribut;


        // Initialisations
        // ---------------
        __sens = _sens;


        // Analyse du Bloc d'instruction
        foreach ( XmlNode XMLDUnNoeudFils in _XMLDuBloc.ChildNodes ) {

            nomDeLAttribut = "";
            if ( XMLDUnNoeudFils.Attributes["name"] != null )
                nomDeLAttribut = XMLDUnNoeudFils.Attributes["name"].Value;

            switch ( nomDeLAttribut ) {

            case "Distance":
                distance = Int32.Parse( XMLDUnNoeudFils.InnerText );
                break;

            case "Vitesse":

                switch ( XMLDUnNoeudFils.InnerText ) {
                case "LENTEMENT":	__vitesse = (int)__MOTEUR.VITESSE_LENTE;	break;
                case "NORMALEMENT":	__vitesse = (int)__MOTEUR.VITESSE_NORMALE;	break;
                case "RAPIDEMENT":	__vitesse = (int)__MOTEUR.VITESSE_RAPIDE;	break;
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

