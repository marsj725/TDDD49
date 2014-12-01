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
	public override bool isMoveLegal(int fromRow, int fromCol, int toRow, int toCol) {
		//Vi måste implementera något som berättar vilken direction vi spelar
		//Firstmove (Special)
		if(fromRow == 6 || fromRow == 1) {
			if(Math.Abs(fromRow - toRow) > 0 && Math.Abs(fromRow - toRow) <= 2) { 
				return true;
			} else {
				return false;
			}
			//Hortizontal movement
		} else if(Math.Abs(fromRow - toRow) == 1) {
			return true;
		} else {
			return false;
		}
	}
}