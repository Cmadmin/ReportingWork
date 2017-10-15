namespace ReportingWork.Controls
{
    partial class ColumnSelector
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstTables = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.lstColumns = new System.Windows.Forms.ListBox();
            this.pColumnDetails = new System.Windows.Forms.Panel();
            this.pQuery = new System.Windows.Forms.Panel();
            this.tabProperties = new System.Windows.Forms.TableLayoutPanel();
            this.pQuery.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstTables
            // 
            this.lstTables.FormattingEnabled = true;
            this.lstTables.Location = new System.Drawing.Point(28, 84);
            this.lstTables.Margin = new System.Windows.Forms.Padding(2);
            this.lstTables.Name = "lstTables";
            this.lstTables.Size = new System.Drawing.Size(222, 316);
            this.lstTables.TabIndex = 7;
            this.lstTables.SelectedIndexChanged += new System.EventHandler(this.lstTables_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Select a table to view columns";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(29, 445);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(56, 24);
            this.button4.TabIndex = 22;
            this.button4.Text = "<< Back";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // lstColumns
            // 
            this.lstColumns.FormattingEnabled = true;
            this.lstColumns.Location = new System.Drawing.Point(278, 84);
            this.lstColumns.Margin = new System.Windows.Forms.Padding(2);
            this.lstColumns.Name = "lstColumns";
            this.lstColumns.Size = new System.Drawing.Size(222, 316);
            this.lstColumns.TabIndex = 23;
            this.lstColumns.SelectedIndexChanged += new System.EventHandler(this.lstColumns_SelectedIndexChanged);
            // 
            // pColumnDetails
            // 
            this.pColumnDetails.AutoScroll = true;
            this.pColumnDetails.Location = new System.Drawing.Point(525, 84);
            this.pColumnDetails.Name = "pColumnDetails";
            this.pColumnDetails.Size = new System.Drawing.Size(218, 316);
            this.pColumnDetails.TabIndex = 24;
            // 
            // pQuery
            // 
            this.pQuery.AutoScroll = true;
            this.pQuery.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pQuery.Controls.Add(this.tabProperties);
            this.pQuery.Location = new System.Drawing.Point(767, 84);
            this.pQuery.Name = "pQuery";
            this.pQuery.Size = new System.Drawing.Size(343, 316);
            this.pQuery.TabIndex = 25;
            // 
            // tabProperties
            // 
            this.tabProperties.ColumnCount = 2;
            this.tabProperties.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tabProperties.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tabProperties.Location = new System.Drawing.Point(3, 3);
            this.tabProperties.Name = "tabProperties";
            this.tabProperties.RowCount = 1;
            this.tabProperties.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tabProperties.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tabProperties.Size = new System.Drawing.Size(337, 107);
            this.tabProperties.TabIndex = 0;
            // 
            // ColumnSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pQuery);
            this.Controls.Add(this.pColumnDetails);
            this.Controls.Add(this.lstColumns);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstTables);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ColumnSelector";
            this.Size = new System.Drawing.Size(1130, 547);
            this.pQuery.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstTables;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ListBox lstColumns;
        private System.Windows.Forms.Panel pColumnDetails;
        private System.Windows.Forms.Panel pQuery;
        private System.Windows.Forms.TableLayoutPanel tabProperties;
    }
}
