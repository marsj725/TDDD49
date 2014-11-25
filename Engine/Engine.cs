using System;

/// <summary>
/// Chess engine.
/// </summary>
public class Engine {

	private Player player1;
	private Board board;

	/// <summary>
	/// Initializes a new instance of the <see cref="Engine"/> class.
	/// </summary>
	public Engine(Player player1) {
		this.board = new Board();
		this.player1 = player1;
		this.player1.initializeEngine(this);
		this.player1.updateBoard(board.BoardGrid);
	}

	/// <summary>
	/// Performs the draw on the board.
	/// </summary>
	/// <param name="color">Color.</param>
	/// <param name="fromRow">From row.</param>
	/// <param name="fromCol">From col.</param>
	/// <param name="toRow">To row.</param>
	/// <param name="toCol">To col.</param>
	public bool performDraw(Piece.PieceColor color, int fromRow, int fromCol, int toRow, int toCol) {
		// The draw is obviously not allowed if the user trying to make the draw isn't the same color.
		if(this.board.BoardGrid[fromRow, fromCol].getColor() != color)
			return false;
		if(this.board.BoardGrid[toRow, toCol].getColor() == color)
			return false;
		if(this.board.BoardGrid[fromRow, fromCol].isMoveLegal(fromRow, fromCol, toRow, toCol)) {
			this.board.movePiece(fromRow, fromCol, toRow, toCol);
			player1.updateBoard(this.board.BoardGrid);
			return true;
		}
		return false;
	}

	/// <summary>
	/// Controls whether it is check or not.
	/// </summary>
	/// <returns><c>true</c>, if check, <c>false</c> otherwise.</returns>
	private bool isCheck() {
		// To be implemented
		return false;
	}

	/// <summary>
	///	Controls whether it is check mate or not. 
	/// </summary>
	/// <returns><c>true</c>, if check mate, <c>false</c> otherwise.</returns>
	private bool isCheckMate() {
		// To be implemented
		return false;
	}

}

