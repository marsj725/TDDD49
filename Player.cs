using System;

/// <summary>
/// A chess player.
/// </summary>
public interface Player {

	/// <summary>
	/// Sets a value indicating whether it is the <see cref="Player"/>s turn in the game.
	/// </summary>
	/// <value><c>true</c> if my turn; otherwise, <c>false</c>.</value>
	bool MyTurn {
		set;
	}

	Piece.PieceColor Color {
		get;
	}

	/// <summary>
	/// Makes a draw.
	/// </summary>
	/// <returns><c>true</c>, if draw was made, <c>false</c> otherwise.</returns>
	/// <param name="fromRow">From row.</param>
	/// <param name="fromCol">From col.</param>
	/// <param name="toRow">To row.</param>
	/// <param name="toCol">To col.</param>
	bool makeDraw(int fromRow, int fromCol, int toRow, int toCol);

	/// <summary>
	/// Updates the board state.
	/// </summary>
	/// <param name="board">Board.</param>
	void updateBoard(Piece[,] board);
}
