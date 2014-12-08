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

			BoardGUI player = new BoardGUI(mediator);

			this.Controls.Add(player);

			Engine engine = new Engine(mediator);

			InitializeComponent();
		}

	}
}
