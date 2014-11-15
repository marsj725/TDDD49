public class Pawn : Piece {

	private bool firstMove;

	public Pawn(PieceColor color) : base(PieceType.PAWN, color) {
		firstMove = true;
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
		// To be implemented.
		return false;
	}
}