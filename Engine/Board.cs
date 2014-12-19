using System;
using C5;

public class Board {

	public enum PieceType {
		NONE,
		PAWN,
		ROOK,
		BISHOP,
		KNIGHT,
		KING,
		QUEEN}
	;

	public enum PieceColor {
		WHITE,
		BLACK,
		NONE}
	;

	public Piece[,] BoardGrid {
		get;
		private set;
	}

	public const int ROWS = 8;
	public const int COLUMNS = 8;
	private Mediator mediator;

	public Board(Mediator mediator) {
		this.BoardGrid = new Piece[ROWS, COLUMNS];
		this.mediator = mediator;
		//Asks the database class if there is an existing database file, creates one otherwise.
		if(!mediator.checkXMLfile()) {
			this.resetBoard();
		} else {
			this.BoardGrid = this.mediator.fetchXMLBoard();
		}
	}

	/// <summary>
	/// Moves a piece from one position to another. If there are a piece on the other position it will simply be replaced.
	/// </summary>
	/// <param name="fromRow">From row.</param>
	/// <param name="fromCol">From col.</param>
	/// <param name="toRow">To row.</param>
	/// <param name="toCol">To col.</param>
	public void movePiece(int fromRow, int fromCol, int toRow, int toCol) {
		this.BoardGrid[toRow, toCol] = this.BoardGrid[fromRow, fromCol];
		this.BoardGrid[toRow, toCol].Row = toRow;
		this.BoardGrid[toRow, toCol].Col = toCol;
		this.BoardGrid[fromRow, fromCol] = new None(PieceColor.NONE, fromRow, fromCol);
	}

	/// <summary>
	/// Updates the board whenever there has been a change in databas XML file.
	/// </summary>
	/// <param name="grid">Grid.</param>
	public void forcedBoardUpdate(Piece[,] grid) {
		this.BoardGrid = grid;
		this.mediator.updateBoard(grid);
	}

	/// <summary>
	/// Returns all the positions where the color can possibly attack. 
	/// </summary>
	/// <returns>A boolean array where true is a position where the color can attack.</returns>
	/// <param name="color">The color.</param>
	public bool[,] getAttackedPositions(Board.PieceColor color) {

		bool[,] attackedPositions = new bool[8, 8];

		foreach(Piece piece in BoardGrid) {
			if(piece.Color == color) {
				ArrayList<Tuple<int, int>> positions = piece.getPossibleMoves(this);
				foreach(Tuple<int, int> position in positions) {
					attackedPositions[position.Item1, position.Item2] = true;
				}
			}
		}

		return attackedPositions;
	}

	/// <summary>
	/// Returns all the draws the color can possibly make. 
	/// </summary>
	/// <returns>An array of draws. The draws are represented as an integer array where the two first indexes is 
	/// from where the draw is made and the last two is to where the draws are made.</returns>
	/// <param name="color">The color.</param>
	public ArrayList<int[]> getPossibleAttacks(Board.PieceColor color) {

		ArrayList<int[]> possibleAttacks = new ArrayList<int[]>();

		foreach(Piece piece in BoardGrid) {
			if(piece.Color == color) {
				ArrayList<Tuple<int, int>> positions = piece.getPossibleMoves(this);
				foreach(Tuple<int, int> position in positions) {
					int[] possibleAttack = { piece.Row, piece.Col, position.Item1, position.Item2 };
					possibleAttacks.Add(possibleAttack);
				}
			}
		}

		return possibleAttacks;
	}


	/// <summary>
	/// Resets the board pieces to its initial positions.
	/// </summary>
	public void resetBoard() {
		this.BoardGrid[0, 0] = new Rook(PieceColor.BLACK, 0, 0);
		this.BoardGrid[0, 7] = new Rook(PieceColor.BLACK, 0, 7);
		this.BoardGrid[0, 1] = new Knight(PieceColor.BLACK, 0, 1);
		this.BoardGrid[0, 6] = new Knight(PieceColor.BLACK, 0, 6);
		this.BoardGrid[0, 2] = new Bishop(PieceColor.BLACK, 0, 2);
		this.BoardGrid[0, 5] = new Bishop(PieceColor.BLACK, 0, 5);
		this.BoardGrid[0, 3] = new Queen(PieceColor.BLACK, 0, 3);
		this.BoardGrid[0, 4] = new King(PieceColor.BLACK, 0, 4);

		// Sets the positions of the pawns.
		for(int i = 0; i < 8; i++) {
			this.BoardGrid[1, i] = new Pawn(PieceColor.BLACK, 1, i);
			this.BoardGrid[6, i] = new Pawn(PieceColor.WHITE, 6, i);
		}

		for(int i = 2; i < 6; i++) {
			for(int j = 0; j < 8; j++) {
				this.BoardGrid[i, j] = new None(PieceColor.NONE, i, j);
			}
		}

		this.BoardGrid[7, 0] = new Rook(PieceColor.WHITE, 7, 0);
		this.BoardGrid[7, 7] = new Rook(PieceColor.WHITE, 7, 7); 
		this.BoardGrid[7, 1] = new Knight(PieceColor.WHITE, 7, 1);
		this.BoardGrid[7, 6] = new Knight(PieceColor.WHITE, 7, 6); 
		this.BoardGrid[7, 2] = new Bishop(PieceColor.WHITE, 7, 2);
		this.BoardGrid[7, 5] = new Bishop(PieceColor.WHITE, 7, 5); 
		this.BoardGrid[7, 3] = new Queen(PieceColor.WHITE, 7, 3);
		this.BoardGrid[7, 4] = new King(PieceColor.WHITE, 7, 4);

		//resets the database XML file with a clean board. 
		this.mediator.setXMLBoard(this);
	}
}