using System.Drawing;
using System.Windows.Forms;

public class ChessGUI : Form {

	public ChessGUI() {
		Text = "Chess";
		Size = new Size(200, 250);
		CenterToScreen();
		loadIcon();
	}

	static public void Main() {
		Application.Run(new ChessGUI());
	}

	private void loadIcon() {
		Icon = new Icon("icon.ico");
	}

}

