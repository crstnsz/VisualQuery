using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Literal;

namespace VisualQuery
{
    public partial class VisualWhereTable : UserControl
    {
#region Definion
        private Query _query = null;
        private Column _selectedColumn = null;
        private List<Where>[] _selectedWhere = { new List<Where>(), new List<Where>(), new List<Where>(), new List<Where>(), new List<Where>(), new List<Where>(), new List<Where>() };
        private List<Where> _selectecdHaving = new List<Where>();
        private Order _selectedOrder = null;
        public event EventHandler RenderSQL = null;
        internal event ColumnsSelectionChanged ShowColumnChanged = null;
        internal event EventHandler RedrawWhere = null;
        internal event ResizeVisualWhereTableHandler ResizeVisualWhereTable = null; 
        private int _index = -1;
        private bool _noRedrawWhere = false;
        private bool _externalAdition = false;
#endregion

#region Traduz Tela
        private void TraduzTela()
        {
            toolStripMenuItemClear.Text = Literal.LiteralManager.GetLiteral("apagar");
            toolStripMenuItemCopy.Text = Literal.LiteralManager.GetLiteral("copiar");
            toolStripMenuItemPaste.Text = Literal.LiteralManager.GetLiteral("colar");
            toolStripMenuItemSelectAll.Text = Literal.LiteralManager.GetLiteral("selecionar_tudo");
            toolStripMenuItemUndo.Text = Literal.LiteralManager.GetLiteral("desfazer");
            buildExpressionToolStripMenuItem.Text = Literal.LiteralManager.GetLiteral("construir_expressao");
        }
#endregion

#region Constructors
        public VisualWhereTable()
        {
            InitializeComponent();
            TraduzTela();
        }
#endregion

#region Properties
        public Query Query
        {
            get { return this._query; }
            set { this._query = value; }
        }

        internal List<Where>[] Where
        {
            get
            {
                return _selectedWhere;
            }
        }

        internal List<Where> Having
        {
            get
            {
                return _selectecdHaving;
            }
        }

        internal Column SelectedColumn
        {
            get { return this._selectedColumn; }
            set 
            { 
                this._selectedColumn = value;
                this.LoadColumn();
            }
        }

        internal Table Table
        {
            get
            {
                if (this.IsEmpty())
                    return null;
                return this._selectedColumn.Table;
            }
        }

        internal bool ShowData
        {
            get { return this.checkBoxShow.Checked; }
            set { this.checkBoxShow.Checked = value; }
        }

        internal bool Group
        {
            get { return this.checkBoxGroup.Checked; }
            set { this.checkBoxGroup.Checked = value; }
        }

        internal int Index
        {
            get { return this._index; }
            set { this._index = value; }
        }

#endregion

#region Methods
        /// <summary>
        /// Atualiza os dados dos ComboBox
        /// </summary>
        public void Refresh()
        {
            this.comboBoxColumn.Items.Clear();
        }

        public void AddItensFromDataBase()
        {
            if (this.Query != null)
            {
                foreach (Table _tab in this.Query.Tables)
                {
                    foreach (Column _col in _tab.Columns)
                        this.comboBoxColumn.Items.Add(_col.FullName);
                }
            }
        }

        public void BeginExternalAdition()
        {
            _externalAdition = true;
        }

        public void EndExternalAdition()
        {
            _externalAdition = false;
        }

        private void LoadColumn()
        {
            if (_selectedColumn != null)
            {
                this.comboBoxColumn.Text = _selectedColumn.FullName;
                if (_selectedColumn.Table != null)
                    this.textBoxTable.Text = _selectedColumn.Table.FullName;
            }
        }

        public void LoadColumnByName(string columnName)
        {
            this.comboBoxColumn.Text = columnName;
            this.DoChangeColumnName();
        }

        /// <summary>
        /// Se a Unidade está sem dados
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return this._selectedColumn == null;
        }
        
        /// <summary>
        /// Limpa as informações da Unidade de Filtro
        /// </summary>
        public void Clear()
        {
            if (this.IsEmpty())
                return;

            // Elimina a coluna das consultas
            if (_selectedColumn != null)
            {
                if (_query.Orders.Count > 0)
                {
                    for (int i = _query.Orders.Count - 1; i > -1; i--)
                        if (_query.Orders[i].Column == _selectedColumn)
                            _query.Orders.RemoveAt(i);
                }

                if (_query.Havings.Count > 0)
                {
                    for (int i = _query.Havings.Count - 1; i > -1; i--)
                        if (_query.Havings[i].Left == _selectedColumn)
                            _query.Havings.RemoveAt(i);
                }

                this._query.Groups.Remove(_selectedColumn);

                if (_query.Wheres.Count > 0)
                {
                    for (int i = _query.Wheres.Count - 1; i > -1; i--)
                        if (_query.Wheres[i].Left == _selectedColumn)
                            _query.Wheres.RemoveAt(i);
                }

                this._query.Columns.Remove(_selectedColumn);

                // Se estiver no visual table desmarca de lá
                if (!_selectedColumn.Expression)
                    if (ShowColumnChanged != null)
                        ShowColumnChanged(_selectedColumn, false);
            }

            this.textBoxHaving.Text = string.Empty;
            this.textBoxOr1.Text = string.Empty;
            this.textBoxOr2.Text = string.Empty;
            this.textBoxOr3.Text = string.Empty;
            this.textBoxOr4.Text = string.Empty;
            this.textBoxOr5.Text = string.Empty;
            this.textBoxWhere.Text = string.Empty;
            this.checkBoxGroup.Checked = false;
            this.checkBoxShow.Checked = true;
            this.comboBoxColumn.Text = string.Empty;
            this.comboBoxColumn.Items.Clear();
            this.comboBoxOrder.Text = string.Empty;
            this.textBoxTable.Text = string.Empty;
            this._selectedColumn = null;
            foreach (List<Where> lst in _selectedWhere)
                lst.Clear();
            this._selectedOrder = null;
        }

        private void DoChangeColumnName()
        {
            // Nome da nova coluna
            string _fullColumnName = comboBoxColumn.Text.Trim();

            // Se apagou a coluna elimina os dados associados a ela
            if (_fullColumnName == string.Empty)
            {
                this.Clear();
                return;
            }

            // Mesma coluna não faz nada
            if (_selectedColumn != null && _selectedColumn.FullName == _fullColumnName)
                return;

            // Se está selecionando duas vezes a mesma coluna cria um alias
            foreach(Column _col in _query.Columns)
                if (_col.FullName == _fullColumnName)
                {
                    _fullColumnName = string.Format("{0} AS Exp{1}", _fullColumnName, new Random().Next().ToString());
                    comboBoxColumn.Text = _fullColumnName;
                    break;
                }


            int _index = -1;
            // Se estava preenchida 
            if (_selectedColumn != null)
            {
                _index = _query.Columns.IndexOf(_selectedColumn);
                _query.Columns.Remove(_selectedColumn); // Elimina para evitar problemas
                // Chama o evento que desmarca a Tabela visual
                if (ShowColumnChanged != null && _selectedColumn.Expression == false)
                    ShowColumnChanged(_selectedColumn, false);
                
            }
            
            // Procura nas tabelas
            _selectedColumn = _query.FindColumn(_fullColumnName);
            if (_selectedColumn != null) // Achou
            {
                // Mostra os valores
                string[] parts = _fullColumnName.Split('.');
                switch (parts.Length)
                {
                    case 2:
                        textBoxTable.Text = parts[0];
                        break;
                    case 3:
                        textBoxTable.Text = string.Format("{0}.{1}", parts[0], parts[1]);
                        break;
                }
            }
            else // É uma expressao
            {
                Column _expColumn = new Column(_fullColumnName);
                
                textBoxTable.Text = Literal.LiteralManager.GetLiteral("expressao");

                _selectedColumn = _expColumn;

            }

            // Se a coluna vai pro project do sql
            if (checkBoxShow.Checked)
            {
                // Se é substituição põe no mesmo lugar
                if (_index > -1)
                    _query.Columns.Insert(_index, _selectedColumn);
                else // Senão põe no fim
                    _query.Columns.Add(_selectedColumn);

                // Marca o campo na Visual Table
                if (!_selectedColumn.Expression)
                    DoShowColumnChanged();
            }

            // Redesenha a Consulta
            DoRenderSQL();
        }

        private void DoRenderSQL()
        {
            if (RenderSQL != null)
                RenderSQL(this, new EventArgs());
        }

        private void DoShowColumnChanged()
        {
            if (ShowColumnChanged != null)
                ShowColumnChanged(_selectedColumn, checkBoxShow.Checked);
        }

        enum WHOper
        {
            Value,
            Arithmetic,
            Logical,
            Column
        }


        /// <summary>
        /// Substitui as palavras reservadas
        /// </summary>
        /// <param name="word">Palavra que será analisada</param>
        /// <param name="toUser">Traduz para o usuário ver ou para a sitnaxe</param>
        /// <param name="value">Valor de retorno</param>
        /// <returns>Verdadeiro se traduziu</returns>
        private bool ReplaceReserveWord(string word, bool toUser, ref string value)
        {
            if (toUser)
            {
                // Se a lista nunca foi carregada
                if (_user.Count == 0)
                {
                    _user.Add("IN", "Lista");
                    _user.Add("NULL", "Nulo");
                    _user.Add("EXISTS", "Existe");
                    _user.Add("LIKE", "Contendo");
                    _user.Add("BETWEEN", "Entre");
                    _user.Add("IS", "É");
                    _user.Add("NOT", "Não");
                    _user.Add("AND", "E");
                    _user.Add("OR", "Ou");
                }

                // Traduz
                if (_user.ContainsKey(word.ToUpper()))
                {
                    value = _user[word.ToUpper()];
                    return true;
                }

            }
            else
            {
                // Se a lista nunca foi carregada
                if (_sql.Count == 0)
                {
                    _sql.Add("LISTA", "IN");
                    _sql.Add("NULO", "NULL");
                    _sql.Add("EXISTE", "EXISTS");
                    _sql.Add("CONTENDO", "LIKE");
                    _sql.Add("ENTRE", "BETWEEN");
                    _sql.Add("É", "IS");
                    _sql.Add("NÃO", "NOT");
                    _sql.Add("E", "AND");
                    _sql.Add("OU", "OR");
                }
                // Traduz
                if (_sql.ContainsKey(word.ToUpper()))
                {
                    value = _sql[word.ToUpper()];
                    return true;
                }

                // Garante que está em uppercase
                if (_sql.ContainsValue(word.ToUpper()))
                {
                    value = word.ToUpper();
                    return true; ;
                }
            }

            value = word;
            return false;
        }

        private string MakeWhereAndHavingSyntax(List<Database.SelectAnalyzer.Consulta.WherePiece> lineWhere, string textBoxContent)
        {
            string text = textBoxContent;

            bool canSimplifier = true;
            foreach (Database.SelectAnalyzer.Consulta.WherePiece item in lineWhere)
            {
                if (item is Database.SelectAnalyzer.Consulta.WhereSubQueryPiece ||
                    item is Database.SelectAnalyzer.Consulta.WhereOpenParentesesPiece ||
                    item is Database.SelectAnalyzer.Consulta.WhereCloseParentesesPiece)
                {
                    canSimplifier = false;
                    break;
                }
            }

            bool first = true;
            bool firstLoop = true;
            foreach (Database.SelectAnalyzer.Consulta.WherePiece item in lineWhere)
            {
                if (item is Database.SelectAnalyzer.Consulta.WhereJunctionPiece)
                {
                    if (firstLoop) // se for o primeiro comando uma junção salta a junção
                    {
                        first = false;
                        continue;
                    }
                    else
                        first = true;
                }
                else if (canSimplifier)
                {
                    if (first && item is Database.SelectAnalyzer.Consulta.WhereColumnPiece)
                    {
                        first = false;
                        continue;
                    }
                    else if (item is Database.SelectAnalyzer.Consulta.WhereLogicalOperatorPiece)
                    {
                        first = false;
                        if (item.Syntax == "=")
                            continue;
                    }
                    else
                        first = false;
                }

                string piece = item.Syntax;

                if (item is Database.SelectAnalyzer.Consulta.WhereFunctionOperatorPiece ||
                    item is Database.SelectAnalyzer.Consulta.WhereComandPiece ||
                    item is Database.SelectAnalyzer.Consulta.WhereJunctionPiece)
                    if (canSimplifier)
                        this.ReplaceReserveWord(piece, true, ref piece);

                if (text != string.Empty)
                    text += " " + piece;
                else
                    text = piece;

                // Primeiro loop do where
                firstLoop = false;

            }
            return text;
        }

        internal void SetWhereValue(int index, List<Database.SelectAnalyzer.Consulta.WherePiece> lineWhere)
        {
            TextBox[] data = { textBoxWhere, textBoxOr1, textBoxOr2, textBoxOr3, textBoxOr4, textBoxOr5 };
            data[index].Text = MakeWhereAndHavingSyntax(lineWhere, data[index].Text);
            _noRedrawWhere = true;
            WhereAndHavingTextChanged(data[index], new EventArgs());
            _noRedrawWhere = false;
        }

        internal void SetHavingValue(List<Database.SelectAnalyzer.Consulta.WherePiece> lineHaving)
        {
            textBoxHaving.Text = MakeWhereAndHavingSyntax(lineHaving, textBoxHaving.Text);
            _noRedrawWhere = true;
            WhereAndHavingTextChanged(textBoxHaving, new EventArgs());
            _noRedrawWhere = false;
        }


        private void ResolveWH(List<Where> whereToWork, string sufix, string operation, string value, string logical)
        {
            if (sufix == string.Empty && value == string.Empty)
                return;

            if (operation == string.Empty)
            {
                operation = "=";
                value = sufix;
                sufix = string.Empty;
            }
            if (logical == string.Empty)
                logical = "AND";

            Where _where = new Where();
            _where.Left = _selectedColumn;
            _where.LeftSufix = sufix;
            _where.Operation = OperationFX.StringToOperation(operation);
            _where.Right = value;
            _where.Junction = logical;

            whereToWork.Add(_where);
        }
#endregion

#region Events
        private void VisualWhereTable_Resize(object sender, EventArgs e)
        {
            checkBoxShow.Left = this.Width / 2;
            checkBoxGroup.Left = this.Width / 2;
        }

        private void comboBoxColumn_Click(object sender, EventArgs e)
        {
            if (this.comboBoxColumn.Items.Count == 0)
                this.AddItensFromDataBase();
        }

        private void comboBoxColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.DoChangeColumnName();
        }

        private void comboBoxOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_selectedColumn != null)
            {
                if (comboBoxOrder.Text.Trim() != string.Empty)
                {
                    if (_selectedOrder == null)
                    {
                        _selectedOrder = new Order();
                        _query.Orders.Add(_selectedOrder);
                        _selectedOrder.Column = _selectedColumn;
                    }

                    _selectedOrder.DescendingOrder = comboBoxOrder.Text == "DESC";
                }
                else
                {
                    _query.Orders.Remove(_selectedOrder);
                }

                DoRenderSQL();
            }

        }

        private void checkBoxGroup_CheckedChanged(object sender, EventArgs e)
        {
            if (_selectedColumn != null)
            {
                if (checkBoxGroup.Checked)
                    _query.Groups.Add(_selectedColumn);
                else
                    _query.Groups.Remove(_selectedColumn);

                if (RenderSQL != null)
                    RenderSQL(this, new EventArgs());
            }
        }

        private void checkBoxShow_CheckedChanged(object sender, EventArgs e)
        {
            // Se tenho coluna informada
            if (_selectedColumn != null && !_externalAdition)
            {
                if (checkBoxShow.Checked)
                    _query.Columns.Add(_selectedColumn);
                else
                    _query.Columns.Remove(_selectedColumn);

                if (ShowColumnChanged != null)
                    ShowColumnChanged(_selectedColumn, checkBoxShow.Checked);
            }
        }

        private void comboBoxColumn_Validating(object sender, CancelEventArgs e)
        {
            DoChangeColumnName();
        }


        /// <summary>
        /// O Texto do Where ou do Having foi alterado
        /// </summary>
        /// <param name="sender">Textbox que foi alterado</param>
        /// <param name="e">Argumentos</param>
        private void WhereAndHavingTextChanged(object sender, EventArgs e)
        {
            // Pega o que foi escrito na tela
            string script = ((TextBox)sender).Text.Trim();
            // Posição no vetor de where
            int _indexPos = Convert.ToInt16(((TextBox)sender).Tag);

            List<Where> _whereToWork;
            if (_indexPos > 0 && _indexPos < 7) // É Where
                _whereToWork = _selectedWhere[_indexPos];
            else // é Having
                _whereToWork = _selectecdHaving;

            // Limpando o anterior
            _whereToWork.Clear();

            // Sem script não precisa continuar
            if (script == string.Empty)
            {
                if (RedrawWhere != null && !_noRedrawWhere)
                    RedrawWhere(this, new EventArgs());
                return;
            }

            // Se a coluna está no where não processa nada copia a coluna;
            if (_selectedColumn != null)
            {
                if (script.ToLower().Contains(_selectedColumn.Name.ToLower()))
                {
                    Where _where = new Where();
                    _where.Syntax = script;
                    _whereToWork.Add(_where);
                    if (RedrawWhere != null&& !_noRedrawWhere)
                        RedrawWhere(this, new EventArgs());
                    return;
                }
            }


            ProjectString ps = new ProjectString();
            // Separar os comandos da expressão
            ProjectString.BreakExpressionInWordsMap[] map = ps.BreakExpressionInWords(script);

            const byte LEFT = 0;
            const byte OPERATION = 1;
            const byte RIGHT = 2;
            const byte JUNCTION = 3;
            
            string _leftSide = string.Empty;
            string _rightSide = string.Empty;
            string _operation = string.Empty;
            string _valueToSQL;
            int _fase = LEFT;
            bool _between = false;

            //string _userVisualization
            foreach (ProjectString.BreakExpressionInWordsMap item in map)
            {
                
                string _wordToSQL = string.Empty;
                if (ReplaceReserveWord(item.Value, false, ref _wordToSQL))
                {
                    if (_wordToSQL == "NULL")
                    {
                        // Verifica se o valor é a esquerda ou a direita
                        if (_fase == OPERATION)
                            _fase = RIGHT;
                    }
                    else if (_wordToSQL == "BETWEEN")
                    {
                        _between = true;
                        _fase = OPERATION;
                    }
                    else
                    {
                        if (_wordToSQL == "AND")
                        {
                            if (_between)
                                _between = false;
                            else
                                _fase = JUNCTION;
                        }
                        else if (_wordToSQL == "OR")
                            _fase = JUNCTION;
                        else
                            _fase = OPERATION;
                    }
                }
                else
                {
                    switch (_wordToSQL)
                    {
                        case "=":
                        case "<>":
                        case "<":
                        case ">":
                        case ">=":
                        case "<=":
                        case "!=":
                        case "^=":
                            _fase = OPERATION;
                            break;
                    }
                }

                switch (_fase)
                {
                    case LEFT:
                        if (_leftSide != string.Empty)
                            _leftSide += " ";
                        _leftSide += _wordToSQL;
                        break;
                    case OPERATION:
                        if (_operation != string.Empty)
                            _operation += " ";
                        _operation += _wordToSQL;
                        _fase = RIGHT;
                        break;
                    case RIGHT:
                        if (_rightSide != string.Empty)
                            _rightSide += " ";
                        _rightSide += _wordToSQL;
                        break;
                    case JUNCTION:
                        ResolveWH(_whereToWork, _leftSide, _operation, _rightSide, _wordToSQL);
                        _leftSide = string.Empty;
                        _operation = string.Empty;
                        _rightSide = string.Empty;
                        _fase = LEFT;
                        break;
                }
    
            }
            ResolveWH(_whereToWork, _leftSide, _operation, _rightSide, string.Empty);

            if (_whereToWork.Count > 1)
            {
                _whereToWork[0].ParetesisBlockStart++;
                _whereToWork[_whereToWork.Count - 1].ParetesisBlockEnd++;
            }

            if (RedrawWhere != null && !_noRedrawWhere)
                RedrawWhere(this, new EventArgs());
        }

        private static Dictionary<string, string> _user = new Dictionary<string, string>();
        private static Dictionary<string, string> _sql = new Dictionary<string,string>();

        private void comboBoxColumn_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ManutExpressao me = new ManutExpressao();
            me.Query = _query;
            me.Show();
        }

        private void comboBoxColumn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //contextMenuStripWhere.Show();
            }
        }

        private void contextMenuStripWhere_Opening(object sender, CancelEventArgs e)
        {
            toolStripMenuItemClear.Enabled = comboBoxColumn.Text != string.Empty;
            toolStripMenuItemCopy.Enabled = comboBoxColumn.SelectedText != string.Empty;
            toolStripMenuItemPaste.Enabled = Clipboard.GetText() != string.Empty;
            toolStripMenuItemSelectAll.Enabled = comboBoxColumn.Text != string.Empty;     
        }

        private void toolStripMenuItemCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(comboBoxColumn.Text);
        }

        private void toolStripMenuItemPaste_Click(object sender, EventArgs e)
        {
            comboBoxColumn.Text = Clipboard.GetText();
        }

        private void toolStripMenuItemSelectAll_Click(object sender, EventArgs e)
        {
            comboBoxColumn.SelectAll();
        }

        private void toolStripMenuItemClear_Click(object sender, EventArgs e)
        {
            comboBoxColumn.ResetText();
        }

        private void toolStripMenuItemUndo_Click(object sender, EventArgs e)
        {
            SendKeys.Send("^z");
        }

        /// <summary>
        /// Menu de Contexto. Abrir Editor de Expressões
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buildExpressionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManutExpressao me = new ManutExpressao();
            me.Expression = comboBoxColumn.Text;
            me.Query = _query;
            me.ShowDialog();
            if (me.DialogResult == DialogResult.OK)
            {
                if (comboBoxColumn.Text != me.Expression)
                {
                    comboBoxColumn.Text = me.Expression;
                    DoChangeColumnName();
                }
            }
        }

        private long resizeDiference = 0;
        private VisualWhereTable _visualResing = null;

        private void buttonResize_MouseDown(object sender, MouseEventArgs e)
        {
            _visualResing = this;
        }

        void Parent_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        private void buttonResize_MouseUp(object sender, MouseEventArgs e)
        {
            if (_visualResing != null)
            {
                if (ResizeVisualWhereTable != null)
                    ResizeVisualWhereTable(new ResizeVisualWhereTableArgs(this.Index, this.Left + this.Width));
            }
            _visualResing = null;
            
        }

        private void buttonResize_Click(object sender, EventArgs e)
        {
            int i = 0;
        }

        private void buttonResize_MouseMove(object sender, MouseEventArgs e)
        {
            if (_visualResing != null)
            {
                _visualResing.Width = _visualResing.PointToClient(MousePosition).X;

            }
        }

#endregion

    }

}
