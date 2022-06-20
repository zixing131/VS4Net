using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VS4Net
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void buttonStart_Click(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"(\-|\+)?\d+(\.\d+)?");
            foreach (var item in checkedListBoxVersion.CheckedItems)
            {
                var match = regex.Match(item.ToString());
                var link = $"https://www.nuget.org/packages/Microsoft.NETFramework.ReferenceAssemblies.net{match.Value.Replace(".", "")}";
                DownoadManager.Instance.Add(link);
            }
            DownoadManager.Instance.Start();
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DownoadManager.Instance.Running && MessageBox.Show("Task Still Running, Are You Sure to Cancel ?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DownoadManager.Instance.About();
                Application.Exit();
            }
            else
                e.Cancel = true;
        }
    }
}