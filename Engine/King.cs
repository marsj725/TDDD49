using System;
public class King : Piece {

	public King(Board.PieceColor color,int x, int y) : base(PieceType.KING, color, x ,y) {
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
	public override bool isMoveLegal(int fromRow, int fromCol, int toRow, int toCol) {
		if(fromRow - toRow == 0 && fromCol - toCol == 0)
			return false;

		if((Math.Abs(fromRow - toRow) <= 1) && (Math.Abs(fromCol - toCol) <= 1)) {
			return true;
		}
		return false;
	}
}