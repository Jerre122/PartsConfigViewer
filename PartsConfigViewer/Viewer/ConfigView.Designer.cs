namespace Viewer
{
    partial class ConfigView
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
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.configTreeView = new System.Windows.Forms.TreeView();
            this.generalInfoPanel = new System.Windows.Forms.TableLayoutPanel();
            this.nameLbl = new System.Windows.Forms.Label();
            this.typeLbl = new System.Windows.Forms.Label();
            this.parentUrlLbl = new System.Windows.Forms.Label();
            this.urlLbl = new System.Windows.Forms.Label();
            this.nameTxtBox = new System.Windows.Forms.TextBox();
            this.typeTxtBox = new System.Windows.Forms.TextBox();
            this.parentUrlTxtBox = new System.Windows.Forms.TextBox();
            this.urlTxtBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.generalInfoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.generalInfoPanel);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.splitContainer.Size = new System.Drawing.Size(494, 378);
            this.splitContainer.SplitterDistance = 255;
            this.splitContainer.TabIndex = 0;
            // 
            // configTreeView
            // 
            this.generalInfoPanel.SetColumnSpan(this.configTreeView, 2);
            this.configTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.configTreeView.Location = new System.Drawing.Point(3, 107);
            this.configTreeView.Name = "configTreeView";
            this.configTreeView.Size = new System.Drawing.Size(249, 268);
            this.configTreeView.TabIndex = 0;
            // 
            // generalInfoPanel
            // 
            this.generalInfoPanel.AutoSize = true;
            this.generalInfoPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.generalInfoPanel.ColumnCount = 2;
            this.generalInfoPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.generalInfoPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.generalInfoPanel.Controls.Add(this.urlTxtBox, 1, 3);
            this.generalInfoPanel.Controls.Add(this.configTreeView, 0, 4);
            this.generalInfoPanel.Controls.Add(this.parentUrlTxtBox, 1, 2);
            this.generalInfoPanel.Controls.Add(this.typeTxtBox, 1, 1);
            this.generalInfoPanel.Controls.Add(this.nameLbl, 0, 0);
            this.generalInfoPanel.Controls.Add(this.typeLbl, 0, 1);
            this.generalInfoPanel.Controls.Add(this.urlLbl, 0, 3);
            this.generalInfoPanel.Controls.Add(this.parentUrlLbl, 0, 2);
            this.generalInfoPanel.Controls.Add(this.nameTxtBox, 1, 0);
            this.generalInfoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.generalInfoPanel.Location = new System.Drawing.Point(0, 0);
            this.generalInfoPanel.Name = "generalInfoPanel";
            this.generalInfoPanel.RowCount = 5;
            this.generalInfoPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.generalInfoPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.generalInfoPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.generalInfoPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.generalInfoPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.generalInfoPanel.Size = new System.Drawing.Size(255, 378);
            this.generalInfoPanel.TabIndex = 1;
            // 
            // nameLbl
            // 
            this.nameLbl.AutoSize = true;
            this.nameLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nameLbl.Location = new System.Drawing.Point(3, 0);
            this.nameLbl.Name = "nameLbl";
            this.nameLbl.Size = new System.Drawing.Size(66, 26);
            this.nameLbl.TabIndex = 0;
            this.nameLbl.Text = "Name:";
            this.nameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // typeLbl
            // 
            this.typeLbl.AutoSize = true;
            this.typeLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.typeLbl.Location = new System.Drawing.Point(3, 26);
            this.typeLbl.Name = "typeLbl";
            this.typeLbl.Size = new System.Drawing.Size(66, 26);
            this.typeLbl.TabIndex = 1;
            this.typeLbl.Text = "Type:";
            this.typeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // parentUrlLbl
            // 
            this.parentUrlLbl.AutoSize = true;
            this.parentUrlLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.parentUrlLbl.Location = new System.Drawing.Point(3, 52);
            this.parentUrlLbl.Name = "parentUrlLbl";
            this.parentUrlLbl.Size = new System.Drawing.Size(66, 26);
            this.parentUrlLbl.TabIndex = 2;
            this.parentUrlLbl.Text = "Parent URL:";
            this.parentUrlLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // urlLbl
            // 
            this.urlLbl.AutoSize = true;
            this.urlLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.urlLbl.Location = new System.Drawing.Point(3, 78);
            this.urlLbl.Name = "urlLbl";
            this.urlLbl.Size = new System.Drawing.Size(66, 26);
            this.urlLbl.TabIndex = 3;
            this.urlLbl.Text = "URL:";
            this.urlLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nameTxtBox
            // 
            this.nameTxtBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nameTxtBox.Enabled = false;
            this.nameTxtBox.Location = new System.Drawing.Point(75, 3);
            this.nameTxtBox.Name = "nameTxtBox";
            this.nameTxtBox.Size = new System.Drawing.Size(177, 20);
            this.nameTxtBox.TabIndex = 4;
            // 
            // typeTxtBox
            // 
            this.typeTxtBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.typeTxtBox.Enabled = false;
            this.typeTxtBox.Location = new System.Drawing.Point(75, 29);
            this.typeTxtBox.Name = "typeTxtBox";
            this.typeTxtBox.Size = new System.Drawing.Size(177, 20);
            this.typeTxtBox.TabIndex = 5;
            // 
            // parentUrlTxtBox
            // 
            this.parentUrlTxtBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.parentUrlTxtBox.Enabled = false;
            this.parentUrlTxtBox.Location = new System.Drawing.Point(75, 55);
            this.parentUrlTxtBox.Name = "parentUrlTxtBox";
            this.parentUrlTxtBox.Size = new System.Drawing.Size(177, 20);
            this.parentUrlTxtBox.TabIndex = 6;
            // 
            // urlTxtBox
            // 
            this.urlTxtBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.urlTxtBox.Enabled = false;
            this.urlTxtBox.Location = new System.Drawing.Point(75, 81);
            this.urlTxtBox.Name = "urlTxtBox";
            this.urlTxtBox.Size = new System.Drawing.Size(177, 20);
            this.urlTxtBox.TabIndex = 7;
            // 
            // ConfigView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Name = "ConfigView";
            this.Size = new System.Drawing.Size(494, 378);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.generalInfoPanel.ResumeLayout(false);
            this.generalInfoPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TreeView configTreeView;
        private System.Windows.Forms.TableLayoutPanel generalInfoPanel;
        private System.Windows.Forms.TextBox urlTxtBox;
        private System.Windows.Forms.TextBox parentUrlTxtBox;
        private System.Windows.Forms.TextBox typeTxtBox;
        private System.Windows.Forms.Label nameLbl;
        private System.Windows.Forms.Label typeLbl;
        private System.Windows.Forms.Label urlLbl;
        private System.Windows.Forms.Label parentUrlLbl;
        private System.Windows.Forms.TextBox nameTxtBox;
    }
}
