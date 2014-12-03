public class None : Piece {

	public None(PieceColor color, int x, int y) : base(PieceType.NONE, color, x, y) {
	}

	public override bool isMoveLegal(int fromRow, int fromCol, int toRow, int toCol) {
		return false;
	}

	public override C5.ArrayList<System.Tuple<int, int>> getPossibleMoves(Board board) {
		return new C5.ArrayList<System.Tuple<int, int>>();
	}
}

