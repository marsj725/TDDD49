using System;

public class AI : Player {

	public AI(Mediator mediator) : base(mediator) {
	}

	protected override bool makeDraw(int fromRow, int fromCol, int toRow, int toCol) {
		throw new NotImplementedException();
	}

	/// <summary>
	/// Calculates which draw to make and performs it.
	/// </summary>
	/// <returns><c>true</c>, if draw was made, <c>false</c> otherwise.</returns>
	private bool makeDraw() {
		bool[,] possibleDraws = mediator.Engine.board.getPossibleAttacks(this.Color);

		for(int i = 0; i < 8; i++) {
			for(int j = 0; j < 8; j++) {
				if(possibleDraws[i, j]) {
					if(mediator.Engine.board.BoardGrid[i, j].getColor() != this.Color &&
					   mediator.Engine.board.BoardGrid[i, j].getColor() != Board.PieceColor.NONE) {
					}
				}
			}
		}
	}

	public bool initializeEngine(Engine engine) {
		throw new NotImplementedException();
	}

	public void updateBoard(Piece[,] board) {
		throw new NotImplementedException();
	}

	protected override void setTurn(bool value) {
		makeDraw();
	}

}

 