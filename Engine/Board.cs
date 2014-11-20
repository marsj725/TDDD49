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
		this.board[0, 0] = new Rook(Piece.PieceColor.BLACK, 0, 0);
		this.board[0, 7] = new Rook(Piece.PieceColor.BLACK, 0, 7);
		this.board[0, 1] = new Knight(Piece.PieceColor.BLACK, 0, 1);
		this.board[0, 6] = new Knight(Piece.PieceColor.BLACK, 0, 6);
		this.board[0, 2] = new Bishop(Piece.PieceColor.BLACK, 0, 2);
		this.board[0, 5] = new Bishop(Piece.PieceColor.BLACK, 0, 5);
		this.board[0, 3] = new Queen(Piece.PieceColor.BLACK, 0, 3);
		this.board[0, 4] = new King(Piece.PieceColor.BLACK, 0, 4);

		// Sets the positions of the pawns.
		for(int i = 0; i < 8; i++) {
			this.board[1, i] = new Pawn(Piece.PieceColor.BLACK, 1, i);
			this.board[6, i] = new Pawn(Piece.PieceColor.WHITE, 1, i);
		}

		this.board[7, 0] = new Rook(Piece.PieceColor.WHITE, 7, 0);
		this.board[7, 7] = new Rook(Piece.PieceColor.WHITE, 7, 7); 
		this.board[7, 1] = new Knight(Piece.PieceColor.WHITE, 7, 1);
		this.board[7, 6] = new Knight(Piece.PieceColor.WHITE, 7, 6); 
		this.board[7, 2] = new Bishop(Piece.PieceColor.WHITE, 7, 5);
		this.board[7, 5] = new Bishop(Piece.PieceColor.WHITE, 7, 5); 
		this.board[7, 3] = new Queen(Piece.PieceColor.WHITE, 7, 3);
		this.board[7, 4] = new King(Piece.PieceColor.WHITE, 7, 3);
	}

}