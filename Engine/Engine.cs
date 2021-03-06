using System;
using C5;

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
		this.mediator = mediator;
		setGameType ("HumanVsHuman");
		this.board = new Board(this.mediator);

		this.mediator.registerEngine(this);
		this.mediator.updateBoard(board.BoardGrid);

		if (!mediator.checkXMLfile ()) {
			this.PlayerTurn = Board.PieceColor.WHITE;
		} else {
			Tuple<Board.PieceColor,string> list = this.mediator.Database.fetchGameStatus ();
			this.PlayerTurn = list.Item1;
			setGameType (list.Item2);
		}
	}

	public void setGameType(string type){
		if (type == "HumanVsHuman") {
			mediator.Player1 = new User(mediator, Board.PieceColor.WHITE);
			mediator.Player2 = new User(mediator, Board.PieceColor.BLACK);
		} else if (type == "HumanVsAi") {
			mediator.Player1 = new User(mediator, Board.PieceColor.WHITE);
			mediator.Player2 = new AI(mediator, Board.PieceColor.BLACK);
		} else {
			mediator.Player1 = new AI(mediator, Board.PieceColor.WHITE);
			mediator.Player2 = new User(mediator, Board.PieceColor.BLACK);
		}
	}
	//Sets and controls which player is currently active!
	public Board.PieceColor PlayerTurn {
		get {
			return this.activePlayer;
		}set{
			this.activePlayer = value;
			mediator.informOfTurnChange();
			mediator.updateActivePlayer (this.activePlayer);
		}
	}

	private void switchTurn() {
		if(this.PlayerTurn == Board.PieceColor.WHITE)
			this.PlayerTurn = Board.PieceColor.BLACK;
		else
			this.PlayerTurn = Board.PieceColor.WHITE;
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
		Board.PieceColor color = this.PlayerTurn;
		if(this.board.BoardGrid[fromRow, fromCol].Color != color)
			return false;

		if(this.board.BoardGrid[toRow, toCol].Color == color)
			return false;

		if(this.board.BoardGrid[fromRow, fromCol].isMoveLegal(this.board, fromRow, fromCol, toRow, toCol)) {
			// Create a backup of the piece in order to revert the draw if the player puts himself in a chess position.
			Type backupType = this.board.BoardGrid[toRow, toCol].GetType();
			Board.PieceColor backupColor = this.board.BoardGrid[toRow, toCol].Color;
			this.board.movePiece(fromRow, fromCol, toRow, toCol);
			// If the player puts himself in a chess position revert the draw, since the draw is not allowed.
			if(isCheck(this.PlayerTurn)) {
				this.board.movePiece(toRow, toCol, fromRow, fromCol);
				this.board.BoardGrid[toRow, toCol] = (Piece)System.Activator.CreateInstance(backupType, backupColor, toRow, toCol);
				return false;
			}
			// If the opponent is put in a check mate, show the user that there is a winner and reset everything.
			if(isCheckMate(getOppositeColor(this.PlayerTurn))) {
				mediator.updateBoard(fromRow, fromCol);
				mediator.updateBoard(toRow, toCol);
				winner(this.PlayerTurn);
				return false;
			}

			checkForAndPerformPromotion(fromRow, fromCol, toRow, toCol);

			mediator.updateBoard(fromRow, fromCol);
			mediator.updateBoard(toRow, toCol);

			if(this.board.getPossibleAttacks(this.PlayerTurn).IsEmpty ||
			   this.board.getPossibleAttacks(getOppositeColor(this.PlayerTurn)).IsEmpty) {
				draw();
				return true;
			}
			//Updates database with current piece movement.
			this.mediator.movePiece(fromRow, fromCol, toRow, toCol);
			this.mediator.updateLog(color, board.BoardGrid[toRow, toCol].PieceType, fromRow, fromCol, toRow, toCol);
			switchTurn();
			return true;
		}
		return false;
	}

	/// <summary>
	/// Controls whether the player is in check or not.
	/// </summary>
	/// <returns><c>true</c>, if check, <c>false</c> otherwise.</returns>
	private bool isCheck(Board.PieceColor color) {

		Board.PieceColor oppositeColor;

		if(color == Board.PieceColor.WHITE)
			oppositeColor = Board.PieceColor.BLACK;
		else
			oppositeColor = Board.PieceColor.WHITE;

		Tuple<int, int> kingPosition = getPositionOf(Board.PieceType.KING, color);

		if(board.getAttackedPositions(oppositeColor)[kingPosition.Item1, kingPosition.Item2] == true)
			return true;

		return false;
	}

	/// <summary>
	///	Controls whether it is check mate or not. 
	/// </summary>
	/// <returns><c>true</c>, if check mate, <c>false</c> otherwise.</returns>
	private bool isCheckMate(Board.PieceColor color) {
		if(isCheck(color)) {
			Tuple<int, int> kingPosition = getPositionOf(Board.PieceType.KING, color);
			ArrayList<Tuple<int, int>> possibleAttacks = board.BoardGrid[kingPosition.Item1, kingPosition.Item2].getPossibleMoves(this.board);

			foreach(Tuple<int, int> draw in possibleAttacks) {
				Type backupType = this.board.BoardGrid[draw.Item1, draw.Item2].GetType();
				Board.PieceColor backupColor = this.board.BoardGrid[draw.Item1, draw.Item2].Color;

				board.movePiece(kingPosition.Item1, kingPosition.Item2, draw.Item1, draw.Item2);
				if(!isCheck(color)) {
					this.board.movePiece(draw.Item1, draw.Item2, kingPosition.Item1, kingPosition.Item2);
					this.board.BoardGrid[draw.Item1, draw.Item2] = (Piece)System.Activator.CreateInstance(backupType, backupColor, draw.Item1, draw.Item2);
					return false;
				}

				this.board.movePiece(draw.Item1, draw.Item2, kingPosition.Item1, kingPosition.Item2);
				this.board.BoardGrid[draw.Item1, draw.Item2] = (Piece)System.Activator.CreateInstance(backupType, backupColor, draw.Item1, draw.Item2);
			}			
			return true;
		}
		return false;
	}

	/// <summary>
	/// Gets the position of a piece. If the piece is not on the board it returns null.
	/// </summary>
	/// <returns>The position of.</returns>
	/// <param name="type">Type.</param>
	/// <param name="color">Color.</param>
	private Tuple<int, int> getPositionOf(Board.PieceType type, Board.PieceColor color) {
		foreach(Piece piece in this.board.BoardGrid) {
			if(piece.Color == color && piece.PieceType == type)
				return new Tuple<int, int>(piece.Row, piece.Col);
		}
		return null;
	}

	/// <summary>
	/// Is called when there is a winner. Prints a winner message and resets the engine.
	/// </summary>
	/// <param name="winner">Winner.</param>
	private void winner(Board.PieceColor winner) {
		mediator.printWinner(winner);
		reset();
	}

	private void draw() {
		mediator.printDraw();
		reset();
	}

	/// <summary>
	/// Gets the opposite color of the input parameter.
	/// </summary>
	/// <returns>The opposite color.</returns>
	/// <param name="color">Color.</param>
	public Board.PieceColor getOppositeColor(Board.PieceColor color) {
		if(color == Board.PieceColor.NONE)
			return Board.PieceColor.NONE;
		if(color == Board.PieceColor.BLACK)
			return Board.PieceColor.WHITE;
		return Board.PieceColor.BLACK;
	}

	public void reset() {
		this.board.resetBoard();
		mediator.updateBoard(this.board.BoardGrid);
		PlayerTurn = Board.PieceColor.WHITE;
	}

	/// <summary>
	/// Checks for promotion, and performs it if promotion is possible.
	/// </summary>
	/// <param name="fromRow">From row.</param>
	/// <param name="fromCol">From col.</param>
	/// <param name="toRow">To row.</param>
	/// <param name="toCol">To col.</param>
	void checkForAndPerformPromotion(int fromRow, int fromCol, int toRow, int toCol) {
		if(board.BoardGrid[toRow, toCol].PieceType == Board.PieceType.PAWN) {

			bool promotion = false;

			if(PlayerTurn == Board.PieceColor.BLACK && toRow == 7) {
				board.BoardGrid[toRow, toCol] = new Queen(PlayerTurn, toRow, toCol);
				promotion = true;
			} else if(toRow == 0) {
				board.BoardGrid[toRow, toCol] = new Queen(PlayerTurn, toRow, toCol);
				promotion = true;
			}

			// Have to look for chess mate again.
			if(promotion) {
				mediator.updateBoard(fromRow, fromCol);
				mediator.updateBoard(toRow, toCol);
				if(isCheckMate(getOppositeColor(PlayerTurn)))
					winner(this.PlayerTurn);
			}
		}
	}
}

