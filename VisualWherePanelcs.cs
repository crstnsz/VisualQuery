using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace VisualQuery
{
    /// <summary>
    /// Painel de Visualização do Grupo de Where
    /// </summary>
    public partial class VisualWherePanel : UserControl
    {
#region Definitions
        /// <summary>
        /// Unidade Visual
        /// </summary>
        private List<VisualWhereTable> _visualUnits = new List<VisualWhereTable>();
        /// <summary>
        /// Consulta
        /// </summary>
        private Query _query = null;
        /// <summary>
        /// Gatilho do Evendo que desenha o SQL
        /// </summary>
        public event EventHandler RenderSQL = null;
        /// <summary>
        /// Gatilho do Evendo disparado ao se alterar os dados da coluna
        /// </summary>
        internal event ColumnsSelectionChanged ShowColumnChanged = null;
#endregion

#region Constructors
        /// <summary>
        /// Construtor do Objeto gráfico
        /// </summary>
        public VisualWherePanel()
        {
            InitializeComponent();

            int xPos = 1;
            for (int _ix = 0; _ix < 20; _ix++)
                this.AddVisualUnit();

        }
#endregion
      
#region Events
        /// <summary>
        /// Evento disparado quado o Editor é carregado na tela
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VisualWherePanel_Load(object sender, EventArgs e)
        {
            this.TraduzTela();
        }


        /// <summary>
        /// Evento disparado quando qualquer elemento que influencie na consulta SQL é alterado em alguma unidade de Coluna
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _newObj_RenderSQL(object sender, EventArgs e)
        {
            if (RenderSQL != null)
                RenderSQL(sender, e);
        }

        /// <summary>
        /// Evento executado quando alguma propriedade referente aos dados do where é alterada dentro de  alguma unidade.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _newObj_RedrawWhere(object sender, EventArgs e)
        {
            _query.Wheres.Clear();

            List<VisualWhereTable> _workUnits = new List<VisualWhereTable>();

            foreach (VisualWhereTable _visualUnit in this._visualUnits)
            {
                if (!_visualUnit.IsEmpty())
                    _workUnits.Add(_visualUnit);
            }


            for (int _line = 0; _line < 7; _line++)
            {
                foreach (VisualWhereTable _visualUnit in _workUnits)
                {
                    foreach (Where _where in _visualUnit.Where[_line])
                        _query.Wheres.Add(_where.Clone());
                }

                if (_query.Wheres.Count > 0)
                    _query.Wheres[_query.Wheres.Count - 1].Junction = "OR";
            }

            _query.Havings.Clear();

            foreach (VisualWhereTable _visualUnit in _workUnits)
                foreach (Where _having in _visualUnit.Having)
                    _query.Havings.Add(_having.Clone());

            if (RenderSQL != null)
                RenderSQL(this, new EventArgs());
        }

        /// <summary>
        /// Evento executado quando a
        /// </summary>
        /// <param name="column"></param>
        /// <param name="selected"></param>
        void _newObj_ShowColumnChanged(Column column, bool selected)
        {
            if (ShowColumnChanged != null)
                ShowColumnChanged(column, selected);
            if (_visualUnits.Count > 0)
                if (!_visualUnits[_visualUnits.Count -1].IsEmpty())
                    FindFirstEmptyUnit();
        }
#endregion

#region TraduzTela
        /// <summary>
        /// Traduz os elementos gráficos da tela
        /// </summary>
        private void TraduzTela()
        {
            labelColumn.Text = Literal.LiteralManager.GetLiteral("coluna");
            labelTable.Text = Literal.LiteralManager.GetLiteral("tabela");
            labelShow.Text = Literal.LiteralManager.GetLiteral("mostrar");
            labelFilter.Text = Literal.LiteralManager.GetLiteral("filtrar");
            labelOr1.Text = Literal.LiteralManager.GetLiteral("ou");
            labelOr2.Text = labelOr1.Text;
            labelGroup.Text = Literal.LiteralManager.GetLiteral("agrupador");
            labelHaving.Text = Literal.LiteralManager.GetLiteral("filtro_apos_grupo");

        }
#endregion

#region Private Methods
        /// <summary>
        /// Adiciona um Unidade de Edição Visual de uma Coluna
        /// </summary>
        private void AddVisualUnit()
        {
            int xPosition = 1;
            int index = 0;
            if (_visualUnits.Count > 0)
            {
                index = _visualUnits.Count - 1;
                xPosition = _visualUnits[index].Left + _visualUnits[index].Width;
            }
            
            VisualWhereTable _newObj = new VisualWhereTable();
            _newObj.Location = new Point(xPosition, 1);
            _newObj.Size = new System.Drawing.Size(150, 214);
            _newObj.Name = string.Format("Unit{0:000}", index);
            _newObj.RenderSQL += new EventHandler(_newObj_RenderSQL);
            _newObj.ShowColumnChanged += new ColumnsSelectionChanged(_newObj_ShowColumnChanged);
            _newObj.RedrawWhere += new EventHandler(_newObj_RedrawWhere);
            _newObj.ResizeVisualWhereTable += new ResizeVisualWhereTableHandler(_newObj_ResizeVisualWhereTable);
            _newObj.TabIndex = _visualUnits.Count;
            _newObj.Query = _query;
            _newObj.Index = _visualUnits.Count;

            _visualUnits.Add(_newObj);

            panelUnitsArea.Controls.Add(_newObj);
        }

        void _newObj_ResizeVisualWhereTable(ResizeVisualWhereTableArgs args)
        {
            int xPosition = args.NextXPosition;
            for (int index = args.Index + 1; index < _visualUnits.Count; index++)
            {
                _visualUnits[index].Left = xPosition;
                xPosition += _visualUnits[index].Width;
            }

        }

        /// <summary>
        /// Método que atualiza as unidades quando a consulta principal é totalmente alterada.
        /// </summary>
        public void Refresh()
        {
            foreach (VisualWhereTable _panel in this._visualUnits)
            {
                if (_query != null)
                    _panel.Query = _query;
                _panel.Refresh();
            }
        }
#endregion

#region Public
        /// <summary>
        /// Autaliza os dados referentes ao SQL que está sendo manipulado
        /// </summary>
        public Query Query
        {
            set
            {
                _query = value;
                this.Refresh();
            }

        }

        /// <summary>
        /// Procura a unidade manipuladora da coluna parametrizada
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        internal VisualWhereTable FindUnit(Column column)
        {
            foreach (VisualWhereTable _unit in this._visualUnits)
                if (_unit.SelectedColumn != null)
                    if (_unit.SelectedColumn.FullName == column.FullName)
                        return _unit;

            return null;
        }

        /// <summary>
        /// Procura a Primeira Unidade de Coluna vazia caso essa não existe cria uma
        /// </summary>
        /// <returns></returns>
        internal VisualWhereTable FindFirstEmptyUnit()
        {
            foreach (VisualWhereTable _unit in this._visualUnits)
                if (_unit.IsEmpty())
                    return _unit;
            this.AddVisualUnit();
            return this._visualUnits[_visualUnits.Count - 1];
            
        }

        /// <summary> 
        /// Informa se uma coluna deve ou não ser mostrada
        /// </summary>
        /// <param name="column"></param>
        /// <param name="value"></param>
        internal void SetShowColumn(Column column, bool value, bool externAdition)
        {
            VisualWhereTable _unit = this.FindUnit(column);
            if (_unit == null)
            {
                // Procura a Primeira Unidade Vazia. Se não achar cria uma
                _unit = FindFirstEmptyUnit();
                _unit.SelectedColumn = column;
            }
            _unit.BeginExternalAdition();
            _unit.ShowData = value;
            _unit.EndExternalAdition();
        }
        
        /// <summary>
        /// Limpa os dados de uma determinada unidade
        /// </summary>
        /// <param name="table"></param>
        internal void ClearTable(Table table)
        {
            foreach (VisualWhereTable _unit in this._visualUnits)
                if (_unit.Table == table)
                {
                    _unit.Clear();
                    break;
                }
        }

        /// <summary>
        /// Limpra todos os dados de todas a unidades
        /// </summary>
        internal void ClearAll()
        {
            foreach (VisualWhereTable _unit in this._visualUnits)
                _unit.Clear();
        }

        /// <summary>
        /// Seta o informação de Grupo
        /// </summary>
        /// <param name="column"></param>
        /// <param name="on"></param>
        internal void SetGroup(Column column, bool on)
        {
            VisualWhereTable _unit = FindUnit(column);
            if (_unit == null)
            {
                _unit = FindFirstEmptyUnit();
                _unit.SelectedColumn = column;
                _unit.ShowData = false;
            }
            _unit.Group = on;       
        }

        /// <summary>
        /// Procura a Unidade de Filtro para a coluna estabelecida no where. Se não existir cria uma
        /// </summary>
        /// <param name="lineWhere">Lista de Comandos do where</param>
        /// <returns>A Unidade de Filtro Finculada a Coluna</returns>
        private VisualWhereTable FindVisualUnitFromFilter(List<Database.SelectAnalyzer.Consulta.WherePiece> lineWhere)
        {
            if (lineWhere.Count < 1)
                return null;

            // Onde começam as instruções
            int _startCmd = 0;
            // se o primeiro valor é uma junção 
            if (lineWhere[_startCmd] is Database.SelectAnalyzer.Consulta.WhereJunctionPiece)
                _startCmd++;

            // ignora qualquer parenteses aberto antes dos comandos de ligação
            while (lineWhere[_startCmd] is Database.SelectAnalyzer.Consulta.WhereOpenParentesesPiece)
                _startCmd++;

            // Onde fica o divisor dos dois lados do comando. Separa o comando em antes e depois do operador lógico
            int logicalInstructionOrCommandOperator = -1;
            List<Database.SelectAnalyzer.Consulta.WherePiece> leftSide = new List<Database.SelectAnalyzer.Consulta.WherePiece>();
            for (logicalInstructionOrCommandOperator = _startCmd;
                !(lineWhere[logicalInstructionOrCommandOperator] is Database.SelectAnalyzer.Consulta.WhereLogicalOperatorPiece ||
                lineWhere[logicalInstructionOrCommandOperator] is Database.SelectAnalyzer.Consulta.WhereComandPiece) &&
                logicalInstructionOrCommandOperator < lineWhere.Count;
                logicalInstructionOrCommandOperator++) // para cada até achar o operador lógico ou chegar no final da expressão
            {
                leftSide.Add(lineWhere[logicalInstructionOrCommandOperator]);
            }


            // analisando o lado esquerdo pra achar a chave de ligação com a unidade visual
            string commandSyntax = string.Empty;
            Column _col = null;
            if (leftSide.Count > 0)
            {
                // descobriu que uma coluna é a ligação 
                if (leftSide[0] is Database.SelectAnalyzer.Consulta.WhereColumnPiece)
                {
                    // procura a coluna
                    _col = _query.FindColumn(((Database.SelectAnalyzer.Consulta.WhereColumnPiece)leftSide[0]).Campo.ColunaCompleta);

                    // qualquer coisa apos a coluna é considerada sufixo
                }
                else if (leftSide[0] is Database.SelectAnalyzer.Consulta.WhereOpenParentesesPiece)
                {
                    string syntax = string.Empty;
                    // trata-se de uma expressão complexa e o parênteses deve ser mantido para não interferir na sintaxe
                    foreach (Database.SelectAnalyzer.Consulta.WherePiece item in leftSide)
                        commandSyntax += item.Syntax + " ";
                    _col = new Column(syntax);
                }
                else
                {
                    // trata-se de uma expressão sem parenteses
                    _col = new Column(leftSide[0].Syntax);
                }
            }

            // captura a unidade visual conectada a coluna
            VisualWhereTable _vt = FindUnit(_col);
            if (_vt == null)
            {
                // não há unidade visual conectada criamos então uma para o novo item
                _vt = FindFirstEmptyUnit();
                _vt.SelectedColumn = _col;
                _vt.ShowData = false;
            }

            return _vt;
        }

        /// <summary>
        /// Adiciona uma linha de where a uma unidade especificada
        /// </summary>
        /// <param name="lineWhere">Comandos para acrescentar no where</param>
        /// <param name="lineUnit">Número da linha do where.Cara nova linha é um OR</param>
        private void AddWhere(List<Database.SelectAnalyzer.Consulta.WherePiece> lineWhere, int lineUnit, ref Dictionary < VisualWhereTable, Dictionary <int , List < Database.SelectAnalyzer.Consulta.WherePiece > > > units)
        {
            VisualWhereTable _vt = FindVisualUnitFromFilter(lineWhere);
            if (_vt == null)
                return;

            // adiciona o Unidade controladora de coluna a lista que controla as adições de where
            if (!units.ContainsKey(_vt))
                units.Add(_vt, new Dictionary<int, List<Database.SelectAnalyzer.Consulta.WherePiece>>());

            // adiciona a linha de or referente a coluna
            if (!units[_vt].ContainsKey(lineUnit))
                units[_vt].Add(lineUnit, new List<Database.SelectAnalyzer.Consulta.WherePiece>());

            // se cabe ter abrir e fechar parenteses
            if (lineWhere.Count > 3)
            {
                if (lineWhere[0] is Database.SelectAnalyzer.Consulta.WhereOpenParentesesPiece
                    && lineWhere[lineWhere.Count - 1] is Database.SelectAnalyzer.Consulta.WhereCloseParentesesPiece)
                {
                    for(int ix = 1; ix < lineWhere.Count - 1;ix ++)
                        // Adiciona todos os comandos de where para determinada unidade linhas
                        units[_vt][lineUnit].Add(lineWhere[ix]);
                }
                else
                {
                    if (lineWhere[0] is Database.SelectAnalyzer.Consulta.WhereJunctionPiece && lineWhere[1] is Database.SelectAnalyzer.Consulta.WhereOpenParentesesPiece && lineWhere[lineWhere.Count - 1] is Database.SelectAnalyzer.Consulta.WhereCloseParentesesPiece)
                    {
                        for(int ix = 2; ix < lineWhere.Count - 1;ix ++)
                            // Adiciona todos os comandos de where para determinada unidade linhas
                            units[_vt][lineUnit].Add(lineWhere[ix]);
                    }
                    else
                        units[_vt][lineUnit].AddRange(lineWhere);
                }

            }
            else
            {
                // Adiciona todos os comandos de where para determinada unidade linhas
                units[_vt][lineUnit].AddRange(lineWhere);
            }
            
        }

        /// <summary>
        /// Informa o valor da célula do where
        /// </summary>
        /// <param name="where">Lista de partes do where</param>
        internal void SetWhereList(List<Database.SelectAnalyzer.Consulta.WherePiece> where)
        {
        
            int lineOr = 0;
            List<Database.SelectAnalyzer.Consulta.WherePiece> lineWhere = new List<Database.SelectAnalyzer.Consulta.WherePiece>();
            Dictionary<VisualWhereTable, Dictionary<int, List<Database.SelectAnalyzer.Consulta.WherePiece>>> units = new Dictionary<VisualWhereTable,Dictionary<int,List<Database.SelectAnalyzer.Consulta.WherePiece>>>();

            // procura as junções das expressões 
            foreach (Database.SelectAnalyzer.Consulta.WherePiece piece in where)
            {
                // testa para ver se é uma junção
                if (piece is Database.SelectAnalyzer.Consulta.WhereJunctionPiece)
                {
                    //adiciona no dicionario de unidades linhas e comandos
                    AddWhere(lineWhere, lineOr, ref units);
                    lineWhere.Clear(); // limpa os comandos anteriores

                    // se for um ou todas as expressões caminham pra linha de baixo
                    if (((Database.SelectAnalyzer.Consulta.WhereJunctionPiece)piece).IsOr())
                        lineOr++;
                   
                }
                // lista que separa os comandos em junções específicas
                lineWhere.Add(piece);
            }

            // adiciona os comandos restantes após a última junção ou na falta dela todos os comandos
            AddWhere(lineWhere, lineOr, ref units);

            // Com todos os elementos agrupados o que é necessário para interpretar se deve  ou não simplificar o comando
            foreach (var _unit in units)
            {
                foreach (var line in _unit.Value)
                {
                    _unit.Key.SetWhereValue(line.Key, line.Value);
                }
            }

            _newObj_RedrawWhere(this, new EventArgs());
        }

        /// <summary>
        /// Adiciona uma linha de having a uma unidade especificada
        /// </summary>
        /// <param name="lineWhere">Comandos para acrescentar no having</param>
        private void AddHaving(List<Database.SelectAnalyzer.Consulta.WherePiece> lineHaving, ref Dictionary<VisualWhereTable, List<Database.SelectAnalyzer.Consulta.WherePiece>> units)
        {
            VisualWhereTable _vt = FindVisualUnitFromFilter(lineHaving);

            // adiciona o Unidade controladora de coluna a lista que controla as adições de where
            if (!units.ContainsKey(_vt))
                units.Add(_vt, new List<Database.SelectAnalyzer.Consulta.WherePiece>());

            // Adiciona todos os comandos de where para determinada unidade linhas
            units[_vt].AddRange(lineHaving);

        }

        /// <summary>
        /// Informa o valor da célula do having
        /// </summary>
        /// <param name="where">Lista de partes do having</param>
        internal void SetHavingList(List<Database.SelectAnalyzer.Consulta.WherePiece> having)
        {

            List<Database.SelectAnalyzer.Consulta.WherePiece> lineHaving = new List<Database.SelectAnalyzer.Consulta.WherePiece>();
            Dictionary<VisualWhereTable, List<Database.SelectAnalyzer.Consulta.WherePiece>> units = new Dictionary<VisualWhereTable, List<Database.SelectAnalyzer.Consulta.WherePiece>>();

            // procura as junções das expressões 
            foreach (Database.SelectAnalyzer.Consulta.WherePiece piece in having)
            {
                // testa para ver se é uma junção
                if (piece is Database.SelectAnalyzer.Consulta.WhereJunctionPiece)
                {
                    //adiciona no dicionario de unidades linhas e comandos
                    AddHaving(lineHaving, ref units);
                    lineHaving.Clear(); // limpa os comandos anteriores
                }
                // lista que separa os comandos em junções específicas
                lineHaving.Add(piece);
            }

            // adiciona os comandos restantes após a última junção ou na falta dela todos os comandos
            AddHaving(lineHaving, ref units);

            // Com todos os elementos agrupados o que é necessário para interpretar se deve  ou não simplificar o comando
            foreach (var _unit in units)
            {
                _unit.Key.SetHavingValue(_unit.Value);
            }

            _newObj_RedrawWhere(this, new EventArgs());
        }

        

#endregion
    }
}
