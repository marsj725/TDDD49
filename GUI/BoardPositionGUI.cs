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

		private Board.PieceColor pieceColor;
		private System.Drawing.Color positionColor;

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

			// If the background is green already (it is chosen), it is unnecessary to do anything
			if(this.BackColor == System.Drawing.Color.Green)
				return;

			// Save the original color so that it is possible to reset it
			this.positionColor = this.BackColor;

			// Get the board this position belongs to
			BoardGUI parent = (BoardGUI)this.Parent;

			// Set as chosen as long as the piece is the same color as the user.
			if(parent.Color == this.pieceColor)
				parent.setChosen(row, column);
			// Make a draw another piece is already chosen
			else if(parent.positionChosen) {
				parent.makeDraw(parent.positionChosenX, parent.positionChosenY, row, column);
				parent.resetChosen();
			}
				
		}

		/// <summary>
		/// Resets the background color.
		/// </summary>
		public void resetChosen() {
			this.BackColor = positionColor;
		}

		/// <summary>
		/// Sets the piece to render in the picturebox.
		/// </summary>
		/// <param name="piece">Piece.</param>
		public void setPiece(Piece piece) {

			this.pieceColor = piece.getColor();

			if(piece.getType() == Piece.PieceType.NONE) {
				this.Image = null;
				return;
			}
			Console.WriteLine("Adding piece");
			if(piece.getColor() == Board.PieceColor.WHITE) {
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