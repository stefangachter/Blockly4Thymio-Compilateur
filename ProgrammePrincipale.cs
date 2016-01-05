
using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;



namespace 	Compilateur {
	static class ProgrammePrincipale {
		/// <summary>
		/// Point d'entrée principal de l'application.
		/// </summary>
		[STAThread]
		static void Main() {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault( false );
			Application.Run( new FEN_Principale() );
		}
	}
}
