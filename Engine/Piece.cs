public abstract class Piece {

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

	private PieceType type;
	private Board.PieceColor color;

	public Piece(PieceType type, Board.PieceColor color, int row, int col) {
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
	public abstract bool isMoveLegal(int fromRow, int fromCol, int toRow, int toCol);

	public Board.PieceColor getColor() {
		return this.color;
	}

	public PieceType getType() {
		return this.type;
	}

}

