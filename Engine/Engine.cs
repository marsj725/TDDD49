using System;

/// <summary>
/// Chess engine.
/// </summary>
public class Engine {

	private Board.PieceColor activePlayer;
	private Mediator mediator;
	public Board board;

	/// <summary>
	/// Initializes a new instance of the <see cref="Engine"/> class.
	/// </summary>
	public Engine(Mediator mediator) {
		this.board = new Board();
		this.mediator = mediator;
//		this.player = player;
		this.mediator.InitializeEngine(this);
		this.mediator.updateBoard(board.BoardGrid);
		this.activePlayer = Board.PieceColor.WHITE;
	}
	//Sets and controls which player is currently active!
	public Board.PieceColor PlayerTurn
	{
		get{
			return this.activePlayer;
		}
		set{
			if(this.activePlayer == Board.PieceColor.WHITE){
				this.activePlayer = Board.PieceColor.BLACK;
			}else{
				this.activePlayer = Board.PieceColor.WHITE;
			}
		}
	}

	/// <summary>
	/// Performs the draw on the board.
	/// </summary>
	/// <param name="color">Color.</param>
	/// <param name="fromRow">From row.</param>
	/// <param name="fromCol">From col.</param>
	/// <param name="toRow">To row.</param>
	/// <param name="toCol">To col.</param>
	public bool performDraw(int fromRow, int fromCol, int toRow, int toCol) {
		// The draw is obviously not allowed if the user trying to make the draw isn't the same color.
		Board.PieceColor color = this.activePlayer;
		if(this.board.BoardGrid[fromRow, fromCol].getColor() != color)
			return false;
		if(this.board.BoardGrid[toRow, toCol].getColor() == color)
			return false;
		if(this.board.BoardGrid[fromRow, fromCol].isMoveLegal(this.board, fromRow, fromCol, toRow, toCol)) {
			this.board.movePiece(fromRow, fromCol, toRow, toCol);
			mediator.updateBoard(this.board.BoardGrid);
			return true;
		}
		return false;
	}

	/// <summary>
	/// Controls whether it is check or not.
	/// </summary>
	/// <returns><c>true</c>, if check, <c>false</c> otherwise.</returns>
	private bool isCheck() {
		// To be implemented
		return false;
	}

	/// <summary>
	///	Controls whether it is check mate or not. 
	/// </summary>
	/// <returns><c>true</c>, if check mate, <c>false</c> otherwise.</returns>
	private bool isCheckMate() {
		// To be implemented
		return false;
	}

}

