using System;
using C5;

public class AI : Player {

	public AI(Mediator mediator, Board.PieceColor color) : base(mediator, color) {
	}

	public override bool makeDraw(int fromRow, int fromCol, int toRow, int toCol) {
		return this.mediator.makeDraw(fromRow, fromCol, toRow, toCol);
	}

	/// <summary>
	/// Calculates which draw to make and performs it.
	/// </summary>
	/// <returns><c>true</c>, if draw was made, <c>false</c> otherwise.</returns>
	private bool makeDraw() {
		ArrayList<int[]> possibleDraws = mediator.Engine.board.getPossibleAttacks(this.Color);

		// If the player can kill an opponent, do that!
		foreach(int[] draw in possibleDraws) {
			if(this.mediator.Engine.board.BoardGrid[draw[2], draw[3]].getColor() != this.Color &&
			   this.mediator.Engine.board.BoardGrid[draw[2], draw[3]].getColor() != Board.PieceColor.NONE)
				return makeDraw(draw[0], draw[1], draw[2], draw[3]);
		}

		// Otherwise make a random draw

		Random random = new Random();

		int randomDraw = random.Next(0, possibleDraws.Count - 1);

		int fromRow = possibleDraws[randomDraw][0];
		int fromCol = possibleDraws[randomDraw][1];
		int toRow = possibleDraws[randomDraw][2];
		int toCol = possibleDraws[randomDraw][3];
		
		return makeDraw(fromRow, fromCol, toRow, toCol);

	}

	public override void turnChanged() {
		if(this.mediator.Engine.PlayerTurn == this.Color)
			makeDraw();
	}

}

 