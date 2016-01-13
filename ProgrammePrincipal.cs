
#define	WINDOWS

//#define	LINUX



#if WINDOWS
#warning Compilation pour WINDOWS
#endif
#if LINUX
#warning "Compilation pour LINUX"
#endif


using	System;
using	System.IO;
using	System.Reflection;
using	System.Windows.Forms;



namespace 		Blockly4Thymio {
static	class 	ProgrammePrincipal {

	/// <summary>
	/// Point d'entrée principal de l'application.
	/// </summary>
	[STAThread]
	static void Main( string[] _args ) {

		// Initialisations
		// ---------------

		Compilateur.version = "0.31";


		// Affichage des commentaires dans le fichier .aesl
		Compilateur.afficherLesCommentaires = false;

		// Arrête le robot si tous les séquenceurs sont terminés
		Compilateur.arrêtDuRobotALaFinDesSéquenceurs = true;

		// Lance automatiquement le programme sur le Thymio à la fin du transfert
		Compilateur.lancementAutomatique = true;

		// Emplacement de programme de transfert AsebaMassloader

		#if WINDOWS
		Compilateur.nomDuFichierASEBAMASSLOADER = Directory.GetCurrentDirectory() + "\\asebamassloader\\asebamassloader.exe";
		#endif
		#if LINUX
		Compilateur.nomDuFichierASEBAMASSLOADER = "asebamassloader";
		#endif
		
		Compilateur.nomDuFichierB4T = "";
		if ( _args != null )
			if ( _args.Length != 0 )
				Compilateur.nomDuFichierB4T = _args[0];

		#if DEBUG

		Compilateur.afficherLesCommentaires = true;
		
		
		// Nom et répertoire du fichier asebamassloader.exe
		#if WINDOWS
		Compilateur.nomDuFichierASEBAMASSLOADER = @"C:\Users\Okimi\Mes projets\2015\Blockly4Thymio\CompilateurAseba\asebamassloader\asebamassloader.exe";
		// Nom du fichier programme.b4t à tester
		Compilateur.nomDuFichierB4T = @"C:\Users\Okimi\Downloads\programme.b4t";
		//Compilateur.nomDuFichierB4T = @"C:\Users\fort\Downloads\programme.b4t";
		#endif
		#if LINUX
		Compilateur.nomDuFichierASEBAMASSLOADER = "asebamassloader";
		Compilateur.nomDuFichierB4T = @"/home/okimi/Téléchargements/programme.b4t";
		#endif
		
		Compilateur.lancementAutomatique = true;
		
		//Compilateur.suppressionDuFichierAESL = false;

		Compilateur.afficheLesMessagesDErreur = false;

		Compilateur.afficheLesMessagesDInformation = false;

		#else

		// Anlyse les arguments
		// --------------------
		#if WINDOWS
		Compilateur.nomDuFichierASEBAMASSLOADER = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6);                
		Compilateur.nomDuFichierASEBAMASSLOADER += @"\asebamassloader\asebamassloader.exe";
		#endif
		#if LINUX
		Compilateur.nomDuFichierASEBAMASSLOADER += @"asebamassloader.exe";
		#endif
		
		Compilateur.afficheLesMessagesDErreur = true;

		Compilateur.afficheLesMessagesDInformation = true;

		#endif


		// Traitements
		// -----------

		Application.EnableVisualStyles();
		Application.SetCompatibleTextRenderingDefault(false);
		Application.Run( new FEN_Principale( _args ) );

	}

}
}


