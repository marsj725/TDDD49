using System;

public class King : Piece {

	public King(PieceColor color, int x, int y) : base(PieceType.KING, color, x, y) {
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

		if((Math.Abs(fromRow - toRow) <= 1) && (Math.Abs(fromCol - toCol) <= 1)) {
			return true;
		}
		return false;
	}

	/// <summary>
	/// Returns the possible moves of this piece.
	/// </summary>
	/// <returns>The possible moves.</returns>
	/// <param name="color">Color.</param>
	/// <param name="board">Board.</param>
	public override C5.ArrayList<Tuple<int, int>> getPossibleMoves(Board board) {
		C5.ArrayList<Tuple<int, int>> result = new C5.ArrayList<Tuple<int, int>>();

		for(int i = -1; i <= 1; i++) {
			for(int j = -1; j <= 1; j++) {
				if(!(i == 0 && j == 0) && this.Row + i <= 7 && this.Col + j <= 7 && this.Row + i >= 0 && this.Col + j >= 0) {
					if(board.BoardGrid[this.Row + i, this.Col + j].getColor() != this.getColor())
						result.Add(new Tuple<int, int>(this.Row + i, this.Col + j));
				}
			}
		}

		return result;
	}
}