using System;

public class Pawn : Piece {

	public Pawn(Board.PieceColor color, int x, int y) : base(PieceType.PAWN, color, x, y) {
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
			
		bool firstMove = false;
		// If the vertival movement is correct
		bool verticalCheck = false;
		// If the user wants to move two steps
		bool twoSteps = false;
		bool horisontalCheck = false;
		int direction;

		if(getColor() == Board.PieceColor.BLACK)
			direction = -1;
		else
			direction = 1;

		// First move if on these rows.
		if(fromRow == 6 || fromRow == 1)
			firstMove = true;
			
		if(firstMove) {
			if(fromRow - toRow == 2 * direction || fromRow - toRow == 1 * direction) {
				verticalCheck = true;
			}
			if(fromRow - toRow == 2 * direction) {
				firstMove = true;
			}
		} else {
			if(fromRow - toRow == 1 * direction) {
				verticalCheck = true;
			}
		}

		if(fromCol - toCol == 0) {
			if(board.BoardGrid[toRow, toCol].getColor() == Board.PieceColor.NONE)
				horisontalCheck = true;
		} else if(Math.Abs(fromCol - toCol) == 1) {
			if(board.BoardGrid[toRow, toCol].getColor() == this.getOppositeColor() && !twoSteps) {
				horisontalCheck = true;
			}
		}

		if(horisontalCheck && verticalCheck)
			return true;
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

		if(this.getColor() == Board.PieceColor.WHITE && this.Row == 6) {
			if(board.BoardGrid[this.Row - 2, this.Col].getColor() == Board.PieceColor.NONE)
				result.Add(new Tuple<int, int>(this.Row - 2, this.Col));
		} else if(this.getColor() == Board.PieceColor.BLACK && this.Row == 1) {
			if(board.BoardGrid[this.Row + 2, this.Col].getColor() == Board.PieceColor.NONE)
				result.Add(new Tuple<int, int>(this.Row + 2, this.Col));
		}

		if(this.getColor() == Board.PieceColor.WHITE) {
			if(this.Row != 0) {
				if(board.BoardGrid[this.Row - 1, this.Col].getColor() == Board.PieceColor.NONE)
					result.Add(new Tuple<int, int>(this.Row - 1, this.Col));
				if(this.Col != 7 && board.BoardGrid[this.Row - 1, this.Col + 1].getColor() == Board.PieceColor.BLACK)
					result.Add(new Tuple<int, int>(this.Row - 1, this.Col + 1));
				if(this.Col != 0 && board.BoardGrid[this.Row - 1, this.Col - 1].getColor() == Board.PieceColor.BLACK)
					result.Add(new Tuple<int, int>(this.Row - 1, this.Col - 1));
			}
		} else {
			if(this.Row != 7) {
				if(board.BoardGrid[this.Row + 1, this.Col].getColor() == Board.PieceColor.NONE)
					result.Add(new Tuple<int, int>(this.Row + 1, this.Col));
				if(this.Col != 7 && board.BoardGrid[this.Row + 1, this.Col + 1].getColor() == Board.PieceColor.WHITE)
					result.Add(new Tuple<int, int>(this.Row + 1, this.Col + 1));
				if(this.Col != 0 && board.BoardGrid[this.Row + 1, this.Col - 1].getColor() == Board.PieceColor.WHITE)
					result.Add(new Tuple<int, int>(this.Row + 1, this.Col - 1));
			}
		}

		return result;
	}
}