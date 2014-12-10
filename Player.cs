using System;

/// <summary>
/// A chess player.
/// </summary>
public abstract class Player {

	private Board.PieceColor color;
	protected Mediator mediator;

	public Board.PieceColor Color {
		get {
			return color;
		} 
		private set {
			color = value;
		}
	}

	public Player(Mediator mediator) {
		this.mediator = mediator;
	}

	/// <summary>
	/// Makes a draw.
	/// </summary>
	/// <returns><c>true</c>, if draw was made, <c>false</c> otherwise.</returns>
	/// <param name="fromRow">From row.</param>
	/// <param name="fromCol">From col.</param>
	/// <param name="toRow">To row.</param>
	/// <param name="toCol">To col.</param>
	public abstract bool makeDraw(int fromRow, int fromCol, int toRow, int toCol);

	/// <summary>
	/// Updates the board state.
	/// </summary>
	/// <param name="board">Board.</param>
	public abstract void updateBoard(Piece[,] board);
}
