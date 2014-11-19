using System;

/// <summary>
/// A chess player.
/// </summary>
public abstract class Player {

	private Piece.PieceColor color;

	/// <summary>
	/// Sets a value indicating whether it is the <see cref="Player"/>s turn in the game.
	/// </summary>
	/// <value><c>true</c> if my turn; otherwise, <c>false</c>.</value>
	public bool MyTurn {
		set { MyTurn = value; }
	}

	/// <summary>
	/// Makes a draw.
	/// </summary>
	/// <returns><c>true</c>, if draw was made, <c>false</c> otherwise.</returns>
	/// <param name="fromRow">From row.</param>
	/// <param name="fromCol">From col.</param>
	/// <param name="toRow">To row.</param>
	/// <param name="toCol">To col.</param>
	protected abstract bool makeDraw(int fromRow, int fromCol, int toRow, int toCol);

	/// <summary>
	/// Updates the board state.
	/// </summary>
	/// <param name="board">Board.</param>
	public abstract void updateBoard(Piece[,] board);

	/// <summary>
	/// Initializes a new instance of the <see cref="Player"/> class.
	/// </summary>
	/// <param name="color">Color.</param>
	public Player(Piece.PieceColor color) {
		MyTurn = false;
		this.color = color;
	}
}

