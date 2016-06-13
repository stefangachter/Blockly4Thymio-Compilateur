
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



using 	System;
using 	System.Collections.Generic;
using 	System.Diagnostics;
using	System.IO;
using   System.Windows.Forms;
using 	System.Xml;



namespace		Blockly4Thymio {
public class	Compilateur {

	/*
	 * Attributs
	 */

    /// <summary>
    /// <c>true</c> Affiche les commentaires dans le code ASEBA
    /// </summary>
    public	static	bool				afficherLesCommentaires;

	public	static	bool				afficheLesMessagesDErreur;

	public	static	bool				afficheLesMessagesDInformation;

    /// <summary>
    /// <c>true</c> Arrête le programme, si tous les séquenceurs ont terminés.
    /// <c>false</c> Le programme reste sur la dernière instruction de chaque séquenceur.
    /// </summary>
    public	static	bool				arrêtDuRobotALaFinDesSéquenceurs;

    public	static	bool				fermetureDeLaFenêtreALaFin;

    /// <summary>
    /// <c>true</c> Le code est éxécuté automatiquement après avoir été téléchargé dans le Thymio.
    /// <c>false</c> Le code est éxécuté lorsque l'utilisateur apppuis sur le bouton rond central du Thymio.
    /// </summary>
	public	static	bool				lancementAutomatique;

    public	static	bool				transfertDuFichierAESL;

	public	static	int					compteurDeSéquenceur;

    public	static	String				nomDuFichierB4T;
	public	static	String				nomDuFichierAESL;
    public	static	String				nomDuFichierAESLTemp;
    public	static	String				nomDuFichierASEBAMASSLOADER;
	public	static	String				version;

	public	static	List<__Evénement>	événementsRacines;
	
	private	static	bool				__transfertEnCours;

	private	static	FEN_Principale		__fenêtrePrincipal;



	/*
	 * Méthodes
	 */

    /// <summary>
    /// Affiche l'aide.
    /// </summary>
    public	static	void	AfficheLAide( TextBox _textBox ) {
        AfficheLEntête( _textBox );
        _textBox.Text += Messages.Message( (int)Messages.TYPE.AIDE );
    }


    /// <summary>
    /// Affiche l'entête du texte.
    /// </summary>
    public	static	void	AfficheLEntête( TextBox _textBox ) {
        _textBox.Clear();
		_textBox.Text += Messages.Message( (int)Messages.TYPE.ENTÊTE );
	}


	public	static	void	AjouteUnMessage( String _message ) {
		__fenêtrePrincipal.AjouteUnMessage( _message );
	}


	public	static	void	AfficheUnMessageDInformation( String _message ) {
		if ( afficheLesMessagesDInformation )
			__fenêtrePrincipal.AfficheUnMessageDInformation( _message );
	}


	public	static	void	AfficheUnMessageDErreur( String _message ) {
		if ( afficheLesMessagesDErreur )
			__fenêtrePrincipal.AfficheUnMessageDErreur( _message );
	}


    /// <summary>
    /// Analyse un noeud de code xml.
    /// </summary>
	public	static	__Bloc	AnalyseUnNoeudDInstruction( int _UIDPourLeBloc, XmlNode _XMLDuBloc, __Bloc _blocPrécédent, __GroupeDeBlocs _groupeDeBlocs ) {

        /*
         * Déclarations
         */
		int		position;

		String	erreur;
		String	instruction;		
		String	version;

        __Bloc	bloc;
			
		XmlNode	XmlDuBlocSuivant;


        /*
         * Initialisations
         */
        bloc = null;



        /*
         * Contrôles
         */
        if ( _XMLDuBloc == null ) { return null; }



        /*
		 * Traitements
		 */
        instruction = _XMLDuBloc.Attributes["type"].Value;
        switch( instruction ) {

        case "":
            break;


		// Evénements - Version 0.1b
		// -------------------------
		case "0_1b_Evénement_QuandLeProgrammeCommence" :
			// Note : L'UID d'un événement est 1
			bloc = new Evénement_QuandLeProgrammeCommence( _XMLDuBloc );
			break;


		// Lumières
		// --------

		case "0_1b_Lumières_AllumeToutesLesLEDs_SELCouleur" :
			bloc = new Lumières_AllumeToutesLesLEDs_SELCouleur( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupeDeBlocs );
			break;

		case "0_1b_Lumières_AllumeLesLEDs_SELLED_SELCouleur":
			bloc = new Lumières_AllumeLesLEDs_SELLED_SELCouleur( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupeDeBlocs );
			break;

		case "0_1b_Lumières_AllumeToutesLesLEDsPendant1Seconde_SELCouleur" :
			bloc = new Lumières_AllumeToutesLesLEDsPendant1Seconde_SELCouleur( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupeDeBlocs );
			break;

		case "0_1b_Lumières_EteinsToutesLesLEDsPendant1Seconde" :
			bloc = new __Lumières_AllumeLesLEDs_AvecDurée( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupeDeBlocs, (int)__LED.LED.TOUTES, 0, 1.0f );
			break;

		case "0_2_Lumières_AllumeLesLEDs_SELLED_SELCouleur_SAIDurée":
			bloc = new Lumières_AllumeLesLEDs_SELLED_SELCouleur_SAIDurée( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupeDeBlocs );
			break;

		case "0_6_Lumières_EteinsToutesLesLEDs":
			bloc = new __Lumières_AllumeLesLEDs( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupeDeBlocs, (int)__LED.LED.TOUTES, 0 );
			break;


		// Sons - version 0.1b
		// -------------------
		case "0_1b_Sons_JoueLaNote_DO_Pendant05Seconde" :
			bloc = new __Sons_JoueUneNote_AvecDurée( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupeDeBlocs, (int)__SONS.NOTES.DO_3, 0.5f );
			break;
		case "0_1b_Sons_JoueLaNote_RE_Pendant05Seconde" :
			bloc = new __Sons_JoueUneNote_AvecDurée( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupeDeBlocs, (int)__SONS.NOTES.RÉ_3, 0.5f );
			break;
		case "0_1b_Sons_JoueLaNote_MI_Pendant05Seconde" :
			bloc = new __Sons_JoueUneNote_AvecDurée( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupeDeBlocs, (int)__SONS.NOTES.MI_3, 0.5f );
			break;
		case "0_1b_Sons_JoueLaNote_FA_Pendant05Seconde" :
			bloc = new __Sons_JoueUneNote_AvecDurée( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupeDeBlocs, (int)__SONS.NOTES.FA_3, 0.5f );
			break;
		case "0_1b_Sons_JoueLaNote_SOL_Pendant05Seconde" :
			bloc = new __Sons_JoueUneNote_AvecDurée( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupeDeBlocs, (int)__SONS.NOTES.SOL_3, 0.5f );
			break;
		case "0_1b_Sons_JoueLaNote_LA_Pendant05Seconde" :
			bloc = new __Sons_JoueUneNote_AvecDurée( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupeDeBlocs, (int)__SONS.NOTES.LA_3, 0.5f );
			break;
		case "0_1b_Sons_JoueLaNote_SI_Pendant05Seconde" :
			bloc = new __Sons_JoueUneNote_AvecDurée( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupeDeBlocs, (int)__SONS.NOTES.SI_3, 0.5f );
			break;
		case "0_1b_Sons_JoueUnSon_SELSon" :
			bloc = new Sons_JoueUnSon_SELSon( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupeDeBlocs );
			break;

		case "0_2_Sons_JoueUneNoteCroche_SELNote" :
			bloc = new Sons_JoueUneNote_SELNote( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupeDeBlocs, (int)__SONS.DUREE.CROCHE );
			break;
		case "0_2_Sons_JoueUneNoteNoire_SELNote" :
			bloc = new Sons_JoueUneNote_SELNote( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupeDeBlocs, (int)__SONS.DUREE.NOIRE );
			break;
		case "0_2_Sons_JoueUneNoteBlanche_SELNote" :
			bloc = new Sons_JoueUneNote_SELNote( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupeDeBlocs, (int)__SONS.DUREE.BLANCHE );
			break;
		case "0_2_Sons_JoueUnSon_SELSon" :
			bloc = new Sons_JoueUnSon_SELSon( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupeDeBlocs );
			break;

		case "0_4_Sons_JoueUnSonPersonnel_SELSon" :
			bloc = new Sons_JoueUnSon_SELSon( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupeDeBlocs );
			break;
		case "0_4_Sons_EnregistreUnSon_Pendant04Seconde" :
			bloc = new __Sons_EnregistreUnSon_AvecDurée( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupeDeBlocs, 4.0f );
			break;
		case "0_4_Sons_RelireLeSonEnregistré" :
			bloc = new __Sons_JoueUnSon( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupeDeBlocs, (int)__SONS.SON.DEPUIS_LE_MICROPHONE );
			break;


		// Contrôles
		// ---------
		case "0_1b_Contrôles_RépèteToutLeTemps":
			bloc = new GroupeDInstructions_Boucle_RépèteToutLeTemps ( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupeDeBlocs );
			break;


		// Sinon, une erreur est déclenchée
		// --------------------------------
		default:
			erreur = "Erreur ! Le bloc " + instruction + " n'est pas traité dans cette version du compilateur.";
			position = instruction.IndexOf( "_", 2 );
			if ( position != -1 ) {
				version = instruction.Substring( 0, position );
				version = version.Replace( "_", "." );
				erreur += "\n\nLa version du compilateur la plus appropiée pour ce bloc est la version " + version;
			}
			throw new Exception( erreur );

        }


        // Lecture du bloc suivant
        // -----------------------
        XmlDuBlocSuivant = _XMLDuBloc.SelectSingleNode( "./next/block" );
		if ( bloc is __Evénement )
			bloc.blocSuivant = Compilateur.AnalyseUnNoeudDInstruction( bloc.UID+bloc.nombreDeSéquence, XmlDuBlocSuivant, bloc, _groupeDeBlocs );
		else if ( bloc is __Bloc )
			bloc.blocSuivant = Compilateur.AnalyseUnNoeudDInstruction( bloc.UID+bloc.nombreDeSéquence, XmlDuBlocSuivant, bloc, _groupeDeBlocs );
		
		
		// Fin
		// ---
        return bloc;

    }



    /// <summary>
    /// Compile le fichier .b4t
    /// </summary>
    public	static	bool	Compile( FEN_Principale _fenêtrePrincipal ) {

		__fenêtrePrincipal = _fenêtrePrincipal;



        /*
         * Contrôles
         */
        if ( !File.Exists(nomDuFichierB4T) ) {
			AfficheUnMessageDErreur( String.Format( Messages.Message( (int)Messages.TYPE.FICHIER_N_EXISTE_PAS ), nomDuFichierB4T ) );
            return false;
        }



        /*
		 * Initialisations
		 */
        compteurDeSéquenceur = 0;
		
		#if (WINDOWS)
		nomDuFichierAESL = Path.GetDirectoryName(nomDuFichierB4T) + @"\temp.aesl";
        nomDuFichierAESLTemp = Path.GetTempPath() + @"\temp.aesl";
		#endif
		
		#if (LINUX)
		nomDuFichierAESL = Path.GetDirectoryName(nomDuFichierB4T) + "/temp.aesl";
		nomDuFichierAESLTemp = Path.GetTempPath() + "/temp.aesl";
		#endif

        événementsRacines = new List<__Evénement>();



        /*
		 * 1er passe.
		 * Les blocs sont décomposés depuis le fichier b4t
		 */
		AjouteUnMessage( Messages.Message( (int)Messages.TYPE.LECTURE_DU_FICHIER_B4T ) + "\n" );
        if ( !DécompositionDuFichierBlockly4Thymio(_fenêtrePrincipal) )
        	return false;


        /*
         * 2ème passe.
         * Le programme est empaqueté dans un fichier .aesl
         */
		AjouteUnMessage( Messages.Message((int)Messages.TYPE.COMPILATION_DU_FICHIER_B4T) + "\n" );
        if ( !CréationDuFichierAESL() )
        	return false;


        /*
         * 3ème passe.
         * Le programme est transmis au robot Thymio
         */
        if (Compilateur.transfertDuFichierAESL) {
			AjouteUnMessage( Messages.Message((int)Messages.TYPE.TRANSFERT_DU_FICHIER_ASEBA) + "\n" );
        	if ( !TransmissionDuFichierAESL( _fenêtrePrincipal ) )
        		return false;
        }
        


        /*
         * Fin
         */
        return true;

    }


    /// <summary>
    /// Création du fichier .aesl.
    /// </summary>
    /// <returns><c>true</c>, si le fichier a été crée, <c>false</c> sinon.</returns>
    private	static	bool	CréationDuFichierAESL() {

        /*
		 * Déclarations
		 */
        StreamWriter	fichierAESL;

        String			codeDéclarationDesVariables;
		String			codeEvénementCapteur;
		String			codeEvénementCapteurArrière;
		String			codeEvénementCapteurAvant;
		String			codeEvénementBoutonFlèche;
        String			codeEvénementCommandeIR;
		String			codeEvénementLancementDuProgramme;        
        String			codeSéquenceur;
        String			framework;


        /*
		 * Initialisations
		 */
        codeDéclarationDesVariables = "";
		codeEvénementCapteur = "";
		codeEvénementCapteurArrière = "";
		codeEvénementCapteurAvant = "";
		codeEvénementBoutonFlèche = "";
		codeEvénementCommandeIR = "";
        codeEvénementLancementDuProgramme = "";
        codeSéquenceur = "";
        framework = FrameworkASEBA.version_0_2_1();
		framework = framework.Replace( "### VERSION ###", version );


        /*
		 * Traitements
		 */
        // Déclaration des variables
        if (événementsRacines.Count > 0)
			codeDéclarationDesVariables +=	"var __sequenceur[" + événementsRacines.Count + "]\n" + 
											"var __chrono[" + événementsRacines.Count + "]\n";
		

        // Ajoute le code généré pour chaque événement
        foreach ( __Evénement événementRacine in événementsRacines ) {
			
            if	( événementRacine is Evénement_QuandLeProgrammeCommence ) {

				// Evénement : Quand le programme commence
                if ( événementRacine.blocSuivant != null ) {
                    // Exécute l'instruction qui suit l'événement
                    if ( codeEvénementLancementDuProgramme != "" ) { codeEvénementLancementDuProgramme += " "; }
                    codeEvénementLancementDuProgramme += "  __sequenceur[" + événementRacine.UIDDuSéquenceur + "]=" + événementRacine.blocSuivant.UID;
                    codeSéquenceur += événementRacine.blocSuivant.codePourLeSéquenceur + "\n";
                }

			}

        }


        // Ajoute le code de fin du séquenceur
        if ( arrêtDuRobotALaFinDesSéquenceurs ) {

            if ( afficherLesCommentaires ) { codeSéquenceur += "  # Code exécuté à la fin de tous les séquenceurs\n"; }
            codeSéquenceur += "  if ";
            for (int séquenceur = 0; séquenceur < événementsRacines.Count; séquenceur++) {
                codeSéquenceur += "__sequenceur[" + séquenceur + "]==0 ";
                if (séquenceur < (événementsRacines.Count - 1)) { codeSéquenceur += "and "; }
            }
            codeSéquenceur += 	"then\n" +
                                "    __etat = ETAT_ARRET\n" +
                                "  end\n";
        }
        // Nettoie le fichier du séquenceur des <
        codeSéquenceur = codeSéquenceur.Replace("<", "&lt;");


        // Remplace les sections définis par des marqueurs par le code correspondant
        framework = framework.Replace("### VARIABLES ###", codeDéclarationDesVariables);

        framework = framework.Replace("### EVENEMENT AU LANCEMENT ###", codeEvénementLancementDuProgramme );

        if ( codeEvénementCommandeIR != "" )
			codeEvénementCommandeIR += "  \n__etat = ETAT_EN_MARCHE";
		framework = framework.Replace("### EVENEMENT COMMANDE INFRAROUGE ###", codeEvénementCommandeIR );

		if( codeEvénementBoutonFlèche != "" )
			codeEvénementBoutonFlèche = "  if button.forward==1 or button.backward==1 or button.left==1 or button.right==1 then\n  " + codeEvénementBoutonFlèche + "\n    __etat = ETAT_EN_MARCHE\n  end";
		framework = framework.Replace("### EVENEMENT BOUTON FLECHE ###", codeEvénementBoutonFlèche );

		if( codeEvénementCapteurAvant != "" )
			codeEvénementCapteur = "  if prox.horizontal[0]!=0 or prox.horizontal[1]!=0 or prox.horizontal[2]!=0 or prox.horizontal[3]!=0 or prox.horizontal[4]!=0 then\n  " + codeEvénementCapteurAvant + "\n    __etat = ETAT_EN_MARCHE\n  end";
		if( codeEvénementCapteurArrière != "" ) {
			if ( codeEvénementCapteur != "" )
				codeEvénementCapteur += "\n";
			codeEvénementCapteur = "  if prox.horizontal[5]!=0 or prox.horizontal[6]!=0 then\n  " + codeEvénementCapteurArrière + "\n    __etat = ETAT_EN_MARCHE\n  end";
		}
		framework = framework.Replace("### EVENEMENT CAPTEUR DISTANCE ###", codeEvénementCapteur );
		
		// Met en place le code du séquenceur
		framework = framework.Replace( "### SEQUENCEUR ###", codeSéquenceur );

        // Définie le mode de lancement du programme auto ou manuel
        if ( lancementAutomatique ) {
            framework = framework.Replace("### ETAT AU LANCEMENT ###", codeEvénementLancementDuProgramme + "\n__etat=ETAT_EN_MARCHE");
        } else {
            framework = framework.Replace("### ETAT AU LANCEMENT ###", codeEvénementLancementDuProgramme + "\n__etat=ETAT_ARRET");
        }


        // Sauve le fichier .aesl
		// Si le fichier ne peut être sauvegardé dans le répertoire du fichier .b4t,
		// celui-ci est redirigé vers le répertoire temporaire du système
        try {	fichierAESL = new StreamWriter( nomDuFichierAESL ); }
		catch {	fichierAESL = new StreamWriter( nomDuFichierAESLTemp ); }
        fichierAESL.Write( framework );
        fichierAESL.Close();



        /*
		 * Fin
		 */
        return true;

    }
	

	/// <summary>
    /// Décomposition du fichier .b4t.
    /// Ouvre le fichier .b4t et décompose le xml interne en une liste d'objets Evénement.
    /// La liste des objets événements est décrite dans l'attribut statique <c>événementsRacines</c> de la classe.
    /// </summary>
    /// <returns><c>true</c>, si la décomposition a fonctionnée, <c>false</c> sinon.</returns>
    private	static	bool	DécompositionDuFichierBlockly4Thymio( FEN_Principale _fenêtrePrincipal ) {

        /*
		 * Déclarations
		 */
        __Bloc			bloc;

        __Evénement		événementRacine;

        StreamReader	fluxXML;

        String			fichierXML;
        String			ligne;

        XmlDocument		XMLDoc;



        /*
		 * Traitements
		 */
        
		// Lecture du fichier .b4t 
        fichierXML = "";
        fluxXML = new System.IO.StreamReader( nomDuFichierB4T );
        while( (ligne = fluxXML.ReadLine()) != null ) { fichierXML += ligne; }
        fluxXML.Close();
        
		// Supprime les espaces de nom dans l'entête XML <xml xmlns="http://www.w3.org/1999/xhtml">
        fichierXML = fichierXML.Replace( @"<xml xmlns=""http://www.w3.org/1999/xhtml"">", "<xml>" );

        // Analyse le fichier .b4t en xml
        try {
            XMLDoc = new XmlDocument();
            XMLDoc.LoadXml( fichierXML );
        } catch {
			AfficheUnMessageDErreur( String.Format( Messages.Message((int)Messages.TYPE.FICHIER_NON_LISIBLE), nomDuFichierB4T ) );
            return false;
        }

        // Décompose le xml en codes Blockly4Thymio et liste les événements
        foreach ( XmlNode noeudRacine in XMLDoc.DocumentElement.ChildNodes ) {
            bloc = AnalyseUnNoeudDInstruction( 0, noeudRacine, null, null );
            if ( bloc != null ) {
				if ( bloc is Evénement_QuandLeProgrammeCommence ) {
					événementRacine = (Evénement_QuandLeProgrammeCommence)bloc;
					événementsRacines.Add( événementRacine );
				}
			}
        }
		if ( événementsRacines.Count == 0 ) {
			AfficheUnMessageDInformation( String.Format( Messages.Message((int)Messages.TYPE.PAS_D_INSTRUCTION_DE_DÉPART), nomDuFichierB4T ) );
			return false;
		}



		/*
		 * Fin
		 */
		return true;

	}

	   

    /// <summary>
    /// Optimise le code du séquenceur, en supprimant les instructions "Saute mouton"
    /// </summary>
    public	static	void Optimisation() {
		/* Recherche une séquence de saute monton à l'aide d'une expession régulière
		Aide sur les sites :
			http://www.regexlib.com/RETester.aspx
			http://lgmorand.developpez.com/dotnet/regex/#L5
			http://www.expreg.com/symbole.php

		Expression de test
			\s*if\s*sequenceur\[[0-9]+\]==[0-9]+\s*then\s*sequenceur\[[0-9]+\]=[0-9]+\s*end
		Retourne le résultat
			if sequenceur[0]==1 then sequenceur[0]=2 end
		Pour la séquencce :
			if sequenceur[0]==1 then
			  sequenceur[0]=2
			end
		*/
    }



	/// <summary>
    /// Transmission du fichier .aesl, à l'aide de l'exécutable asebamassloader.exe
    /// Tests en cours pour réaliser la transmission à l'aide de asebahttp, qui est compatible avec Aseba protocol 5 (pour le firware 10 de Thymio)
	/// Commande : asebahttp --aesl "C:\Users\fort\Downloads\test.aesl" "tcp:localhost;33333"
	/// Commande : asebahttp --aesl temp.aesl "ser:name=Thymio-II"
	/// En version 5, il y a un message d'erreur : "1 scripts have no corresponding nodes in the current network and have not been loaded."
	///
	/// <!--node e-puck-->
	/// <node nodeId="1" name="e-puck0">roues_vitesse_gauche =100
	/// roues_vitesse_droite = 10</node>
	///
    /// </summary>
    /// <returns><c>true</c>, si le fichier a été transmis, <c>false</c> sinon.</returns>
    ///
	/// Aseba 1.5.3 (Aseba 5) + Firmware 10 : Erreur "1 scripts have no corresponding nodes in the current network and have not been loaded."
/// /// Aseba 1.5.3 (Aseba 5) + Firmware 9 : OK : Loaded aesl script from temp.aesl
	/// Aseba 1.4 (Aseba 4) + Firmware 9 : OK : Loaded aesl script from temp.aesl
	///
    private	static	bool	TransmissionDuFichierAESL( FEN_Principale _fenêtrePrincipal ) {

        // Déclarations
        // ------------
        Process				processus;

        ProcessStartInfo	exécutable;



        // Contrôles
        // ---------
        if (!File.Exists(nomDuFichierASEBAMASSLOADER)) {
            AfficheUnMessageDErreur( String.Format( Messages.Message((int)Messages.TYPE.ASEBAMASSLOADER_INTROUVABLE), nomDuFichierASEBAMASSLOADER ) );
            return false;
        }



		// Traitements
        // -----------

        // Prépare le processus de transfert avec l'application asebamassloader.exe
        exécutable = new ProcessStartInfo();
        exécutable.Arguments = "\"" + nomDuFichierAESL + "\" ser:name=Thymio-II";
        exécutable.FileName = nomDuFichierASEBAMASSLOADER;
        exécutable.WorkingDirectory = Path.GetDirectoryName(nomDuFichierASEBAMASSLOADER);
        exécutable.WindowStyle = ProcessWindowStyle.Hidden;
        exécutable.CreateNoWindow = true;
		exécutable.RedirectStandardOutput = true;
		exécutable.RedirectStandardError = true;
		exécutable.UseShellExecute = false;

        // Lance le processus de transfert
		__transfertEnCours = true;
		processus = new Process();
		processus.OutputDataReceived += new DataReceivedEventHandler(RedirectionDeLaConsole);
		processus.ErrorDataReceived += new DataReceivedEventHandler(RedirectionDeLaConsole);	
		processus.EnableRaisingEvents = true;
		processus.StartInfo = exécutable;
		processus.Start();
		processus.BeginOutputReadLine();
		processus.BeginErrorReadLine();

		// Boucle de TimeOut de 10 secondes
		for ( int i=0; i<10*2; i++ ) {
			if ( !__transfertEnCours )
				break;
			System.Threading.Thread.Sleep(500);
		}
		processus.Kill();



        // Fin
        // ---

        return true;

    }


    /*
     * Analyse le texte renvoyé sur la console par AsebaMassLoader.
     * Si le texte contient la chaîne "loaded to target", c'est que le transfert est terminé.
     */
	private	static	void	RedirectionDeLaConsole( object _sender, DataReceivedEventArgs _e ) {
		//Console.Write( _e.Data );		
        if ( _e.Data != null ) 
        	if ( _e.Data.IndexOf("loaded to target") != -1 )
				__transfertEnCours = false;
    }


}
}

