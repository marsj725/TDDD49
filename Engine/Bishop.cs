using System;
using C5;

public class Bishop : Piece {

	public Bishop(PieceColor color, int x, int y) : base(PieceType.BISHOP, color, x, y) {
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
	public override bool isMoveLegal(int fromRow, int fromCol, int toRow, int toCol) {
		if(Math.Abs(fromRow - toRow) == Math.Abs(fromCol - toCol)) {
			return true;
		} else {
			return false;
		}
	}

	public override ArrayList<Tuple<int, int>> getPossibleMoves(Piece.PieceColor color, Board board) {

		ArrayList<Tuple<int, int>> result = new ArrayList<Tuple<int, int>>();

		possibleDrawsInDirection(board, ref result, 1, 1);
		possibleDrawsInDirection(board, ref result, 1, -1);
		possibleDrawsInDirection(board, ref result, -1, 1);
		possibleDrawsInDirection(board, ref result, -1, -1);

		return result;
	}

	private void possibleDrawsInDirection(Board board, ref ArrayList<Tuple<int, int>> result, int directionX, int directionY) {
		int boardLimitX;
		int boardLimitY;

		if(directionX < 0)
			boardLimitX = 0;
		else
			boardLimitX = 7;

		if(directionY < 0)
			boardLimitY = 0;
		else
			boardLimitY = 7;

		for(int i = 1; directionY * (this.Row + i * directionY) <= directionY * boardLimitY && directionX * (this.Col + i * directionX) <= directionX * boardLimitX; i++) {
			Piece.PieceColor color = board.BoardGrid[this.Row + i * directionY, this.Col + i * directionX].getColor();
			System.Console.WriteLine(this.Row + i * directionY + " " + this.Col + i * directionX);
			if(color == PieceColor.NONE) {
				result.Add(new Tuple<int, int>(this.Row + i * directionY, this.Col + i * directionX));
			} else if(color != this.getColor()) {
				result.Add(new Tuple<int, int>(this.Row + i * directionY, this.Col + i * directionX));
				return;
			} else {
				return;
			}
		}
	}
}