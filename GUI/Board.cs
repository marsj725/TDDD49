﻿using System;
using System.Windows.Forms;
using BoardGUI;

public class Board : TableLayoutPanel {

	private const int BOARD_COLUMNS = 8;
	private const int BOARD_ROWS = 8;
	private const int BOARD_SIZE_WIDTH = 240;
	private const int BOARD_SIZE_HEIGHT = 240;

	private BoardPositionGUI[,] chessPositions;

	public Board() {
		this.chessPositions = new BoardPositionGUI[BOARD_ROWS, BOARD_COLUMNS];

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
				this.Controls.Add(this.chessPositions[i, j], i, j);
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
		for(int i = 0; i < this.chessPositions.GetLength(0); i++) {
			for(int j = 0; j < this.chessPositions.GetLength(1); j++) {
				this.chessPositions[i, j] = new BoardPositionGUI(j, i);
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
}
