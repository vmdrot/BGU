namespace BGU.DRPL.SignificantOwnership.BasicUILib.Forms
{
    partial class UltimateOwnersForm
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
            this.dgvw = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvw)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvw
            // 
            this.dgvw.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvw.Location = new System.Drawing.Point(1, 2);
            this.dgvw.Name = "dgvw";
            this.dgvw.Size = new System.Drawing.Size(1007, 362);
            this.dgvw.TabIndex = 0;
            // 
            // UltimateOwnersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 407);
            this.Controls.Add(this.dgvw);
            this.Name = "UltimateOwnersForm";
            this.Text = "UltimateOwnersForm";
            this.Load += new System.EventHandler(this.UltimateOwnersForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvw)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvw;
    }
}