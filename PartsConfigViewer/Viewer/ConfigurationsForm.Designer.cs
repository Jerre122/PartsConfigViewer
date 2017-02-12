namespace Viewer
{
    partial class ConfigurationsForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.OkBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.outputLogTextBox = new System.Windows.Forms.TextBox();
            this.outputLogLbl = new System.Windows.Forms.Label();
            this.browseOutputBtn = new System.Windows.Forms.Button();
            this.configCacheLbl = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.configCacheTextBox = new System.Windows.Forms.TextBox();
            this.browseConfigCacheBtn = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // OkBtn
            // 
            this.OkBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkBtn.Location = new System.Drawing.Point(421, 87);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(75, 23);
            this.OkBtn.TabIndex = 0;
            this.OkBtn.Text = "Ok";
            this.OkBtn.UseVisualStyleBackColor = true;
            this.OkBtn.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.Location = new System.Drawing.Point(502, 87);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 1;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // outputLogTextBox
            // 
            this.outputLogTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.outputLogTextBox.Location = new System.Drawing.Point(167, 6);
            this.outputLogTextBox.Name = "outputLogTextBox";
            this.outputLogTextBox.Size = new System.Drawing.Size(276, 20);
            this.outputLogTextBox.TabIndex = 2;
            // 
            // outputLogLbl
            // 
            this.outputLogLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.outputLogLbl.AutoSize = true;
            this.outputLogLbl.Location = new System.Drawing.Point(3, 10);
            this.outputLogLbl.Name = "outputLogLbl";
            this.outputLogLbl.Size = new System.Drawing.Size(158, 13);
            this.outputLogLbl.TabIndex = 3;
            this.outputLogLbl.Text = "Output log";
            // 
            // browseOutputBtn
            // 
            this.browseOutputBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.browseOutputBtn.Location = new System.Drawing.Point(449, 5);
            this.browseOutputBtn.Name = "browseOutputBtn";
            this.browseOutputBtn.Size = new System.Drawing.Size(121, 23);
            this.browseOutputBtn.TabIndex = 4;
            this.browseOutputBtn.Text = "Browse";
            this.browseOutputBtn.UseVisualStyleBackColor = true;
            this.browseOutputBtn.Click += new System.EventHandler(this.browseOutputBtn_Click);
            // 
            // configCacheLbl
            // 
            this.configCacheLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.configCacheLbl.AutoSize = true;
            this.configCacheLbl.Location = new System.Drawing.Point(3, 43);
            this.configCacheLbl.Name = "configCacheLbl";
            this.configCacheLbl.Size = new System.Drawing.Size(158, 13);
            this.configCacheLbl.TabIndex = 5;
            this.configCacheLbl.Text = "Modulemanager ConfigCache";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.72986F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.27014F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 126F));
            this.tableLayoutPanel1.Controls.Add(this.browseConfigCacheBtn, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.configCacheTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.outputLogLbl, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.configCacheLbl, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.outputLogTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.browseOutputBtn, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(573, 66);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // configCacheTextBox
            // 
            this.configCacheTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.configCacheTextBox.Location = new System.Drawing.Point(167, 39);
            this.configCacheTextBox.Name = "configCacheTextBox";
            this.configCacheTextBox.Size = new System.Drawing.Size(276, 20);
            this.configCacheTextBox.TabIndex = 6;
            // 
            // browseConfigCacheBtn
            // 
            this.browseConfigCacheBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.browseConfigCacheBtn.Location = new System.Drawing.Point(449, 38);
            this.browseConfigCacheBtn.Name = "browseConfigCacheBtn";
            this.browseConfigCacheBtn.Size = new System.Drawing.Size(121, 23);
            this.browseConfigCacheBtn.TabIndex = 7;
            this.browseConfigCacheBtn.Text = "Browse";
            this.browseConfigCacheBtn.UseVisualStyleBackColor = true;
            this.browseConfigCacheBtn.Click += new System.EventHandler(this.browseConfigCacheBtn_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // ConfigurationsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 122);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.OkBtn);
            this.Name = "ConfigurationsForm";
            this.Text = "ConfigurationsForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OkBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.TextBox outputLogTextBox;
        private System.Windows.Forms.Label outputLogLbl;
        private System.Windows.Forms.Button browseOutputBtn;
        private System.Windows.Forms.Label configCacheLbl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button browseConfigCacheBtn;
        private System.Windows.Forms.TextBox configCacheTextBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}