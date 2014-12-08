using System;

public class Queen : Piece {
	public Queen(Board.PieceColor color,int x, int y) : base(PieceType.QUEEN, color, x ,y) {
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
				if(board.BoardGrid[fromRow + i * directionY, fromCol + i * directionX].getColor() != PieceColor.NONE)
					return false;
			}
			return true;
		}
		// Vertical movement
		if(fromCol - toCol == 0) {
			for(int i = 1; i < Math.Abs(fromRow - toRow); i++) {
				if(board.BoardGrid[fromRow + i * directionY, fromCol].getColor() != PieceColor.NONE)
					return false;
			}
			return true;
		}
		// Horisontal movement
		if(fromRow - toRow == 0) {
			for(int i = 1; i < Math.Abs(fromCol - toCol); i++) {
				if(board.BoardGrid[fromRow, fromCol + i * directionX].getColor() != PieceColor.NONE)
					return false;
			}
			return true;
		}
		return false;
	}
}