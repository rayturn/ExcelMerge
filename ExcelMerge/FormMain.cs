using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OfficeOpenXml;
using System.IO;

namespace ExcelMerge
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.toolTextOnly.Visible = !Properties.Settings.Default.ShowFormat;
            this.toolShowFormat.Visible = Properties.Settings.Default.ShowFormat;
            ExcelMergeManager.Instance.OpenDiffView(this.excelViewLeft, this.excelViewRight);
            
        }

        private void toolPrevCell_Click(object sender, EventArgs e)
        {
            ExcelMergeManager.Instance.PrevDiff(ContentType.None);
        }

        private void toolNextCell_Click(object sender, EventArgs e)
        {
            ExcelMergeManager.Instance.NextDiff(ContentType.None);
        }

        private void toolTextOnly_Click(object sender, EventArgs e)
        {
            this.toolShowFormat.Visible = true;
            this.toolTextOnly.Visible = false;
            Properties.Settings.Default.ShowFormat = true;
            Properties.Settings.Default.Save();
            MessageBox.Show("Format display will take effect after next startup.");
        }

        private void toolShowFormat_Click(object sender, EventArgs e)
        {
            this.toolTextOnly.Visible = true;
            this.toolShowFormat.Visible = false;
            Properties.Settings.Default.ShowFormat = false;
            Properties.Settings.Default.Save();
            MessageBox.Show("Format display will take effect after next startup.");
        }
    }
}
