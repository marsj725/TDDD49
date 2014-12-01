public abstract class Piece {

	public enum PieceColor {
		WHITE,
		BLACK,
		NONE}

	;

	public enum PieceType {
		NONE,
		PAWN,
		ROOK,
		BISHOP,
		KNIGHT,
		KING,
		QUEEN}

	;

	public int Row;
	public int Col;

	private PieceColor color;
	private PieceType type;

	public Piece(PieceType type, PieceColor color, int row, int col) {
		this.color = color;
		this.type = type;
		this.Col = col;
		this.Row = row;
	}

	/// <summary>
	/// Is the move legal for this piece.
	/// </summary>
	/// <returns><c>true</c>, if move legal was ised, <c>false</c> otherwise.</returns>
	/// <param name="fromRow">From row.</param>
	/// <param name="fromColumn">From column.</param>
	/// <param name="toRow">To row.</param>
	/// <param name="toCol">To col.</param>
	public abstract bool isMoveLegal(Board board, int fromRow, int fromCol, int toRow, int toCol);

	public PieceColor getColor() {
		return this.color;
	}

	public PieceType getType() {
		return this.type;
	}

	public PieceColor getOppositeColor() {
		if(color == PieceColor.NONE)
			return PieceColor.NONE;
		if(color == PieceColor.BLACK)
			return PieceColor.WHITE;
		return PieceColor.BLACK;
	}
}

