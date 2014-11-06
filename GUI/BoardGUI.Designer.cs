using System;
namespace BoardGUI {
	partial class BoardGUI {

		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.TableLayoutPanel board;
		private BoardPositionGUI[,] chessPositions;

		private const int WINDOW_SIZE_WIDTH = 240;
		private const int WINDOW_SIZE_HEIGHT = 240;

		private const int BOARD_COLUMNS = 8;
		private const int BOARD_ROWS = 8;
		private const int BOARD_SIZE_WIDTH = 240;
		private const int BOARD_SIZE_HEIGHT = 240;

		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		/// <summary>
		/// Initializes the component.
		/// </summary>
		private void InitializeComponent ()
		{

			Icon = new System.Drawing.Icon ("icon.ico");

			this.board = new System.Windows.Forms.TableLayoutPanel ();
			this.chessPositions = new BoardPositionGUI[BOARD_ROWS, BOARD_COLUMNS];

			//int WINDOWS_CURRENT_SIZE = this.board.ClientSize.Height;
			

			// Initializes all the positions on the board.
			for (int i = 0; i < this.chessPositions.GetLength(0); i++) {
				for (int j = 0; j < this.chessPositions.GetLength(1); j++) {
					this.chessPositions [i, j] = new BoardPositionGUI (j, i);
				}
			}

			this.board.SuspendLayout ();

			foreach (BoardPositionGUI position in this.chessPositions) {
				((System.ComponentModel.ISupportInitialize)(position)).BeginInit ();
			}

			this.SuspendLayout ();

			// Sets the number of columns on the board and sets its size to be 1/8 of the board width. 
			this.board.ColumnCount = BOARD_COLUMNS;
			float percentage = 100 / BOARD_COLUMNS;

			// Adds colums to the playerfield
			for (int i = 0; i < BOARD_COLUMNS; i++) {
				this.board.ColumnStyles.Add (new System.Windows.Forms.ColumnStyle (System.Windows.Forms.SizeType.Percent, percentage));
			}

			// Adds all the chess positions to the board.
			for (int i = 0; i < this.chessPositions.GetLength(0); i++) {
				for (int j = 0; j < this.chessPositions.GetLength(1); j++) {
					this.board.Controls.Add (this.chessPositions [i, j], i, j);
				}
			}

			this.board.Location = new System.Drawing.Point (0, 0);
			this.board.Name = "Board";
			this.board.RowCount = BOARD_ROWS;
			percentage = 100 / BOARD_ROWS;

			// Adds rows to the playerfield
			for (int i = 0; i < BOARD_ROWS; i++) {
				this.board.RowStyles.Add (new System.Windows.Forms.RowStyle (System.Windows.Forms.SizeType.Percent, percentage));
			}
			this.board.Size = new System.Drawing.Size(BOARD_SIZE_WIDTH, BOARD_SIZE_HEIGHT);

			// Sets the size and location of the chess positions.
			this.drawBoard(this.board.Width,this.board.Height);
				
			this.ClientSize = new System.Drawing.Size(WINDOW_SIZE_WIDTH, WINDOW_SIZE_HEIGHT);
			this.Controls.Add(this.board);
			this.Name = "Chess";
			this.Text = "Chess";
			this.Resize += new System.EventHandler(OnResize);
			this.board.ResumeLayout(false);

			// Signals the chess positions that initialization is complete.
			foreach(BoardPositionGUI position in this.chessPositions) {
				((System.ComponentModel.ISupportInitialize)(position)).EndInit();
			}

			// Sets the colors on the Board to black and white.
			for(int i = 0; i < this.chessPositions.GetLength(0); i++) {
				for(int j = 0; j < this.chessPositions.GetLength(1); j++) {
					if(i % 2 == 0) {
						if(j % 2 == 0)
							this.chessPositions[i, j].BackColor = System.Drawing.Color.Black;
						else
							this.chessPositions[i, j].BackColor = System.Drawing.Color.White;
					} else {
						if(j % 2 == 1)
							this.chessPositions[i, j].BackColor = System.Drawing.Color.Black;
						else
							this.chessPositions[i, j].BackColor = System.Drawing.Color.White;
					}
				}
			}



			// Adds a mouse click event for each PictureBox on the board.
			foreach(BoardPositionGUI position in chessPositions) {
				position.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chessPositionMouseClick);
			}

			this.ResumeLayout(false);
		}

		// Sets the size and location of the chess positions.
		private void drawBoard (int WIDTH, int HEIGHT)
		{
			for(int i = 0; i < this.chessPositions.GetLength(0); i++) {
				for(int j = 0; j < this.chessPositions.GetLength(1); j++) {
					this.chessPositions[i, j].Location = new System.Drawing.Point(i * WIDTH / BOARD_ROWS, j * HEIGHT / BOARD_COLUMNS);
					this.chessPositions[i, j].Size = new System.Drawing.Size(WIDTH / BOARD_ROWS, HEIGHT / BOARD_COLUMNS);
				}
			}
		}

		//Listener handeling window resizes, makes sure it's always in a square shape.
		private void OnResize (object sender, EventArgs a)
		{
			if(this.Size.Width>this.Size.Height){
				this.Size = new System.Drawing.Size(this.Size.Width,this.Size.Width);
			}else{
				this.Size = new System.Drawing.Size(this.Size.Height,this.Size.Height);
			}
		}

		private void chessPositionMouseClick(object sender, System.EventArgs e) {
			// Write code for what is going to happen when a position on the board is clicked on.

			System.Console.WriteLine("Clicked on position: " + ((BoardPositionGUI)sender).getRow() + ((BoardPositionGUI)sender).getColumn());
		}
	}
}

