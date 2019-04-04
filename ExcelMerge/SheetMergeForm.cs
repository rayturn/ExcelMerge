using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExcelMerge
{
    public partial class SheetMergeForm : Form
    {

        public ExcelPackage leftExcel;
        public ExcelPackage rightExcel;

        bool selectLock = false;

        public SheetMergeForm()
        {
            InitializeComponent();
        }

        public void Init(ExcelPackage left, ExcelPackage right)
        {
            this.leftExcel = left;
            this.rightExcel = right;

            this.SheetsLeft.Items.Clear();
            this.SheetsRight.Items.Clear();

            this.FileLeft.Text = left.File.FullName;
            this.FileRight.Text = right.File.FullName;

            var sheets = ExcelMergeManager.Instance.Sheets;
            var lefts = ExcelMergeManager.Instance.LeftOnlySheets;
            var rights = ExcelMergeManager.Instance.RightOnlySheets;

            foreach (var sheet in this.leftExcel.Workbook.Worksheets)
            {
                var item = this.SheetsLeft.Items.Add(sheet.Index.ToString());
                item.SubItems.Add(sheet.Name);
                if(!sheets.Contains(sheet.Name))
                {
                    if (lefts.Contains(sheet.Name))
                    {//右边删除了
                        item.BackColor = Colors.Deleted;
                    }
                    if(rights.Contains(sheet.Name))
                    {//
                        item.BackColor = Colors.Deleted;
                    }
                }
            }


            foreach (var sheet in this.rightExcel.Workbook.Worksheets)
            {
                var item = this.SheetsRight.Items.Add(sheet.Index.ToString());
                item.SubItems.Add(sheet.Name);
                if (!sheets.Contains(sheet.Name))
                {
                    if (rights.Contains(sheet.Name))
                    {//
                        item.BackColor = Colors.Added;
                        var newItem = SheetsLeft.Items.Insert(item.Index, "-");
                        newItem.BackColor = Colors.Null;
                    }
                }
            }
        }

        private void SheetsLeft_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (this.selectLock) return;
            if(e.IsSelected)
            {
                this.selectLock = true;
                foreach(ListViewItem item in SheetsRight.Items)
                {
                    if (item.SubItems.Count == e.Item.SubItems.Count && item.SubItems[1].Text == e.Item.SubItems[1].Text)
                    {
                        item.Selected = true;
                    }
                    else
                    {
                        item.Selected = false;
                    }
                }
                this.selectLock = false;
            }
        }

        private void SheetsRight_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (this.selectLock) return;
            if (e.IsSelected)
            {
                this.selectLock = true;
                foreach (ListViewItem item in SheetsLeft.Items)
                {
                    if (item.SubItems.Count == e.Item.SubItems.Count && item.SubItems[1].Text == e.Item.SubItems[1].Text)
                    {
                        item.Selected = true;
                    }
                    else
                    {
                        item.Selected = false;
                    }
                }
                this.selectLock = false;
            }
            else
            {
            }
        }
    }
}
