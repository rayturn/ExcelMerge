namespace ExcelMerge
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolTextOnly = new System.Windows.Forms.ToolStripButton();
            this.toolShowFormat = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolPrevColumn = new System.Windows.Forms.ToolStripButton();
            this.toolNextColumn = new System.Windows.Forms.ToolStripButton();
            this.toolPrevRow = new System.Windows.Forms.ToolStripButton();
            this.toolNextRow = new System.Windows.Forms.ToolStripButton();
            this.toolPrevCell = new System.Windows.Forms.ToolStripButton();
            this.toolNextCell = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton9 = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.excelViewLeft = new ExcelMerge.ExcelView();
            this.excelViewRight = new ExcelMerge.ExcelView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripSeparator3,
            this.toolTextOnly,
            this.toolShowFormat,
            this.toolStripSeparator1,
            this.toolPrevColumn,
            this.toolNextColumn,
            this.toolPrevRow,
            this.toolNextRow,
            this.toolPrevCell,
            this.toolNextCell,
            this.toolStripSeparator2,
            this.toolStripButton8,
            this.toolStripButton9});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolStrip1.Size = new System.Drawing.Size(1200, 57);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.AutoSize = false;
            this.toolStripButton2.Enabled = false;
            this.toolStripButton2.Image = global::ExcelMerge.Properties.Resources.icon_1_all;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(26, 37);
            this.toolStripButton2.Text = "All";
            this.toolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Enabled = false;
            this.toolStripButton3.Image = global::ExcelMerge.Properties.Resources.icon_2_diff;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(53, 52);
            this.toolStripButton3.Text = "Diffs";
            this.toolStripButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Enabled = false;
            this.toolStripButton4.Image = global::ExcelMerge.Properties.Resources.icon_3_same;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(61, 52);
            this.toolStripButton4.Text = "Same";
            this.toolStripButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 57);
            // 
            // toolTextOnly
            // 
            this.toolTextOnly.Image = global::ExcelMerge.Properties.Resources.icons_10_text;
            this.toolTextOnly.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolTextOnly.Name = "toolTextOnly";
            this.toolTextOnly.Size = new System.Drawing.Size(107, 52);
            this.toolTextOnly.Text = "No Format";
            this.toolTextOnly.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTextOnly.Click += new System.EventHandler(this.toolTextOnly_Click);
            // 
            // toolShowFormat
            // 
            this.toolShowFormat.Image = global::ExcelMerge.Properties.Resources.icons_11_format;
            this.toolShowFormat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolShowFormat.Name = "toolShowFormat";
            this.toolShowFormat.Size = new System.Drawing.Size(127, 52);
            this.toolShowFormat.Text = "Show Format";
            this.toolShowFormat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolShowFormat.Click += new System.EventHandler(this.toolShowFormat_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 57);
            // 
            // toolPrevColumn
            // 
            this.toolPrevColumn.Enabled = false;
            this.toolPrevColumn.Image = ((System.Drawing.Image)(resources.GetObject("toolPrevColumn.Image")));
            this.toolPrevColumn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPrevColumn.Name = "toolPrevColumn";
            this.toolPrevColumn.Size = new System.Drawing.Size(123, 52);
            this.toolPrevColumn.Text = "Prev Column";
            this.toolPrevColumn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolNextColumn
            // 
            this.toolNextColumn.Enabled = false;
            this.toolNextColumn.Image = ((System.Drawing.Image)(resources.GetObject("toolNextColumn.Image")));
            this.toolNextColumn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolNextColumn.Name = "toolNextColumn";
            this.toolNextColumn.Size = new System.Drawing.Size(127, 52);
            this.toolNextColumn.Text = "Next Column";
            this.toolNextColumn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolPrevRow
            // 
            this.toolPrevRow.Enabled = false;
            this.toolPrevRow.Image = ((System.Drawing.Image)(resources.GetObject("toolPrevRow.Image")));
            this.toolPrevRow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPrevRow.Name = "toolPrevRow";
            this.toolPrevRow.Size = new System.Drawing.Size(97, 52);
            this.toolPrevRow.Text = "Next Row";
            this.toolPrevRow.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolNextRow
            // 
            this.toolNextRow.Enabled = false;
            this.toolNextRow.Image = ((System.Drawing.Image)(resources.GetObject("toolNextRow.Image")));
            this.toolNextRow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolNextRow.Name = "toolNextRow";
            this.toolNextRow.Size = new System.Drawing.Size(93, 52);
            this.toolNextRow.Text = "Prev Row";
            this.toolNextRow.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolPrevCell
            // 
            this.toolPrevCell.Image = ((System.Drawing.Image)(resources.GetObject("toolPrevCell.Image")));
            this.toolPrevCell.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPrevCell.Name = "toolPrevCell";
            this.toolPrevCell.Size = new System.Drawing.Size(88, 52);
            this.toolPrevCell.Text = "Prev Cell";
            this.toolPrevCell.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolPrevCell.Click += new System.EventHandler(this.toolPrevCell_Click);
            // 
            // toolNextCell
            // 
            this.toolNextCell.Image = ((System.Drawing.Image)(resources.GetObject("toolNextCell.Image")));
            this.toolNextCell.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolNextCell.Name = "toolNextCell";
            this.toolNextCell.Size = new System.Drawing.Size(92, 52);
            this.toolNextCell.Text = "Next Cell";
            this.toolNextCell.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolNextCell.Click += new System.EventHandler(this.toolNextCell_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 57);
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.Image = global::ExcelMerge.Properties.Resources.icons_9_swap;
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(60, 52);
            this.toolStripButton8.Text = "Swap";
            this.toolStripButton8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripButton9
            // 
            this.toolStripButton9.Enabled = false;
            this.toolStripButton9.Image = global::ExcelMerge.Properties.Resources.icons_7_reload;
            this.toolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton9.Name = "toolStripButton9";
            this.toolStripButton9.Size = new System.Drawing.Size(74, 52);
            this.toolStripButton9.Text = "Reload";
            this.toolStripButton9.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 57);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.excelViewLeft);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.excelViewRight);
            this.splitContainer1.Size = new System.Drawing.Size(1200, 618);
            this.splitContainer1.SplitterDistance = 600;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 1;
            // 
            // excelViewLeft
            // 
            this.excelViewLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.excelViewLeft.Excel = null;
            this.excelViewLeft.Location = new System.Drawing.Point(0, 0);
            this.excelViewLeft.Margin = new System.Windows.Forms.Padding(6);
            this.excelViewLeft.Name = "excelViewLeft";
            this.excelViewLeft.Size = new System.Drawing.Size(600, 618);
            this.excelViewLeft.TabIndex = 0;
            this.excelViewLeft.ViewType = ExcelMerge.ViewType.Base;
            this.excelViewLeft.SelectFileChanged += new ExcelMerge.ExcelView.SelectedFileChanged(this.excelViewLeft_SelectFileChanged);
            // 
            // excelViewRight
            // 
            this.excelViewRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.excelViewRight.Excel = null;
            this.excelViewRight.Location = new System.Drawing.Point(0, 0);
            this.excelViewRight.Margin = new System.Windows.Forms.Padding(6);
            this.excelViewRight.Name = "excelViewRight";
            this.excelViewRight.Size = new System.Drawing.Size(594, 618);
            this.excelViewRight.TabIndex = 0;
            this.excelViewRight.ViewType = ExcelMerge.ViewType.Base;
            this.excelViewRight.SelectFileChanged += new ExcelMerge.ExcelView.SelectedFileChanged(this.excelViewRight_SelectFileChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1200, 675);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormMain";
            this.Text = "Excel Merge";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolShowFormat;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolPrevColumn;
        private System.Windows.Forms.ToolStripButton toolNextColumn;
        private System.Windows.Forms.ToolStripButton toolPrevRow;
        private System.Windows.Forms.ToolStripButton toolNextCell;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.ToolStripButton toolStripButton9;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private ExcelView excelViewLeft;
        private ExcelView excelViewRight;
        private System.Windows.Forms.ToolStripButton toolNextRow;
        private System.Windows.Forms.ToolStripButton toolPrevCell;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolTextOnly;
    }
}

