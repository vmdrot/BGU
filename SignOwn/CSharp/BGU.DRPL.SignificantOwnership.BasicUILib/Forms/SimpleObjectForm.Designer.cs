using System.Windows.Forms;
using BGU.DRPL.SignificantOwnership.Core.TypeEditors;
namespace BGU.DRPL.SignificantOwnership.BasicUILib.Forms
{
    partial class SimpleObjectForm<T> : Form, IDataSourcedForm<T>
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.propGrid = new System.Windows.Forms.PropertyGrid();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.statusLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnFillObject = new System.Windows.Forms.Button();
            this.openFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ultimateOwnersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ownershipGraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDgl = new System.Windows.Forms.SaveFileDialog();
            this.ultimateOwnersAsIsMnu = new System.Windows.Forms.ToolStripMenuItem();
            this.ultimateOwnersGroupedMnu = new System.Windows.Forms.ToolStripMenuItem();
            this.asIsOwnersGraphMnu = new System.Windows.Forms.ToolStripMenuItem();
            this.groupedOwnersGraphMnu = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(212, 306);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(294, 306);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Can&cel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // propGrid
            // 
            this.propGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.propGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.propGrid.Location = new System.Drawing.Point(2, 26);
            this.propGrid.Name = "propGrid";
            this.propGrid.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.propGrid.Size = new System.Drawing.Size(385, 277);
            this.propGrid.TabIndex = 2;
            this.propGrid.UseCompatibleTextRendering = true;
            this.propGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propGrid_PropertyValueChanged);
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLbl});
            this.statusBar.Location = new System.Drawing.Point(0, 331);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(389, 22);
            this.statusBar.TabIndex = 3;
            this.statusBar.Text = "statusStrip1";
            // 
            // statusLbl
            // 
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(0, 17);
            // 
            // btnFillObject
            // 
            this.btnFillObject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFillObject.Location = new System.Drawing.Point(1, 308);
            this.btnFillObject.Name = "btnFillObject";
            this.btnFillObject.Size = new System.Drawing.Size(19, 20);
            this.btnFillObject.TabIndex = 4;
            this.btnFillObject.Text = "+";
            this.btnFillObject.UseVisualStyleBackColor = true;
            this.btnFillObject.Visible = false;
            this.btnFillObject.Click += new System.EventHandler(this.btnFillObject_Click);
            // 
            // openFileDlg
            // 
            this.openFileDlg.FileName = "openFileDialog1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.moreToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(389, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "&Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Sa&ve";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveAsToolStripMenuItem.Text = "Save &As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // moreToolStripMenuItem
            // 
            this.moreToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ultimateOwnersToolStripMenuItem,
            this.ownershipGraphToolStripMenuItem});
            this.moreToolStripMenuItem.Name = "moreToolStripMenuItem";
            this.moreToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.moreToolStripMenuItem.Text = "Більше...";
            this.moreToolStripMenuItem.Visible = false;
            // 
            // ultimateOwnersToolStripMenuItem
            // 
            this.ultimateOwnersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ultimateOwnersAsIsMnu,
            this.ultimateOwnersGroupedMnu});
            this.ultimateOwnersToolStripMenuItem.Name = "ultimateOwnersToolStripMenuItem";
            this.ultimateOwnersToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.ultimateOwnersToolStripMenuItem.Text = "Кінцеві власники";
            // 
            // ownershipGraphToolStripMenuItem
            // 
            this.ownershipGraphToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.asIsOwnersGraphMnu,
            this.groupedOwnersGraphMnu});
            this.ownershipGraphToolStripMenuItem.Name = "ownershipGraphToolStripMenuItem";
            this.ownershipGraphToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.ownershipGraphToolStripMenuItem.Text = "Граф власності";
            // 
            // ultimateOwnersAsIsMnu
            // 
            this.ultimateOwnersAsIsMnu.Name = "ultimateOwnersAsIsMnu";
            this.ultimateOwnersAsIsMnu.Size = new System.Drawing.Size(152, 22);
            this.ultimateOwnersAsIsMnu.Text = "як є";
            this.ultimateOwnersAsIsMnu.Click += new System.EventHandler(this.ultimateOwnersAsIsMnu_Click);
            // 
            // ultimateOwnersGroupedMnu
            // 
            this.ultimateOwnersGroupedMnu.Name = "ultimateOwnersGroupedMnu";
            this.ultimateOwnersGroupedMnu.Size = new System.Drawing.Size(152, 22);
            this.ultimateOwnersGroupedMnu.Text = "згруповані";
            this.ultimateOwnersGroupedMnu.Click += new System.EventHandler(this.ultimateOwnersGroupedMnu_Click);
            // 
            // asIsOwnersGraphMnu
            // 
            this.asIsOwnersGraphMnu.Name = "asIsOwnersGraphMnu";
            this.asIsOwnersGraphMnu.Size = new System.Drawing.Size(152, 22);
            this.asIsOwnersGraphMnu.Text = "як є";
            this.asIsOwnersGraphMnu.Click += new System.EventHandler(this.asIsOwnersGraphMnu_Click);
            // 
            // groupedOwnersGraphMnu
            // 
            this.groupedOwnersGraphMnu.Name = "groupedOwnersGraphMnu";
            this.groupedOwnersGraphMnu.Size = new System.Drawing.Size(152, 22);
            this.groupedOwnersGraphMnu.Text = "згруповані";
            this.groupedOwnersGraphMnu.Click += new System.EventHandler(this.groupedOwnersGraphMnu_Click);
            // 
            // SimpleObjectForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(389, 353);
            this.Controls.Add(this.btnFillObject);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.propGrid);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SimpleObjectForm";
            this.Text = "Simple object edit form";
            this.Load += new System.EventHandler(this.DummyForm_Load);
            this.ResizeEnd += new System.EventHandler(this.DummyForm_ResizeEnd);
            this.Resize += new System.EventHandler(this.DummyForm_Resize);
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PropertyGrid propGrid;
        private StatusStrip statusBar;
        private ToolStripStatusLabel statusLbl;
        private Button btnFillObject;
        private OpenFileDialog openFileDlg;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private SaveFileDialog saveFileDgl;
        private ToolStripMenuItem moreToolStripMenuItem;
        private ToolStripMenuItem ultimateOwnersToolStripMenuItem;
        private ToolStripMenuItem ownershipGraphToolStripMenuItem;
        private ToolStripMenuItem ultimateOwnersAsIsMnu;
        private ToolStripMenuItem ultimateOwnersGroupedMnu;
        private ToolStripMenuItem asIsOwnersGraphMnu;
        private ToolStripMenuItem groupedOwnersGraphMnu;
    }
}