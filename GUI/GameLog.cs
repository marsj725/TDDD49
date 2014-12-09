using System;
using System.Windows.Forms;
using System.Drawing;

/// <summary>
/// Displays the draws made by the user and the opponent.
/// </summary>
public class GameLog : TextBox {

	private bool firstLine;

	/// <summary>
	/// Initializes a new instance of the <see cref="ChessDrawDisplay"/> class.
	/// </summary>
	public GameLog(Mediator mediator) {
		this.ReadOnly = true;
		this.Multiline = true;
		this.ScrollBars = ScrollBars.Vertical;
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
	private void writeLine(string text) {
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
	public void writeMove(Board.PieceColor playerColor, Piece.PieceType pieceType, int fromRow, int fromCol, int toRow, int toCol) {
		string color = colorToString(playerColor);
		string type = typeToString(pieceType);

		string result = color + " moved " + type + " from (" + fromRow + "," + toRow + ") to (" + toRow + "," + toCol + ")";

		writeLine(result);
	}

	private string typeToString(Piece.PieceType pieceType) {
		if(pieceType == Piece.PieceType.BISHOP)
			return "bishop";
		if(pieceType == Piece.PieceType.KING)
			return "king";
		if(pieceType == Piece.PieceType.KNIGHT)
			return "knight";
		if(pieceType == Piece.PieceType.PAWN)
			return "pawn";
		if(pieceType == Piece.PieceType.QUEEN)
			return "queen";
		if(pieceType == Piece.PieceType.ROOK)
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

