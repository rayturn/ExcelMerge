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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(767, 30);
            this.panel1.TabIndex = 0;
            // 
            // SheetList
            // 
            this.SheetList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SheetList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SheetList.FormattingEnabled = true;
            this.SheetList.Location = new System.Drawing.Point(613, 4);
            this.SheetList.Name = "SheetList";
            this.SheetList.Size = new System.Drawing.Size(151, 20);
            this.SheetList.TabIndex = 3;
            this.SheetList.SelectedIndexChanged += new System.EventHandler(this.SheetList_SelectedIndexChanged);
            // 
            // Save
            // 
            this.Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Save.Image = global::ExcelMerge.Properties.Resources.icons_6_save;
            this.Save.Location = new System.Drawing.Point(581, 2);
            this.Save.Margin = new System.Windows.Forms.Padding(1);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(24, 24);
            this.Save.TabIndex = 2;
            this.Save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Save.UseVisualStyleBackColor = true;
            // 
            // Open
            // 
            this.Open.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Open.Image = global::ExcelMerge.Properties.Resources.icons_8_open;
            this.Open.Location = new System.Drawing.Point(553, 2);
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(24, 24);
            this.Open.TabIndex = 1;
            this.Open.UseVisualStyleBackColor = true;
            // 
            // ExcelFile
            // 
            this.ExcelFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ExcelFile.Location = new System.Drawing.Point(3, 3);
            this.ExcelFile.Name = "ExcelFile";
            this.ExcelFile.Size = new System.Drawing.Size(544, 21);
            this.ExcelFile.TabIndex = 0;
            // 
            // View
            // 
            this.View.AllowUserToAddRows = false;
            this.View.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Ivory;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.View.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.View.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.View.DefaultCellStyle = dataGridViewCellStyle2;
            this.View.Dock = System.Windows.Forms.DockStyle.Fill;
            this.View.Location = new System.Drawing.Point(0, 30);
            this.View.Name = "View";
            this.View.ReadOnly = true;
            this.View.RowHeadersWidth = 60;
            this.View.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.View.RowTemplate.Height = 23;
            this.View.Size = new System.Drawing.Size(767, 493);
            this.View.TabIndex = 1;
            this.View.CurrentCellChanged += new System.EventHandler(this.View_CurrentCellChanged);
            this.View.Scroll += new System.Windows.Forms.ScrollEventHandler(this.View_Scroll);
            // 
            // ExcelView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.View);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "ExcelView";
            this.Size = new System.Drawing.Size(767, 523);
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
