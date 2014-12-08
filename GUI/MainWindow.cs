using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Window {
	public partial class MainWindow : Form {

		public MainWindow() {

			Mediator mediator = new Mediator();

			new User(mediator, Board.PieceColor.WHITE);
			new User(mediator, Board.PieceColor.BLACK);
			BoardGUI boardGUI = new BoardGUI(mediator);
			new Engine(mediator);

			InitializeComponent();

			this.Controls.Add(boardGUI);
		}

	}
}
