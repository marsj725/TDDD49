using System;
using System.Drawing;
using System.Windows.Forms;

/// <summary>
/// Creates a PictureBox which includes a board position since it is intended to be used on a chess board, or any grid.
/// </summary>
namespace BoardGUI {
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
			// For testing purposes
			setPiece(Pieces.BISHOP_WHITE);
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
		public void setPiece(Pieces piece) {
			switch(piece) {
			case (Pieces.NONE):
				this.Image = null;
				break;
			case (Pieces.PAWN_WHITE):
				this.ImageLocation = "Assets/pawn_white.png";
				break;
			case (Pieces.PAWN_BLACK):
				this.ImageLocation = "Assets/pawn_black.png";
				break;
			case (Pieces.HORSE_WHITE): 
				this.ImageLocation = "Assets/horse_white.png";
				break;
			case (Pieces.HORSE_BLACK): 
				this.ImageLocation = "Assets/horse_black.png";
				break;
			case (Pieces.ROOK_WHITE): 
				this.ImageLocation = "Assets/rook_white.png";
				break;
			case (Pieces.ROOK_BLACK): 
				this.ImageLocation = "Assets/rook_black.png";
				break;
			case (Pieces.BISHOP_WHITE): 
				this.ImageLocation = "Assets/bishop_white.png";
				break;
			case (Pieces.BISHOP_BLACK): 
				this.ImageLocation = "Assets/bishop_black.png";
				break;
			case (Pieces.KING_WHITE): 
				this.ImageLocation = "Assets/king_white.png";
				break;
			case (Pieces.KING_BLACK): 
				this.ImageLocation = "Assets/king_black.png";
				break;
			case (Pieces.QUEEN_WHITE): 
				this.ImageLocation = "Assets/queen_white.png";
				break;
			case (Pieces.QUEEN_BLACK): 
				this.ImageLocation = "Assets/queen_black.png";
				break;
			}
		}

	}
}