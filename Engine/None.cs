public class None : Piece {

	public None(Board.PieceColor color, int x, int y) : base(Board.PieceType.NONE, color, x, y) {
	}

	public override bool isMoveLegal(Board board, int fromRow, int fromCol, int toRow, int toCol) {
		return false;
	}

	public override C5.ArrayList<System.Tuple<int, int>> getPossibleMoves(Board board) {
		return new C5.ArrayList<System.Tuple<int, int>>();
	}
}

