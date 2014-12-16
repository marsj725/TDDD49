using System;

namespace Window {

	partial class MainWindow {

		private System.ComponentModel.IContainer components = null;

		private const int WINDOW_SIZE_WIDTH = 720;
		private const int WINDOW_SIZE_HEIGHT = 560;

		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		/// <summary>
		/// Initializes the component.
		/// </summary>
		private void InitializeComponent() {

			Icon = new System.Drawing.Icon("icon.ico");

			this.SuspendLayout();

			this.ClientSize = new System.Drawing.Size(WINDOW_SIZE_WIDTH, WINDOW_SIZE_HEIGHT);
			this.Name = "Chess";
			this.Text = "Chess";
			this.Resize += new System.EventHandler(OnResize);

			this.ResumeLayout(false);
		}

		/// <summary>
		/// Listener handeling window resizes, makes sure it's always in a square shape.
		/// </summary>
		private void OnResize(object sender, EventArgs a) {
			if(!(this.Size.Width == WINDOW_SIZE_WIDTH)) {
				this.Size = new System.Drawing.Size(WINDOW_SIZE_WIDTH, WINDOW_SIZE_HEIGHT);
			}
			if(!(this.Size.Height == WINDOW_SIZE_HEIGHT)) {
				this.Size = new System.Drawing.Size(WINDOW_SIZE_WIDTH, WINDOW_SIZE_HEIGHT);
			}
		}
	}
}