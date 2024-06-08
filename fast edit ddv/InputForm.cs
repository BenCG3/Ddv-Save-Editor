using System;
using System.Windows.Forms;

namespace ddv_edit
{
	public partial class InputForm : Form
	{
		public string InputValue { get; private set; }

		public InputForm()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void buttonOk_Click(object sender, EventArgs e)
		{
			InputValue = textBoxInput.Text;
			DialogResult = DialogResult.OK;
			Close();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}
