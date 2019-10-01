namespace VisualQuery
{
    partial class ManutExpressao
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
            this.richTextBoxExpression = new System.Windows.Forms.RichTextBox();
            this.buttonPlus = new System.Windows.Forms.Button();
            this.buttonMinus = new System.Windows.Forms.Button();
            this.buttonDivide = new System.Windows.Forms.Button();
            this.buttonMutiply = new System.Windows.Forms.Button();
            this.buttonClosePar = new System.Windows.Forms.Button();
            this.buttonOpenPar = new System.Windows.Forms.Button();
            this.buttonMax = new System.Windows.Forms.Button();
            this.buttonMin = new System.Windows.Forms.Button();
            this.buttonAvg = new System.Windows.Forms.Button();
            this.buttonSum = new System.Windows.Forms.Button();
            this.buttonCount = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelExpression = new System.Windows.Forms.Label();
            this.labelFields = new System.Windows.Forms.Label();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabelFilter = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBoxFilter = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButtonGo = new System.Windows.Forms.ToolStripButton();
            this.treeViewColumns = new System.Windows.Forms.TreeView();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBoxExpression
            // 
            this.richTextBoxExpression.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.richTextBoxExpression.Location = new System.Drawing.Point(12, 22);
            this.richTextBoxExpression.Name = "richTextBoxExpression";
            this.richTextBoxExpression.Size = new System.Drawing.Size(513, 180);
            this.richTextBoxExpression.TabIndex = 0;
            this.richTextBoxExpression.Text = "";
            // 
            // buttonPlus
            // 
            this.buttonPlus.Location = new System.Drawing.Point(531, 21);
            this.buttonPlus.Name = "buttonPlus";
            this.buttonPlus.Size = new System.Drawing.Size(22, 21);
            this.buttonPlus.TabIndex = 1;
            this.buttonPlus.Text = "+";
            this.buttonPlus.UseVisualStyleBackColor = true;
            this.buttonPlus.Click += new System.EventHandler(this.buttonPlus_Click);
            // 
            // buttonMinus
            // 
            this.buttonMinus.Location = new System.Drawing.Point(552, 21);
            this.buttonMinus.Name = "buttonMinus";
            this.buttonMinus.Size = new System.Drawing.Size(22, 21);
            this.buttonMinus.TabIndex = 2;
            this.buttonMinus.Text = "-";
            this.buttonMinus.UseVisualStyleBackColor = true;
            this.buttonMinus.Click += new System.EventHandler(this.buttonMinus_Click);
            // 
            // buttonDivide
            // 
            this.buttonDivide.Location = new System.Drawing.Point(552, 43);
            this.buttonDivide.Name = "buttonDivide";
            this.buttonDivide.Size = new System.Drawing.Size(22, 21);
            this.buttonDivide.TabIndex = 4;
            this.buttonDivide.Text = "/";
            this.buttonDivide.UseVisualStyleBackColor = true;
            this.buttonDivide.Click += new System.EventHandler(this.buttonDivide_Click);
            // 
            // buttonMutiply
            // 
            this.buttonMutiply.Location = new System.Drawing.Point(531, 43);
            this.buttonMutiply.Name = "buttonMutiply";
            this.buttonMutiply.Size = new System.Drawing.Size(22, 21);
            this.buttonMutiply.TabIndex = 3;
            this.buttonMutiply.Text = "x";
            this.buttonMutiply.UseVisualStyleBackColor = true;
            this.buttonMutiply.Click += new System.EventHandler(this.buttonMutiply_Click);
            // 
            // buttonClosePar
            // 
            this.buttonClosePar.Location = new System.Drawing.Point(552, 65);
            this.buttonClosePar.Name = "buttonClosePar";
            this.buttonClosePar.Size = new System.Drawing.Size(22, 21);
            this.buttonClosePar.TabIndex = 6;
            this.buttonClosePar.Text = ")";
            this.buttonClosePar.UseVisualStyleBackColor = true;
            this.buttonClosePar.Click += new System.EventHandler(this.buttonClosePar_Click);
            // 
            // buttonOpenPar
            // 
            this.buttonOpenPar.Location = new System.Drawing.Point(531, 65);
            this.buttonOpenPar.Name = "buttonOpenPar";
            this.buttonOpenPar.Size = new System.Drawing.Size(22, 21);
            this.buttonOpenPar.TabIndex = 5;
            this.buttonOpenPar.Text = "(";
            this.buttonOpenPar.UseVisualStyleBackColor = true;
            this.buttonOpenPar.Click += new System.EventHandler(this.buttonOpenPar_Click);
            // 
            // buttonMax
            // 
            this.buttonMax.Location = new System.Drawing.Point(531, 86);
            this.buttonMax.Name = "buttonMax";
            this.buttonMax.Size = new System.Drawing.Size(43, 23);
            this.buttonMax.TabIndex = 8;
            this.buttonMax.Text = "Max";
            this.buttonMax.UseVisualStyleBackColor = true;
            this.buttonMax.Click += new System.EventHandler(this.buttonMax_Click);
            // 
            // buttonMin
            // 
            this.buttonMin.Location = new System.Drawing.Point(531, 109);
            this.buttonMin.Name = "buttonMin";
            this.buttonMin.Size = new System.Drawing.Size(43, 23);
            this.buttonMin.TabIndex = 9;
            this.buttonMin.Text = "Min";
            this.buttonMin.UseVisualStyleBackColor = true;
            this.buttonMin.Click += new System.EventHandler(this.buttonMin_Click);
            // 
            // buttonAvg
            // 
            this.buttonAvg.Location = new System.Drawing.Point(531, 132);
            this.buttonAvg.Name = "buttonAvg";
            this.buttonAvg.Size = new System.Drawing.Size(43, 23);
            this.buttonAvg.TabIndex = 10;
            this.buttonAvg.Text = "Avg";
            this.buttonAvg.UseVisualStyleBackColor = true;
            this.buttonAvg.Click += new System.EventHandler(this.buttonAvg_Click);
            // 
            // buttonSum
            // 
            this.buttonSum.Location = new System.Drawing.Point(531, 154);
            this.buttonSum.Name = "buttonSum";
            this.buttonSum.Size = new System.Drawing.Size(43, 23);
            this.buttonSum.TabIndex = 11;
            this.buttonSum.Text = "Sum";
            this.buttonSum.UseVisualStyleBackColor = true;
            this.buttonSum.Click += new System.EventHandler(this.buttonSum_Click);
            // 
            // buttonCount
            // 
            this.buttonCount.Location = new System.Drawing.Point(531, 177);
            this.buttonCount.Name = "buttonCount";
            this.buttonCount.Size = new System.Drawing.Size(43, 23);
            this.buttonCount.TabIndex = 12;
            this.buttonCount.Text = "Count";
            this.buttonCount.UseVisualStyleBackColor = true;
            this.buttonCount.Click += new System.EventHandler(this.buttonCount_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Location = new System.Drawing.Point(605, 203);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 22);
            this.buttonOk.TabIndex = 13;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(681, 203);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 22);
            this.buttonCancel.TabIndex = 14;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelExpression
            // 
            this.labelExpression.AutoSize = true;
            this.labelExpression.Location = new System.Drawing.Point(12, 4);
            this.labelExpression.Name = "labelExpression";
            this.labelExpression.Size = new System.Drawing.Size(56, 13);
            this.labelExpression.TabIndex = 15;
            this.labelExpression.Text = "Expressão";
            // 
            // labelFields
            // 
            this.labelFields.AutoSize = true;
            this.labelFields.Location = new System.Drawing.Point(575, 4);
            this.labelFields.Name = "labelFields";
            this.labelFields.Size = new System.Drawing.Size(91, 13);
            this.labelFields.TabIndex = 16;
            this.labelFields.Text = "Coluna da Tabela";
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.treeViewColumns);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(178, 150);
            this.toolStripContainer1.Location = new System.Drawing.Point(578, 25);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(178, 175);
            this.toolStripContainer1.TabIndex = 18;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabelFilter,
            this.toolStripTextBoxFilter,
            this.toolStripButtonGo});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(174, 25);
            this.toolStrip1.TabIndex = 1;
            // 
            // toolStripLabelFilter
            // 
            this.toolStripLabelFilter.Name = "toolStripLabelFilter";
            this.toolStripLabelFilter.Size = new System.Drawing.Size(37, 22);
            this.toolStripLabelFilter.Text = "Filtro:";
            // 
            // toolStripTextBoxFilter
            // 
            this.toolStripTextBoxFilter.Name = "toolStripTextBoxFilter";
            this.toolStripTextBoxFilter.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripButtonGo
            // 
            this.toolStripButtonGo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonGo.Image = global::VisualQuery.Properties.Resources.Run;
            this.toolStripButtonGo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonGo.Name = "toolStripButtonGo";
            this.toolStripButtonGo.Size = new System.Drawing.Size(23, 20);
            this.toolStripButtonGo.Text = "Filtrar";
            this.toolStripButtonGo.Click += new System.EventHandler(this.toolStripButtonGo_Click);
            // 
            // treeViewColumns
            // 
            this.treeViewColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewColumns.Location = new System.Drawing.Point(0, 0);
            this.treeViewColumns.Name = "treeViewColumns";
            this.treeViewColumns.Size = new System.Drawing.Size(178, 150);
            this.treeViewColumns.TabIndex = 8;
            this.treeViewColumns.DoubleClick += new System.EventHandler(this.treeViewColumns_DoubleClick);
            // 
            // ManutExpressao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 240);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.labelFields);
            this.Controls.Add(this.labelExpression);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCount);
            this.Controls.Add(this.buttonSum);
            this.Controls.Add(this.buttonAvg);
            this.Controls.Add(this.buttonMin);
            this.Controls.Add(this.buttonMax);
            this.Controls.Add(this.buttonClosePar);
            this.Controls.Add(this.buttonOpenPar);
            this.Controls.Add(this.buttonDivide);
            this.Controls.Add(this.buttonMutiply);
            this.Controls.Add(this.buttonMinus);
            this.Controls.Add(this.buttonPlus);
            this.Controls.Add(this.richTextBoxExpression);
            this.Name = "ManutExpressao";
            this.Text = "ManutExpressao";
            this.Load += new System.EventHandler(this.ManutExpressao_Load);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxExpression;
        private System.Windows.Forms.Button buttonPlus;
        private System.Windows.Forms.Button buttonMinus;
        private System.Windows.Forms.Button buttonDivide;
        private System.Windows.Forms.Button buttonMutiply;
        private System.Windows.Forms.Button buttonClosePar;
        private System.Windows.Forms.Button buttonOpenPar;
        private System.Windows.Forms.Button buttonMax;
        private System.Windows.Forms.Button buttonMin;
        private System.Windows.Forms.Button buttonAvg;
        private System.Windows.Forms.Button buttonSum;
        private System.Windows.Forms.Button buttonCount;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelExpression;
        private System.Windows.Forms.Label labelFields;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.TreeView treeViewColumns;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabelFilter;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxFilter;
        private System.Windows.Forms.ToolStripButton toolStripButtonGo;
    }
}