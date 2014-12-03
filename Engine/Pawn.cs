using System;

public class Pawn : Piece {

	public Pawn(PieceColor color, int x, int y) : base(PieceType.PAWN, color, x, y) {
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
		//Vi måste implementera något som berättar vilken direction vi spelar
		//Firstmove (Special)
		if(fromRow == 7 || fromRow == 1) {
			if(Math.Abs(fromRow - toRow) > 0 && Math.Abs(fromRow - toRow) <= 2) { 
				return true;
			} else {
				return false;
			}
			//Hortizontal movement
		} else if(Math.Abs(fromRow - toRow) == 1) {
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

		if(this.getColor() == PieceColor.WHITE && this.Row == 6) {
			if(board.BoardGrid[this.Row - 2, this.Col].getColor() == PieceColor.NONE)
				result.Add(new Tuple<int, int>(this.Row - 2, this.Col));
		} else if(this.getColor() == PieceColor.BLACK && this.Row == 1) {
			if(board.BoardGrid[this.Row + 2, this.Col].getColor() == PieceColor.NONE)
				result.Add(new Tuple<int, int>(this.Row + 2, this.Col));
		}

		if(this.getColor() == PieceColor.WHITE) {
			if(this.Row != 0) {
				if(board.BoardGrid[this.Row - 1, this.Col].getColor() == PieceColor.NONE)
					result.Add(new Tuple<int, int>(this.Row - 1, this.Col));
				if(this.Col != 7 && board.BoardGrid[this.Row - 1, this.Col + 1].getColor() == PieceColor.BLACK)
					result.Add(new Tuple<int, int>(this.Row - 1, this.Col + 1));
				if(this.Col != 0 && board.BoardGrid[this.Row - 1, this.Col - 1].getColor() == PieceColor.BLACK)
					result.Add(new Tuple<int, int>(this.Row - 1, this.Col - 1));
			}
		} else {
			if(this.Row != 7) {
				if(board.BoardGrid[this.Row + 1, this.Col].getColor() == PieceColor.NONE)
					result.Add(new Tuple<int, int>(this.Row + 1, this.Col));
				if(this.Col != 7 && board.BoardGrid[this.Row + 1, this.Col + 1].getColor() == PieceColor.WHITE)
					result.Add(new Tuple<int, int>(this.Row + 1, this.Col + 1));
				if(this.Col != 0 && board.BoardGrid[this.Row + 1, this.Col - 1].getColor() == PieceColor.WHITE)
					result.Add(new Tuple<int, int>(this.Row + 1, this.Col - 1));
			}
		}

		return result;
	}
}