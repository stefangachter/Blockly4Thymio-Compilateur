
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

		// ATTENTION !!! Le numéro de version doit aussi être modifié dans la méthode FrameworkASEBA.version_x_x
		Compilateur.version = "0.3";


		// Affichage des commentaires dans le fichier .aesl
		Compilateur.afficherLesCommentaires = false;

		// Arrête le robot si tous les séquenceurs sont terminés
		Compilateur.arrêtDuRobotALaFinDesSéquenceurs = true;

		// Lance automatiquement le programme sur le Thymio à la fin du transfert
		Compilateur.lancementAutomatique = true;

		//Compilateur.suppressionDuFichierAESL = true;

		Compilateur.nomDuFichierASEBAMASSLOADER = Directory.GetCurrentDirectory() + "\\asebamassloader\\asebamassloader.exe";

		Compilateur.nomDuFichierB4T = "";
		if ( _args != null )
			if ( _args.Length != 0 )
				Compilateur.nomDuFichierB4T = _args[0];

		#if DEBUG

		Compilateur.afficherLesCommentaires = true;

		// Nom et répertoire du fichier asebamassloader.exe
		Compilateur.nomDuFichierASEBAMASSLOADER = @"C:\Users\Okimi\Mes projets\2015\Blockly4Thymio\CompilateurAseba\asebamassloader\asebamassloader.exe";

		Compilateur.nomDuFichierB4T = @"C:\Users\Okimi\Downloads\programme.b4t";
		//Compilateur.nomDuFichierB4T = @"C:\Users\fort\Downloads\programme.b4t";

		Compilateur.lancementAutomatique = true;

		//Compilateur.suppressionDuFichierAESL = false;

		Compilateur.afficheLesMessagesDErreur = false;

		Compilateur.afficheLesMessagesDInformation = false;

		#else

		// Anlyse les arguments
		// --------------------
		Compilateur.nomDuFichierASEBAMASSLOADER = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6);                
		Compilateur.nomDuFichierASEBAMASSLOADER += @"\asebamassloader\asebamassloader.exe";

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


