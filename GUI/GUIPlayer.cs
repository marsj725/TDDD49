using System;

public class GUIPlayer : Player {

	public GUIPlayer(Piece.PieceColor color) : base(color) {

	}

	/// <summary>
	/// Makes a draw.
	/// </summary>
	/// <returns>true</returns>
	/// <c>false</c>
	/// <param name="fromRow">From row.</param>
	/// <param name="fromCol">From col.</param>
	/// <param name="toRow">To row.</param>
	/// <param name="toCol">To col.</param>
	protected override bool makeDraw(int fromRow, int fromCol, int toRow, int toCol) {
		throw new NotImplementedException();
	}

	/// <summary>
	/// Updates the board state.
	/// </summary>
	/// <param name="board">Board.</param>
	public override void updateBoard(Piece[,] board) {
		throw new NotImplementedException();
	}

}

