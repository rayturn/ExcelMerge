using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ExcelMerge
{
    class ExcelColorHelper
    {
        public static List<Color> Themes = new List<Color>()
        {
            ColorTranslator.FromHtml("#FFFFFF"),
            ColorTranslator.FromHtml("#000000"),
            ColorTranslator.FromHtml("#EEECE1"),
            ColorTranslator.FromHtml("#1F497D"),
            ColorTranslator.FromHtml("#4F81BD"),
            ColorTranslator.FromHtml("#C0504D"),
            ColorTranslator.FromHtml("#9BBB59"),
            ColorTranslator.FromHtml("#8064A2"),
            ColorTranslator.FromHtml("#4BACC6"),
            ColorTranslator.FromHtml("#F79646"),
        };

        public static Color GetFillColor(ExcelFill fill)
        {
            if(fill.PatternType == ExcelFillStyle.None)
            {
                return Color.Transparent;
            }

            if(!Properties.Settings.Default.ShowFormat && fill.PatternType != ExcelMergeManager.Instance.DiffStyle)
            {
                return Color.Transparent;
            }


            if(fill.PatternType == ExcelFillStyle.Solid || fill.PatternType == ExcelMergeManager.Instance.DiffStyle)
            {
                if (string.IsNullOrEmpty(fill.BackgroundColor.Rgb))
                {
                    if(!string.IsNullOrEmpty(fill.BackgroundColor.Theme))
                    {
                        int theme = int.Parse(fill.BackgroundColor.Theme);
                        return GetTintColor(Themes[theme], (double)fill.BackgroundColor.Tint);
                    }
                    if(fill.BackgroundColor.Indexed > 0 && fill.BackgroundColor.Indexed <64)
                    {
                        var col = System.Windows.Media.Imaging.BitmapPalettes.Halftone64.Colors[fill.BackgroundColor.Indexed];
                        return Color.FromArgb(col.A, col.R, col.G, col.B);
                    }
                    if (string.IsNullOrEmpty(fill.PatternColor.Rgb))
                    {
                        if(fill.PatternColor.Indexed > 0 && fill.PatternColor.Indexed < 64)
                        {
                            var col = System.Windows.Media.Imaging.BitmapPalettes.Halftone64.Colors[fill.PatternColor.Indexed];
                            return Color.FromArgb(col.A, col.R, col.G, col.B);
                        }
                        return Color.Transparent;
                    }
                    return ColorTranslator.FromHtml("#" + fill.PatternColor.Rgb);
                }
                    
                return ColorTranslator.FromHtml("#" + fill.BackgroundColor.Rgb);
            }

            switch (fill.PatternType)
            {
                case ExcelFillStyle.Gray125: return Color.Gray;
                case ExcelFillStyle.DarkDown: return Color.DarkGreen;
                case ExcelFillStyle.DarkGray: return Color.DarkGray;
                case ExcelFillStyle.MediumGray: return Color.MediumTurquoise;
                case ExcelFillStyle.LightGray: return Color.LightGray;
                case ExcelFillStyle.Gray0625: return Color.DarkGray;
                case ExcelFillStyle.DarkVertical: return Color.DarkGray;
                case ExcelFillStyle.DarkHorizontal: return Color.DarkGray;
                case ExcelFillStyle.DarkUp: return Color.DarkGray;
                case ExcelFillStyle.DarkGrid: return Color.DarkGray;
                case ExcelFillStyle.DarkTrellis: return Color.DarkGray;
                case ExcelFillStyle.LightVertical: return Color.LightGray;
                case ExcelFillStyle.LightHorizontal: return Color.LightGray;
                case ExcelFillStyle.LightDown: return Color.LightGray;
                case ExcelFillStyle.LightUp: return Color.LightGray;
                case ExcelFillStyle.LightGrid: return Color.LightGray;
                case ExcelFillStyle.LightTrellis: return Color.LightGray;
            }
            return Color.Transparent;
        }

        public static Color GetTintColor(Color color,double tint)
        {
            int iColor = color.ToArgb();
            int iRed = (iColor >> 16) & 0xff;
            iRed = GetTintValue(iRed, tint);
            int iGreen = (iColor >> 8) & 0xff;
            iGreen = GetTintValue(iGreen, tint);
            int iBlue = (iColor) & 0xff;
            iBlue = GetTintValue(iBlue, tint);
            iColor = (iRed << 16) + (iGreen << 8) + iBlue;
            iColor = (int)(iColor | 0xFF000000);
            return  Color.FromArgb(iColor);
        }

        public static int GetTintValue(int color, double tint)
        {
            if (tint < 0)
            {
                return (int)(color * (1 + tint));
            }
            else if (tint > 0)
            {
                return (int)((255 - color) * tint + color);
            }
            else
                return color;
        }
    }
}
