using System;
using System.Windows.Forms;

/// <summary>
/// Displays the draws made by the user and the opponent.
/// </summary>
public class ChessDrawDisplay : TextBox {

	/// <summary>
	/// Initializes a new instance of the <see cref="ChessDrawDisplay"/> class.
	/// </summary>
	public ChessDrawDisplay() {
		this.ReadOnly = true;
		this.Multiline = true;
		this.ScrollBars = true;
	}

}

