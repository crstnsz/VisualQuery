namespace VisualQuery
{
    partial class QueryDesigner
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
            System.Windows.Forms.DataGridView dataGridViewWhere;
            this.colunaDataGridViewComboBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.operationDataGridViewComboBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.valueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.junction = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataSetTable = new System.Data.DataSet();
            this.dataTableWhere = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumnJunction = new System.Data.DataColumn();
            this.splitContainerTables = new System.Windows.Forms.SplitContainer();
            this.splitContainerWork = new System.Windows.Forms.SplitContainer();
            this.tabControlSQL = new System.Windows.Forms.TabControl();
            this.tabPageWhere = new System.Windows.Forms.TabPage();
            this.tabPageSintaxe = new System.Windows.Forms.TabPage();
            this.richTextBoxSQL = new VisualQuery.SQLSyntaxHighlightingTextBox(this.components);
            this.tabPageModeler = new System.Windows.Forms.TabPage();
            this.visualFilters = new VisualQuery.VisualWherePanel();
            this.toolStripContainerFilter = new System.Windows.Forms.ToolStripContainer();
            this.listBoxTables = new System.Windows.Forms.ListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabelFilter = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBoxFilter = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButtonGo = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainerOwner = new System.Windows.Forms.ToolStrip();
            this.toolStripLabelShowTables = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBoxOwner = new System.Windows.Forms.ToolStripComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.splitContainerMaster = new System.Windows.Forms.SplitContainer();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.treeViewSQL = new System.Windows.Forms.TreeView();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            dataGridViewWhere = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(dataGridViewWhere)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableWhere)).BeginInit();
            this.splitContainerTables.Panel1.SuspendLayout();
            this.splitContainerTables.Panel2.SuspendLayout();
            this.splitContainerTables.SuspendLayout();
            this.splitContainerWork.Panel2.SuspendLayout();
            this.splitContainerWork.SuspendLayout();
            this.tabControlSQL.SuspendLayout();
            this.tabPageWhere.SuspendLayout();
            this.tabPageSintaxe.SuspendLayout();
            this.tabPageModeler.SuspendLayout();
            this.toolStripContainerFilter.ContentPanel.SuspendLayout();
            this.toolStripContainerFilter.TopToolStripPanel.SuspendLayout();
            this.toolStripContainerFilter.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStripContainerOwner.SuspendLayout();
            this.splitContainerMaster.Panel1.SuspendLayout();
            this.splitContainerMaster.Panel2.SuspendLayout();
            this.splitContainerMaster.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewWhere
            // 
            dataGridViewWhere.AutoGenerateColumns = false;
            dataGridViewWhere.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewWhere.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colunaDataGridViewComboBoxColumn,
            this.operationDataGridViewComboBoxColumn,
            this.valueDataGridViewTextBoxColumn,
            this.junction});
            dataGridViewWhere.DataMember = "where";
            dataGridViewWhere.DataSource = this.dataSetTable;
            dataGridViewWhere.Dock = System.Windows.Forms.DockStyle.Fill;
            dataGridViewWhere.Location = new System.Drawing.Point(3, 3);
            dataGridViewWhere.Name = "dataGridViewWhere";
            dataGridViewWhere.Size = new System.Drawing.Size(558, 241);
            dataGridViewWhere.TabIndex = 0;
            dataGridViewWhere.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridViewWhere_UserDeletingRow);
            dataGridViewWhere.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewWhere_CellEndEdit);
            // 
            // colunaDataGridViewComboBoxColumn
            // 
            this.colunaDataGridViewComboBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colunaDataGridViewComboBoxColumn.DataPropertyName = "coluna";
            this.colunaDataGridViewComboBoxColumn.HeaderText = "Coluna";
            this.colunaDataGridViewComboBoxColumn.Name = "colunaDataGridViewComboBoxColumn";
            this.colunaDataGridViewComboBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colunaDataGridViewComboBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // operationDataGridViewComboBoxColumn
            // 
            this.operationDataGridViewComboBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.operationDataGridViewComboBoxColumn.DataPropertyName = "operation";
            this.operationDataGridViewComboBoxColumn.HeaderText = "Operação";
            this.operationDataGridViewComboBoxColumn.Items.AddRange(new object[] {
            "=",
            "<>",
            ">",
            ">=",
            "<",
            "<=",
            "LIKE",
            "IS",
            "IN",
            "NOT IN",
            "Exists",
            "Not Exists"});
            this.operationDataGridViewComboBoxColumn.Name = "operationDataGridViewComboBoxColumn";
            this.operationDataGridViewComboBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.operationDataGridViewComboBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.operationDataGridViewComboBoxColumn.Width = 79;
            // 
            // valueDataGridViewTextBoxColumn
            // 
            this.valueDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.valueDataGridViewTextBoxColumn.DataPropertyName = "value";
            this.valueDataGridViewTextBoxColumn.HeaderText = "Valor";
            this.valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
            // 
            // junction
            // 
            this.junction.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.junction.DataPropertyName = "junction";
            this.junction.HeaderText = "E/OU";
            this.junction.Items.AddRange(new object[] {
            "AND",
            "OR"});
            this.junction.Name = "junction";
            this.junction.Width = 41;
            // 
            // dataSetTable
            // 
            this.dataSetTable.DataSetName = "NewDataSet";
            this.dataSetTable.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTableWhere});
            // 
            // dataTableWhere
            // 
            this.dataTableWhere.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumnJunction});
            this.dataTableWhere.TableName = "where";
            // 
            // dataColumn1
            // 
            this.dataColumn1.Caption = "Coluna";
            this.dataColumn1.ColumnName = "coluna";
            // 
            // dataColumn2
            // 
            this.dataColumn2.Caption = "Operação";
            this.dataColumn2.ColumnName = "operation";
            // 
            // dataColumn3
            // 
            this.dataColumn3.Caption = "Valor";
            this.dataColumn3.ColumnName = "value";
            // 
            // dataColumnJunction
            // 
            this.dataColumnJunction.ColumnName = "junction";
            // 
            // splitContainerTables
            // 
            this.splitContainerTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerTables.Location = new System.Drawing.Point(0, 0);
            this.splitContainerTables.Name = "splitContainerTables";
            // 
            // splitContainerTables.Panel1
            // 
            this.splitContainerTables.Panel1.AutoScroll = true;
            this.splitContainerTables.Panel1.Controls.Add(this.splitContainerWork);
            // 
            // splitContainerTables.Panel2
            // 
            this.splitContainerTables.Panel2.Controls.Add(this.toolStripContainerFilter);
            this.splitContainerTables.Size = new System.Drawing.Size(762, 540);
            this.splitContainerTables.SplitterDistance = 572;
            this.splitContainerTables.TabIndex = 0;
            // 
            // splitContainerWork
            // 
            this.splitContainerWork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerWork.Location = new System.Drawing.Point(0, 0);
            this.splitContainerWork.Name = "splitContainerWork";
            this.splitContainerWork.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerWork.Panel1
            // 
            this.splitContainerWork.Panel1.AutoScroll = true;
            this.splitContainerWork.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainerWork_Panel1_Paint);
            this.splitContainerWork.Panel1.DragDrop += new System.Windows.Forms.DragEventHandler(this.splitContainerWork_Panel1_DragDrop);
            this.splitContainerWork.Panel1.DragEnter += new System.Windows.Forms.DragEventHandler(this.splitContainerWork_Panel1_DragEnter);
            // 
            // splitContainerWork.Panel2
            // 
            this.splitContainerWork.Panel2.Controls.Add(this.tabControlSQL);
            this.splitContainerWork.Size = new System.Drawing.Size(572, 540);
            this.splitContainerWork.SplitterDistance = 263;
            this.splitContainerWork.TabIndex = 0;
            // 
            // tabControlSQL
            // 
            this.tabControlSQL.Controls.Add(this.tabPageWhere);
            this.tabControlSQL.Controls.Add(this.tabPageSintaxe);
            this.tabControlSQL.Controls.Add(this.tabPageModeler);
            this.tabControlSQL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSQL.Location = new System.Drawing.Point(0, 0);
            this.tabControlSQL.Name = "tabControlSQL";
            this.tabControlSQL.SelectedIndex = 0;
            this.tabControlSQL.Size = new System.Drawing.Size(572, 273);
            this.tabControlSQL.TabIndex = 1;
            // 
            // tabPageWhere
            // 
            this.tabPageWhere.Controls.Add(dataGridViewWhere);
            this.tabPageWhere.Location = new System.Drawing.Point(4, 22);
            this.tabPageWhere.Name = "tabPageWhere";
            this.tabPageWhere.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageWhere.Size = new System.Drawing.Size(564, 247);
            this.tabPageWhere.TabIndex = 0;
            this.tabPageWhere.Text = "Where";
            this.tabPageWhere.UseVisualStyleBackColor = true;
            // 
            // tabPageSintaxe
            // 
            this.tabPageSintaxe.Controls.Add(this.richTextBoxSQL);
            this.tabPageSintaxe.Location = new System.Drawing.Point(4, 22);
            this.tabPageSintaxe.Name = "tabPageSintaxe";
            this.tabPageSintaxe.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSintaxe.Size = new System.Drawing.Size(564, 247);
            this.tabPageSintaxe.TabIndex = 1;
            this.tabPageSintaxe.Text = "Sintaxe";
            this.tabPageSintaxe.UseVisualStyleBackColor = true;
            // 
            // richTextBoxSQL
            // 
            this.richTextBoxSQL.CaseSensitive = false;
            this.richTextBoxSQL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxSQL.FilterAutoComplete = false;
            this.richTextBoxSQL.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxSQL.Location = new System.Drawing.Point(3, 3);
            this.richTextBoxSQL.MaxUndoRedoSteps = 50;
            this.richTextBoxSQL.Name = "richTextBoxSQL";
            this.richTextBoxSQL.ReadOnly = true;
            this.richTextBoxSQL.Size = new System.Drawing.Size(558, 241);
            this.richTextBoxSQL.TabIndex = 1;
            this.richTextBoxSQL.Text = "";
            this.richTextBoxSQL.WordWrap = false;
            // 
            // tabPageModeler
            // 
            this.tabPageModeler.Controls.Add(this.visualFilters);
            this.tabPageModeler.Location = new System.Drawing.Point(4, 22);
            this.tabPageModeler.Name = "tabPageModeler";
            this.tabPageModeler.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageModeler.Size = new System.Drawing.Size(564, 247);
            this.tabPageModeler.TabIndex = 2;
            this.tabPageModeler.Text = "Modelador";
            this.tabPageModeler.UseVisualStyleBackColor = true;
            // 
            // visualFilters
            // 
            this.visualFilters.BackColor = System.Drawing.SystemColors.Control;
            this.visualFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.visualFilters.Location = new System.Drawing.Point(3, 3);
            this.visualFilters.Name = "visualFilters";
            this.visualFilters.Size = new System.Drawing.Size(558, 241);
            this.visualFilters.TabIndex = 0;
            this.visualFilters.Load += new System.EventHandler(this.visualFilters_Load);
            this.visualFilters.RenderSQL += new System.EventHandler(this.visualFilters_RenderSQL);
            // 
            // toolStripContainerFilter
            // 
            // 
            // toolStripContainerFilter.ContentPanel
            // 
            this.toolStripContainerFilter.ContentPanel.Controls.Add(this.listBoxTables);
            this.toolStripContainerFilter.ContentPanel.Size = new System.Drawing.Size(186, 490);
            this.toolStripContainerFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainerFilter.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainerFilter.Name = "toolStripContainerFilter";
            this.toolStripContainerFilter.Size = new System.Drawing.Size(186, 540);
            this.toolStripContainerFilter.TabIndex = 1;
            this.toolStripContainerFilter.Text = "toolStripContainer1";
            // 
            // toolStripContainerFilter.TopToolStripPanel
            // 
            this.toolStripContainerFilter.TopToolStripPanel.Controls.Add(this.toolStrip1);
            this.toolStripContainerFilter.TopToolStripPanel.Controls.Add(this.toolStripContainerOwner);
            // 
            // listBoxTables
            // 
            this.listBoxTables.AllowDrop = true;
            this.listBoxTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxTables.FormattingEnabled = true;
            this.listBoxTables.Location = new System.Drawing.Point(0, 0);
            this.listBoxTables.Name = "listBoxTables";
            this.listBoxTables.Size = new System.Drawing.Size(186, 485);
            this.listBoxTables.TabIndex = 1;
            this.listBoxTables.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listBoxTables_MouseUp);
            this.listBoxTables.DoubleClick += new System.EventHandler(this.listBoxTables_DoubleClick);
            this.listBoxTables.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBoxTables_MouseDown);
            this.listBoxTables.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBoxTables_DragEnter);
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
            this.toolStrip1.Size = new System.Drawing.Size(172, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripLabelFilter
            // 
            this.toolStripLabelFilter.Name = "toolStripLabelFilter";
            this.toolStripLabelFilter.Size = new System.Drawing.Size(35, 22);
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
            this.toolStripButtonGo.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonGo.Text = "Filtrar";
            this.toolStripButtonGo.Click += new System.EventHandler(this.toolStripButtonGo_Click);
            // 
            // toolStripContainerOwner
            // 
            this.toolStripContainerOwner.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripContainerOwner.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabelShowTables,
            this.toolStripComboBoxOwner});
            this.toolStripContainerOwner.Location = new System.Drawing.Point(3, 25);
            this.toolStripContainerOwner.Name = "toolStripContainerOwner";
            this.toolStripContainerOwner.Size = new System.Drawing.Size(173, 25);
            this.toolStripContainerOwner.TabIndex = 1;
            // 
            // toolStripLabelShowTables
            // 
            this.toolStripLabelShowTables.Name = "toolStripLabelShowTables";
            this.toolStripLabelShowTables.Size = new System.Drawing.Size(44, 22);
            this.toolStripLabelShowTables.Text = "Mostrar";
            // 
            // toolStripComboBoxOwner
            // 
            this.toolStripComboBoxOwner.Name = "toolStripComboBoxOwner";
            this.toolStripComboBoxOwner.Size = new System.Drawing.Size(115, 25);
            this.toolStripComboBoxOwner.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxOwner_SelectedIndexChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // splitContainerMaster
            // 
            this.splitContainerMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMaster.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMaster.Name = "splitContainerMaster";
            // 
            // splitContainerMaster.Panel1
            // 
            this.splitContainerMaster.Panel1.Controls.Add(this.toolStripContainer1);
            // 
            // splitContainerMaster.Panel2
            // 
            this.splitContainerMaster.Panel2.Controls.Add(this.splitContainerTables);
            this.splitContainerMaster.Size = new System.Drawing.Size(904, 540);
            this.splitContainerMaster.SplitterDistance = 138;
            this.splitContainerMaster.TabIndex = 1;
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.treeViewSQL);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(138, 515);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(138, 540);
            this.toolStripContainer1.TabIndex = 1;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // treeViewSQL
            // 
            this.treeViewSQL.AllowDrop = true;
            this.treeViewSQL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewSQL.Location = new System.Drawing.Point(0, 0);
            this.treeViewSQL.Name = "treeViewSQL";
            this.treeViewSQL.Size = new System.Drawing.Size(138, 515);
            this.treeViewSQL.TabIndex = 1;
            this.treeViewSQL.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeViewSQL_MouseUp);
            this.treeViewSQL.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeViewSQL_DragDrop);
            this.treeViewSQL.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeViewSQL_MouseDown);
            this.treeViewSQL.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeViewSQL_DragEnter);
            // 
            // timer2
            // 
            this.timer2.Interval = 500;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // QueryDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerMaster);
            this.Name = "QueryDesigner";
            this.Size = new System.Drawing.Size(904, 540);
            ((System.ComponentModel.ISupportInitialize)(dataGridViewWhere)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableWhere)).EndInit();
            this.splitContainerTables.Panel1.ResumeLayout(false);
            this.splitContainerTables.Panel2.ResumeLayout(false);
            this.splitContainerTables.ResumeLayout(false);
            this.splitContainerWork.Panel2.ResumeLayout(false);
            this.splitContainerWork.ResumeLayout(false);
            this.tabControlSQL.ResumeLayout(false);
            this.tabPageWhere.ResumeLayout(false);
            this.tabPageSintaxe.ResumeLayout(false);
            this.tabPageModeler.ResumeLayout(false);
            this.toolStripContainerFilter.ContentPanel.ResumeLayout(false);
            this.toolStripContainerFilter.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainerFilter.TopToolStripPanel.PerformLayout();
            this.toolStripContainerFilter.ResumeLayout(false);
            this.toolStripContainerFilter.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStripContainerOwner.ResumeLayout(false);
            this.toolStripContainerOwner.PerformLayout();
            this.splitContainerMaster.Panel1.ResumeLayout(false);
            this.splitContainerMaster.Panel2.ResumeLayout(false);
            this.splitContainerMaster.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerTables;
        private System.Windows.Forms.SplitContainer splitContainerWork;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.SplitContainer splitContainerMaster;
        private System.Windows.Forms.ToolStripContainer toolStripContainerFilter;
        private System.Windows.Forms.ListBox listBoxTables;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabelFilter;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxFilter;
        private System.Windows.Forms.ToolStripButton toolStripButtonGo;
        private System.Windows.Forms.TabControl tabControlSQL;
        private System.Windows.Forms.TabPage tabPageWhere;
        private System.Windows.Forms.TabPage tabPageSintaxe;
        private System.Data.DataSet dataSetTable;
        private System.Data.DataTable dataTableWhere;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumnJunction;
        private System.Windows.Forms.DataGridViewComboBoxColumn colunaDataGridViewComboBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn operationDataGridViewComboBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn junction;
        private System.Windows.Forms.TabPage tabPageModeler;
        private VisualWherePanel visualFilters;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ToolStrip toolStripContainerOwner;
        private System.Windows.Forms.ToolStripLabel toolStripLabelShowTables;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxOwner;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.TreeView treeViewSQL;
        private SQLSyntaxHighlightingTextBox richTextBoxSQL;



    }
}
