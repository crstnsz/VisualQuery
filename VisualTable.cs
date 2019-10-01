using System;
using System.Drawing;
using System.Windows.Forms;

namespace VisualQuery
{
    public partial class VisualTable : UserControl
    {
        bool _moveable = false;
        Point startPoint = new Point();
        internal event ColumnsSelectionChanged ColumnChanged;
        internal event JoinEventHandler JoinChanged;
        internal event RemoveTable CloseTable;
        private Table _table;
        private bool _inResizeMode = false;

        public VisualTable()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.Selectable, true);
            this.visualTablePanel1.ColumnChanged += new ColumnsSelectionChanged(visualTablePanel1_ColumnChanged);
            this.visualTablePanel1.JoinChanged += new JoinEventHandler(visualTablePanel1_JoinChanged);
        }

        void visualTablePanel1_JoinChanged(object sender, JoinEventArgs args)
        {
            if (JoinChanged != null)
                JoinChanged(this, args);
        }

        void visualTablePanel1_ColumnChanged(Column column, bool selected)
        {
            if (ColumnChanged != null)
                ColumnChanged(column, selected);
        }

        internal void Load(Table table)
        {
            this.labelTableName.Text = table.Alias;

            this.visualTablePanel1.Load(table);

            this._table = table;

            this.Parent.MouseMove += new MouseEventHandler(Parent_MouseMove);

        }

        void Parent_MouseMove(object sender, MouseEventArgs e)
        {
            // Se está movendo a tabela
            if (this._moveable && e.X > 0 && e.Y > 0)
            {

                this.Location = Point.Subtract(e.Location, new Size(startPoint));
                this.Parent.Invalidate();
            }
    
        }

        private void labelTableName_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this._moveable = true;
                startPoint = e.Location;
            }
        }

        private void labelTableName_MouseMove(object sender, MouseEventArgs e)
        {
            Parent_MouseMove(this, new MouseEventArgs(e.Button, e.Clicks, this.Left + e.X, this.Top + e.Y, e.Delta));
        }

        private void labelTableName_MouseUp(object sender, MouseEventArgs e)
        {
            this._moveable = false;
            this.Parent.Invalidate();
        }

        private void buttonX_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Close()
        {
            if (CloseTable != null)
                CloseTable(_table);
            this.Parent.Controls.Remove(this);
        }

        private void checkBoxAll_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAll.Checked)
                this.visualTablePanel1.SelectAll();
            else
                this.visualTablePanel1.UnselectAll();
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.SizeNWSE;
        }

        private void VisualTable_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void label2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                _inResizeMode = true;
            }

        }

        private void label2_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && _inResizeMode)
                _inResizeMode = false;
        }

        private void label2_MouseMove(object sender, MouseEventArgs e)
        {
            if (this._inResizeMode)
            {
                Size _newSize = new Size(this.PointToClient(label2.PointToScreen(e.Location)));

                // Limite mínimo para tamanho da table
                if (_newSize.Height < 100)
                    _newSize.Height = 100;
                if (_newSize.Width < 100)
                    _newSize.Width = 100;
                    
                this.Size = _newSize;
                
            }
        }

        /// <summary>
        /// Pega a Posicao da coluna na Tabela
        /// </summary>
        /// <param name="coluna">coluna a ser procurada</param>
        /// <returns>retornar o ponto da coluna na tabela</returns>
        internal Point GetPositionOnTable(Column coluna)
        {
            Point _p = visualTablePanel1.GetPositionOnTable(coluna);
            Point _newPoint = Point.Add(Point.Add(this.Location, new Size(this.visualTablePanel1.Location)), new Size(_p));
            if (_newPoint.Y > this.Top + this.Height)
                _newPoint.Y = this.Top + this.Height;
            else if(_newPoint.Y < this.Top)
                _newPoint.Y = this.Top;

            return _newPoint;
        }

        internal Table Table
        {
            get
            {
                return this._table;
            }
        }

        internal void SetSelectedColumn(Column column, bool value)
        {
            visualTablePanel1.SetSelectedColumn(column, value);
        }

        private void labelTableName_Click(object sender, EventArgs e)
        {

        }

        internal void SelectAll()
        {
            checkBoxAll.Checked = true;
        }
    }
}
