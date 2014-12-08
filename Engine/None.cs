public class None : Piece {

	public None(Board.PieceColor color, int x, int y) : base(PieceType.NONE, color,x ,y) {
	}
	public override bool isMoveLegal(int fromRow, int fromCol, int toRow, int toCol) {
		return false;
	}
}

