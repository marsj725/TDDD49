using System;
using System.IO;
using System.Data.Linq;
using System.Collections.Generic;
using Mono.Data.Sqlite;

public class Database
{
	private SqliteConnection m_dbConnection;
	private Mediator mediator;

	public Database(Mediator mediator){
		this.mediator = mediator;
		this.m_dbConnection = new SqliteConnection("Data Source=database.sqlite;Version=3;");
		setUpSQLLITE3();
	}
	public class boardData{
		public int col;
		public int row;
		public int moved;
		public string piece;
		public string color;
	}
	public void setUpSQLLITE3 ()
	{
		if(!File.Exists("database.sqlite")){
			//Creates database file and opens database connection.
			SqliteConnection.CreateFile("database.sqlite");

			setUpConnection();
			//Creates tables.
			string sql = "create table chess (rows int, cols int, piece varchar(6), color varchar(5), moved int)";
			//Generates pieces on the board.
			SqliteCommand command = new SqliteCommand(sql, this.m_dbConnection);
			command.ExecuteNonQuery();
			generateNewChessBoard();
			closeConnection();
		}
	}
	public void generateNewChessBoard ()
	{
		clearTable();
		List<string> query = new List<string>();
		query.Add("insert into chess (rows, cols, piece, color, moved) values(0, 0, 'rook', 'black', 0)");
		query.Add("insert into chess (rows, cols, piece, color, moved) values(0, 7, 'rook', 'black', 0)");
		query.Add("insert into chess (rows, cols, piece, color, moved) values(0, 1, 'knight', 'black', 0)");
		query.Add("insert into chess (rows, cols, piece, color, moved) values(0, 6, 'knight', 'black', 0)");
		query.Add("insert into chess (rows, cols, piece, color, moved) values(0, 2, 'bishop', 'black', 0)");
		query.Add("insert into chess (rows, cols, piece, color, moved) values(0, 5, 'bishop', 'black', 0)");
		query.Add("insert into chess (rows, cols, piece, color, moved) values(0, 3, 'queen', 'black', 0)");
		query.Add("insert into chess (rows, cols, piece, color, moved) values(0, 4, 'king', 'black', 0)");
		for(int i = 0; i < 8; i++) {
			query.Add("insert into chess (rows, cols, piece, color, moved) values(0, "+i+", 'pawn', 'black', 0)");
			query.Add("insert into chess (rows, cols, piece, color, moved) values(0, "+i+", 'pawn', 'white', 0)");
		}
		for(int i = 2; i < 6; i++) {
			for(int j = 0; j < 8; j++) {
				query.Add("insert into chess (rows, cols, piece, color, moved) values("+i+", "+j+", 'none', 'none', 0)");
			}
		}
		query.Add("insert into chess (rows, cols, piece, color, moved) values(7, 0, 'rook', 'white', 0)");
		query.Add("insert into chess (rows, cols, piece, color, moved) values(7, 7, 'rook', 'white', 0)");
		query.Add("insert into chess (rows, cols, piece, color, moved) values(7, 1, 'knight', 'white', 0)");
		query.Add("insert into chess (rows, cols, piece, color, moved) values(7, 6, 'knight', 'white', 0)");
		query.Add("insert into chess (rows, cols, piece, color, moved) values(7, 2, 'bishop', 'white', 0)");
		query.Add("insert into chess (rows, cols, piece, color, moved) values(7, 5, 'bishop', 'white', 0)");
		query.Add("insert into chess (rows, cols, piece, color, moved) values(7, 3, 'queen', 'white', 0)");
		query.Add("insert into chess (rows, cols, piece, color, moved) values(7, 4, 'king', 'white', 0)");

		runQuery(query);
	}
	//Clears tablestructure of all data
	public void clearTable ()
	{
		List<string> query = new List<string>();
		query.Add ("delete from chess");
		runQuery(query);
	}
	//Executes all queries in the list! 
	public void runQuery (List<string> query)
	{
		setUpConnection();
		foreach (string sql in query) {
			SqliteCommand command = new SqliteCommand (sql, this.m_dbConnection);
			command.ExecuteNonQuery();
		}
		closeConnection();
	}

	public void setUpConnection(){
		this.m_dbConnection = new SqliteConnection("Data Source = database.sqlite;version=3;");
		this.m_dbConnection.Open();
	}

	public void closeConnection (){
		this.m_dbConnection.Close();
	}

	public void setDatabaseBoard (Board board)
	{
		setUpConnection ();
		List<boardData> list = new List<boardData> ();
		List<string> query = new List<string> ();
		list = convertToSQLStructure (board);
		foreach (boardData brade in list) {
			query.Add("insert into chess (rows, cols, piece, color, moved) values("+brade.row+", "+brade.col+", '"+brade.piece+"', '"+brade.color+"', 0)");
		}
		runQuery(query);

		closeConnection();
			
	}
	public Board getDatabaseBoard (){
		setUpConnection ();
		Board tempboard = new Board();
		List<boardData> list = new List<boardData>();
		string sql = "select * from chess order by row desc";
		SqliteCommand command = new SqliteCommand (sql, this.m_dbConnection);

		SqliteDataReader reader = command.ExecuteReader ();

		while (reader.Read()) {
			boardData temp = new boardData();
			temp.col = (int)reader["cols"];
			temp.row = (int)reader["rows"];
			temp.piece = (string)reader["piece"];
			temp.color = (string)reader["color"];
			temp.moved = (int)reader["moved"];
			list.Add(temp);
		}
		closeConnection();
		tempboard = convertToEngineStructure(list);
		return tempboard;
	}
	public void fetchfromDatabase ()
	{
		//TODO
		setUpConnection();
		List<string> query = new List<string>();
		query.Add("select * from chess");
		runQuery(query);
		closeConnection();
	}
	public List<boardData> convertToSQLStructure (Board board)
	{
		List<boardData> SQLList = new List<boardData>();
		//board = mediator.Engine.board;

		foreach(Piece piece in board.BoardGrid){
			boardData output = new boardData();
			if(piece.getColor() == Board.PieceColor.WHITE){
				output.color = "white";
			}else if(piece.getColor() == Board.PieceColor.BLACK){
				output.color = "black";
			}else{
				output.color = "none";
			}
			if(piece.getType() == Piece.PieceType.ROOK){
				output.piece = "rook";
			}else if(piece.getType() == Piece.PieceType.KNIGHT){
				output.piece = "knight";
			}else if(piece.getType() == Piece.PieceType.BISHOP){
				output.piece = "bishop";
			}else if(piece.getType() == Piece.PieceType.QUEEN){
				output.piece = "queen";
			}else if(piece.getType() == Piece.PieceType.KING){
				output.piece = "king";
			}else if(piece.getType() == Piece.PieceType.PAWN){
				output.piece = "pawn";
			}else{
				output.piece = "none";
			}
			output.col = piece.Col;
			output.row = piece.Row;
			//TEMP LÖSNING!!!!
			output.moved = 0;
			SQLList.Add(output);
		}
		return SQLList;
	}
	public class LocalPiece{
		public Piece.PieceType piece;
		public int col;
		public int row;
	}
	public Board convertToEngineStructure (List<boardData> list)
	{
		Board board = new Board ();
		Board.PieceColor color;
		foreach (boardData brade in list) {
			if(brade.color == "white"){
				color = Board.PieceColor.WHITE;
			}else if(brade.color == "black"){
				color = Board.PieceColor.BLACK;
			}else{
				color = Board.PieceColor.NONE;
			}
			if(brade.piece == "rook"){
				board.BoardGrid[brade.row, brade.col] = new Rook(color, brade.row, brade.col);
			}else if(brade.piece == "knight"){
				board.BoardGrid[brade.row, brade.col] = new Knight(color, brade.row, brade.col);
			}else if(brade.piece == "bishop"){
				board.BoardGrid[brade.row, brade.col] = new Bishop(color, brade.row, brade.col);
			}else if(brade.piece == "queen"){
				board.BoardGrid[brade.row, brade.col] = new Queen(color, brade.row, brade.col);
			}else if(brade.piece == "king"){
				board.BoardGrid[brade.row, brade.col] = new King(color, brade.row, brade.col);
			}else if(brade.piece == "pawn"){
				board.BoardGrid[brade.row, brade.col] = new Pawn(color, brade.row, brade.col);
			}else{
				board.BoardGrid[brade.row, brade.col] = new None(color, brade.row, brade.col);
			}
		}
		return board;
	}
}