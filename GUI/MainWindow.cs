using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Window {
	public partial class MainWindow : Form {

		public MainWindow() {

			BoardGUI player1 = new BoardGUI();

			this.Controls.Add(player1);

			new Engine(player1);

			InitializeComponent();
		}

	}
}
