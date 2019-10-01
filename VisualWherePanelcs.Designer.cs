namespace VisualQuery
{
    partial class VisualWherePanel
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
            this.panelUnitsArea = new System.Windows.Forms.Panel();
            this.labelColumn = new System.Windows.Forms.Label();
            this.labelTable = new System.Windows.Forms.Label();
            this.labelOrder = new System.Windows.Forms.Label();
            this.labelShow = new System.Windows.Forms.Label();
            this.labelFilter = new System.Windows.Forms.Label();
            this.labelOr1 = new System.Windows.Forms.Label();
            this.labelOr2 = new System.Windows.Forms.Label();
            this.labelGroup = new System.Windows.Forms.Label();
            this.labelHaving = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panelUnitsArea
            // 
            this.panelUnitsArea.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelUnitsArea.AutoScroll = true;
            this.panelUnitsArea.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panelUnitsArea.Location = new System.Drawing.Point(127, 5);
            this.panelUnitsArea.Name = "panelUnitsArea";
            this.panelUnitsArea.Size = new System.Drawing.Size(843, 223);
            this.panelUnitsArea.TabIndex = 1;
            // 
            // labelColumn
            // 
            this.labelColumn.AutoSize = true;
            this.labelColumn.Location = new System.Drawing.Point(81, 15);
            this.labelColumn.Name = "labelColumn";
            this.labelColumn.Size = new System.Drawing.Size(43, 13);
            this.labelColumn.TabIndex = 0;
            this.labelColumn.Text = "Coluna:";
            // 
            // labelTable
            // 
            this.labelTable.AutoSize = true;
            this.labelTable.Location = new System.Drawing.Point(81, 37);
            this.labelTable.Name = "labelTable";
            this.labelTable.Size = new System.Drawing.Size(43, 13);
            this.labelTable.TabIndex = 1;
            this.labelTable.Text = "Tabela:";
            // 
            // labelOrder
            // 
            this.labelOrder.AutoSize = true;
            this.labelOrder.Location = new System.Drawing.Point(61, 57);
            this.labelOrder.Name = "labelOrder";
            this.labelOrder.Size = new System.Drawing.Size(63, 13);
            this.labelOrder.TabIndex = 2;
            this.labelOrder.Text = "Ordenação:";
            this.labelOrder.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelShow
            // 
            this.labelShow.AutoSize = true;
            this.labelShow.Location = new System.Drawing.Point(76, 75);
            this.labelShow.Name = "labelShow";
            this.labelShow.Size = new System.Drawing.Size(45, 13);
            this.labelShow.TabIndex = 3;
            this.labelShow.Text = "Mostrar:";
            // 
            // labelFilter
            // 
            this.labelFilter.AutoSize = true;
            this.labelFilter.Location = new System.Drawing.Point(92, 92);
            this.labelFilter.Name = "labelFilter";
            this.labelFilter.Size = new System.Drawing.Size(32, 13);
            this.labelFilter.TabIndex = 4;
            this.labelFilter.Text = "Filtro:";
            // 
            // labelOr1
            // 
            this.labelOr1.AutoSize = true;
            this.labelOr1.Location = new System.Drawing.Point(100, 105);
            this.labelOr1.Name = "labelOr1";
            this.labelOr1.Size = new System.Drawing.Size(24, 13);
            this.labelOr1.TabIndex = 5;
            this.labelOr1.Text = "Ou:";
            // 
            // labelOr2
            // 
            this.labelOr2.AutoSize = true;
            this.labelOr2.Location = new System.Drawing.Point(100, 121);
            this.labelOr2.Name = "labelOr2";
            this.labelOr2.Size = new System.Drawing.Size(24, 13);
            this.labelOr2.TabIndex = 6;
            this.labelOr2.Text = "Ou:";
            // 
            // labelGroup
            // 
            this.labelGroup.Location = new System.Drawing.Point(34, 179);
            this.labelGroup.Name = "labelGroup";
            this.labelGroup.Size = new System.Drawing.Size(90, 13);
            this.labelGroup.TabIndex = 7;
            this.labelGroup.Text = "Agrupar:";
            this.labelGroup.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelHaving
            // 
            this.labelHaving.AutoSize = true;
            this.labelHaving.Location = new System.Drawing.Point(31, 195);
            this.labelHaving.Name = "labelHaving";
            this.labelHaving.Size = new System.Drawing.Size(93, 13);
            this.labelHaving.TabIndex = 8;
            this.labelHaving.Text = "Filtros após grupo:";
            // 
            // VisualWherePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.labelHaving);
            this.Controls.Add(this.labelGroup);
            this.Controls.Add(this.panelUnitsArea);
            this.Controls.Add(this.labelOr2);
            this.Controls.Add(this.labelOr1);
            this.Controls.Add(this.labelOrder);
            this.Controls.Add(this.labelFilter);
            this.Controls.Add(this.labelColumn);
            this.Controls.Add(this.labelShow);
            this.Controls.Add(this.labelTable);
            this.Name = "VisualWherePanel";
            this.Size = new System.Drawing.Size(977, 231);
            this.Load += new System.EventHandler(this.VisualWherePanel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelUnitsArea;
        private System.Windows.Forms.Label labelOr2;
        private System.Windows.Forms.Label labelOr1;
        private System.Windows.Forms.Label labelFilter;
        private System.Windows.Forms.Label labelShow;
        private System.Windows.Forms.Label labelOrder;
        private System.Windows.Forms.Label labelTable;
        private System.Windows.Forms.Label labelColumn;
        private System.Windows.Forms.Label labelGroup;
        private System.Windows.Forms.Label labelHaving;

    }
}
