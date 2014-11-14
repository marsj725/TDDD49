public class Bishop : Piece {

	public Bishop(PieceColor color) : base(PieceType.BISHOP, color) {
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
	public override bool isMoveLegal(int fromRow, int fromColumn, int toRow, int toCol) {
		// To be implemented.
		return false;
	}
}