using System;
using System.IO;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
public class Database{

	private Mediator mediator;
	public string database;
	public Board bradet;

	public class boardData{
		public int col;
		public int row;
		public int moved;
		public string piece;
		public string color;
	}
	public Database(Mediator mediator){
		this.mediator = mediator;
		this.bradet = this.mediator.Engine.board;

		this.database = "databas.xml";
		movePiece (0, 0, 0, 1);
	}
		
	public Board fetchXMLBoard(){
		Board tempboard = new Board();
		List<boardData> XMList = new List<boardData>();
		XElement XMLdata = XElement.Load (this.database);
		IEnumerable<XElement> chess = XMLdata.Elements ();
		foreach (var type in chess) {
			boardData temp = new boardData();
			temp.col = (int)type.Element("col");
			temp.row = (int)type.Element("row");
			temp.piece = (string)type.Element("piece");
			temp.color = (string)type.Element("color");
			temp.moved = (int)type.Element("moved");
			XMList.Add(temp);
		}
		tempboard = convertToEngineStructure(XMList);
		return tempboard;
	}
	public void createXMLfile(){
		XDocument XML = new XDocument (this.database);
	}

	public void setXMLBoard (Board board)
	{
		List<boardData> list = new List<boardData> ();
		list = convertToXMLStructure (board);
		XElement XMLdata = XElement.Load (this.database);
		foreach (var item in list) {
			addXMLValue (item.row, item.col, item.piece, item.color, item.moved);
		}
	}
	public void clearXML(){
		XElement XMLdata = XElement.Load (this.database);
		XMLdata.RemoveNodes ();
		XMLdata.Save (this.database);
	}
	public void movePiece(int fromrow, int fromcol, int torow,int tocol){
		string tmpPiece = "";
		string tmpColor = "";
		XElement XMLdata = XElement.Load (this.database);
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
		XMLdata.Save (this.database);
	}

	public void addXMLValue(int row,int col,string piece, string color,int moved){
		XElement XMLdata = XElement.Load (this.database);
		XMLdata.Add(new XElement("square",
			new XElement("row",row),
			new XElement("col",col),
			new XElement("piece",piece),
			new XElement("color",color),
			new XElement("moved",moved)));
		XMLdata.Save (this.database);
	}

	public List<boardData> convertToXMLStructure (Board board)
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