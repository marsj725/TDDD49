using System;

/// <summary>
/// Chess engine.
/// </summary>
public class Engine {

	private Player player1;

	/// <summary>
	/// Initializes a new instance of the <see cref="Engine"/> class.
	/// </summary>
	public Engine(Player player1) {
		Board board = new Board();
		this.player1 = player1;
		this.player1.updateBoard(board.board);
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
		// To be implemented
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

