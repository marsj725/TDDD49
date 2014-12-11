using System;
using C5;

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
	public int Moved;

	private PieceType type;
	private Board.PieceColor color;

	public Piece(PieceType type, Board.PieceColor color, int row, int col) {
		this.color = color;
		this.type = type;
		this.Col = col;
		this.Row = row;
		this.Moved = 0;
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

	public Board.PieceColor getColor() {
		return this.color;
	}

	public PieceType getType() {
		return this.type;
	}

	/// <summary>
	/// Returns the possible moves of this piece.
	/// </summary>
	/// <returns>The possible moves.</returns>
	public abstract ArrayList<Tuple<int, int>> getPossibleMoves(Board board);

	/// <summary>
	/// Checks diagonally which moves is possible for this piece and returns them.
	/// </summary>
	/// <param name="board">Board.</param>
	/// <param name="result">Result.</param>
	/// <param name="directionX">Direction x.</param>
	/// <param name="directionY">Direction y.</param>
	protected void possibleDrawsDiagonally(Board board, ref ArrayList<Tuple<int, int>> result, int directionX, int directionY) {
		int boardLimitX;
		int boardLimitY;

		if(directionX < 0)
			boardLimitX = 0;
		else
			boardLimitX = 7;

		if(directionY < 0)
			boardLimitY = 0;
		else
			boardLimitY = 7;

		for(int i = 1; directionY * (this.Row + i * directionY) <= directionY * boardLimitY && directionX * (this.Col + i * directionX) <= directionX * boardLimitX; i++) {
			Board.PieceColor color = board.BoardGrid[this.Row + i * directionY, this.Col + i * directionX].getColor();
			if(color == Board.PieceColor.NONE) {
				result.Add(new Tuple<int, int>(this.Row + i * directionY, this.Col + i * directionX));
			} else if(color != this.getColor()) {
				result.Add(new Tuple<int, int>(this.Row + i * directionY, this.Col + i * directionX));
				return;
			} else {
				return;
			}
		}
	}

	/// <summary>
	/// Checks horisontally and vertically which moves is possible for this piece and returns it.
	/// </summary>
	/// <param name="result">Result.</param>
	/// <param name="board">Board.</param>
	protected void possibleMovesHorisontallyAndVertically(ref C5.ArrayList<Tuple<int, int>> result, Board board) {

		for(int i = -1; this.Row + i >= 0; i--) {
			if(board.BoardGrid[this.Row + i, this.Col].getColor() == Board.PieceColor.NONE)
				result.Add(new Tuple<int, int>(this.Row + i, this.Col));
			else if(board.BoardGrid[this.Row + i, this.Col].getColor() != this.getColor()) {
				result.Add(new Tuple<int, int>(this.Row + i, this.Col));
				break;
			} else
				break;
		}

		for(int i = -1; this.Col + i >= 0; i--) {
			if(board.BoardGrid[this.Row, this.Col + i].getColor() == Board.PieceColor.NONE)
				result.Add(new Tuple<int, int>(this.Row, this.Col + i));
			else if(board.BoardGrid[this.Row, this.Col + i].getColor() != this.getColor()) {
				result.Add(new Tuple<int, int>(this.Row, this.Col + i));
				break;
			} else
				break;
		}

		for(int i = 1; this.Row + i <= 7; i++) {
			if(board.BoardGrid[this.Row + i, this.Col].getColor() == Board.PieceColor.NONE)
				result.Add(new Tuple<int, int>(this.Row + i, this.Col));
			else if(board.BoardGrid[this.Row + i, this.Col].getColor() != this.getColor()) {
				result.Add(new Tuple<int, int>(this.Row + i, this.Col));
				break;
			} else
				break;
		}

		for(int i = 1; this.Col + i <= 7; i++) {
			if(board.BoardGrid[this.Row, this.Col + i].getColor() == Board.PieceColor.NONE)
				result.Add(new Tuple<int, int>(this.Row, this.Col + i));
			else if(board.BoardGrid[this.Row, this.Col + i].getColor() != this.getColor()) {
				result.Add(new Tuple<int, int>(this.Row, this.Col + i));
				break;
			} else
				break;
		}	
	}

	/// <summary>
	/// Gets the opposite color of the input parameter.
	/// </summary>
	/// <returns>The opposite color.</returns>
	/// <param name="color">Color.</param>
	public Board.PieceColor getOppositeColor() {
		if(color == Board.PieceColor.NONE)
			return Board.PieceColor.NONE;
		if(color == Board.PieceColor.BLACK)
			return Board.PieceColor.WHITE;
		return Board.PieceColor.BLACK;
	}

}

