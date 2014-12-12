using System;
using System.Windows.Forms;

public class ChessMenu : MainMenu {

	private Mediator mediator;

	public ChessMenu(Mediator mediator) : base() {
		this.mediator = mediator;

		MenuItem menuItemNew = new MenuItem("Mode");

		MenuItem subMenu1 = new MenuItem("Human vs human");
		MenuItem subMenu2 = new MenuItem("Human vs AI");
		MenuItem subMenu3 = new MenuItem("AI vs human");

		menuItemNew.MenuItems.Add(subMenu1);
		menuItemNew.MenuItems.Add(subMenu2);
		menuItemNew.MenuItems.Add(subMenu3);

		MenuItems.Add(menuItemNew);

		subMenu1.Click += new EventHandler(humanVsHuman);
		subMenu2.Click += new EventHandler(humanVsAI);
		subMenu3.Click += new EventHandler(AIVsHuman);
	}

	void humanVsHuman(object sender, EventArgs e) {
		mediator.Player1 = new User(mediator, Board.PieceColor.WHITE);
		mediator.Player2 = new User(mediator, Board.PieceColor.BLACK);
		mediator.resetGame();
	}

	void humanVsAI(object sender, EventArgs e) {
		mediator.Player1 = new User(mediator, Board.PieceColor.WHITE);
		mediator.Player2 = new AI(mediator, Board.PieceColor.BLACK);
		mediator.resetGame();
	}

	void AIVsHuman(object sender, EventArgs e) {
		mediator.Player1 = new AI(mediator, Board.PieceColor.WHITE);
		mediator.Player2 = new User(mediator, Board.PieceColor.BLACK);
		mediator.resetGame();
	}
}

