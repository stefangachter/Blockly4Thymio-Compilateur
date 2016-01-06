

using 	System;
using 	System.Xml;



namespace	Blockly4Thymio {
public	class	__Valeurs : __Bloc {

    /*
     * Membres
     */
    protected   String	__code;

    

	/*
	 * Propriétés surchargeant la classe mère __Bloc.
     */
    public override String codePourLeSéquenceur {
    get { return __code; }
    }

    
    
    /*
     * Constructeur
     */
    public	__Valeurs( int _UID, XmlNode _XMLDuBloc, __Bloc _blocPrécédent, __GroupeDInstructions _groupe ) : base( _UID, _XMLDuBloc, _blocPrécédent, _groupe ) {

		// Initialisations
        // ---------------
		__code = "";

    }



}
}

