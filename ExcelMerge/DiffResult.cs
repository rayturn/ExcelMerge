using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcelMerge
{
    public enum DiffType
    {
        None,
        Add,
        Delete,
        Modify
    }
    public enum ContentType
    {
        None,
        Cell = 0,
        Column = 1,
        Row = 2
    }

    public class DiffItem
    {
        public string Sheet;

        public DiffType Diff;
        public ContentType Type;

        public ExcelRange Range;

        public DiffItem(DiffType diff, ContentType type,string sheet, ExcelRange range)
        {
            this.Sheet = sheet;
            this.Diff = diff;
            this.Type = type;
            this.Range = range;
        }
    }
    class DiffResult
    {
        public List<DiffItem> Diffs = new List<DiffItem>();


        public void Clear()
        {
            this.Diffs.Clear();
        }

        public void AddDiff(DiffType diff,ContentType type, string sheet, ExcelRange range)
        {
            this.Diffs.Add(new DiffItem(diff, type, sheet, range));
        }
    }
}
