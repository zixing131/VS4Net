using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace VS4Net
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private async void buttonStart_Click(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"(\-|\+)?\d+(\.\d+)?(\.\d+)?");
            foreach (var item in checkedListBoxVersion.CheckedItems)
            {
                var match = regex.Match(item.ToString());
                var link = $"Microsoft.NETFramework.ReferenceAssemblies.net{match.Value.Replace(".", "")}";
                DownoadManager.Instance.Add(link);
            }
            await DownoadManager.Instance.Start();
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DownoadManager.Instance.Running && MessageBox.Show("Task Still Running, Are You Sure to Cancel?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DownoadManager.Instance.About();
                Application.Exit();
            }
            else
                e.Cancel = true;
        }
    }
}