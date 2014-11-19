using System;

/// <summary>
/// Mediator pattern between the players and the chess engine, 
/// to make it possible for them communicate with each other. 
/// Player1, Player2 and Engine is suppose to be initialized 
/// in the mediator in their constructors. 
/// </summary>
public class Mediator {

	private Player Player1;
	private Player Player2;

	public Engine Engine {
		get {
			return this.Engine;
		}
		set {
			Engine = value;
		}
	}

	/// <summary>
	/// A player makes a move.
	/// </summary>
	/// <returns><c>true</c>, if draw was made, <c>false</c> otherwise.</returns>
	/// <param name="color">Color.</param>
	/// <param name="fromRow">From row.</param>
	/// <param name="fromCol">From col.</param>
	/// <param name="toRow">To row.</param>
	/// <param name="toCol">To col.</param>
	public bool makeDraw(Piece.PieceColor color, int fromRow, int fromCol, int toRow, int toCol) {
		return this.Engine.performDraw(color, fromRow, fromCol, toRow, toCol); 
	}

	/// <summary>
	/// The players are informed of a change in the board.
	/// </summary>
	/// <param name="board">Board.</param>
	public void updateBoard(Piece[,] board) {
		Player1.updateBoard(board);
		Player2.updateBoard(board);
	}

	/// <summary>
	/// A player registers itself in the mediator. 
	/// </summary>
	/// <returns><c>true</c>, if player was registered, <c>false</c> otherwise.</returns>
	/// <param name="player">Player.</param>
	public bool registerPlayer(Player player) {
		if(this.Player1 != null) {
			this.Player1 = player;
			return true;
		} else if(this.Player2 != null) {
			this.Player2 = player;
			return true;
		}
		return false;
	}

}
