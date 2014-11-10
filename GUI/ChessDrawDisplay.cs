using System;
using System.Windows.Forms;

/// <summary>
/// Displays the draws made by the user and the opponent.
/// </summary>
public class ChessDrawDisplay : TextBox {

	private bool firstLine;

	/// <summary>
	/// Initializes a new instance of the <see cref="ChessDrawDisplay"/> class.
	/// </summary>
	public ChessDrawDisplay() {
		this.ReadOnly = true;
		this.Multiline = true;
		this.ScrollBars = ScrollBars.Vertical;
		firstLine = true;

		// Example line
		this.writeLine("Player 1", "queen", "A1", "A3");
	}

	/// <summary>
	/// Prints a move to the textbox on a new line.
	/// </summary>
	/// <param name="player">Player.</param>
	/// <param name="piece">Piece.</param>
	/// <param name="from">From.</param>
	/// <param name="to">To.</param>
	public void writeLine(String player, String piece, String from, String to) {
		if(firstLine) {
			this.Text += "- " + player + " moved " + piece + " from " + from + " to " + to;
			firstLine = false;
			return;
		}
		this.Text += "\n" + "- " + player + " moved " + piece + " from " + from + " to " + to;
	}

}

