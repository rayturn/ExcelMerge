namespace ExcelMerge
{
    partial class ExcelView
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SheetList = new System.Windows.Forms.ComboBox();
            this.Save = new System.Windows.Forms.Button();
            this.Open = new System.Windows.Forms.Button();
            this.ExcelFile = new System.Windows.Forms.TextBox();
            this.View = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.View)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.SheetList);
            this.panel1.Controls.Add(this.Save);
            this.panel1.Controls.Add(this.Open);
            this.panel1.Controls.Add(this.ExcelFile);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1150, 45);
            this.panel1.TabIndex = 0;
            // 
            // SheetList
            // 
            this.SheetList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SheetList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SheetList.FormattingEnabled = true;
            this.SheetList.Location = new System.Drawing.Point(920, 6);
            this.SheetList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SheetList.Name = "SheetList";
            this.SheetList.Size = new System.Drawing.Size(224, 26);
            this.SheetList.TabIndex = 3;
            this.SheetList.SelectedIndexChanged += new System.EventHandler(this.SheetList_SelectedIndexChanged);
            // 
            // Save
            // 
            this.Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Save.Image = global::ExcelMerge.Properties.Resources.icons_6_save;
            this.Save.Location = new System.Drawing.Point(872, 3);
            this.Save.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(36, 36);
            this.Save.TabIndex = 2;
            this.Save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Save.UseVisualStyleBackColor = true;
            // 
            // Open
            // 
            this.Open.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Open.Image = global::ExcelMerge.Properties.Resources.icons_8_open;
            this.Open.Location = new System.Drawing.Point(830, 3);
            this.Open.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(36, 36);
            this.Open.TabIndex = 1;
            this.Open.UseVisualStyleBackColor = true;
            this.Open.Click += new System.EventHandler(this.Open_Click);
            // 
            // ExcelFile
            // 
            this.ExcelFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ExcelFile.Location = new System.Drawing.Point(4, 4);
            this.ExcelFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ExcelFile.Name = "ExcelFile";
            this.ExcelFile.Size = new System.Drawing.Size(814, 28);
            this.ExcelFile.TabIndex = 0;
            this.ExcelFile.TextChanged += new System.EventHandler(this.ExcelFile_TextChanged);
            // 
            // View
            // 
            this.View.AllowUserToAddRows = false;
            this.View.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Ivory;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.View.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.View.ColumnHeadersHeight = 34;
            this.View.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.View.DefaultCellStyle = dataGridViewCellStyle4;
            this.View.Dock = System.Windows.Forms.DockStyle.Fill;
            this.View.Location = new System.Drawing.Point(0, 45);
            this.View.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.View.Name = "View";
            this.View.ReadOnly = true;
            this.View.RowHeadersWidth = 60;
            this.View.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.View.RowTemplate.Height = 23;
            this.View.Size = new System.Drawing.Size(1150, 739);
            this.View.TabIndex = 1;
            this.View.CurrentCellChanged += new System.EventHandler(this.View_CurrentCellChanged);
            this.View.Scroll += new System.Windows.Forms.ScrollEventHandler(this.View_Scroll);
            // 
            // ExcelView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.View);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ExcelView";
            this.Size = new System.Drawing.Size(1150, 784);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.View)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Open;
        private System.Windows.Forms.TextBox ExcelFile;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.DataGridView View;
        private System.Windows.Forms.ComboBox SheetList;
    }
}
