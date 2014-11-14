using System;

public class Board {

	private Piece[,] board;

	public const int ROWS = 8;
	public const int COLUMNS = 8;

	public Board() {
		this.board = new Piece[ROWS, COLUMNS];
		this.resetBoard();
	}

	/// <summary>
	/// Resets the board pieces to its initial positions.
	/// </summary>
	public void resetBoard() {
		this.board[0, 0] = this.board[0, 7] = new Rook(Piece.PieceColor.BLACK);
		this.board[0, 1] = this.board[0, 6] = new Knight(Piece.PieceColor.BLACK);
		this.board[0, 2] = this.board[0, 5] = new Bishop(Piece.PieceColor.BLACK);
		this.board[0, 3] = new Queen(Piece.PieceColor.BLACK);
		this.board[0, 4] = new King(Piece.PieceColor.BLACK);

		// Sets the positions of the pawns.
		for(int i = 0; i < 8; i++) {
			this.board[1, i] = new Pawn(Piece.PieceColor.BLACK);
			this.board[6, i] = new Pawn(Piece.PieceColor.WHITE);
		}

		this.board[7, 0] = this.board[7, 7] = new Rook(Piece.PieceColor.BLACK);
		this.board[7, 1] = this.board[7, 6] = new Knight(Piece.PieceColor.BLACK);
		this.board[7, 2] = this.board[7, 5] = new Bishop(Piece.PieceColor.BLACK);
		this.board[7, 3] = new Queen(Piece.PieceColor.BLACK);
		this.board[7, 4] = new King(Piece.PieceColor.BLACK);
	}

}