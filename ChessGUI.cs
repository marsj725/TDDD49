using System.Drawing;
using System.Windows.Forms;

public class ChessGUI : Form {

	public ChessGUI() {
		Text = "Chess";
		Size = new Size(250, 200);
		CenterToScreen();
	}

	static public void Main() {
		Application.Run(new ChessGUI());
	}

}

