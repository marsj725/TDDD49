using System;
using System.IO;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
public class Database{

	private Mediator mediator;
	private Database database;
	public string database_dir;
	public FileSystemWatcher watcher;
	public System.IO.FileInfo fileInfo; 

	public class boardData{
		public int col;
		public int row;
		public int moved;
		public string piece;
		public string color;
	}
	public Database(Mediator mediator){
		this.mediator = mediator;
		this.mediator.Database = this;
		this.database_dir = "databas.xml";
		this.watcher = new FileSystemWatcher();
		this.fileInfo = new System.IO.FileInfo(this.database_dir);
		onFileChange ();
	}
	/// <summary>
	/// Checks if the XMLfile exists
	/// </summary>
	/// <returns><c>true</c>, if XMLfile exists, <c>false</c> otherwise.</returns>
	public bool checkXMLfile ()
	{
		if (!File.Exists (this.database_dir)) {
			using (StreamWriter sw = File.CreateText(this.database_dir)) 
			{
				sw.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>\n");
				sw.WriteLine ("<chess>");
					sw.WriteLine ("<status>");
					sw.WriteLine ("</status>");
				sw.WriteLine("</chess>");
			}	
			return false;
		}
		return true;
	}

	public void startListener(){
		this.fileInfo = new System.IO.FileInfo(this.database_dir);
		this.watcher.EnableRaisingEvents = true;
	}

	public void stopListener(){
		this.watcher.EnableRaisingEvents = false;
	}
		
	/// <summary>
	/// Fetches chess board positions and what's occuping the squares.
	/// </summary>
	/// <returns>The XML board.</returns>
	public Piece[,] fetchXMLBoard(){
		Piece[,] grid = new Piece[8,8];
		List<boardData> XMList = new List<boardData>();
		XElement XMLdata = XElement.Load (this.database_dir);
		IEnumerable<XElement> chess = XMLdata.Elements ("square");
		foreach (var type in chess) {
			boardData temp = new boardData();
			temp.col = (int)type.Element("col");
			temp.row = (int)type.Element("row");
			temp.piece = (string)type.Element("piece");
			temp.color = (string)type.Element("color");
			temp.moved = (int)type.Element("moved");
			XMList.Add(temp);
		}
		grid = convertToEngineStructure(XMList);
		return grid;
	}
	/// <summary>
	/// Sets the XML board.
	/// </summary>
	/// <param name="board">Board.</param>
	public void setXMLBoard (Board board)
	{
		stopListener ();
		clearXML ();
		List<boardData> list = new List<boardData> ();
		list = convertToXMLStructure (board);
		XElement XMLdata = XElement.Load (this.database_dir);
		XMLdata.Add (new XElement ("status",
			new XElement ("activeplayer", "white"),
			new XElement ("matchtype","HvAi")));
		XMLdata.Save (this.database_dir);
		foreach (var item in list) {
			addXMLValue (item.row, item.col, item.piece, item.color, item.moved);
		}
		startListener ();
	}
	private void clearXML(){
		stopListener ();
		XElement XMLdata = XElement.Load (this.database_dir);
		XMLdata.RemoveNodes ();
		XMLdata.Save (this.database_dir);
		startListener ();
	}
	/// <summary>
	/// Moves a piece from a col row to a new col row.
	/// </summary>
	/// <param name="fromrow">Fromrow.</param>
	/// <param name="fromcol">Fromcol.</param>
	/// <param name="torow">Torow.</param>
	/// <param name="tocol">Tocol.</param>
	public void movePiece(int fromrow, int fromcol, int torow,int tocol){
		stopListener ();
		string tmpPiece = "";
		string tmpColor = "";
		XElement XMLdata = XElement.Load (this.database_dir);
		var oldPiece =
			(from square in XMLdata.Descendants ("square")
				where int.Parse(square.Element ("row").Value) == fromrow && int.Parse(square.Element ("col").Value) == fromcol
				select square);
		var newPiece =
			(from square in XMLdata.Descendants ("square")
				where int.Parse(square.Element ("row").Value) == torow && int.Parse(square.Element ("col").Value) == tocol
				select square);
		foreach (XElement square in oldPiece){
			tmpPiece = square.Element ("piece").Value;
			tmpColor = square.Element ("color").Value;
			square.SetElementValue ("piece", "none");
			square.SetElementValue ("color", "none");
		}
		foreach (XElement square in newPiece){
			square.SetElementValue ("piece", tmpPiece);
			square.SetElementValue ("color", tmpColor);
		}
		XMLdata.Save (this.database_dir);
		startListener ();
	}
	public void onFileChange(){
		this.watcher.Filter = this.database_dir;
		this.watcher.Changed += new FileSystemEventHandler (fileChanged);
		this.watcher.EnableRaisingEvents = true;
	}
	public void fileChanged(object source, FileSystemEventArgs e){
		System.IO.FileInfo temp = new System.IO.FileInfo (this.database_dir);
		if (this.fileInfo.LastWriteTime != temp.LastWriteTime) {
			Piece[,] grid = new Piece[8, 8];
			grid = fetchXMLBoard ();
			this.mediator.forcedBoardUpdate (grid);
			Console.WriteLine ("pushing board update");
			this.fileInfo = new System.IO.FileInfo(this.database_dir);
		} else {
			Console.WriteLine ("file was not updated!");
		}
	}

	private void addXMLValue(int row,int col,string piece, string color,int moved){
		XElement XMLdata = XElement.Load (this.database_dir);
		XMLdata.Add(new XElement("square",
			new XElement("row",row),
			new XElement("col",col),
			new XElement("piece",piece),
			new XElement("color",color),
			new XElement("moved",moved)));
		XMLdata.Save (this.database_dir);
	}

	private List<boardData> convertToXMLStructure (Board board)
	{
		List<boardData> XMList = new List<boardData>();
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
			XMList.Add(output);
		}
		return XMList;
	}

	private Piece[,] convertToEngineStructure (List<boardData> list)
	{
		Board.PieceColor color;
		Piece[,] grid = new Piece[8,8];
		foreach (boardData brade in list) {
			if(brade.color == "white"){
				color = Board.PieceColor.WHITE;
			}else if(brade.color == "black"){
				color = Board.PieceColor.BLACK;
			}else{
				color = Board.PieceColor.NONE;
			}
			if(brade.piece == "rook"){
				grid [brade.row, brade.col] = new Rook (color, brade.row, brade.col);
			}else if(brade.piece == "knight"){
				grid [brade.row, brade.col] = new Knight(color, brade.row, brade.col);
			}else if(brade.piece == "bishop"){
				grid [brade.row, brade.col] = new Bishop(color, brade.row, brade.col);
			}else if(brade.piece == "queen"){
				grid [brade.row, brade.col] = new Queen(color, brade.row, brade.col);
			}else if(brade.piece == "king"){
				grid [brade.row, brade.col] = new King(color, brade.row, brade.col);
			}else if(brade.piece == "pawn"){
				grid [brade.row, brade.col] = new Pawn(color, brade.row, brade.col);
			}else{
				grid [brade.row, brade.col] = new None(color, brade.row, brade.col);
			}
		}
		return grid;
	}
}