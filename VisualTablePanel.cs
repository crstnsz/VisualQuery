using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace VisualQuery
{
    public partial class VisualTablePanel : UserControl
    {
        private bool _internalEventsDisable = false;
        internal event ColumnsSelectionChanged ColumnChanged;
        internal event JoinEventHandler JoinChanged;
        private SortedDictionary<string, Column> _columns = new SortedDictionary<string, Column>();


        public VisualTablePanel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Carrega a Coluna visualmente no painel
        /// </summary>
        /// <param name="_table">Table de dados com as colunas</param>
        internal void Load(Table _table)
        {
           int _top = 0;

            foreach (Column _col in _table.Columns)
            {
                this._columns.Add(_col.Name, _col);

                // Caixa de Marcação para marcar as tabelas selecionadas
                CheckBox _cb = new CheckBox();
                _cb.Font = new Font(FontFamily.GenericSansSerif, 8);
                _cb.Top = _top;
                _cb.Left = 5;
                _cb.Width = 18;
                _cb.Height = 18;
                _cb.Text = _col.Name;
                _cb.CheckedChanged += new EventHandler(_cb_CheckedChanged);
                this.Controls.Add(_cb);

                // Textos para visualização do usuário
                TextBox _tb = new TextBox();
                _tb.Text = string.Format("{0} {1} ({2})", _col.Name, (_col.PK)?"(PK)":string.Empty, _col.Type);
                _tb.Top = _top + 4;
                _tb.Left = 25;
                _tb.Width = this.Width - 20;
                _tb.Height = 18;
                _tb.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
                _tb.ReadOnly = true;
                _tb.BorderStyle = BorderStyle.None;
                _tb.BackColor = SystemColors.Window;
                _tb.DragEnter += new DragEventHandler(_tb_DragEnter);
                _tb.DragDrop += new DragEventHandler(_tb_DragDrop);
                _tb.MouseDown += new MouseEventHandler(_tb_MouseDown);
                _tb.Tag = _col.Name;
                _tb.AllowDrop = true;
                
                this.Controls.Add(_tb);
                // Calculando a próxima coluna
                _top += _cb.Height;
                
            }
        }

        void _tb_MouseDown(object sender, MouseEventArgs e)
        {
            if (((TextBox)sender).Tag != null)
                ((TextBox)sender).DoDragDrop(_columns[((TextBox)sender).Tag.ToString()], DragDropEffects.Link);
        }

        void _tb_DragDrop(object sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent(typeof(Column)))
            {
                Column _col = (Column)e.Data.GetData(typeof(Column));
                Column _this = _columns[((TextBox)sender).Tag.ToString()];
                if (_col.Table.Alias != _this.Table.Alias)
                {
                    JoinEventArgs _args = new JoinEventArgs(_col, _this, JoinEventAction.Add);
                    if (JoinChanged != null)
                        JoinChanged(sender, _args);
                }
            }
        }

        void _tb_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Column)))
                e.Effect = DragDropEffects.Link;
        }

        void _cb_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox && !_internalEventsDisable)
            {
                CheckBox _clicked = (CheckBox)sender;

                if (ColumnChanged != null)
                {
                    if (_clicked.Text.Length > 0)
                        ColumnChanged(_columns[_clicked.Text] , _clicked.Checked);
                }
            }
        }

        public void SelectAll()
        {
            foreach (Control _cntrl in this.Controls)
            {
                if (_cntrl is CheckBox)
                {
                    CheckBox _cb = (CheckBox)_cntrl;
                    if (!_cb.Checked)
                    {
                        _cb.Checked = true;
                    }
                }
            }

        }

        public void UnselectAll()
        {
            foreach (Control _cntrl in this.Controls)
            {
                if (_cntrl is CheckBox)
                {
                    CheckBox _cb = (CheckBox)_cntrl;
                    if (_cb.Checked)
                        _cb.Checked = false;
                }
            }
        }

        internal Point GetPositionOnTable(Column coluna)
        {
            foreach (Control _cntrl in this.Controls)
            {
                if (_cntrl is TextBox)
                {
                    TextBox _tb = (TextBox)_cntrl;
                    if (((string)_tb.Tag) == coluna.Name)
                        return new Point(0, _tb.Location.Y + _tb.Height / 2); ;
                }
            }
            return new Point (0,0);
        }

        internal void SetSelectedColumn(Column column, bool value)
        {
            _internalEventsDisable = true;
            foreach (Control _cntrl in this.Controls)
            {
                if (_cntrl is CheckBox)
                {
                    if (_cntrl.Text == column.Name)
                    {
                        ((CheckBox)_cntrl).Checked = value;
                        break;
                    }
                }
            }
            _internalEventsDisable = false;
        }
      
    }
}
