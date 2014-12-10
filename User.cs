using System;

public class User : Player {

	public User(Mediator mediator, Board.PieceColor color) : base(mediator, color) {
	}

	public override bool makeDraw(int fromRow, int fromCol, int toRow, int toCol) {
		return this.mediator.makeDraw(fromRow, fromCol, toRow, toCol);
	}

	public override void turnChanged() {

	}

}