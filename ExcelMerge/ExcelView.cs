using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ExcelMerge
{
    public partial class ExcelView : UserControl
    {
        public ViewType ViewType { get; set; }

        public delegate void SheetChangedHandle(string sheet);
        public event SheetChangedHandle SheetChanged;

        public delegate void ViewScrollHandle(int row,int col);
        public event ViewScrollHandle ViewScrolled;

        public delegate void CurrentCellChangedHandler(DataGridViewCell cell);
        public event CurrentCellChangedHandler CurrentCellChanged;



        public ExcelPackage Excel { get; set; }

        public string Sheet
        {
            get { return this.SheetList.Text; }
        }

        public ExcelView()
        {
            InitializeComponent();

            var DoubleBuffered = this.View.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            DoubleBuffered.SetValue(this.View, true, null);
        }

        public void OpenExcel(ExcelPackage excel)
        {
            Excel = excel;
            this.InitView();
        }

        public void InitView()
        {
            if (this.Excel == null) return;
            this.ExcelFile.Text = this.Excel.File.FullName;

            foreach (ExcelWorksheet sheet in this.Excel.Workbook.Worksheets)
            {
                this.SheetList.Items.Add(sheet.Name);
            }
            this.SheetList.SelectedIndex = 0;
        }

        public void ChangeSheet(string sheet)
        {
            if (this.SheetList.Text != sheet)
                this.SheetList.Text = sheet;
        }


        public void Refreah()
        {
            ExcelWorksheet sheet = this.Excel.Workbook.Worksheets[this.SheetList.Text];
            
            this.View.Visible = false;
            this.View.Enabled = false;
            this.View.Columns.Clear();
            this.View.Rows.Clear();

            if (sheet.Dimension != null)
            {

                for (int i = 1; i <= sheet.Dimension.Columns; i++)
                {
                    this.View.Columns.Add(sheet.Cells[1, i].Text, sheet.Cells[1, i].Text);
                    this.View.Columns[i - 1].SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                int rowCount = sheet.Dimension.Rows;
                this.View.Rows.Add(rowCount);
                for (int row = 0; row < sheet.Dimension.Rows - 1; row++)
                {
                    this.View.Rows[row].HeaderCell.Value = string.Format("{0}", row + 1);
                    this.View.Rows[row].HeaderCell.Style.BackColor = Color.Red;

                    Color bgColor = ExcelColorHelper.GetFillColor(sheet.Row(row + 2).Style.Fill);
                    if (bgColor != Color.Transparent)
                    {
                        this.View.Rows[row].DefaultCellStyle.BackColor = bgColor;
                    }

                    string styleName = sheet.Row(row + 1).StyleName;
                    if (!string.IsNullOrEmpty(styleName))
                    {
                        this.View.Rows[row].ErrorText = styleName;
                    }

                    for (int col = 0; col < sheet.Dimension.Columns; col++)
                    {
                        this.View.Rows[row].Cells[col].Value = sheet.Cells[row + 2, col + 1].Text;
                        var viewCell = this.View.Rows[row].Cells[col];
                        var excelCell = sheet.Cells[row + 2, col + 1];
                        viewCell.Value = excelCell.Text;

                        bgColor = ExcelColorHelper.GetFillColor(excelCell.Style.Fill);
                        if (bgColor != Color.Transparent)
                        {
                            viewCell.Style.BackColor = bgColor;
                        }
                    }
                }
            }
            this.View.Visible = true;
            this.View.Enabled = true;
        }

        private void SheetList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Refreah();
            if (SheetChanged != null)
                SheetChanged(this.SheetList.Text);
        }

        int viewRow = 0;
        int viewCol = 0;
        private void View_Scroll(object sender, ScrollEventArgs e)
        {
            if (!this.View.Visible) return;
            int viewRow = this.View.FirstDisplayedScrollingRowIndex;
            int viewCol = this.View.FirstDisplayedScrollingColumnIndex;
            if (this.ViewScrolled!=null)
            {
                if (this.View.FirstDisplayedScrollingRowIndex>=0 && this.View.FirstDisplayedScrollingColumnIndex >= 0)
                    this.ViewScrolled(this.View.FirstDisplayedScrollingRowIndex, this.View.FirstDisplayedScrollingColumnIndex);
            }
        }


        
        public void SetViewPos(int row, int col)
        {
            if (this.View.FirstDisplayedScrollingRowIndex != row && viewRow != row)
            {
                this.View.FirstDisplayedScrollingRowIndex = row;
            }
            if (this.View.FirstDisplayedScrollingColumnIndex != col && viewCol != col)
            {
                this.View.FirstDisplayedScrollingColumnIndex = col;
            }
        }

        public void GotoDiff(DiffItem diff)
        {
            this.View.ClearSelection();
            if(this.Sheet!=diff.Sheet)
            {
                this.ChangeSheet(diff.Sheet);
            }
            switch(diff.Type)
            {
                case ContentType.Column:
                    for (int c = 0; c < diff.Range.Columns; c++)
                    {
                        for (int r = 0; r < diff.Range.Rows; r++)
                        {
                            this.View.Rows[diff.Range.Start.Row + r - 1].Cells[diff.Range.Start.Column + c - 1].Selected = true;
                        }
                        this.View.CurrentCell = this.View.Rows[diff.Range.Start.Row - 1].Cells[diff.Range.Start.Column - 1];
                    }
                    break;
                case ContentType.Row:
                    for(int i=0;i< diff.Range.Rows;i++)
                    {
                        this.View.Rows[diff.Range.Start.Row + i - 2].Selected = true;
                        this.View.CurrentCell = this.View.Rows[diff.Range.Start.Row - 2].Cells[0];
                    }
                    break;
                case ContentType.Cell:
                    {
                        this.View.Rows[diff.Range.Start.Row - 2].Cells[diff.Range.Start.Column - 1].Selected = true;
                        this.View.CurrentCell = this.View.Rows[diff.Range.Start.Row - 2].Cells[diff.Range.Start.Column - 1];
                    }
                    break;
            }
        }

        DataGridViewCell Current;
        private void View_CurrentCellChanged(object sender, EventArgs e)
        {
            if (!this.View.Visible) return;
            this.Current = this.View.CurrentCell;
            if(CurrentCellChanged!=null)
            {
                this.CurrentCellChanged(this.Current);
            }
        }

        public void SetCurrentCell(DataGridViewCell cell)
        {
            if (cell!=null && this.Current != cell)
            {
                if (cell.RowIndex >= 0 && cell.RowIndex < this.View.RowCount && cell.ColumnIndex >= 0 && cell.ColumnIndex < this.View.ColumnCount)
                    this.View.CurrentCell = this.View.Rows[cell.RowIndex].Cells[cell.ColumnIndex];
            }
        }

    }
}
