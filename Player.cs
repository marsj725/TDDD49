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

	/// <summary>
	/// Called to inform the player that it is his/her turn.
	/// </summary>
	public abstract void turnChanged();

	public Player(Mediator mediator, Board.PieceColor color) {
		mediator.registerPlayer(this);
		this.mediator = mediator;
		Color = color;
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
}