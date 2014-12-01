using System;

public class Bishop : Piece {

	public Bishop(PieceColor color, int x, int y) : base(PieceType.BISHOP, color, x, y) {
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
	/// 

	//Checks that the change in rows is the same as the change in cols
	public override bool isMoveLegal(Board board, int fromRow, int fromCol, int toRow, int toCol) {
		if(Math.Abs(fromRow - toRow) == Math.Abs(fromCol - toCol)) {
			return true;
		} else {
			return false;
		}
	}
}