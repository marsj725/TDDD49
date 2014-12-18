using System;

/// <summary>
/// Mediator pattern between the players and the chess engine, 
/// to make it possible for them communicate with each other. 
/// Player1, Player2 and Engine is suppose to be initialized 
/// in the mediator in their constructors. 
/// </summary>
public class Mediator {

	private Player player1;
	private Player player2;
	private Engine engine;
	private Database database;
	private Window.BoardGUI gui;
	private GameLog gameLog;

	public Engine Engine {
		get {
			return this.engine;
		}
		private set {
			engine = value;
		}
	}

	public Window.BoardGUI GUI {
		get {
			return this.gui;
		}
		private set {
			this.gui = value;
		}
	}

	public Player Player1 {
		get {
			return player1;
		}
		set {
			player1 = value;
		}
	}

	public Player Player2 {
		get {
			return player2;
		}
		set {
			player2 = value;
		}
	}

	public Database Database {
		get {
			return this.database;
		}
		set {
			this.database = value;
		}
	}

	public GameLog GameLog {
		get {
			return this.gameLog;
		} 
		set {
			this.gameLog = value;
		}
	}

	/// <summary>
	/// A player makes a move.
	/// </summary>
	/// <returns><c>true</c>, if draw was made, <c>false</c> otherwise.</returns>
	/// <param name="color">Color.</param>
	/// <param name="fromRow">From row.</param>
	/// <param name="fromCol">From col.</param>
	/// <param name="toRow">To row.</param>
	/// <param name="toCol">To col.</param>
	public bool makeDraw(int fromRow, int fromCol, int toRow, int toCol) {
		return this.Engine.performDraw(fromRow, fromCol, toRow, toCol);
	}

	/// <summary>
	/// Re-renders the board.
	/// </summary>
	/// <param name="board">Board.</param>
	public void updateBoard(Piece[,] board) {
		GUI.renderBoard(board);
	}

	/// <summary>
	/// Re-renders a position of the board.
	/// </summary>
	/// <param name="board">Board.</param>
	public void updateBoard(int row, int col) {
		GUI.renderBoard(row, col);
	}

	/// <summary>
	/// Called when the GUI detects that someone will make a move.
	/// </summary>
	/// <returns><c>true</c>, if the move where allowed, <c>false</c> otherwise.</returns>
	/// <param name="fromRow">From row.</param>
	/// <param name="fromCol">From col.</param>
	/// <param name="toRow">To row.</param>
	/// <param name="toCol">To col.</param>
	public bool GUIMakeMove(int fromRow, int fromCol, int toRow, int toCol) {
		if(this.Engine.PlayerTurn == Player1.Color)
			return Player1.makeDraw(fromRow, fromCol, toRow, toCol);
		else
			return Player2.makeDraw(fromRow, fromCol, toRow, toCol);
	}

	/// <summary>
	/// A player registers itself in the mediator. 
	/// </summary>
	/// <returns><c>true</c>, if player was registered, <c>false</c> otherwise.</returns>
	/// <param name="player">Player.</param>
	public bool registerPlayer(Player player) {
		if(this.Player1 == null) {
			this.Player1 = player;
			return true;
		} else if(this.Player2 == null) {
			this.Player2 = player;
			return true;
		}
		return false;
	}

	public bool registerEngine(Engine engine) {
		if(this.Engine == null) {
			this.Engine = engine;
			return true;
		}
		return false;
	}

	public bool registerGUI(Window.BoardGUI gui) {
		if(this.GUI == null) {
			this.GUI = gui;
			return true;
		}
		return false;
	}

	public bool registerGameLog(GameLog log) {
		if(this.GameLog == null) {
			this.GameLog = log;
			return true;
		}
		return false;
	}

	public void informOfTurnChange() {
		Player1.turnChanged();
		Player2.turnChanged();
	}

	public void printWinner(Board.PieceColor color) {
		GUI.winnerMessage(color);
		GameLog.Clear();
	}

	public void printDraw() {
		GUI.drawMessage();
		GameLog.Clear();
	}

	public void resetGame() {
		Engine.reset();
		GameLog.Clear();
	}

	public bool checkXMLfile() {
		return this.database.checkXMLfile();
	}

	public void setXMLBoard(Board board) {
		this.database.setXMLBoard(board);
	}

	public Piece[,] fetchXMLBoard() {
		return this.database.fetchXMLBoard();
	}

	public void movePiece(int fromrow, int fromcol, int torow, int tocol) {
		this.database.movePiece(fromrow, fromcol, torow, tocol);
	}

	public void forcedBoardUpdate(Piece[,] grid) {
		this.Engine.board.forcedBoardUpdate(grid);
	}

	public void updateActivePlayer(Board.PieceColor playerColor) {
		this.database.updateActivePlayer(playerColor);
	}

	public void setMatchType(string type) {
		this.database.setmatchType(type);
	}

	public void updateLog(Board.PieceColor color, Board.PieceType type, int fromrow, int fromcol, int torow, int tocol) {
		this.gameLog.writeMove(color, type, fromrow, fromcol, torow, tocol);
		this.database.updateActivityLog(color, type, fromrow, fromcol, torow, tocol);
	}

	public void updateGUILog(Board.PieceColor color, Board.PieceType type, int fromrow, int fromcol, int torow, int tocol) {
		this.gameLog.writeMove(color, type, fromrow, fromcol, torow, tocol);
	}
}