namespace ClippingPathVisualizer
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.edJSON = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxCPIdx = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.edRelTxtIdx = new System.Windows.Forms.TextBox();
            this.edRelTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.edCurrShapeJSON = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.edTxtJSON = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Shapes JSON:";
            // 
            // edJSON
            // 
            this.edJSON.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edJSON.Location = new System.Drawing.Point(102, 12);
            this.edJSON.MaxLength = 0;
            this.edJSON.Multiline = true;
            this.edJSON.Name = "edJSON";
            this.edJSON.Size = new System.Drawing.Size(473, 20);
            this.edJSON.TabIndex = 1;
            this.edJSON.TextChanged += new System.EventHandler(this.edJSON_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Location = new System.Drawing.Point(7, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 755);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 43);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Clipping path index:";
            // 
            // cbxCPIdx
            // 
            this.cbxCPIdx.FormattingEnabled = true;
            this.cbxCPIdx.Location = new System.Drawing.Point(104, 40);
            this.cbxCPIdx.Name = "cbxCPIdx";
            this.cbxCPIdx.Size = new System.Drawing.Size(54, 21);
            this.cbxCPIdx.TabIndex = 4;
            this.cbxCPIdx.SelectedIndexChanged += new System.EventHandler(this.cbxCPIdx_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(162, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Rel.TxtIdx";
            // 
            // edRelTxtIdx
            // 
            this.edRelTxtIdx.Location = new System.Drawing.Point(219, 40);
            this.edRelTxtIdx.Name = "edRelTxtIdx";
            this.edRelTxtIdx.ReadOnly = true;
            this.edRelTxtIdx.Size = new System.Drawing.Size(45, 20);
            this.edRelTxtIdx.TabIndex = 6;
            // 
            // edRelTxt
            // 
            this.edRelTxt.Location = new System.Drawing.Point(310, 41);
            this.edRelTxt.Name = "edRelTxt";
            this.edRelTxt.ReadOnly = true;
            this.edRelTxt.Size = new System.Drawing.Size(222, 20);
            this.edRelTxt.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(267, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Rel.Txt";
            // 
            // edCurrShapeJSON
            // 
            this.edCurrShapeJSON.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edCurrShapeJSON.Location = new System.Drawing.Point(580, 41);
            this.edCurrShapeJSON.Name = "edCurrShapeJSON";
            this.edCurrShapeJSON.ReadOnly = true;
            this.edCurrShapeJSON.Size = new System.Drawing.Size(446, 20);
            this.edCurrShapeJSON.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(537, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "JSON:";
            // 
            // edTxtJSON
            // 
            this.edTxtJSON.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edTxtJSON.Location = new System.Drawing.Point(642, 13);
            this.edTxtJSON.MaxLength = 0;
            this.edTxtJSON.Multiline = true;
            this.edTxtJSON.Name = "edTxtJSON";
            this.edTxtJSON.Size = new System.Drawing.Size(389, 20);
            this.edTxtJSON.TabIndex = 12;
            this.edTxtJSON.TextChanged += new System.EventHandler(this.edTxtJSON_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(580, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Txts JSON:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 821);
            this.Controls.Add(this.edTxtJSON);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.edCurrShapeJSON);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.edRelTxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.edRelTxtIdx);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxCPIdx);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.edJSON);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox edJSON;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxCPIdx;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox edRelTxtIdx;
        private System.Windows.Forms.TextBox edRelTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox edCurrShapeJSON;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox edTxtJSON;
        private System.Windows.Forms.Label label6;
    }
}

