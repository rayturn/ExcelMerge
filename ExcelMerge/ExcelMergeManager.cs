using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OfficeOpenXml;
using System.IO;
using System.Windows;
using OfficeOpenXml.Style;

namespace ExcelMerge
{
    class ExcelMergeManager
    {
        public ExcelPackage leftExcel;
        public ExcelPackage rightExcel;

        public ExcelPackage leftExcelDiffed;
        public ExcelPackage rightExcelDiffed;

        private ExcelView leftView;
        private ExcelView rightView;

        public ExcelFillStyle DiffStyle = (ExcelFillStyle)20;

        public List<string> Sheets;
        public List<string> LeftOnlySheets;
        public List<string> RightOnlySheets;

        static ExcelMergeManager instance;
        public static ExcelMergeManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new ExcelMergeManager();
                return instance;
            }
        }

        public bool ShowFormat { get; internal set; }

        public DiffResult Result = new DiffResult();
        private int currentDiff = -1;

        public void OpenDiffView(ExcelView left,ExcelView right)
        {
            this.leftView = left;
            this.rightView = right;

            this.leftView.SheetChanged += LeftView_SheetChanged;
            this.rightView.SheetChanged += RightView_SheetChanged;

            this.leftView.ViewScrolled += LeftView_ViewScrolled;
            this.rightView.ViewScrolled += RightView_ViewScrolled;

            this.leftView.CurrentCellChanged += LeftView_CurrentCellChanged;
            this.rightView.CurrentCellChanged += RightView_CurrentCellChanged;

            this.leftView.OpenExcel(leftExcelDiffed);
            this.rightView.OpenExcel(rightExcelDiffed);

            this.NextDiff(ContentType.None);
        }

        private void RightView_CurrentCellChanged(System.Windows.Forms.DataGridViewCell cell)
        {
            this.leftView.SetCurrentCell(cell);
        }

        private void LeftView_CurrentCellChanged(System.Windows.Forms.DataGridViewCell cell)
        {
            this.rightView.SetCurrentCell(cell);
        }

        private void RightView_ViewScrolled(int row, int col)
        {
            this.leftView.SetViewPos(row, col);
        }

        private void LeftView_ViewScrolled(int row, int col)
        {
            this.rightView.SetViewPos(row, col);
        }

        private void LeftView_SheetChanged(string sheet)
        {
            this.rightView.ChangeSheet(sheet);
        }

        private void RightView_SheetChanged(string sheet)
        {
            this.leftView.ChangeSheet(sheet);
        }

        public bool OpenDiff(string left,string right)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            if (!string.IsNullOrEmpty(left))
                leftExcel = new ExcelPackage(new FileInfo(left));
            if (!string.IsNullOrEmpty(right))
                rightExcel = new ExcelPackage(new FileInfo(right));

            this.Result.Clear();

            this.DiffSheet();
            this.Diff();

            if(this.Result.Diffs.Count == 0)
            {
                MessageBox.Show("The following two files are identical:\r\n\r\n" + left + "\r\n" + right);
                return false;
            }
            return true;
        }

        void DiffSheet()
        {
            HashSet<string> leftSheets = new HashSet<string>();
            for (int i = 0; i < this.leftExcel.Workbook.Worksheets.Count; i++)
            {
                leftSheets.Add(this.leftExcel.Workbook.Worksheets[i].Name);
            }

            HashSet<string> rightSheets = new HashSet<string>();
            for (int i = 0; i < this.rightExcel.Workbook.Worksheets.Count; i++)
            {
                rightSheets.Add(this.rightExcel.Workbook.Worksheets[i].Name);
            }
            LeftOnlySheets = leftSheets.Except(rightSheets).ToList();

            RightOnlySheets = rightSheets.Except(leftSheets).ToList();

            this.Sheets = leftSheets.Intersect(rightSheets).ToList();

            if (LeftOnlySheets.Count > 0 || RightOnlySheets.Count > 0)
            {
                SheetMergeForm dlg = new SheetMergeForm();
                dlg.Init(this.leftExcel, this.rightExcel);
                dlg.ShowDialog();
            }
        }

        public void Diff()
        {
            this.Diff(this.leftExcel, this.rightExcel);
        }

        public void Diff(ExcelPackage left,ExcelPackage right)
        {
            this.leftExcelDiffed = new ExcelPackage(left.File);
            this.rightExcelDiffed = new ExcelPackage(right.File);

            foreach(string sheetName in this.Sheets)
            {
                var leftSheet = leftExcelDiffed.Workbook.Worksheets[sheetName];
                var rightSheet = rightExcelDiffed.Workbook.Worksheets[sheetName];
                if (leftSheet.Dimension == null || rightSheet.Dimension == null) continue;

                HashSet<string> ids = new HashSet<string>();

                int leftCol = 1; int rightCol = 1;
                int idcount = 1;

                for (int i = 1; i <= leftSheet.Dimension.Rows; i++)
                {
                    string id = leftSheet.Cells[i, 1].Text.Trim();
                    if (idcount == 1)
                    {
                        if (ids.Contains(id))
                            idcount++;
                        else
                            ids.Add(id);
                    }
                }

                while (true)
                {
                    if (leftCol > leftSheet.Dimension.Columns && rightCol > rightSheet.Dimension.Columns)
                    {
                        break;
                    }
                    else
                    {
                        if (leftCol > leftSheet.Dimension.Columns)
                        {
                            leftSheet.InsertColumn(leftCol, 1);
                            leftSheet.Column(leftCol).StyleName = "Added";
                            this.Result.AddDiff(DiffType.Add, ContentType.Column, leftSheet.Name, leftSheet.Cells[1, leftCol, leftSheet.Dimension.Rows, leftCol]);
                            leftSheet.Column(leftCol).Style.Fill.PatternType = DiffStyle;
                            leftSheet.Column(leftCol).Style.Fill.BackgroundColor.SetColor(Colors.Null);

                            rightSheet.Column(leftCol).Style.Fill.PatternType = DiffStyle;
                            rightSheet.Column(leftCol).Style.Fill.BackgroundColor.SetColor(Colors.Added);
                            leftCol++;
                            rightCol++;
                            continue;
                        }

                        if (rightCol > rightSheet.Dimension.Columns)
                        {
                            rightSheet.InsertColumn(rightCol, 1);
                            leftSheet.Column(leftCol).StyleName = "Deleted";
                            this.Result.AddDiff(DiffType.Delete, ContentType.Column, leftSheet.Name, leftSheet.Cells[1, leftCol, leftSheet.Dimension.Rows, leftCol]);
                            rightSheet.Column(rightCol).Style.Fill.PatternType = DiffStyle;
                            rightSheet.Column(rightCol).Style.Fill.BackgroundColor.SetColor(Colors.Deleted);

                            rightSheet.Column(rightCol).Style.Fill.PatternType = DiffStyle;
                            rightSheet.Column(rightCol).Style.Fill.BackgroundColor.SetColor(Colors.Null);
                            leftCol++;
                            rightCol++;
                            continue;
                        }
                    }

                    if (leftSheet.Cells[1, leftCol].Text != rightSheet.Cells[1, rightCol].Text)
                    {
                        //target in source =>
                        string leftVal = leftSheet.Cells[1, leftCol].Text;
                        string rightVal = rightSheet.Cells[1, rightCol].Text;

                        int foundInRight = 0;
                        for (int chkCol = leftCol + 1; chkCol < rightSheet.Dimension.Rows; chkCol++)
                        {
                            if (leftSheet.Cells[1, leftCol].Text == rightSheet.Cells[1, chkCol].Text)
                            {
                                foundInRight = chkCol;
                                break;
                            }
                        }

                        int foundInLeft = 0;
                        for (int chkCol = leftCol + 1; chkCol < leftSheet.Dimension.Rows; chkCol++)
                        {
                            if (leftSheet.Cells[1, chkCol].Text == rightSheet.Cells[1, rightCol].Text)
                            {
                                foundInLeft = chkCol;
                                break;
                            }
                        }

                        if (foundInRight == 0 && foundInLeft == 0)
                        {//左右都没找到，说明修改了
                            leftSheet.Column(leftCol).StyleName = "Modified";
                            leftSheet.Column(leftCol).Style.Fill.PatternType = DiffStyle;
                            leftSheet.Column(leftCol).Style.Fill.BackgroundColor.SetColor(Colors.Modified);
                            this.Result.AddDiff(DiffType.Modify, ContentType.Column, leftSheet.Name, leftSheet.Cells[1, leftCol, leftSheet.Dimension.Rows, leftCol]);
                            rightSheet.Column(rightCol).Style.Fill.PatternType = DiffStyle;
                            rightSheet.Column(rightCol).Style.Fill.BackgroundColor.SetColor(Colors.Modified);
                        }
                        else
                        {
                            if (foundInRight > 0)
                            {////左边的在右侧找到了,说明左侧删除了，左侧插入占位
                                rightCol = foundInRight;
                                int difCols = foundInRight - leftCol;
                                leftSheet.InsertColumn(leftCol, difCols);
                                for (int ci = 0; ci < difCols; ci++)
                                {
                                    leftSheet.Column(leftCol + ci).StyleName = "Deleted";
                                    leftSheet.Column(leftCol + ci).Style.Fill.PatternType = DiffStyle;
                                    leftSheet.Column(leftCol + ci).Style.Fill.BackgroundColor.SetColor(Colors.Deleted);

                                    rightSheet.Column(leftCol + ci).Style.Fill.PatternType = DiffStyle;
                                    rightSheet.Column(leftCol + ci).Style.Fill.BackgroundColor.SetColor(Colors.Null);
                                }
                                this.Result.AddDiff(DiffType.Delete, ContentType.Column, leftSheet.Name, leftSheet.Cells[1, leftCol, leftSheet.Dimension.Rows, foundInRight - 1]);
                                leftCol += difCols;
                            }


                            if (foundInLeft > 0)
                            {//右边在左侧找到了,说明左侧新增了，右侧插入占位
                                leftCol = foundInLeft;
                                int difCols = foundInLeft - rightCol;
                                rightSheet.InsertColumn(rightCol, difCols);
                                for (int ci = 0; ci < difCols; ci++)
                                {
                                    rightSheet.Column(rightCol + ci).Style.Fill.PatternType = DiffStyle;
                                    rightSheet.Column(rightCol + ci).Style.Fill.BackgroundColor.SetColor(Colors.Null);

                                    leftSheet.Column(rightCol + ci).StyleName = "Added";
                                    leftSheet.Column(rightCol + ci).Style.Fill.PatternType = DiffStyle;
                                    leftSheet.Column(rightCol + ci).Style.Fill.BackgroundColor.SetColor(Colors.Added);
                                }
                                this.Result.AddDiff(DiffType.Add, ContentType.Row, leftSheet.Name, leftSheet.Cells[1, rightCol, leftSheet.Dimension.Rows, foundInLeft - 1]);
                                rightCol += difCols;
                            }
                        }
                    }
                    leftCol++;
                    rightCol++;
                }


                int leftRow = 2;int rightRow = 2;
                while(true)
                {
                    if (leftRow > leftSheet.Dimension.Rows && rightRow > rightSheet.Dimension.Rows)
                    {
                        break;
                    }
                    else
                    {
                        if (leftRow > leftSheet.Dimension.Rows)
                        {
                            leftSheet.InsertRow(leftRow, 1);
                            leftSheet.Row(leftRow).StyleName = "Added";
                            this.Result.AddDiff(DiffType.Add, ContentType.Row, leftSheet.Name, leftSheet.Cells[leftRow, 1, leftRow, leftSheet.Dimension.Columns]);
                            leftSheet.Row(leftRow).Style.Fill.PatternType = DiffStyle;
                            leftSheet.Row(leftRow).Style.Fill.BackgroundColor.SetColor(Colors.Null);

                            rightSheet.Row(rightRow).Style.Fill.PatternType = DiffStyle;
                            rightSheet.Row(rightRow).Style.Fill.BackgroundColor.SetColor(Colors.Added);
                            leftRow++;
                            rightRow++;
                            continue;
                        }

                        if (rightRow > rightSheet.Dimension.Rows)
                        {
                            rightSheet.InsertRow(rightRow, 1);
                            leftSheet.Row(leftRow).StyleName = "Deleted";
                            this.Result.AddDiff(DiffType.Delete, ContentType.Row, leftSheet.Name, leftSheet.Cells[leftRow, 1, leftRow, leftSheet.Dimension.Columns]);
                            rightSheet.Row(rightRow).Style.Fill.PatternType = DiffStyle;
                            rightSheet.Row(rightRow).Style.Fill.BackgroundColor.SetColor(Colors.Deleted);

                            rightSheet.Row(rightRow).Style.Fill.PatternType = DiffStyle;
                            rightSheet.Row(rightRow).Style.Fill.BackgroundColor.SetColor(Colors.Null);
                            leftRow++;
                            rightRow++;
                            continue;
                        }
                    }

                    if (IsNullRow(leftSheet,leftRow) && !IsNullRow(rightSheet, rightRow))
                    {//Diff Delete Null
                        rightSheet.InsertRow(rightRow, 1);
                        leftSheet.Row(leftRow).StyleName = "Deleted";
                        rightSheet.Row(rightRow).Style.Fill.PatternType = DiffStyle;
                        rightSheet.Row(rightRow).Style.Fill.BackgroundColor.SetColor(Colors.Deleted);

                        this.Result.AddDiff(DiffType.Delete, ContentType.Row, leftSheet.Name, leftSheet.Cells[leftRow, 1, leftRow, leftSheet.Dimension.Columns]);
                        continue;
                    }

                    if (IsNullRow(rightSheet, rightRow) && !IsNullRow(leftSheet, leftRow))
                    {//Diff Added Null
                        leftSheet.InsertRow(leftRow, 1);
                        leftSheet.Row(leftRow).StyleName = "Added";
                        this.Result.AddDiff(DiffType.Add, ContentType.Row, leftSheet.Name, leftSheet.Cells[leftRow, 1, leftRow, leftSheet.Dimension.Columns]);
                        leftSheet.Row(leftRow).Style.Fill.PatternType = DiffStyle;
                        leftSheet.Row(leftRow).Style.Fill.BackgroundColor.SetColor(Colors.Added);
                        continue;
                    }

                    List<int> diffColumns = new List<int>();
                    int weight = RowCompare(leftSheet, leftRow, rightSheet, rightRow, diffColumns, idcount);
                    if(diffColumns.Count == 0)
                    {

                    }
                    else
                    {
                        if (weight > 0)
                        {
                            foreach (var col in diffColumns)
                            {
                                leftSheet.Cells[leftRow,col].StyleName = "Modified";
                                leftSheet.Cells[leftRow, col].Style.Fill.PatternType = DiffStyle;
                                leftSheet.Cells[leftRow, col].Style.Fill.BackgroundColor.SetColor(Colors.Modified);

                                rightSheet.Cells[rightRow, col].StyleName = "Modified";
                                rightSheet.Cells[rightRow, col].Style.Fill.PatternType = DiffStyle;
                                rightSheet.Cells[rightRow, col].Style.Fill.BackgroundColor.SetColor(Colors.Modified);

                                this.Result.AddDiff(DiffType.Modify, ContentType.Cell, leftSheet.Name, leftSheet.Cells[leftRow, col]);
                            }
                        }
                        else
                        {
                            int foundInRight = 0;
                            for (int chkRow = rightRow + 1; chkRow < rightSheet.Dimension.Rows; chkRow++)
                            {
                                weight = RowCompare(leftSheet, leftRow, rightSheet, chkRow, diffColumns, idcount);
                                if (weight >0)
                                {
                                    foundInRight = chkRow;
                                    break;
                                }
                            }

                            int foundInLeft = 0;
                            for (int chkRow = leftRow + 1; chkRow < leftSheet.Dimension.Rows; chkRow++)
                            {
                                weight = RowCompare(leftSheet, chkRow, rightSheet, rightRow, diffColumns, idcount);
                                if (weight > 0)
                                {
                                    foundInLeft = chkRow;
                                    break;
                                }
                            }

                            if (foundInRight == 0 && foundInLeft == 0)
                            {//左右都没找到，说明修改了
                                leftSheet.Row(leftRow).StyleName = "Modified";
                                leftSheet.Row(leftRow).Style.Fill.PatternType = DiffStyle;
                                leftSheet.Row(leftRow).Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Red);
                                this.Result.AddDiff(DiffType.Modify, ContentType.Row, leftSheet.Name, leftSheet.Cells[leftRow, 1, leftRow, leftSheet.Dimension.Columns]);
                                rightSheet.Row(rightRow).Style.Fill.PatternType = DiffStyle;
                                rightSheet.Row(rightRow).Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Red);
                            }
                            else
                            {
                                if (foundInRight > 0)
                                {////左边的在右侧找到了,说明右侧新增，左侧插入占位
                                    rightRow = foundInRight;
                                    int difRows = foundInRight - leftRow;
                                    leftSheet.InsertRow(leftRow, difRows);
                                    for (int ci = 0; ci < difRows; ci++)
                                    {
                                        leftSheet.Row(leftRow + ci).Style.Fill.PatternType = DiffStyle;
                                        leftSheet.Row(leftRow + ci).Style.Fill.BackgroundColor.SetColor(Colors.Null);

                                        rightSheet.Row(leftRow + ci).StyleName = "Added";
                                        rightSheet.Row(leftRow + ci).Style.Fill.PatternType = DiffStyle;
                                        rightSheet.Row(leftRow + ci).Style.Fill.BackgroundColor.SetColor(Colors.Added);
                                    }
                                    this.Result.AddDiff(DiffType.Delete, ContentType.Row, leftSheet.Name, leftSheet.Cells[leftRow, 1, foundInRight - 1, leftSheet.Dimension.Columns]);
                                    leftRow += difRows;
                                }

                                if (foundInLeft > 0)
                                {//右边在左侧找到了,说明右侧删除，右侧插入占位
                                    leftRow = foundInLeft;
                                    int difRows = foundInLeft - rightRow;
                                    rightSheet.InsertRow(rightRow, difRows);
                                    for (int ci = 0; ci < difRows; ci++)
                                    {
                                        rightSheet.Row(rightRow + ci).Style.Fill.PatternType = DiffStyle;
                                        rightSheet.Row(rightRow + ci).Style.Fill.BackgroundColor.SetColor(Colors.Deleted);

                                        leftSheet.Row(rightRow + ci).StyleName = "Deleted";
                                        leftSheet.Row(rightRow + ci).Style.Fill.PatternType = DiffStyle;
                                        leftSheet.Row(rightRow + ci).Style.Fill.BackgroundColor.SetColor(Colors.Null);
                                    }
                                    this.Result.AddDiff(DiffType.Add, ContentType.Row, leftSheet.Name, leftSheet.Cells[rightRow, 1, foundInLeft - 1, leftSheet.Dimension.Columns]);
                                    rightRow += difRows;
                                }
                            }
                        }
                    }

                    leftRow++;
                    rightRow++;
                }
            }
        }

        public void PrevDiff(ContentType type)
        {
            if (this.Result.Diffs.Count == 0) return;
            if (this.currentDiff > 0)
            {
                this.currentDiff--;
            }
            else
            {
                this.currentDiff = 0;
            }
            this.leftView.GotoDiff(this.Result.Diffs[this.currentDiff]);
            this.rightView.GotoDiff(this.Result.Diffs[this.currentDiff]);
        }

        public void NextDiff(ContentType type)
        {
            if (this.Result.Diffs.Count == 0) return;
            if(this.currentDiff<this.Result.Diffs.Count-1)
            {
                this.currentDiff++;
            }
            else
            {
                this.currentDiff = this.Result.Diffs.Count - 1;
            }
            this.leftView.GotoDiff(this.Result.Diffs[this.currentDiff]);
            this.rightView.GotoDiff(this.Result.Diffs[this.currentDiff]);
        }


        public void Refreah()
        {
            this.leftView.Refreah();
            this.rightView.Refreah();
        }


        bool IsNullRow(ExcelWorksheet sheet,int row)
        {
            if (row > sheet.Dimension.Rows) return true;
            for(int i=1;i<=sheet.Dimension.Columns;i++)
            {
                if (!string.IsNullOrEmpty(sheet.Cells[row, i].Text))
                    return false;
            }
            return true;
        }

        int RowCompare(ExcelWorksheet left, int leftRow, ExcelWorksheet right, int rightRow, List<int> result,int idCount)
        {
            result.Clear();
            float sameWeight = 0;
            for (int i = 1; i <= left.Dimension.Columns; i++)
            {
                string lv = left.Cells[leftRow, i].Text;
                string rv = right.Cells[rightRow, i].Text;
                if (lv != rv)
                {
                    result.Add(i);
                }
                else
                {
                        if(idCount == 2)
                        {
                            if (i == 1) sameWeight += 0.5f;
                            if (i == 2) sameWeight += 0.5f;
                        }
                        else
                        {
                            if (i == 1) sameWeight += 1f;
                        }
                }
            }
            return (int)sameWeight;
        }
    }
}
