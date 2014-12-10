using System;

public class User : Player {

	private bool myTurn;
	private Board.PieceColor color;

	public User(Mediator mediator, Board.PieceColor color) : base(mediator) {
		mediator.registerPlayer(this);
		this.mediator = mediator;
	}

	public override bool makeDraw(int fromRow, int fromCol, int toRow, int toCol) {
		return this.mediator.makeDraw(fromRow, fromCol, toRow, toCol);
	}

	public override void updateBoard(Piece[,] board) {
	}

}