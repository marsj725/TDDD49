using System;
using System.Windows.Forms;
using Window;

namespace Window {
	public class BoardGUI : TableLayoutPanel {

		public bool positionChosen;
		public int positionChosenX;
		public int positionChosenY;
		public Mediator mediator;

		private const int BOARD_COLUMNS = 8;
		private const int BOARD_ROWS = 8;
		private const int BOARD_SIZE_WIDTH = 512;
		private const int BOARD_SIZE_HEIGHT = 512;

		private BoardPositionGUI[,] chessPositions;

		public BoardGUI(Mediator mediator) {
			mediator.registerGUI(this);
			this.mediator = mediator;

			positionChosen = false;
			this.chessPositions = new BoardPositionGUI[BOARD_ROWS, BOARD_COLUMNS];
			this.mediator = mediator;

			// Initializes all the positions on the board.
			InitializeBoardPositions();
			AddChessPositionsToBoard();
			SetBoardDimensions(BOARD_ROWS, BOARD_COLUMNS);
			this.Location = new System.Drawing.Point(0, 0);
			this.Name = "Board";
			this.Size = new System.Drawing.Size(BOARD_SIZE_WIDTH, BOARD_SIZE_HEIGHT);

			// Sets the size and location of the chess positions.
			this.drawBoard();
			this.ResumeLayout(false);

			// Sets the colors on the Board to black and white.
			SetBoardColors();

		}


		/// <summary>
		/// Adds the chess positions to board.
		/// </summary>
		private void AddChessPositionsToBoard() {
			for(int i = 0; i < this.chessPositions.GetLength(0); i++) {
				for(int j = 0; j < this.chessPositions.GetLength(1); j++) {
					this.Controls.Add(this.chessPositions[i, j], j, i);
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
			this.ColumnCount = columns;
			float percentage = 100 / columns;

			// Adds colums to the playerfield
			for(int i = 0; i < columns; i++) {
				this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, percentage));
			}

			this.RowCount = rows;
			percentage = 100 / rows;

			// Adds rows to the playerfield
			for(int i = 0; i < rows; i++) {
				this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, percentage));
			}
		}


		/// <summary>
		/// Sets the size and location of the chess positions.
		/// </summary>
		private void drawBoard() {
			for(int i = 0; i < this.chessPositions.GetLength(0); i++) {
				for(int j = 0; j < this.chessPositions.GetLength(1); j++) {
					this.chessPositions[i, j].Location = new System.Drawing.Point(i * this.Width / BOARD_ROWS, j * this.Height / BOARD_COLUMNS);
					this.chessPositions[i, j].Size = new System.Drawing.Size(this.Width / BOARD_ROWS, this.Height / BOARD_COLUMNS);
				}
			}
		}

		/// <summary>
		/// Initializes the board positions.
		/// </summary>
		private void InitializeBoardPositions() {
			for(int i = 0; i < BOARD_ROWS; i++) {
				for(int j = 0; j < BOARD_COLUMNS; j++) {
					this.chessPositions[i, j] = new BoardPositionGUI(i, j);
				}
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

		/// <summary>
		/// Makes a draw.
		/// </summary>
		/// <returns>true</returns>
		/// <c>false</c>
		/// <param name="fromRow">From row.</param>
		/// <param name="fromCol">From col.</param>
		/// <param name="toRow">To row.</param>
		/// <param name="toCol">To col.</param>
		public bool makeDraw(int fromRow, int fromCol, int toRow, int toCol) {
			return this.mediator.GUIMakeMove(fromRow, fromCol, toRow, toCol);
		}

		/// <summary>
		/// Updates the board state.
		/// </summary>
		/// <param name="board">Board.</param>
		public void renderBoard(Piece[,] board) {
			for(int i = 0; i < BOARD_ROWS; i++) {
				for(int j = 0; j < BOARD_COLUMNS; j++) {
					this.chessPositions[i, j].setPiece(board[i, j]);
				}
			}
		}

		/// <summary>
		/// Resets the chosen position (the green ones) so no position is chosen any more.
		/// </summary>
		public void resetChosen() {
			this.positionChosen = false;
			chessPositions[positionChosenX, positionChosenY].resetChosen();
		}

		/// <summary>
		/// Marks a position as chosen.
		/// </summary>
		/// <param name="row">Row.</param>
		/// <param name="col">Col.</param>
		public void setChosen(int row, int col) {
			this.resetChosen();
			this.positionChosen = true;
			this.positionChosenX = row;
			this.positionChosenY = col;
			this.chessPositions[row, col].BackColor = System.Drawing.Color.Green;
		}
	}
}

