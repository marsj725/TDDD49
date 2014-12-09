using System;

public class User : Player {

	private Mediator mediator;

	private bool myTurn;
	private Board.PieceColor color;

	public Board.PieceColor Color {
		get {
			return color;
		}
		private set {
			color = value;
		}
	}

	public User(Mediator mediator, Board.PieceColor color) {
		mediator.registerPlayer(this);
		this.mediator = mediator;
	}

	public bool makeDraw(int fromRow, int fromCol, int toRow, int toCol) {
		return this.mediator.makeDraw(fromRow, fromCol, toRow, toCol);
	}

	public void updateBoard(Piece[,] board) {
	}

}