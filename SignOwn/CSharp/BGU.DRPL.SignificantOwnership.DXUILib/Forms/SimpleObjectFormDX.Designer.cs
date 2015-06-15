namespace BGU.DRPL.SignificantOwnership.DXUILib.Forms
{
    partial class SimpleObjectFormDX
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
            this.components = new System.ComponentModel.Container();
            this.propGrid = new DevExpress.XtraVerticalGrid.PropertyGridControl();
            this.propGridDescr = new DevExpress.XtraVerticalGrid.PropertyDescriptionControl();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.propGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // propGrid
            // 
            this.propGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propGrid.Location = new System.Drawing.Point(1, 1);
            this.propGrid.Name = "propGrid";
            this.propGrid.ShowButtonMode = DevExpress.XtraVerticalGrid.ShowButtonModeEnum.ShowAlways;
            this.propGrid.Size = new System.Drawing.Size(755, 405);
            this.propGrid.TabIndex = 0;
            this.propGrid.ToolTipController = this.toolTipController1;
            // 
            // propGridDescr
            // 
            this.propGridDescr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propGridDescr.Appearance.Caption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.propGridDescr.Appearance.Caption.Options.UseFont = true;
            this.propGridDescr.Appearance.Description.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.propGridDescr.Appearance.Description.Options.UseFont = true;
            this.propGridDescr.Location = new System.Drawing.Point(1, 408);
            this.propGridDescr.Name = "propGridDescr";
            this.propGridDescr.PropertyGrid = this.propGrid;
            this.propGridDescr.Size = new System.Drawing.Size(650, 100);
            this.propGridDescr.TabIndex = 1;
            this.propGridDescr.TabStop = false;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(670, 424);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 25);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "&OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(670, 472);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Can&cel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // SimpleObjectFormDX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 510);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.propGridDescr);
            this.Controls.Add(this.propGrid);
            this.Name = "SimpleObjectFormDX";
            this.Text = "SimpleObjectFormDX";
            this.Load += new System.EventHandler(this.SimpleObjectFormDX_Load);
            ((System.ComponentModel.ISupportInitialize)(this.propGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraVerticalGrid.PropertyGridControl propGrid;
        private DevExpress.XtraVerticalGrid.PropertyDescriptionControl propGridDescr;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.Utils.ToolTipController toolTipController1;
    }
}