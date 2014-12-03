using System;

public class Knight : Piece {

	public Knight(PieceColor color, int x, int y) : base(PieceType.KNIGHT, color, x, y) {
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
		if(fromRow - toRow == 0 && fromCol - toCol == 0)
			return false;
		if(Math.Abs(fromRow - toRow) == 2 && Math.Abs(fromCol - toCol) == 1)
			return true;
		else if(Math.Abs(fromCol - toCol) == 2 && Math.Abs(fromRow - toRow) == 1)
			return true;
		return false;
	}

	public override C5.ArrayList<Tuple<int, int>> getPossibleMoves(PieceColor color, Board board) {
		throw new NotImplementedException();
	}
}

