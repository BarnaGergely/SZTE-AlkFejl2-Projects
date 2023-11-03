namespace WinFormsApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            listázásToolStripMenuItem = new ToolStripMenuItem();
            kisállatHozzáadásaToolStripMenuItem = new ToolStripMenuItem();
            kategóriaHozzáadásaToolStripMenuItem = new ToolStripMenuItem();
            exportálásToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { listázásToolStripMenuItem, kisállatHozzáadásaToolStripMenuItem, kategóriaHozzáadásaToolStripMenuItem, exportálásToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // listázásToolStripMenuItem
            // 
            listázásToolStripMenuItem.Name = "listázásToolStripMenuItem";
            listázásToolStripMenuItem.Size = new Size(59, 20);
            listázásToolStripMenuItem.Text = "Listázás";
            listázásToolStripMenuItem.Click += listázásToolStripMenuItem_Click;
            // 
            // kisállatHozzáadásaToolStripMenuItem
            // 
            kisállatHozzáadásaToolStripMenuItem.Name = "kisállatHozzáadásaToolStripMenuItem";
            kisállatHozzáadásaToolStripMenuItem.Size = new Size(119, 20);
            kisállatHozzáadásaToolStripMenuItem.Text = "Kisállat hozzáadása";
            // 
            // kategóriaHozzáadásaToolStripMenuItem
            // 
            kategóriaHozzáadásaToolStripMenuItem.Name = "kategóriaHozzáadásaToolStripMenuItem";
            kategóriaHozzáadásaToolStripMenuItem.Size = new Size(132, 20);
            kategóriaHozzáadásaToolStripMenuItem.Text = "Kategória hozzáadása";
            // 
            // exportálásToolStripMenuItem
            // 
            exportálásToolStripMenuItem.Name = "exportálásToolStripMenuItem";
            exportálásToolStripMenuItem.Size = new Size(73, 20);
            exportálásToolStripMenuItem.Text = "Exportálás";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem listázásToolStripMenuItem;
        private ToolStripMenuItem kisállatHozzáadásaToolStripMenuItem;
        private ToolStripMenuItem kategóriaHozzáadásaToolStripMenuItem;
        private ToolStripMenuItem exportálásToolStripMenuItem;
    }
}