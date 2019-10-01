namespace VisualQuery
{
    partial class VisualTable
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
            this.buttonX = new System.Windows.Forms.Button();
            this.labelTableName = new System.Windows.Forms.Label();
            this.checkBoxAll = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.visualTablePanel1 = new VisualQuery.VisualTablePanel();
            this.SuspendLayout();
            // 
            // buttonX
            // 
            this.buttonX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonX.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonX.Font = new System.Drawing.Font("Marlett", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.buttonX.Location = new System.Drawing.Point(118, 4);
            this.buttonX.Name = "buttonX";
            this.buttonX.Size = new System.Drawing.Size(42, 20);
            this.buttonX.TabIndex = 2;
            this.buttonX.Text = "r";
            this.buttonX.UseVisualStyleBackColor = false;
            this.buttonX.Click += new System.EventHandler(this.buttonX_Click);
            // 
            // labelTableName
            // 
            this.labelTableName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTableName.Location = new System.Drawing.Point(25, 7);
            this.labelTableName.Name = "labelTableName";
            this.labelTableName.Size = new System.Drawing.Size(135, 20);
            this.labelTableName.TabIndex = 3;
            this.labelTableName.Text = "[Table Name]";
            this.labelTableName.MouseMove += new System.Windows.Forms.MouseEventHandler(this.labelTableName_MouseMove);
            this.labelTableName.Click += new System.EventHandler(this.labelTableName_Click);
            this.labelTableName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelTableName_MouseDown);
            this.labelTableName.MouseUp += new System.Windows.Forms.MouseEventHandler(this.labelTableName_MouseUp);
            // 
            // checkBoxAll
            // 
            this.checkBoxAll.AutoSize = true;
            this.checkBoxAll.Location = new System.Drawing.Point(8, 7);
            this.checkBoxAll.Name = "checkBoxAll";
            this.checkBoxAll.Size = new System.Drawing.Size(15, 14);
            this.checkBoxAll.TabIndex = 4;
            this.checkBoxAll.UseVisualStyleBackColor = true;
            this.checkBoxAll.CheckedChanged += new System.EventHandler(this.checkBoxAll_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(298, 275);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 2F);
            this.label2.Location = new System.Drawing.Point(157, 221);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(6, 6);
            this.label2.TabIndex = 6;
            this.label2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label2_MouseMove);
            this.label2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label2_MouseDown);
            this.label2.MouseHover += new System.EventHandler(this.label2_MouseHover);
            this.label2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label2_MouseUp);
            // 
            // visualTablePanel1
            // 
            this.visualTablePanel1.AllowDrop = true;
            this.visualTablePanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.visualTablePanel1.AutoScroll = true;
            this.visualTablePanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.visualTablePanel1.BackColor = System.Drawing.Color.White;
            this.visualTablePanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.visualTablePanel1.Location = new System.Drawing.Point(3, 30);
            this.visualTablePanel1.Name = "visualTablePanel1";
            this.visualTablePanel1.Size = new System.Drawing.Size(157, 194);
            this.visualTablePanel1.TabIndex = 1;
            // 
            // VisualTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBoxAll);
            this.Controls.Add(this.buttonX);
            this.Controls.Add(this.visualTablePanel1);
            this.Controls.Add(this.labelTableName);
            this.Name = "VisualTable";
            this.Size = new System.Drawing.Size(163, 227);
            this.MouseLeave += new System.EventHandler(this.VisualTable_MouseLeave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private VisualTablePanel visualTablePanel1;
        private System.Windows.Forms.Button buttonX;
        private System.Windows.Forms.Label labelTableName;
        private System.Windows.Forms.CheckBox checkBoxAll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
