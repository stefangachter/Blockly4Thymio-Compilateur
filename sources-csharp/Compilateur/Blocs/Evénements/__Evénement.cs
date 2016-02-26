
using 	System.Xml;



namespace	Blockly4Thymio {
public	class	__Evénement : __Bloc {
	

	/*
	 * Constructeur
	 */
	// Note : Un événement à toujours l'UID 1
	public __Evénement( XmlNode _XMLDuBloc ) : base( 1, _XMLDuBloc, null, null ) {

		__nombreDeSéquenceInitiale = 0;

		__UIDDuSéquenceur = Compilateur.compteurDeSéquenceur++;

	}


}
}

