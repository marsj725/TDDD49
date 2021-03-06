﻿using System;
using System.Windows.Forms;
using System.Drawing;

/// <summary>
/// Displays the draws made by the user and the opponent.
/// </summary>
public class GameLog : TextBox {

	private bool firstLine;
	private Mediator mediator;

	/// <summary>
	/// Initializes a new instance of the <see cref="ChessDrawDisplay"/> class.
	/// </summary>
	public GameLog(Mediator mediator) {
		this.mediator = mediator;
		this.ReadOnly = true;
		this.Multiline = true;
		this.ScrollBars = ScrollBars.Vertical;
		this.mediator.GameLog = this;
		firstLine = true;
		mediator.registerGameLog(this);
	}

	/// <summary>
	/// Prints a move to the textbox on a new line.
	/// </summary>
	/// <param name="player">Player.</param>
	/// <param name="piece">Piece.</param>
	/// <param name="from">From.</param>
	/// <param name="to">To.</param>
	public void writeLine(string text) {
		if(firstLine) {
			this.Text += "- " + text + "\n";
			firstLine = false;
			return;
		}
		this.Text += "- " + text + "\n";
	}

	/// <summary>
	/// Prints a move to the textbox.
	/// </summary>
	/// <param name="playerColor">Player color.</param>
	/// <param name="pieceType">Piece type.</param>
	/// <param name="fromRow">From row.</param>
	/// <param name="fromCol">From col.</param>
	/// <param name="toRow">To row.</param>
	/// <param name="toCol">To col.</param>
	public void writeMove(Board.PieceColor playerColor, Board.PieceType pieceType, int fromRow, int fromCol, int toRow, int toCol) {
		string color = colorToString(playerColor);
		string type = typeToString(pieceType);

		string result = color + " moved " + type + " from (" + fromRow + "," + fromRow + ") to (" + toRow + "," + toCol + ")";

		writeLine(result);
	}

	public void writeWhosTurn(Board.PieceColor player) {
		string result = "It is " + colorToString(player) + "'s turn";

		writeLine(result);
	}

	private string typeToString(Board.PieceType pieceType) {
		if(pieceType == Board.PieceType.BISHOP)
			return "bishop";
		if(pieceType == Board.PieceType.KING)
			return "king";
		if(pieceType == Board.PieceType.KNIGHT)
			return "knight";
		if(pieceType == Board.PieceType.PAWN)
			return "pawn";
		if(pieceType == Board.PieceType.QUEEN)
			return "queen";
		if(pieceType == Board.PieceType.ROOK)
			return "rook";
		return "";
	}

	private string colorToString(Board.PieceColor color) {
		if(color == Board.PieceColor.BLACK)
			return "Black";
		else
			return "White";
	}

	public void writeNotAllowed() {
		writeLine("That draw is not allowed!");
	}

}

