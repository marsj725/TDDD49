using System;
using System.Windows.Forms;

/// <summary>
/// Creates a PictureBox which includes a board position since it is intended to be used on a chess board, or any grid.
/// </summary>
namespace BoardGUI {
	public class BoardPositionGUI : PictureBox {

		private int row;
		private int column;

		/// <summary>
		/// Initializes a new instance of the <see cref="BoardGUI.BoardPositionGUI"/> class.
		/// </summary>
		/// <param name="row">Row. On which row on the grid the PictureBox is on.</param>
		/// <param name="column">Column. On which column on the grid the picturebox is.</param>
		public BoardPositionGUI(int row, int column) : base() {
			this.row = row;
			this.column = column;
			this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chessPositionMouseClick);
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

	}
}