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
		private void InitializeComponent() {

			Icon = new System.Drawing.Icon("icon.ico");

			this.board = new System.Windows.Forms.TableLayoutPanel();
			this.chessPositions = new BoardPositionGUI[BOARD_ROWS, BOARD_COLUMNS];

			//int WINDOWS_CURRENT_SIZE = this.board.ClientSize.Height;
			

			// Initializes all the positions on the board.
			InitializeBoardPositions();

			this.board.SuspendLayout();

			foreach(BoardPositionGUI position in this.chessPositions) {
				((System.ComponentModel.ISupportInitialize)(position)).BeginInit();
			}

			this.SuspendLayout();

			AddChessPositionsToBoard();

			SetBoardDimensions(BOARD_ROWS, BOARD_COLUMNS);

			this.board.Location = new System.Drawing.Point(0, 0);
			this.board.Name = "Board";

			this.board.Size = new System.Drawing.Size(BOARD_SIZE_WIDTH, BOARD_SIZE_HEIGHT);

			// Sets the size and location of the chess positions.
			this.drawBoard(this.board.Width, this.board.Height);
				
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
			SetBoardColors();

			// Adds a mouse click event for each PictureBox on the board.
			foreach(BoardPositionGUI position in chessPositions) {
			}

			this.ResumeLayout(false);
		}

		/// <summary>
		/// Sets the size and location of the chess positions.
		/// </summary>
		private void drawBoard(int WIDTH, int HEIGHT) {
			for(int i = 0; i < this.chessPositions.GetLength(0); i++) {
				for(int j = 0; j < this.chessPositions.GetLength(1); j++) {
					this.chessPositions[i, j].Location = new System.Drawing.Point(i * WIDTH / BOARD_ROWS, j * HEIGHT / BOARD_COLUMNS);
					this.chessPositions[i, j].Size = new System.Drawing.Size(WIDTH / BOARD_ROWS, HEIGHT / BOARD_COLUMNS);
				}
			}
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

		/// <summary>
		/// Initializes the board positions.
		/// </summary>
		private void InitializeBoardPositions() {
			for(int i = 0; i < this.chessPositions.GetLength(0); i++) {
				for(int j = 0; j < this.chessPositions.GetLength(1); j++) {
					this.chessPositions[i, j] = new BoardPositionGUI(j, i);
				}
			}
		}

		/// <summary>
		/// Adds the chess positions to board.
		/// </summary>
		private void AddChessPositionsToBoard() {
			for(int i = 0; i < this.chessPositions.GetLength(0); i++) {
				for(int j = 0; j < this.chessPositions.GetLength(1); j++) {
					this.board.Controls.Add(this.chessPositions[i, j], i, j);
				}
			}
		}

		/// <summary>
		/// Sets the board dimensions.
		/// </summary>
		/// <param name="rows">Rows.</param>
		/// <param name="columns">Columns.</param>
		private void SetBoardDimensions(int rows, int columns) {
			// Sets the number of columns on the board and sets its size to be 1/8 of the board width. 
			this.board.ColumnCount = columns;
			float percentage = 100 / columns;

			// Adds colums to the playerfield
			for(int i = 0; i < columns; i++) {
				this.board.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, percentage));
			}

			this.board.RowCount = rows;
			percentage = 100 / rows;

			// Adds rows to the playerfield
			for(int i = 0; i < rows; i++) {
				this.board.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, percentage));
			}
		}

		/// <summary>
		/// Sets the board colors.
		/// </summary>
		private void SetBoardColors() {
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
		}
	}
}