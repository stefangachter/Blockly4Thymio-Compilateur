
/*
 * __Sons_JoueUnSon_SELSon
 * -----------------------
 *
 * Joue un des fichier son de la carte micro SD.
 *
 */


using 	System;
using 	System.Xml;



namespace	Blockly4Thymio {
public	class	__Sons_JoueUnSon_SELSon : __Instruction {
	
	/*
	 * Propriétés surchargeant la classe mère Instruction.
     */
	public	override	int		nombreDeSéquence { get { return 2; } }



    /*
     * Constructeur
     */
    public	__Sons_JoueUnSon_SELSon( int _UID, XmlNode _XMLDuBloc, __Bloc _blocPrécédent, __GroupeDInstructions _groupe ) : base( _UID, _XMLDuBloc, _blocPrécédent, _groupe ) {

        // Déclarations
        // ------------
        int son;

        String nomDeLAttribut;


        // Initialisations
        // ---------------
        son = (int)__SONS.SON.PAS_DE_SON;


        // Traitements
        // -----------

        // Analyse du Block d'instruction
        foreach (XmlNode XMLDUnNoeudFils in _XMLDuBloc.ChildNodes) {

            nomDeLAttribut = "";
            if (XMLDUnNoeudFils.Attributes["name"] != null)
                nomDeLAttribut = XMLDUnNoeudFils.Attributes["name"].Value;

            switch (nomDeLAttribut) {
			case "Son" :
            case "SelectSound" :

                switch (XMLDUnNoeudFils.InnerText) {
                case "SON_BONJOUR":
					son = (int)__SONS.SON.BONJOUR;
                    break;
                case "SON_HO":
					son = (int)__SONS.SON.HO;
                    break;
                case "SON_QUOI":
					son = (int)__SONS.SON.QUOI;
                    break;
                case "SON_JE_SUIS_PAS_CONTENT":
					son = (int)__SONS.SON.JE_SUIS_PAS_CONTENT;
                    break;
				case "SON_SIRENE_DES_POMPIERS":
					son = (int)__SONS.SON.SIRÈNE_DES_POMPIERS;
                    break;
                }
                break;

            }

        }


        // Code d'initialisation
        // ---------------------

        __codeDInitialisation = "__lectureDUnSon=1 call sound.play(" + son + ")";


        // Code de traitement
        // ------------------

        // Dans la classe mère : Aucun


        // Code de fin
        // -----------

        // Dans la classe mère : Aucun


        // Condition de passage à l'instruction suivante
        // ---------------------------------------------

        __conditionDePassageALInstructionSuivante = "__lectureDUnSon==0";

    }


}
}

