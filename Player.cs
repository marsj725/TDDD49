using System;

/// <summary>
/// A chess player.
/// </summary>
public abstract class Player {

	private bool myTurn;
	private Board.PieceColor color;
	protected Mediator mediator;

	/// <summary>
	/// Sets a value indicating whether it is the <see cref="Player"/>s turn in the game.
	/// </summary>
	/// <value><c>true</c> if my turn; otherwise, <c>false</c>.</value>
	protected bool MyTurn {
		get {
			return myTurn;
		}
		set {
			setTurn(value);
		}
	}

	protected abstract void setTurn(bool value);

	protected Board.PieceColor Color {
		get {
			return color;
		} 
		private set {
			color = value;
		}
	}

	public Player(Mediator mediator) {
		MyTurn = false;
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
	protected abstract bool makeDraw(int fromRow, int fromCol, int toRow, int toCol);

	abstract bool initializeEngine(Engine engine);

	/// <summary>
	/// Updates the board state.
	/// </summary>
	/// <param name="board">Board.</param>
	abstract void updateBoard(Piece[,] board);
}
