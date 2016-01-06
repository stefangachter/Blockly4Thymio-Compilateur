
using	System;
using	System.Drawing;
using	System.Reflection;
using	System.Windows.Forms;



namespace	Blockly4Thymio {
public		partial	class	FEN_Principale : Form {

	/*
	 * Déclarations
	 */
	static	Timer	timer;
	
	string[] args;
	
	
	
	/*
     * Constructeur de la fenêtre
     */
	public FEN_Principale( string[] _args ) {
		args = _args;
		InitializeComponent();
	}
	
	
	public	void	AjouteUnMessage( String _texte ) {
		TEXT_Messages.Text += _texte + "\r\n";
	}
	
	
	public	void	EffaceLesMessages() {
		TEXT_Messages.Text = "";
	}
	
	
	private	void FenêtrePrincipale_Load( object sender, EventArgs e ) {

		// Affiche l'entête
		// ----------------

		if ( Compilateur.nomDuFichierB4T == "" ) {
			Compilateur.AfficheLAide(this.TEXT_Messages);
			return;
		}

		Compilateur.AfficheLEntête(this.TEXT_Messages);

		AjouteUnMessage("\nFichier : " + Compilateur.nomDuFichierB4T + "\n\n");


		// Lance la compilation.
		// Si la compilation s'est bien déroulée, le programme se ferme automatiquement
		try {
			if (Compilateur.Compile(this)) {
				//#if !DEBUG
				FermeLaFenêtreDans2Secondes();            
				//#endif
			}
			AjouteUnMessage( "\nCompilation terminée !" );
		} catch ( Exception ex ) {
			AfficheUnMessageDErreur( ex.Message );
		}


	}

	private	void	FermeLaFenêtreDans2Secondes() {
		timer = new Timer();
		timer.Interval = 2000;
		timer.Tick+= new EventHandler( Evénement_FinDuTimer );
		timer.Start();
	}
	private	void	Evénement_FinDuTimer( object sender, EventArgs e  ) {
		timer.Stop();
		Application.Exit();
	}

	public	void	AfficheUnMessageDErreur( String _message ) {
		EffaceLesMessages();
		this.BackColor = Color.Red;
		this.TEXT_Messages.BackColor = Color.Red;
		AjouteUnMessage( "\n" + _message + "\n\n" );		
	}

	public	void	AfficheUnMessageDInformation( String _message ) {
		EffaceLesMessages();
		this.BackColor = Color.DarkOrange;
		this.TEXT_Messages.BackColor = Color.DarkOrange;
		AjouteUnMessage( "\n" + _message + "\n\n" );
	}

}
}


