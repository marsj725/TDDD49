using System;

public class Bishop : Piece {

	public Bishop(Board.PieceColor color, int x, int y) : base(Board.PieceType.BISHOP, color, x, y) {
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
	/// 

	//Checks that the change in rows is the same as the change in cols
	public override bool isMoveLegal(Board board, int fromRow, int fromCol, int toRow, int toCol) {

		if(fromRow - toRow == 0 && fromCol - toCol == 0)
			return false;

		// The direction to iterate below. (The direction of the move).
		int directionX;
		int directionY;

		if(fromRow < toRow)
			directionY = 1;
		else
			directionY = -1;

		if(fromCol < toCol)
			directionX = 1;
		else
			directionX = -1;

		// Check if there are any pieces in between.

		// Diagonal movement
		if(Math.Abs(fromRow - toRow) == Math.Abs(fromCol - toCol)) {
			for(int i = 1; i < Math.Abs(fromRow - toRow); i++) {
				if(board.BoardGrid[fromRow + i * directionY, fromCol + i * directionX].Color != Board.PieceColor.NONE)
					return false;
			}
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

		possibleDrawsDiagonally(board, ref result, 1, 1);
		possibleDrawsDiagonally(board, ref result, 1, -1);
		possibleDrawsDiagonally(board, ref result, -1, 1);
		possibleDrawsDiagonally(board, ref result, -1, -1);

		return result;
	}

}