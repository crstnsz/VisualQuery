namespace VisualQuery
{
    partial class VisualWhereTable
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
            this.components = new System.ComponentModel.Container();
            this.comboBoxColumn = new System.Windows.Forms.ComboBox();
            this.contextMenuStripWhere = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.buildExpressionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemClear = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBoxOrder = new System.Windows.Forms.ComboBox();
            this.checkBoxShow = new System.Windows.Forms.CheckBox();
            this.textBoxWhere = new System.Windows.Forms.TextBox();
            this.textBoxOr2 = new System.Windows.Forms.TextBox();
            this.textBoxOr1 = new System.Windows.Forms.TextBox();
            this.textBoxOr3 = new System.Windows.Forms.TextBox();
            this.textBoxHaving = new System.Windows.Forms.TextBox();
            this.textBoxOr5 = new System.Windows.Forms.TextBox();
            this.textBoxOr4 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxGroup = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonResize = new System.Windows.Forms.Button();
            this.textBoxTable = new System.Windows.Forms.TextBox();
            this.contextMenuStripWhere.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxColumn
            // 
            this.comboBoxColumn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxColumn.ContextMenuStrip = this.contextMenuStripWhere;
            this.comboBoxColumn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxColumn.FormattingEnabled = true;
            this.comboBoxColumn.Location = new System.Drawing.Point(2, 8);
            this.comboBoxColumn.Name = "comboBoxColumn";
            this.comboBoxColumn.Size = new System.Drawing.Size(144, 21);
            this.comboBoxColumn.TabIndex = 0;
            this.comboBoxColumn.Validating += new System.ComponentModel.CancelEventHandler(this.comboBoxColumn_Validating);
            this.comboBoxColumn.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.comboBoxColumn_MouseDoubleClick);
            this.comboBoxColumn.SelectedIndexChanged += new System.EventHandler(this.comboBoxColumn_SelectedIndexChanged);
            this.comboBoxColumn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.comboBoxColumn_MouseDown);
            this.comboBoxColumn.Click += new System.EventHandler(this.comboBoxColumn_Click);
            // 
            // contextMenuStripWhere
            // 
            this.contextMenuStripWhere.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buildExpressionToolStripMenuItem,
            this.toolStripSeparator1,
            this.toolStripMenuItemUndo,
            this.toolStripSeparator3,
            this.toolStripMenuItemCopy,
            this.toolStripMenuItemPaste,
            this.toolStripMenuItemClear,
            this.toolStripSeparator2,
            this.toolStripMenuItemSelectAll});
            this.contextMenuStripWhere.Name = "contextMenuStripWhere";
            this.contextMenuStripWhere.Size = new System.Drawing.Size(186, 154);
            this.contextMenuStripWhere.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripWhere_Opening);
            // 
            // buildExpressionToolStripMenuItem
            // 
            this.buildExpressionToolStripMenuItem.Name = "buildExpressionToolStripMenuItem";
            this.buildExpressionToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.buildExpressionToolStripMenuItem.Text = "Construir Expressão";
            this.buildExpressionToolStripMenuItem.Click += new System.EventHandler(this.buildExpressionToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(182, 6);
            // 
            // toolStripMenuItemUndo
            // 
            this.toolStripMenuItemUndo.Name = "toolStripMenuItemUndo";
            this.toolStripMenuItemUndo.Size = new System.Drawing.Size(185, 22);
            this.toolStripMenuItemUndo.Text = "Desfazer";
            this.toolStripMenuItemUndo.Click += new System.EventHandler(this.toolStripMenuItemUndo_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(182, 6);
            // 
            // toolStripMenuItemCopy
            // 
            this.toolStripMenuItemCopy.Name = "toolStripMenuItemCopy";
            this.toolStripMenuItemCopy.Size = new System.Drawing.Size(185, 22);
            this.toolStripMenuItemCopy.Text = "Copiar";
            this.toolStripMenuItemCopy.Click += new System.EventHandler(this.toolStripMenuItemCopy_Click);
            // 
            // toolStripMenuItemPaste
            // 
            this.toolStripMenuItemPaste.Name = "toolStripMenuItemPaste";
            this.toolStripMenuItemPaste.Size = new System.Drawing.Size(185, 22);
            this.toolStripMenuItemPaste.Text = "Colar";
            this.toolStripMenuItemPaste.Click += new System.EventHandler(this.toolStripMenuItemPaste_Click);
            // 
            // toolStripMenuItemClear
            // 
            this.toolStripMenuItemClear.Name = "toolStripMenuItemClear";
            this.toolStripMenuItemClear.Size = new System.Drawing.Size(185, 22);
            this.toolStripMenuItemClear.Text = "Excluir";
            this.toolStripMenuItemClear.Click += new System.EventHandler(this.toolStripMenuItemClear_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(182, 6);
            // 
            // toolStripMenuItemSelectAll
            // 
            this.toolStripMenuItemSelectAll.Name = "toolStripMenuItemSelectAll";
            this.toolStripMenuItemSelectAll.Size = new System.Drawing.Size(185, 22);
            this.toolStripMenuItemSelectAll.Text = "Selecionar Tudo";
            this.toolStripMenuItemSelectAll.Click += new System.EventHandler(this.toolStripMenuItemSelectAll_Click);
            // 
            // comboBoxOrder
            // 
            this.comboBoxOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxOrder.FormattingEnabled = true;
            this.comboBoxOrder.Items.AddRange(new object[] {
            "ASC",
            "DESC",
            ""});
            this.comboBoxOrder.Location = new System.Drawing.Point(2, 44);
            this.comboBoxOrder.Name = "comboBoxOrder";
            this.comboBoxOrder.Size = new System.Drawing.Size(144, 21);
            this.comboBoxOrder.TabIndex = 2;
            this.comboBoxOrder.SelectedIndexChanged += new System.EventHandler(this.comboBoxOrder_SelectedIndexChanged);
            // 
            // checkBoxShow
            // 
            this.checkBoxShow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxShow.AutoSize = true;
            this.checkBoxShow.BackColor = System.Drawing.SystemColors.Window;
            this.checkBoxShow.Checked = true;
            this.checkBoxShow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShow.Location = new System.Drawing.Point(69, 69);
            this.checkBoxShow.Name = "checkBoxShow";
            this.checkBoxShow.Size = new System.Drawing.Size(15, 14);
            this.checkBoxShow.TabIndex = 3;
            this.checkBoxShow.UseVisualStyleBackColor = false;
            this.checkBoxShow.CheckedChanged += new System.EventHandler(this.checkBoxShow_CheckedChanged);
            // 
            // textBoxWhere
            // 
            this.textBoxWhere.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxWhere.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxWhere.Location = new System.Drawing.Point(2, 86);
            this.textBoxWhere.Name = "textBoxWhere";
            this.textBoxWhere.Size = new System.Drawing.Size(144, 13);
            this.textBoxWhere.TabIndex = 4;
            this.textBoxWhere.Tag = "1";
            this.textBoxWhere.Validated += new System.EventHandler(this.WhereAndHavingTextChanged);
            // 
            // textBoxOr2
            // 
            this.textBoxOr2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOr2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxOr2.Location = new System.Drawing.Point(2, 114);
            this.textBoxOr2.Name = "textBoxOr2";
            this.textBoxOr2.Size = new System.Drawing.Size(144, 13);
            this.textBoxOr2.TabIndex = 6;
            this.textBoxOr2.Tag = "3";
            this.textBoxOr2.Validated += new System.EventHandler(this.WhereAndHavingTextChanged);
            // 
            // textBoxOr1
            // 
            this.textBoxOr1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOr1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxOr1.Location = new System.Drawing.Point(2, 100);
            this.textBoxOr1.Name = "textBoxOr1";
            this.textBoxOr1.Size = new System.Drawing.Size(144, 13);
            this.textBoxOr1.TabIndex = 5;
            this.textBoxOr1.Tag = "2";
            this.textBoxOr1.Validated += new System.EventHandler(this.WhereAndHavingTextChanged);
            // 
            // textBoxOr3
            // 
            this.textBoxOr3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOr3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxOr3.Location = new System.Drawing.Point(2, 128);
            this.textBoxOr3.Name = "textBoxOr3";
            this.textBoxOr3.Size = new System.Drawing.Size(144, 13);
            this.textBoxOr3.TabIndex = 7;
            this.textBoxOr3.Tag = "4";
            this.textBoxOr3.Validated += new System.EventHandler(this.WhereAndHavingTextChanged);
            // 
            // textBoxHaving
            // 
            this.textBoxHaving.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxHaving.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxHaving.Location = new System.Drawing.Point(2, 190);
            this.textBoxHaving.Name = "textBoxHaving";
            this.textBoxHaving.Size = new System.Drawing.Size(144, 13);
            this.textBoxHaving.TabIndex = 11;
            this.textBoxHaving.Tag = "32767";
            this.textBoxHaving.Validated += new System.EventHandler(this.WhereAndHavingTextChanged);
            // 
            // textBoxOr5
            // 
            this.textBoxOr5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOr5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxOr5.Location = new System.Drawing.Point(2, 156);
            this.textBoxOr5.Name = "textBoxOr5";
            this.textBoxOr5.Size = new System.Drawing.Size(144, 13);
            this.textBoxOr5.TabIndex = 9;
            this.textBoxOr5.Tag = "6";
            this.textBoxOr5.Validated += new System.EventHandler(this.WhereAndHavingTextChanged);
            // 
            // textBoxOr4
            // 
            this.textBoxOr4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOr4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxOr4.Location = new System.Drawing.Point(2, 142);
            this.textBoxOr4.Name = "textBoxOr4";
            this.textBoxOr4.Size = new System.Drawing.Size(144, 13);
            this.textBoxOr4.TabIndex = 8;
            this.textBoxOr4.Tag = "5";
            this.textBoxOr4.Validated += new System.EventHandler(this.WhereAndHavingTextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(2, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 19);
            this.label1.TabIndex = 12;
            // 
            // checkBoxGroup
            // 
            this.checkBoxGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxGroup.AutoSize = true;
            this.checkBoxGroup.BackColor = System.Drawing.SystemColors.Window;
            this.checkBoxGroup.Location = new System.Drawing.Point(69, 173);
            this.checkBoxGroup.Name = "checkBoxGroup";
            this.checkBoxGroup.Size = new System.Drawing.Size(15, 14);
            this.checkBoxGroup.TabIndex = 13;
            this.checkBoxGroup.UseVisualStyleBackColor = false;
            this.checkBoxGroup.CheckedChanged += new System.EventHandler(this.checkBoxGroup_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.SystemColors.Window;
            this.label2.Location = new System.Drawing.Point(2, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 19);
            this.label2.TabIndex = 14;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(-1, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 9);
            this.button1.TabIndex = 15;
            this.button1.Text = "buttonSelectAll";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // buttonResize
            // 
            this.buttonResize.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.buttonResize.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonResize.Location = new System.Drawing.Point(147, 0);
            this.buttonResize.Name = "buttonResize";
            this.buttonResize.Size = new System.Drawing.Size(3, 205);
            this.buttonResize.TabIndex = 16;
            this.buttonResize.Text = "buttonResize";
            this.buttonResize.UseVisualStyleBackColor = true;
            this.buttonResize.MouseMove += new System.Windows.Forms.MouseEventHandler(this.buttonResize_MouseMove);
            this.buttonResize.Click += new System.EventHandler(this.buttonResize_Click);
            this.buttonResize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonResize_MouseDown);
            this.buttonResize.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonResize_MouseUp);
            // 
            // textBoxTable
            // 
            this.textBoxTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTable.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxTable.Location = new System.Drawing.Point(2, 30);
            this.textBoxTable.Name = "textBoxTable";
            this.textBoxTable.ReadOnly = true;
            this.textBoxTable.Size = new System.Drawing.Size(144, 13);
            this.textBoxTable.TabIndex = 17;
            // 
            // VisualWhereTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.textBoxTable);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBoxGroup);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxHaving);
            this.Controls.Add(this.textBoxOr5);
            this.Controls.Add(this.textBoxOr4);
            this.Controls.Add(this.textBoxOr1);
            this.Controls.Add(this.textBoxOr3);
            this.Controls.Add(this.textBoxOr2);
            this.Controls.Add(this.textBoxWhere);
            this.Controls.Add(this.checkBoxShow);
            this.Controls.Add(this.comboBoxOrder);
            this.Controls.Add(this.comboBoxColumn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonResize);
            this.Name = "VisualWhereTable";
            this.Size = new System.Drawing.Size(150, 205);
            this.Resize += new System.EventHandler(this.VisualWhereTable_Resize);
            this.contextMenuStripWhere.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxColumn;
        private System.Windows.Forms.ComboBox comboBoxOrder;
        private System.Windows.Forms.CheckBox checkBoxShow;
        private System.Windows.Forms.TextBox textBoxWhere;
        private System.Windows.Forms.TextBox textBoxOr2;
        private System.Windows.Forms.TextBox textBoxOr1;
        private System.Windows.Forms.TextBox textBoxOr3;
        private System.Windows.Forms.TextBox textBoxHaving;
        private System.Windows.Forms.TextBox textBoxOr5;
        private System.Windows.Forms.TextBox textBoxOr4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxGroup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonResize;
        private System.Windows.Forms.TextBox textBoxTable;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripWhere;
        private System.Windows.Forms.ToolStripMenuItem buildExpressionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemUndo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCopy;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemPaste;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemClear;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSelectAll;
    }
}
