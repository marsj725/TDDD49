using System;

public class Rook : Piece {

	public Rook(PieceColor color, int x, int y) : base(PieceType.ROOK, color, x, y) {
	}

	/// <summary>
	/// Is the move legal for this piece.
	/// </summary>
	/// <returns>true</returns>
	/// <c>false</c>
	/// <param name="fromRow">From row.</param>
	/// <param name="fromColumn">From column.</param>
	/// <param name="toRow">To row.</param>
	/// <param name="toCol">To col.</param>
	public override bool isMoveLegal(int fromRow, int fromCol, int toRow, int toCol) {
		if((fromRow - toRow == 0) && (Math.Abs(fromCol - toCol) > 0))
			return true;
		else if((fromCol - toCol == 0) && (Math.Abs(fromRow - toRow) > 0)) {
			return true;
		} else {
			return false;
		}
	}

	/// <summary>
	/// Returns the possible moves of this piece.
	/// </summary>
	/// <returns>The possible moves.</returns>
	/// <param name="color">Color.</param>
	/// <param name="board">Board.</param>
	public override C5.ArrayList<Tuple<int, int>> getPossibleMoves(Board board) {
		C5.ArrayList<Tuple<int, int>> result = new C5.ArrayList<Tuple<int, int>>();

		possibleMovesHorisontallyAndVertically(ref result, board);

		return result;
	}

}