using System;

public class Pawn : Piece {

	public Pawn(PieceColor color, int x, int y) : base(PieceType.PAWN, color, x, y) {

	}

	/// <summary>
	/// Is the move legal for this piece.
	/// </summary>
	/// <returns>true</returns>
	/// <c>false</c>
	/// <param name="fromRow">From row.</param>
	/// <param name="fromColumn">From column.</param>
	/// <param name="toRow">To row.</param>
	/// <param name="toCol">To col.</param>
	public override bool isMoveLegal(Board board, int fromRow, int fromCol, int toRow, int toCol) {

		if(fromRow - toRow == 0 && fromCol - toCol == 0)
			return false;

		bool firstMove = false;
		bool verticalCheck = false;
		bool twoSteps = false;
		bool horisontalCheck = false;
		int direction;

		if(getColor() == PieceColor.BLACK)
			direction = -1;
		else
			direction = 1;

		if(fromRow == 6 || fromRow == 1)
			firstMove = true;

		if(firstMove) {
			if(fromRow - toRow == 2 * direction || fromRow - toRow == 1 * direction) {
				verticalCheck = true;
			}
			if(fromRow - toRow == 2 * direction)
				firstMove = true;
		} else {
			if(fromRow - toRow == 1 * direction) {
				verticalCheck = true;
			}
		}

		if(fromCol - toCol == 0) {
			if(board.BoardGrid[toRow, toCol].getColor() == PieceColor.NONE)
				horisontalCheck = true;
		} else if(Math.Abs(fromCol - toCol) == 1) {
			if(board.BoardGrid[toRow, toCol].getColor() == this.getOppositeColor() && !twoSteps) {
				horisontalCheck = true;
			}
		}

		if(horisontalCheck && verticalCheck)
			return true;
		return false;
	}
}