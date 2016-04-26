
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

    /// <summary>
    /// <c>true</c> Le code est éxécuté automatiquement après avoir été téléchargé dans le Thymio.
    /// <c>false</c> Le code est éxécuté lorsque l'utilisateur apppuis sur le bouton rond central du Thymio.
    /// </summary>
    public	static	bool				lancementAutomatique;

	public	static	int					compteurDeSéquenceur;
	public	static	int					compteurDeMarqueur;

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
        _textBox.Text += @"
Aucun fichier source .b4t n'a été déclaré.

Utilisation : Associez les fichier .b4t à cet éxécutable.

";
    }


    /// <summary>
    /// Affiche l'aide.
    /// </summary>
    public	static	void	AfficheLEntête( TextBox _textBox ) {

        _textBox.Clear();

		#if DEBUG
		_textBox.Text += @"
***********************
* !!! MODE DEBUG !!! *
***********************
";
		#endif

		_textBox.Text += @"Compilateur Blockly4Thymio - Okimi ©2016 - version " + version + @"

Compile un fichier .b4t en  fichier Aseba  et le transmet  au robot Thymio II.
Blockly4Thymio utilise le programme asebamassloader.exe pour le transfert du fichier Aseba vers le robot Thymio.

";
	
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
    public	static	__Bloc	AnalyseUnNoeudDInstruction( int _UIDPourLeBloc, XmlNode _XMLDuBloc, __Bloc _blocPrécédent, __GroupeDInstructions _groupe ) {

        /*
         * Déclarations
         */
		String					erreur;
		String					instruction;		

        __Bloc					bloc;
		__GroupeDInstructions	groupe;
			
		XmlNode					XmlDuBlocSuivant;



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


		/*
		 * Blocs d'instruction de la version 0.1b
		 * --------------------------------------
		 */


		// Evénements - Version 0.1b
		// -------------------------
		case "0_1b_Evénement_QuandLeProgrammeCommence":
			// Note : L'UID d'un événement est 1
			bloc = new Evénement_QuandLeProgrammeCommence( _XMLDuBloc );
			break;

		// Evénements - Version 0.2
		// ------------------------
		case "0_2_Evénement_QuandUnOrdreArriveDeLaTélécommandeIR":
			// Note : L'UID d'un événement est 1
			bloc = new Evénement_QuandUnOrdreArriveDeLaTélécommandeIR( _XMLDuBloc );
			break;
		case "0_2_Evénement_QuandUnBoutonFlècheEstAppuyé":
			// Note : L'UID d'un événement est 1
			bloc = new Evénement_QuandUnBoutonFlècheEstAppuyé( _XMLDuBloc );
			break;


		// Mouvements - version 0.1b
		// -------------------------
		case "0_1b_Mouvement_Arrête":
			bloc = new __Mouvement_Arrêt( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupe );
			break;
		case "0_1b_Mouvement_Avance":
			bloc = new __Mouvement_Déplacement( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupe, (int)__MOTEUR.SENS_EN_AVANT, (int)__MOTEUR.VITESSE_NORMALE );
			break;
		case "0_1b_Mouvement_Avance_De5Centimètres":
			bloc = new __Mouvement_Déplacement_AvecDistance( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupe, (int)__MOTEUR.SENS_EN_AVANT, (int)__MOTEUR.VITESSE_NORMALE, 5 );
			break;
		case "0_1b_Mouvement_Avance_SELVitesse_SAIDistance":
			bloc = new Mouvement_Déplacement_SELVitesse_SAIDistance( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupe, (int)__MOTEUR.SENS_EN_AVANT );
			break;
		case "0_1b_Mouvement_Recule":
			bloc = new __Mouvement_Déplacement( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupe, (int)__MOTEUR.SENS_EN_ARRIERE, (int)__MOTEUR.VITESSE_NORMALE );
			break;
		case "0_1b_Mouvement_Recule_SELVitesse_SAIDistance":
			bloc = new Mouvement_Déplacement_SELVitesse_SAIDistance( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupe, (int)__MOTEUR.SENS_EN_ARRIERE );
			break;
		case "0_1b_Mouvement_TourneADroite_SAIAngle":
			bloc = new Mouvement_Tourne_SAIAngle( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupe, __MOTEUR.TOURNE_A_DROITE );
			break;
		case "0_1b_Mouvement_TourneAGauche_SAIAngle":
			bloc = new Mouvement_Tourne_SAIAngle( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupe, __MOTEUR.TOURNE_A_GAUCHE );
			break;

		// Mouvements - version 0.2
		// ------------------------
		case "0_2_Mouvement_Tourne_SELSens_SAIAngle":
			bloc = new Mouvement_Tourne_SELSens_SAIAngle( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupe );
			break;

		// Mouvements - version 0.5
		// ------------------------
		case "0_5_Mouvement_TourneADroite":
			bloc = new __Mouvement_Tourne_AvecAngle( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupe, (int)__MOTEUR.TOURNE_A_DROITE, 90 );
			break;
		case "0_5_Mouvement_TourneAGauche":
			bloc = new __Mouvement_Tourne_AvecAngle( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupe, (int)__MOTEUR.TOURNE_A_GAUCHE, 90 );
			break;


		// Lumières - version 0.1b
		// -----------------------
		case "0_1b_Lumières_AllumeLesLEDs_SELLED_SELCouleur" :
			bloc = new Lumières_AllumeLesLEDs_SELLED_SELCouleur( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupe );
			break;
		case "0_1b_Lumières_AllumeToutesLesLEDs_SELCouleur":
			bloc = new Lumières_AllumeToutesLesLEDs_SELCouleur( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupe );
			break;
		case "0_1b_Lumières_AllumeToutesLesLEDsPendant1Seconde_SELCouleur":
			bloc = new Lumières_AllumeToutesLesLEDsPendant1Seconde_SELCouleur( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupe );
			break;
		case "0_1b_Lumières_EteinsToutesLesLEDsPendant1Seconde":
			bloc = new __Lumières_AllumeLesLED_AvecDurée( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupe, (int)__LED.TOUTE_LES_LEDS, 0, 1.0f );
			break;
			
		// Lumières - version 0.2
		// ----------------------
		case "0_2_Lumières_AllumeLesLEDs_SELLED_SELCouleur_SAIDurée" :
			bloc = new Lumières_AllumeLesLEDs_SELLED_SELCouleur_SAIDurée( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupe );
			break;


		// Sons - version 0.1b
		// -------------------
		case "0_1b_Sons_JoueLaNote_DO_Pendant05Seconde":
			bloc = new Sons_JoueUneNote( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupe, (int)__SONS.NOTES.DO_3, 0.5f );
			break;
		case "0_1b_Sons_JoueLaNote_RE_Pendant05Seconde":
			bloc = new Sons_JoueUneNote( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupe, (int)__SONS.NOTES.RÉ_3, 0.5f );
			break;
		case "0_1b_Sons_JoueLaNote_MI_Pendant05Seconde":
			bloc = new Sons_JoueUneNote( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupe, (int)__SONS.NOTES.MI_3, 0.5f );
			break;
		case "0_1b_Sons_JoueLaNote_FA_Pendant05Seconde":
			bloc = new Sons_JoueUneNote( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupe, (int)__SONS.NOTES.FA_3, 0.5f );
			break;
		case "0_1b_Sons_JoueLaNote_SOL_Pendant05Seconde":
			bloc = new Sons_JoueUneNote( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupe, (int)__SONS.NOTES.SOL_3, 0.5f );
			break;
		case "0_1b_Sons_JoueLaNote_LA_Pendant05Seconde":
			bloc = new Sons_JoueUneNote( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupe, (int)__SONS.NOTES.LA_3, 0.5f );
			break;
		case "0_1b_Sons_JoueLaNote_SI_Pendant05Seconde":
			bloc = new Sons_JoueUneNote( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupe, (int)__SONS.NOTES.SI_3, 0.5f );
			break;
		case "0_1b_Sons_JoueUnSon_SELSon":
			bloc = new __Sons_JoueUnSon_SELSon( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupe );
			break;
		
		// Sons - version 0.2
		// ------------------
        case "0_2_Sons_JoueUneNoteCroche_SELNote":
            bloc = new Sons_JoueUneNote_SELNote( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupe, (int)__SONS.DUREE.CROCHE );
            break;
		case "0_2_Sons_JoueUneNoteNoire_SELNote":
			bloc = new Sons_JoueUneNote_SELNote( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupe, (int)__SONS.DUREE.NOIRE );
			break;
		case "0_2_Sons_JoueUneNoteBlanche_SELNote":
			bloc = new Sons_JoueUneNote_SELNote( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupe, (int)__SONS.DUREE.BLANCHE );
			break;
		case "0_2_Sons_JoueUnSon_SELSon":
			bloc = new __Sons_JoueUnSon_SELSon( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupe );
			break;

		// Sons - version 0.4
		// ------------------
		case "0_4_Sons_JoueUnSonPersonnel_SELSon":
			bloc = new __Sons_JoueUnSon_SELSon( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupe );
			break;
		case "0_4_Sons_EnregistreUnSon_Pendant04Seconde":
			bloc = new __Sons_EnregistreUnSon_AvecDurée( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupe, 4.0f );
			break;
		case "0_4_Sons_RelireLeSonEnregistré":
			bloc = new Sons_RejoueLeSonEnregistré( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupe );
			break;


		// Contrôles - version 0.1b
		// ------------------------
		case "0_1b_Contrôles_Attends1Seconde":
			bloc = new __Contrôle_Attends_Avec_eDurée( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupe, 1 );
			break;
		case "0_1b_Contrôles_Répète_SAIBoucle":
			bloc = new GroupeDInstructions_Boucle_Répète_SAINombre( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupe );
			break;
		case "0_1b_Contrôles_RépèteToutLeTemps" :
			bloc = new GroupeDInstructions_Boucle_RépèteToutLeTemps( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupe );
			break;

		// Contrôles - version 0.2
		// -----------------------
		case "0_2_Contrôles_Attends_SAIDurée":
			bloc = new Contrôle_Attends_SAIDurée( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupe );
			break;
		case "0_2_Contrôles_Attends_ENTDurée":
			bloc = new Contrôle_Attends_ENTDurée( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupe );
			break;
		case "0_2_Contrôles_Si_IlYAUnObstacleDevant_Alors":
			bloc = new __GroupeDInstructions_Si_Avec_cCondition( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupe, __CAPTEURS.code( (int)__CAPTEURS.NOM.AVANT, (int)__CAPTEURS.PARAMÈTRE.DISTANCE_PRÈS ) );
			break;
		case "0_2_Contrôles_Si_ENTCondition_Alors":
			bloc = new __GroupeDInstructions_Si_Avec_cCondition( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupe, "" );
			break;


		// Paramètres - version 0.4
		// ------------------------
		case "0_4_Paramètre_CalibreLesMoteurs_SAIValeur":
			bloc = new Paramètre_CalibreLesMoteurs_SAIValeur( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupe );
			break;

		// Paramètres - version 0.5
		// ------------------------
		case "0_5_Paramètre_LAdresseDeLaTélécommandeEst_SAIAdresse" :
			bloc = new Paramètre_LAdresseDeLaTélécommandeEst_SAIValeur( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupe );
			break;


		// Sinon, une erreur est déclenchée
		// --------------------------------
		default:
			int		pos;	
			String	ver;

			erreur = "Erreur ! Le bloc " + instruction + " n'est pas traité dans cette version du compilateur.";
			pos = instruction.IndexOf( "_", 2 );
			if ( pos != -1 ) {
				ver = instruction.Substring( 0, pos );
				ver = ver.Replace( "_", "." );
				erreur += "\n\nLa version du compilateur la plus appropiée pour ce bloc est la version " + ver;
			}
			throw new Exception( erreur );

        }


        // Lecture du bloc suivant
        // -----------------------
        XmlDuBlocSuivant = _XMLDuBloc.SelectSingleNode( "./next/block" );
		if ( bloc is __Evénement )
			bloc.blocSuivant = Compilateur.AnalyseUnNoeudDInstruction( bloc.UID+bloc.nombreDeSéquence, XmlDuBlocSuivant, bloc, _groupe );
		else if ( bloc is __Instruction )
			bloc.blocSuivant = Compilateur.AnalyseUnNoeudDInstruction( bloc.UID+bloc.nombreDeSéquence, XmlDuBlocSuivant, bloc, _groupe );
		else if ( bloc is __GroupeDInstructions ) {
			groupe = (__GroupeDInstructions)bloc;
			bloc.blocSuivant = Compilateur.AnalyseUnNoeudDInstruction( groupe.UID + groupe.nombreDeSéquence, XmlDuBlocSuivant, bloc, _groupe );
		} else if ( bloc is __Paramètre )
			bloc.blocSuivant = Compilateur.AnalyseUnNoeudDInstruction( bloc.UID+bloc.nombreDeSéquence, XmlDuBlocSuivant, bloc, _groupe );
		
		
		// Fin
		// ---
        return bloc;

    }


    /// <summary>
    /// Analyse un noeud d'expression et retourne la chaine équivalente de cette expression.
    /// </summary>
	public	static	String	AnalyseUnNoeudDExpression( int _UIDPourLeBloc, XmlNode _XMLDuBloc, __Bloc _blocPrécédent, __GroupeDInstructions _groupe ) {

		// Déclarations
		// ------------
		String		code;
		String		erreur;
		String		instruction;		
		
		__Valeur	expression;



        /*
         * Initialisations
         */
        code = "";



        /*
         * Contrôles
         */
        if ( _XMLDuBloc == null ) { return code; }



        /*
		 * Traitements
		 */
        instruction = _XMLDuBloc.Attributes["type"].Value;
        switch( instruction ) {

        case "":
            break;


		/*
		 * Blocs d'instruction de la version 0.2
		 * -------------------------------------
		 */

		// Valeurs booléenes
		// -----------------
		case "0_2_Valeur_Booléen_Bouton_FlècheAvant" :
			code = __BOUTONS.code( (int)__BOUTONS.NOM.FLECHE_VERS_L_AVANT );
			break;
		case "0_2_Valeur_Booléen_Bouton_FlècheArrière" :
			code = __BOUTONS.code( (int)__BOUTONS.NOM.FLECHE_VERS_L_ARRIERE );
			break;
		case "0_2_Valeur_Booléen_Bouton_FlècheADroite" :
			code = __BOUTONS.code( (int)__BOUTONS.NOM.FLECHE_VERS_LA_DROITE );
			break;
		case "0_2_Valeur_Booléen_Bouton_FlècheAGauche" :
			code = __BOUTONS.code( (int)__BOUTONS.NOM.FLECHE_VERS_LA_GAUCHE );
			break;

		// Capteurs de proximité avant
		// ---------------------------
		case "0_2_Valeur_Booléen_Capteur_AvantDroite" :
			code = __CAPTEURS.code( (int)__CAPTEURS.NOM.AVANT_DROITE, (int)__CAPTEURS.PARAMÈTRE.DISTANCE_PRÈS );
			break;
		case "0_2_Valeur_Booléen_Capteur_AvantGauche" :
			code = __CAPTEURS.code( (int)__CAPTEURS.NOM.AVANT_GAUCHE, (int)__CAPTEURS.PARAMÈTRE.DISTANCE_PRÈS );
			break;
		case "0_2_Valeur_Booléen_Capteur_AvantMilieu" :
			code = __CAPTEURS.code( (int)__CAPTEURS.NOM.AVANT_MILIEU, (int)__CAPTEURS.PARAMÈTRE.DISTANCE_PRÈS );
			break;
		case "0_2_Valeur_Booléen_Capteur_AvantMilieuDroite" :
			code = __CAPTEURS.code( (int)__CAPTEURS.NOM.AVANT_MILIEU_DROITE, (int)__CAPTEURS.PARAMÈTRE.DISTANCE_PRÈS );
			break;
		case "0_2_Valeur_Booléen_Capteur_AvantMilieuGauche" :
			code = __CAPTEURS.code( (int)__CAPTEURS.NOM.AVANT_MILIEU_GAUCHE, (int)__CAPTEURS.PARAMÈTRE.DISTANCE_PRÈS );
			break;

		// Capteurs de proximité arrière
		// -----------------------------
		case "0_2_Valeur_Booléen_Capteur_ArrièreDroite" :
			code = __CAPTEURS.code( (int)__CAPTEURS.NOM.ARRIÈRE_DROITE, (int)__CAPTEURS.PARAMÈTRE.DISTANCE_PRÈS );
			break;
		case "0_2_Valeur_Booléen_Capteur_ArrièreGauche" :
			code = __CAPTEURS.code( (int)__CAPTEURS.NOM.ARRIÈRE_GAUCHE, (int)__CAPTEURS.PARAMÈTRE.DISTANCE_PRÈS );
			break;

		// Capteur de teinte du dessous
		// ----------------------------
		case "0_2_Valeur_Booléen_Capteur_DessousGauche_Noir" :
			code = __CAPTEURS.code( (int)__CAPTEURS.NOM.DESSOUS_GAUCHE, (int)__CAPTEURS.PARAMÈTRE.COULEUR_SOL_NOIR );
			break;
		case "0_2_Valeur_Booléen_Capteur_DessousGauche_Blanc" :
			code = __CAPTEURS.code( (int)__CAPTEURS.NOM.DESSOUS_GAUCHE, (int)__CAPTEURS.PARAMÈTRE.COULEUR_SOL_BLANC );
			break;
		case "0_2_Valeur_Booléen_Capteur_DessousDroite_Noir" :
			code = __CAPTEURS.code( (int)__CAPTEURS.NOM.DESSOUS_DROITE, (int)__CAPTEURS.PARAMÈTRE.COULEUR_SOL_NOIR );
			break;
		case "0_2_Valeur_Booléen_Capteur_DessousDroite_Blanc" :
			code = __CAPTEURS.code( (int)__CAPTEURS.NOM.DESSOUS_DROITE, (int)__CAPTEURS.PARAMÈTRE.COULEUR_SOL_BLANC );
			break;

		// Télécommande infra-rouge
		// ------------------------
		case "0_2_Valeur_Booléen_ToucheDeLaTélécommandeEst_SELTouche" :
			expression = new Valeur_CapteurIR_SELTouche( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupe );
			code = expression.codePourLeSéquenceur;
			break;
		case "0_5_Valeur_Booléen_BoutonDeLaTélécommandeEst_SELTouche" :
			expression = new Valeur_CapteurIR_SELBouton( _UIDPourLeBloc, _XMLDuBloc, _blocPrécédent, _groupe );
			code = expression.codePourLeSéquenceur;
			break;

		// Valeurs entières
		// ----------------
		case "0_2_Valeur_Entier_1" :
			code = "1";
			break;


		// Sinon, une erreur est déclenchée
		// --------------------------------
		default:
			int		pos;	
			String	ver;

			erreur = "Erreur ! Le bloc " + instruction + " n'est pas traité dans cette version du compilateur.";
			pos = instruction.IndexOf( "_", 2 );
			if ( pos != -1 ) {
				ver = instruction.Substring( 0, pos );
				ver = ver.Replace( "_", "." );
				erreur += "\n\nLa version du compilateur la plus appropiée pour ce bloc est la version " + ver;
			}
			throw new Exception( erreur );

        }



		// Fin
		// ---

		return code;

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
            AfficheUnMessageDErreur( "Erreur ! Le fichier " + nomDuFichierB4T + " n'existe pas.");
            return false;
        }



        /*
		 * Initialisations
		 */
        compteurDeSéquenceur = 0;
		compteurDeMarqueur = 0;

		nomDuFichierAESL = Path.GetDirectoryName(nomDuFichierB4T) + @"\" + "temp.aesl";
        nomDuFichierAESLTemp = Path.GetTempPath() + @"\" + "temp.aesl";

        événementsRacines = new List<__Evénement>();

        __GroupeDInstructions_Boucle_Répère_AvecNombre.__compteurDeBoucle = 0;



        /*
		 * 1er passe.
		 * Les blocs sont décomposés depuis le fichier b4t
		 */
        AjouteUnMessage( "Lecture du fichier b4t...\n" );
        if ( !DécompositionDuFichierBlockly4Thymio(_fenêtrePrincipal) )
        	return false;


        /*
         * 2ème passe.
         * Le programme est empaqueté dans un fichier .aesl
         */
        AjouteUnMessage( "Compilation du fichier b4t...\n" );
        if ( !CréationDuFichierAESL() )
        	return false;


        /*
         * 3ème passe.
         * Le programme est transmis au robot Thymio
         */
        AjouteUnMessage( "Transfert du fichier Aseba...\n" );
        if ( !TransmissionDuFichierAESL( _fenêtrePrincipal ) )
        	return false;
        


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
		String			codeEvénementBoutonFlèche;
        String			codeEvénementCommandeIR;
		String			codeEvénementLancementDuProgramme;        
        String			codeSéquenceur;
        String			framework;


        /*
		 * Initialisations
		 */
        codeDéclarationDesVariables = "";
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
        if (événementsRacines.Count > 0) {
            
			codeDéclarationDesVariables +=	"var __sequenceur[" + événementsRacines.Count + "]\n" +
                                            "var __chrono[" + événementsRacines.Count + "]\n";
			
            if ( __GroupeDInstructions_Boucle_Répère_AvecNombre.__compteurDeBoucle > 0 )
                codeDéclarationDesVariables += "var __boucles[" + __GroupeDInstructions_Boucle_Répère_AvecNombre.__compteurDeBoucle + "]\n";
            
        }


        // Ajoute le code généré pour chaque événement
        foreach ( __Evénement événementRacine in événementsRacines ) {

            // Evénement : Quand le programme commence
            if	( événementRacine is Evénement_QuandLeProgrammeCommence ) {
                if ( événementRacine.blocSuivant != null ) {
                    // Exécute l'instruction qui suit l'événement
                    if ( codeEvénementLancementDuProgramme != "" ) { codeEvénementLancementDuProgramme += " "; }
                    codeEvénementLancementDuProgramme += "  __sequenceur[" + événementRacine.UIDDuSéquenceur + "]=" + événementRacine.blocSuivant.UID;
                    codeSéquenceur += événementRacine.blocSuivant.codePourLeSéquenceur + "\n";
                }
            }
			// Evénement : Quand un ordre arrive de la télécommande IR
            if	( événementRacine is Evénement_QuandUnOrdreArriveDeLaTélécommandeIR ) {
                if ( événementRacine.blocSuivant != null ) {
                    // Exécute l'instruction qui suit l'événement
					if ( codeEvénementCommandeIR != "" ) { codeEvénementCommandeIR += "  "; }
                    codeEvénementCommandeIR += "  __sequenceur[" + événementRacine.UIDDuSéquenceur + "]=" + événementRacine.blocSuivant.UID;
                    codeSéquenceur += événementRacine.blocSuivant.codePourLeSéquenceur + "\n";
                }
            }
			// Evénement : Quand un bouton flèche est appuyé
            if	( événementRacine is Evénement_QuandUnBoutonFlècheEstAppuyé ) {
                if ( événementRacine.blocSuivant != null ) {
                    // Exécute l'instruction qui suit l'événement
					if ( codeEvénementBoutonFlèche != "" ) { codeEvénementBoutonFlèche += "  "; }
                    codeEvénementBoutonFlèche += "  __sequenceur[" + événementRacine.UIDDuSéquenceur + "]=" + événementRacine.blocSuivant.UID;
                    codeSéquenceur += événementRacine.blocSuivant.codePourLeSéquenceur + "\n";
                }
            }
        }


        // Ajoute le code de fin du séquenceur
        if ( arrêtDuRobotALaFinDesSéquenceurs )
        {
            if ( afficherLesCommentaires ) { codeSéquenceur += "\n# Code exécuté à la fin de tous les séquenceurs\n"; }
            codeSéquenceur += "if ";
            for (int séquenceur = 0; séquenceur < événementsRacines.Count; séquenceur++) {
                codeSéquenceur += "__sequenceur[" + séquenceur + "]==0 ";
                if (séquenceur < (événementsRacines.Count - 1)) { codeSéquenceur += "and "; }
            }
            codeSéquenceur += "then\n" +
                                "  __etat = ETAT_ARRET\n" +
                                "end\n";
        }
        // Nettoie le fichier du séquenceur des <
        codeSéquenceur = codeSéquenceur.Replace("<", "&lt;");


        // Remplace les sections définis par des marqueurs par le code correspondant
        framework = framework.Replace("### VARIABLES ###", codeDéclarationDesVariables);
        framework = framework.Replace("### EVENEMENT AU LANCEMENT ###", codeEvénementLancementDuProgramme );
        if ( codeEvénementCommandeIR != "" )
			codeEvénementCommandeIR += "  \n__etat = ETAT_EN_MARCHE";
		framework = framework.Replace("### EVENEMENT COMMANDE INFRAROUGE ###", codeEvénementCommandeIR );
		if( codeEvénementBoutonFlèche != "" ) {
			codeEvénementBoutonFlèche = "  if button.forward==1 or button.backward==1 or button.left==1 or button.right==1 then\n  " + codeEvénementBoutonFlèche + "\n    __etat = ETAT_EN_MARCHE\n  end";

		}
		framework = framework.Replace("### EVENEMENT BOUTON FLECHE ###", codeEvénementBoutonFlèche );
		
		// Met en place le code du séquenceur
		framework = framework.Replace( "### SEQUENCEUR ###", codeSéquenceur );

        // Définie le mode de lancement du programme auto ou manuel
        if ( lancementAutomatique ) {
            framework = framework.Replace("### ETAT AU LANCEMENT ###", codeEvénementLancementDuProgramme + "\n__etat=ETAT_EN_MARCHE");
        } else {
            framework = framework.Replace("### ETAT AU LANCEMENT ###", codeEvénementLancementDuProgramme + "\n__etat=ETAT_ARRET");
        }


        // Sauve le fichier .aesl
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
            AfficheUnMessageDErreur( "Erreur lors de la lecture du fichier " + nomDuFichierB4T );
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
				if ( bloc is Evénement_QuandUnOrdreArriveDeLaTélécommandeIR ) {
					événementRacine = (Evénement_QuandUnOrdreArriveDeLaTélécommandeIR)bloc;
					événementsRacines.Add( événementRacine );
				}
				if ( bloc is Evénement_QuandUnBoutonFlècheEstAppuyé ) {
					événementRacine = (Evénement_QuandUnBoutonFlècheEstAppuyé)bloc;
					événementsRacines.Add( événementRacine );
				}
			}
        }
		if ( événementsRacines.Count == 0 ) {
			AfficheUnMessageDInformation( "Il n'y a pas d'instruction de départ dans le fichier " + nomDuFichierB4T );
			return false;
		}



		/*
		 * Fin
		 */
		return true;

	}


	/// <summary>
	/// Liste des messages d'erreur.
	/// </summary>
	/// <returns>String</returns>
	public	static	String	Message( int _numéro ) {		
		switch( _numéro ) {
		
		case 0x0001 :	return "Dans une des boucle, le nombre de répétition est plus petit que 1. Celui-ci a été corrigé pour être au moins à 1.";
		case 0x0002 :	return "Dans une des boucle, le nombre de répétition est plus grand que 100. Celui-ci a été corrigé pour être à 100.";
		
		case 0x0003 :	return "Une durée est plus petite que 0s. Celle-ci a été corrigée pour être au moins à 0 seconde.";
		case 0x0004 :	return "Une durée est plus grande que 60s. Celle-ci a été corrigée pour être à 60 secondes.";
		
		case 0x0005 :	return "Une distance est plus petite que 1cm. Celle-ci a été corrigée pour être au moins à 1cm.";
		case 0x0006 :	return "Une distance est plus grande que 100cm. Celle-ci a été corrigée pour être de 100cm.";
		
		case 0x0007 :	return "Un angle est plus petit que 0°. Celle-ci a été corrigé pour être au moins à 0°.";
		case 0x0008 :	return "Un angle est plus grand que 360°. Celle-ci a été corrigé pour être de 360°.";

		}

		throw new Exception( "Le message " + _numéro + " n'existe pas dans la liste des  messages." );

	}


	/// <summary>
	/// Créer un marqueur qui peu être inséré dans le code.
	/// Ces marqueurs sont modifiés selon les besoins.
	/// </summary>
	/// <returns></returns>
	public	static	String	NouveauMarqueur() {
		compteurDeMarqueur++;
		return "%%%MARQUEUR_" + compteurDeMarqueur + "%%%";
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
            AfficheUnMessageDErreur( "Erreur ! L'exécutable " + nomDuFichierASEBAMASSLOADER + " pour transmettre le fichier .aesl au robot Thymio n'existe pas." );
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

