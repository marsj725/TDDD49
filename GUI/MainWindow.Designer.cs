using System;

namespace Window {

	partial class MainWindow {

		private System.ComponentModel.IContainer components = null;

		private const int WINDOW_SIZE_WIDTH = 900;
		private const int WINDOW_SIZE_HEIGHT = 512;

		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		/// <summary>
		/// Initializes the component.
		/// </summary>
		private void InitializeComponent() {

			Icon = new System.Drawing.Icon("icon.ico");

			BoardGUI board = new BoardGUI();
			ChessDrawDisplay chessDrawDisplay = new ChessDrawDisplay();

			this.SuspendLayout();

			this.ClientSize = new System.Drawing.Size(WINDOW_SIZE_WIDTH, WINDOW_SIZE_HEIGHT);
			this.Controls.Add(board);
			this.Controls.Add(chessDrawDisplay);
			chessDrawDisplay.Location = new System.Drawing.Point(board.Width, 0);
			chessDrawDisplay.Size = new System.Drawing.Size(this.Size.Width - board.Width, board.Height);
			this.Name = "Chess";
			this.Text = "Chess";
			this.Resize += new System.EventHandler(OnResize);

			this.ResumeLayout(false);
		}

		/// <summary>
		/// Listener handeling window resizes, makes sure it's always in a square shape.
		/// </summary>
		private void OnResize(object sender, EventArgs a) {
			if(this.Size.Width > this.Size.Height) {
				this.Size = new System.Drawing.Size(this.Size.Width, this.Size.Width);
			} else {
				this.Size = new System.Drawing.Size(this.Size.Height, this.Size.Height);
			}
		}

	}
}