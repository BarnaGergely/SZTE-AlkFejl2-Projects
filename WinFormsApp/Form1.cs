using System.Numerics;

namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void list�z�sToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var listPage = new List();
            listPage.ShowDialog();
        }
    }
}