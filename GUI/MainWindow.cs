﻿using System;
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
			BoardGUI boardGUI = new BoardGUI(mediator);
			ChessMenu mainMenu = new ChessMenu(mediator);
			new Database(mediator);
			GameLog log = new GameLog(mediator);
			new Engine(mediator);
			InitializeComponent();

			Menu = mainMenu;
			this.Controls.Add(boardGUI);

			log.Location = new System.Drawing.Point(512, 0);
			log.Size = new System.Drawing.Size(200, WINDOW_SIZE_HEIGHT);
			Controls.Add(log);

		}

	}
}
