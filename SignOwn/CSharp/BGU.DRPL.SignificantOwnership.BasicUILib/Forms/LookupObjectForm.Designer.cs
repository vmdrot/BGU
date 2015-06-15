namespace BGU.DRPL.SignificantOwnership.BasicUILib.Forms
{
    partial class LookupObjectForm<T> : System.Windows.Forms.Form, BGU.DRPL.SignificantOwnership.Core.TypeEditors.IDataSourcedForm<T>
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
            this.grpExistingOrNew = new System.Windows.Forms.GroupBox();
            this.rbNew = new System.Windows.Forms.RadioButton();
            this.rbExisting = new System.Windows.Forms.RadioButton();
            this.propGrid = new System.Windows.Forms.PropertyGrid();
            this.cbxSelectExistingObj = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnFillObject = new System.Windows.Forms.Button();
            this.grpExistingOrNew.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpExistingOrNew
            // 
            this.grpExistingOrNew.Controls.Add(this.rbNew);
            this.grpExistingOrNew.Controls.Add(this.rbExisting);
            this.grpExistingOrNew.Location = new System.Drawing.Point(0, 0);
            this.grpExistingOrNew.Name = "grpExistingOrNew";
            this.grpExistingOrNew.Size = new System.Drawing.Size(362, 36);
            this.grpExistingOrNew.TabIndex = 0;
            this.grpExistingOrNew.TabStop = false;
            this.grpExistingOrNew.Text = "Оберете зі списку чи вводитимете новий";
            // 
            // rbNew
            // 
            this.rbNew.AutoSize = true;
            this.rbNew.Location = new System.Drawing.Point(161, 13);
            this.rbNew.Name = "rbNew";
            this.rbNew.Size = new System.Drawing.Size(95, 17);
            this.rbNew.TabIndex = 1;
            this.rbNew.TabStop = true;
            this.rbNew.Text = "Увести новий";
            this.rbNew.UseVisualStyleBackColor = true;
            // 
            // rbExisting
            // 
            this.rbExisting.AutoSize = true;
            this.rbExisting.Location = new System.Drawing.Point(7, 13);
            this.rbExisting.Name = "rbExisting";
            this.rbExisting.Size = new System.Drawing.Size(111, 17);
            this.rbExisting.TabIndex = 0;
            this.rbExisting.TabStop = true;
            this.rbExisting.Text = "Обрати зі списку";
            this.rbExisting.UseVisualStyleBackColor = true;
            this.rbExisting.CheckedChanged += new System.EventHandler(this.rbExisting_CheckedChanged);
            // 
            // propGrid
            // 
            this.propGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.propGrid.Location = new System.Drawing.Point(0, 69);
            this.propGrid.Name = "propGrid";
            this.propGrid.Size = new System.Drawing.Size(704, 272);
            this.propGrid.TabIndex = 1;
            // 
            // cbxSelectExistingObj
            // 
            this.cbxSelectExistingObj.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxSelectExistingObj.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxSelectExistingObj.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxSelectExistingObj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbxSelectExistingObj.FormattingEnabled = true;
            this.cbxSelectExistingObj.Location = new System.Drawing.Point(0, 42);
            this.cbxSelectExistingObj.Name = "cbxSelectExistingObj";
            this.cbxSelectExistingObj.Size = new System.Drawing.Size(704, 28);
            this.cbxSelectExistingObj.TabIndex = 2;
            this.cbxSelectExistingObj.SelectedIndexChanged += new System.EventHandler(this.cbxSelectExistingObj_SelectedIndexChanged);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(534, 346);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(616, 346);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Can&cel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnFillObject
            // 
            this.btnFillObject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFillObject.Location = new System.Drawing.Point(0, 347);
            this.btnFillObject.Name = "btnFillObject";
            this.btnFillObject.Size = new System.Drawing.Size(19, 20);
            this.btnFillObject.TabIndex = 5;
            this.btnFillObject.Text = "+";
            this.btnFillObject.UseVisualStyleBackColor = true;
            this.btnFillObject.Visible = false;
            this.btnFillObject.Click += new System.EventHandler(this.btnFillObject_Click);
            // 
            // LookupObjectForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(707, 373);
            this.Controls.Add(this.btnFillObject);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cbxSelectExistingObj);
            this.Controls.Add(this.propGrid);
            this.Controls.Add(this.grpExistingOrNew);
            this.Name = "LookupObjectForm";
            this.Text = "LookupObjectForm";
            this.Load += new System.EventHandler(this.LookupObjectForm_Load);
            this.grpExistingOrNew.ResumeLayout(false);
            this.grpExistingOrNew.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpExistingOrNew;
        private System.Windows.Forms.RadioButton rbNew;
        private System.Windows.Forms.RadioButton rbExisting;
        private System.Windows.Forms.PropertyGrid propGrid;
        private System.Windows.Forms.ComboBox cbxSelectExistingObj;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnFillObject;


        
    }
}