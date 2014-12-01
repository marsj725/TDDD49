public class Queen : Piece {
	public Queen(PieceColor color, int x, int y) : base(PieceType.QUEEN, color, x, y) {
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
		// Diagonal movement
		if(fromRow - toRow == fromCol - toCol)
			return true;
		// Horisontal or vertical movement
		else if(fromRow - toRow == 0 || fromCol - toCol == 0)
			return true;
		return false;
	}
}