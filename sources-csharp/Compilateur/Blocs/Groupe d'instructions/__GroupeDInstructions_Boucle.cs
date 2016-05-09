
/*
Copyright Okimi 2015-2016 (contact at okimi dot net)

Ce logiciel est un programme informatique servant à compiler un fichier
Blockly4Thymio (.b4t), à le transfomer en fichier Aseba (.aesl) et le
transmettre à un robot Thymio. Ce logiciel fait partie d'une suites de
logiciels nommée Blockly4Thymio.

Ce logiciel est régi par la licence CeCILL soumise au droit français et
respectant les principes de diffusion des logiciels libres. Vous pouvez
utiliser, modifier et/ou redistribuer ce programme sous les conditions
de la licence CeCILL telle que diffusée par le CEA, le CNRS et l'INRIA 
sur le site "http://www.cecill.info".

En contrepartie de l'accessibilité au code source et des droits de copie,
de modification et de redistribution accordés par cette licence, il n'est
offert aux utilisateurs qu'une garantie limitée.  Pour les mêmes raisons,
seule une responsabilité restreinte pèse sur l'auteur du programme,  le
titulaire des droits patrimoniaux et les concédants successifs.

A cet égard  l'attention de l'utilisateur est attirée sur les risques
associés au chargement,  à l'utilisation,  à la modification et/ou au
développement et à la reproduction du logiciel par l'utilisateur étant 
donné sa spécificité de logiciel libre, qui peut le rendre complexe à 
manipuler et qui le réserve donc à des développeurs et des professionnels
avertis possédant  des  connaissances  informatiques approfondies.  Les
utilisateurs sont donc invités à charger  et  tester  l'adéquation  du
logiciel à leurs besoins dans des conditions permettant d'assurer la
sécurité de leurs systèmes et ou de leurs données et, plus généralement, 
à l'utiliser et l'exploiter dans les mêmes conditions de sécurité. 

Le fait que vous puissiez accéder à cet en-tête signifie que vous avez 
pris connaissance de la licence CeCILL, et que vous en avez accepté les
termes.

===============================================================================

Copyright Okimi 2015-2016 (contact at okimi dot net)

This software is a computer program whose purpose is to compil Blockly4Thymio
file (.b4t), to transform it into Aseba file (.aesl) and send it to Thymio
Robot. This software is part of Blockly4Thymio serie.

This software is governed by the CeCILL license under French law and
abiding by the rules of distribution of free software.  You can  use, 
modify and/ or redistribute the software under the terms of the CeCILL
license as circulated by CEA, CNRS and INRIA at the following URL
"http://www.cecill.info". 

As a counterpart to the access to the source code and  rights to copy,
modify and redistribute granted by the license, users are provided only
with a limited warranty  and the software's author,  the holder of the
economic rights,  and the successive licensors  have only  limited
liability. 

In this respect, the user's attention is drawn to the risks associated
with loading,  using,  modifying and/or developing or reproducing the
software by the user in light of its specific status of free software,
that may mean  that it is complicated to manipulate,  and  that  also
therefore means  that it is reserved for developers  and  experienced
professionals having in-depth computer knowledge. Users are therefore
encouraged to load and test the software's suitability as regards their
requirements in conditions enabling the security of their systems and/or 
data to be ensured and,  more generally, to use and operate it in the 
same conditions as regards security. 

The fact that you are presently reading this means that you have had
knowledge of the CeCILL license and that you accept its terms.
*/



using System;
using System.Xml;



namespace		Blockly4Thymio {
public	class	__GroupeDInstructions_Boucle : __GroupeDInstructions {

	/*
	 * Membres
	 */
	/// <summary>
	/// Code d'action éxécuté à chaque boucle, au début du groupe
	/// </summary>
	protected	String	__codeDActionEnDébut;				// Séquence #2 du groupe
	/// <summary>
	/// Code d'action éxécuté à chaque boucle, à la fin du groupe
	/// </summary>
	protected	String	__codeDActionEnFin;					// Séquence #3 du groupe
	protected	String	__codeDInitialisation;				// Séquence #1 du groupe
    protected	String	__conditionDeSortie;				// Séquence #3 du groupe



	/*
	 * Propriétés virtuelles
     */
	virtual	public	String	codeDActionEnDébut { get { return __codeDActionEnDébut; } }

	virtual	public	String	codeDInitialisation { get { return __codeDInitialisation; } }

	virtual	public	String	conditionDeSortie { get { return __conditionDeSortie; } }

	virtual	public	__Bloc	blocsInternes { get { return __blocsInternes; } }
	
	
	
	/*
	 * Propriétés surchargeant la classe mère Bloc.
     */
	public	override	int		nombreDeSéquence {
	get {
		// Déclarations
		int		nombre;
		__Bloc	dernierBloc;

		// Traitements
		nombre = __nombreDeSéquenceInitiale;
		if ( __blocsInternes != null ) {
			dernierBloc = blocsInternes.DernierBlocsSuivant();
			nombre += dernierBloc.UID - __blocsInternes.UID + dernierBloc.nombreDeSéquence;
		}

		// Fin
		return nombre;

	}
	}

	public	override	String	codePourLeSéquenceur {
	get {

		// Déclarations
		// ------------
		String	code;


		// Initialisations
		// ---------------
		code ="";


		// Traitements
		// -----------
			
		// Séquences de début de groupe
		// ----------------------------
		if ( Compilateur.afficherLesCommentaires ) { code += "\n# Instruction Blockly (UID " + __UID + ") = DEBUT " + __nomDansBlockly + "\n"; }
						
		
		// Séquence d'initialisation.
		if ( codeDInitialisation != "" ) {
			// Il y a un code d'initialisation,
			// une séquence est ajoutée en début de groupe pour cette initialisation.
			code += "if __sequenceur[" + __UIDDuSéquenceur + "]==" + __UID + " then\n";
			code += "  " + codeDInitialisation;
			code += "  __sequenceur[" + __UIDDuSéquenceur + "]=" + UIDDeLaSéquenceDeBoucle + "\n";
			code += "end\n";
		} 		
		// Séquence de boucle
		code += "if __sequenceur[" + __UIDDuSéquenceur + "]==" + UIDDeLaSéquenceDeBoucle + " then\n";
		if ( codeDActionEnDébut != "" )
			code += "  " + codeDActionEnDébut + "\n";
		code += "  __sequenceur[" + __UIDDuSéquenceur + "]=" + UIDDuPremierBloc + "\n";
		code += "end\n";
		
		
		// Blocs internes
		// --------------
		if ( blocsInternes != null )
			code += blocsInternes.codePourLeSéquenceur;
		
		
		// Séquence de fin du groupe
		// -------------------------
		if ( Compilateur.afficherLesCommentaires ) { code += "\n# Instruction Blockly (UID " + __UID + ") = FIN " + __nomDansBlockly + "\n"; }
			
		code += "if __sequenceur[" + __UIDDuSéquenceur + "]==" + UIDDeFin + " then\n";
		if ( __codeDActionEnFin != "" )
			code += "  " + __codeDActionEnFin + "\n";
		if ( __conditionDeSortie == "" ) {
			// Il y a pas de condition de sortie du groupe,
			// le séquenceur boucle sur la séquence de boucle.
			code += "  __sequenceur[" + __UIDDuSéquenceur + "]=" + UIDDeLaSéquenceDeBoucle + "\n";
		} else {
			// Il y a une de condition de sortie du groupe,
			// elle est testée pour sortir
			code += "  if " + __conditionDeSortie + " then\n";
			// La condition est vrai, le séquenceur sort du groupe.
			code += "    __sequenceur[" + __UIDDuSéquenceur + "]=" + UIDDuBlocSuivant + "\n";
			code += "  else\n";
			// La condition est fausse, le séquenceur boucle sur la séquence de boucle.
			code += "    __sequenceur[" + __UIDDuSéquenceur + "]=" + UIDDeLaSéquenceDeBoucle + "\n";
			code += "  end\n";
		}
		code += "end\n";


		// Ajoute le bloc suivant
		if ( blocSuivant != null ) { code += blocSuivant.codePourLeSéquenceur; }


		// Fin
		// ---

		return code;

	}
	}




		
	/// <summary>
	/// UID de la séquence sur laquelle boucle le groupe.
	/// </summary>
	public	int	UIDDeLaSéquenceDeBoucle {
	get {
		if ( codeDInitialisation == "" ) {
			// Il n'y a pas de séquence d'initialisation,
			// la boucle est faite sur l'UID de la première séquence du groupe
			return __UID;
		} else {
			// Il y a une séquence d'initialisation,
			// la boucle est faite sur l'UID de la deuxième séquence du groupe
			return __UID+1;
		}
	}
	}



	/*
     * Constructeur
     */
	public	__GroupeDInstructions_Boucle( int _UID, XmlNode _XMLDuBloc, __Bloc _blocPrécédent, __GroupeDInstructions _groupe ) : base( _UID, _XMLDuBloc, _blocPrécédent, _groupe ) {

		__type = (int)TYPE.BOUCLE;

		__codeDActionEnDébut	= "";
		__codeDActionEnFin		= "";
		__codeDInitialisation	= "";
		__conditionDeSortie		= "";

	}


}
}

