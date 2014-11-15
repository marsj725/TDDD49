public abstract class Piece {

	public enum PieceColor {
		WHITE,
		BLACK}
	;

	public enum PieceType {
		PAWN,
		ROOK,
		BISHOP,
		KNIGHT,
		KING,
		QUEEN}

	;

	private PieceColor color;
	private PieceType type;

	public Piece(PieceType type, PieceColor color) {
		this.color = color;
		this.type = type;
	}

	/// <summary>
	/// Is the move legal for this piece.
	/// </summary>
	/// <returns><c>true</c>, if move legal was ised, <c>false</c> otherwise.</returns>
	/// <param name="fromRow">From row.</param>
	/// <param name="fromColumn">From column.</param>
	/// <param name="toRow">To row.</param>
	/// <param name="toCol">To col.</param>
	public abstract bool isMoveLegal(int fromRow, int fromCol, int toRow, int toCol);

	public PieceColor getColor() {
		return this.color;
	}

	public PieceType getType() {
		return this.type;
	}
}

