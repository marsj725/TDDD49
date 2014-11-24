using System;
using System.Drawing;
using System.Windows.Forms;

/// <summary>
/// Creates a PictureBox which includes a board position since it is intended to be used on a chess board, or any grid.
/// </summary>
namespace Window {
	public class BoardPositionGUI : PictureBox {

		private int row;
		private int column;

		public enum Pieces {
			NONE,
			PAWN_WHITE,
			PAWN_BLACK,
			HORSE_WHITE,
			HORSE_BLACK,
			ROOK_WHITE,
			ROOK_BLACK,
			BISHOP_WHITE,
			BISHOP_BLACK,
			KING_WHITE,
			KING_BLACK,
			QUEEN_WHITE,
			QUEEN_BLACK}

		;

		/// <summary>
		/// Initializes a new instance of the <see cref="BoardGUI.BoardPositionGUI"/> class.
		/// </summary>
		/// <param name="row">Row. On which row on the grid the PictureBox is on.</param>
		/// <param name="column">Column. On which column on the grid the picturebox is.</param>
		public BoardPositionGUI(int row, int column) : base() {
			this.row = row;
			this.column = column;
			this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chessPositionMouseClick);
			this.Margin = new Padding(0, 0, 0, 0);
			// For testing purposes --- and it still is :)
			Pieces[,] temp = new Pieces[8, 8];
			temp[7, 0] = Pieces.ROOK_WHITE;
			temp[7, 7] = Pieces.ROOK_WHITE;
			temp[7, 6] = Pieces.HORSE_WHITE;
			temp[7, 1] = Pieces.HORSE_WHITE;
			temp[7, 2] = Pieces.BISHOP_WHITE;
			temp[7, 5] = Pieces.BISHOP_WHITE;
			temp[7, 4] = Pieces.QUEEN_WHITE;
			temp[7, 3] = Pieces.KING_WHITE;
			
			temp[6, 0] = Pieces.PAWN_WHITE;
			temp[6, 1] = Pieces.PAWN_WHITE;
			temp[6, 2] = Pieces.PAWN_WHITE;
			temp[6, 3] = Pieces.PAWN_WHITE;
			temp[6, 4] = Pieces.PAWN_WHITE;
			temp[6, 5] = Pieces.PAWN_WHITE;
			temp[6, 6] = Pieces.PAWN_WHITE;
			temp[6, 7] = Pieces.PAWN_WHITE;
			setPiece(temp[row, column]);
		}

		public int getRow() {
			return row;
		}

		public int getColumn() {
			return column;
		}

		/// <summary>
		/// Listener for mouseclick events.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		private void chessPositionMouseClick(object sender, System.EventArgs e) {
			// Write code for what is going to happen when a position on the board is clicked on.

			System.Console.WriteLine("Clicked on position: " + ((BoardPositionGUI)sender).getRow() + ((BoardPositionGUI)sender).getColumn());
		}

		/// <summary>
		/// Sets the piece to render in the picturebox.
		/// </summary>
		/// <param name="piece">Piece.</param>
		public void setPiece(Piece piece) {
			if(piece.getType() == Piece.PieceType.NONE)
				this.Image = null;
			else if(piece.getColor() == Piece.PieceColor.WHITE) {

				if(piece.getType() == Piece.PieceType.PAWN)
					this.ImageLocation = "Assets/pawn_white.png";
				else if(piece.getType() == Piece.PieceType.KNIGHT)
					this.ImageLocation = "Assets/horse_white.png";
				else if(piece.getType() == Piece.PieceType.BISHOP)
					this.ImageLocation = "Assets/bishop_white.png";
				else if(piece.getType() == Piece.PieceType.ROOK)
					this.ImageLocation = "Assets/rook_white.png";
				else if(piece.getType() == Piece.PieceType.KING)
					this.ImageLocation = "Assets/king_white.png";
				else
					this.ImageLocation = "Assets/queen_white.png";

			} else {

				if(piece.getType() == Piece.PieceType.PAWN)
					this.ImageLocation = "Assets/pawn_black.png";
				else if(piece.getType() == Piece.PieceType.KNIGHT)
					this.ImageLocation = "Assets/horse_black.png";
				else if(piece.getType() == Piece.PieceType.BISHOP)
					this.ImageLocation = "Assets/bishop_black.png";
				else if(piece.getType() == Piece.PieceType.ROOK)
					this.ImageLocation = "Assets/rook_black.png";
				else if(piece.getType() == Piece.PieceType.KING)
					this.ImageLocation = "Assets/king_black.png";
				else
					this.ImageLocation = "Assets/queen_black.png";

			}

		}

	}
}