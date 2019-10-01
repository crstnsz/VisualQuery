/* Em nome de Deus o onipotente */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace VisualQuery
{
    public partial class QueryDesigner : UserControl
    {
        // Descritor de Objetos da Bae de dados
        private VirtualDataBase _database = new VirtualDataBase();
        // Descritor das consultas
        private Query _query = new Query();
        // Tabelas Visuais
        private SortedList<string, VisualTable> _visualTables = new SortedList<string, VisualTable>();
        private List<VisualJoin> _visualJoins = new List<VisualJoin>();
        public event SintaxeChanged SintaxeChanged = null;

        #region Contructor e Load
        public QueryDesigner()
        {
            InitializeComponent();
            TraduzTela();
            try
            {
                Load_QueryDesigner();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }

            this.tabControlSQL.TabPages.Remove(tabPageWhere);

        }

        private void Load_QueryDesigner()
        {
            visualFilters.ShowColumnChanged += new ColumnsSelectionChanged(visualFilters_ShowColumnChanged);
            visualFilters.Query = _query;

        }
        #endregion

        #region Traduz Tela
        private void TraduzTela()
        {
            tabPageModeler.Text = Literal.LiteralManager.GetLiteral("modelador");
            tabPageSintaxe.Text = Literal.LiteralManager.GetLiteral("sintaxe");
            toolStripLabelShowTables.Text = Literal.LiteralManager.GetLiteral("mostrar") + ":";
            toolStripLabelFilter.Text = Literal.LiteralManager.GetLiteral("filtro") + ":";
            toolStripComboBoxOwner.Items.Add(new ComboBoxIOwnerItem { Value = "ALL", Description = Literal.LiteralManager.GetLiteral("todas_as_tabelas") });
            toolStripComboBoxOwner.Items.Add(new ComboBoxIOwnerItem { Value = "USER", Description = Literal.LiteralManager.GetLiteral("tabelas_do_usuario") });
            toolStripComboBoxOwner.SelectedIndex = 0;
                 
        }
        #endregion

        #region DataProvider
        [Browsable(false)]
        /// <summary>
        /// Conector com o banco do dados
        /// </summary>
        public Database.IDataAccessManager DataProvider
        {
            set
            {
                if (value != null)
                {
                    _database.DataProvider = value;
                    this.LoadDataBase(string.Empty);
                }
            }
        }
        #endregion

        #region Carrega um Modelo Virtual do Banco de Dados
        /// <summary>
        /// Carrega a lista de tabelas
        /// </summary>
        private void LoadDataBase(string filter)
        {
            if (filter == string.Empty)
            {
                listBoxTables.Items.Clear();
                foreach (Table _t in this._database.Tables)
                    this.listBoxTables.Items.Add(new TableListItem(_t));
            }
            else
            {
                listBoxTables.Items.Clear();
                filter = filter.ToUpper();
                foreach (Table _t in this._database.Tables)
                    if (_t.Name.ToUpper().Contains(filter))
                        this.listBoxTables.Items.Add(new TableListItem(_t));
         
            }

            if (this._database.DataProvider is Database.OracleDataAccessManager)
            {
                toolStripContainerOwner.Visible = true;
            }
            else
            {
                toolStripContainerOwner.Visible = false;
            }
        }

        private void toolStripComboBoxOwner_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_database.DataProvider != null && toolStripComboBoxOwner.SelectedItem != null)
            {
                if (_database.DataProvider is Database.OracleDataAccessManager)
                {
                    bool _changeProperty = ((Database.OracleDataAccessManager)_database.DataProvider).ShowAllUsers;
                    ((Database.OracleDataAccessManager)_database.DataProvider).ShowAllUsers = ((ComboBoxIOwnerItem)toolStripComboBoxOwner.SelectedItem).Value == "ALL";
                    if (_changeProperty != ((Database.OracleDataAccessManager)_database.DataProvider).ShowAllUsers)
                        this._database.ReloadTables();
                }
                this.LoadDataBase(toolStripTextBoxFilter.Text);
            }
        }
        #endregion

        #region Visual Tables
        /// <summary>
        /// Adiciona uma tabela visual
        /// </summary>
        /// <param name="table">Tabela</param>
        /// <param name="point">Posição visual</param>
        private void listBoxTables_DoubleClick(object sender, EventArgs e)
        {
            object objSel = listBoxTables.SelectedItem;
            if (objSel != null)
                this.LoadVisualTable(((TableListItem)objSel).Table, new Point(10, 10));
        }

        /// <summary>
        /// Cria um objeto visual representando a tabela
        /// </summary>
        /// <param name="table">Tabela</param>
        /// <param name="point">Posição visual</param>
        private void LoadVisualTable(Table table, Point point)
        {
            Table tableAdd = table;
            for(int index = 0; index < this._query.Tables.Count; index ++)
            {
                Table _tab = this._query.Tables[index];
                if (_tab.Alias == tableAdd.Alias)
                {
                    tableAdd = (Table)table.Clone();
                    if (_tab.Alias == _tab.Name)
                    {

                        tableAdd.Alias = table.Name + "__01";
                        index = 0;
                    }
                    else
                    {
                        string _tempAlias = _tab.Alias.Replace("]", "");
                        if (_tempAlias.Length > 4)
                        {
                            _tempAlias = _tempAlias.Substring(_tempAlias.Length - 4);
                            // se é padrão de alias do sistema
                            if (_tempAlias[0] == '_' && _tempAlias[1] == '_' && char.IsNumber(_tempAlias[2]) && char.IsNumber(_tempAlias[3]))
                            {
                                tableAdd.Alias = string.Format("{0}__{1:00}", table.Name, Convert.ToInt16(_tempAlias.Substring(_tempAlias.LastIndexOf("__") + 2)) + 1);
                                index = 0;// reiniciam as buscas
                            }
                            else
                                tableAdd.Alias = table.Name + "__01";

                        }
                   
                    }
                }
            }

            // if table no have columns
            if (tableAdd.Columns.Count == 0)
            {
                _database.LoadColumn(ref tableAdd);
            }

            VisualTable _newVisualTable = new VisualTable();
            _newVisualTable.Parent = this.splitContainerTables.Panel1;
            _newVisualTable.Load(tableAdd);
            _newVisualTable.Top = point.Y;
            _newVisualTable.Left = point.X;
            _newVisualTable.ColumnChanged += new ColumnsSelectionChanged(_newVisualTable_ColumnChanged);
            _newVisualTable.CloseTable += new RemoveTable(_newVisualTable_CloseTable);
            _newVisualTable.JoinChanged += new JoinEventHandler(_newVisualTable_JoinChanged);

            _query.Tables.Add(tableAdd);

            // Escreve o comando SQL
            this.RenderSQL();

            this.LoadTabControl();

            this.splitContainerWork.Panel1.Controls.Add(_newVisualTable);
            this._visualTables.Add(_newVisualTable.Table.FullName, _newVisualTable);

        }

        /// <summary>
        /// Ao alterar o Join
        /// </summary>
        /// <param name="args">Colunas que participam do Join</param>
        void _newVisualTable_JoinChanged(object sender, JoinEventArgs args)
        {
            // Se for adição de Join
            if (args.Action == JoinEventAction.Add)
            {
                AddVisualJoin(args.Join);
            }
            // redesenha o SQL
            this.RenderSQL();
            this.splitContainerWork.Refresh();
        }

        /// <summary>
        /// Ao fechar uma Janela
        /// </summary>
        /// <param name="table">Tabela fechada</param>
        void _newVisualTable_CloseTable(Table table)
        {
            _query.Tables.Remove(table);

            visualFilters.ClearTable(table);


            // Para cada coluna do select
            for (int _ix = _query.Columns.Count - 1; _ix > -1; _ix--)
                if (_query.Columns[_ix].Table == table)
                    _query.Columns.RemoveAt(_ix);

            // Para cada Join Adicionado
            for(int _ix = _visualJoins.Count - 1; _ix > -1; _ix --)
                // Se a tabela foi retirada
                if (_visualJoins[_ix].TableLeft.Table == table ||
                    _visualJoins[_ix].TableRight.Table == table)
                    _visualJoins[_ix].Close();

            // Remover da lista de tabelas
            _visualTables.Remove(table.FullName);


            // Redesenha o SQL
            this.RenderSQL();

            this.LoadTabControl();

            this.splitContainerWork.Panel1.Invalidate();
        }

        /// <summary>
        /// Ocorre quando uma coluna é selecionada ou perde sua seleção
        /// </summary>
        /// <param name="column">Coluna afetada</param>
        /// <param name="selected">Verdadeiro se ela foi selecionada Falso em caso contrário</param>
        void _newVisualTable_ColumnChanged(Column column, bool selected)
        {
            if (selected)
            {
                // evita que duas colunas apontem para o mesmo lugar
                column = (Column)column.Clone();
                _query.Columns.Add(column);
            }
            else
            {
                int index = 0;
                for (; index < _query.Columns.Count; index++)
                    if (_query.Columns[index].FullName == column.FullName)
                        break;
                if (index < _query.Columns.Count)
                    _query.Columns.RemoveAt(index);
            }

            visualFilters.SetShowColumn(column, selected, true);
            
            // Escreve o comando SQL
            this.RenderSQL();
        }
        #endregion

        #region Escreve o SQL
        /// <summary>
        /// Reescreve o SQL
        /// </summary>
        private void RenderSQL()
        {
            // carrega a tela
            this.richTextBoxSQL.Text = _query.BuildSQL();
            // Carrega o DataAdapter
            if (SintaxeChanged != null)
                SintaxeChanged(this.richTextBoxSQL.Text);
            // Carrega o tree view
            this.LoadTreeView();
        }
        #endregion

        #region Load and Change TreeView of Sintax Explain

        /// <summary>
        /// Carrega os dados do TreeView
        /// </summary>
        private void LoadTreeView()
        {
            treeViewSQL.SuspendLayout();
            treeViewSQL.Nodes.Clear();
            treeViewSQL.Nodes.Add("SQL");
            treeViewSQL.Nodes[0].Nodes.Add("SELECT");
            foreach (Column _col in _query.Columns)
                treeViewSQL.Nodes[0].Nodes[0].Nodes.Add(_col.FullName);
            treeViewSQL.Nodes[0].Nodes.Add("FROM");
            foreach (Table _tab in _query.Tables)
                treeViewSQL.Nodes[0].Nodes[1].Nodes.Add(_tab.FullName);
            treeViewSQL.Nodes[0].Nodes.Add("JOIN");
            foreach (Join _join in _query.Joins)
                treeViewSQL.Nodes[0].Nodes[2].Nodes.Add(string.Format("{0} {1} {2}", _join.Left.SchemaName, OperationFX.OperationToString(_join.Operation), _join.Right.SchemaName));
            treeViewSQL.Nodes[0].Nodes.Add("WHERE");
            foreach (Where _where in _query.Wheres)
                treeViewSQL.Nodes[0].Nodes[3].Nodes.Add(_where.ToString());
            treeViewSQL.Nodes[0].Nodes.Add("GROUP BY");
            foreach (Column _col in _query.Groups)
                treeViewSQL.Nodes[0].Nodes[4].Nodes.Add(_col.SchemaName);
            treeViewSQL.Nodes[0].Nodes.Add("HAVING");
            foreach (Where _hav in _query.Havings)
                treeViewSQL.Nodes[0].Nodes[5].Nodes.Add(_hav.ToString());
            treeViewSQL.Nodes[0].Nodes.Add("ORDER BY");
            foreach (Order _order in _query.Orders)
                treeViewSQL.Nodes[0].Nodes[6].Nodes.Add(string.Format("{0} {1}", _order.Column.SchemaName, (_order.DescendingOrder)?"DESC":"ASC"));


            treeViewSQL.ExpandAll();
            treeViewSQL.PerformLayout();
        }


        private void MoveInQuery(string keyParent, int indexFrom, int indexTo)
        {
            switch (keyParent)
            {
                case "SELECT":
                    MoveColumn<Column>(_query.Columns, indexFrom, indexTo);
                    break;
                case "FROM":
                    MoveColumn<Table>(_query.Tables, indexFrom, indexTo);
                    break;
                case "JOIN":
                    MoveColumn<Join>(_query.Joins, indexFrom, indexTo);
                    break;
                case "WHERE":
                    MoveColumn<Where>(_query.Wheres, indexFrom, indexTo);
                    break;
                case "GROUP BY":
                    MoveColumn<Column>(_query.Groups, indexFrom, indexTo);
                    break;
                case "HAVING":
                    MoveColumn<Where>(_query.Havings, indexFrom, indexTo);
                    break;
                case "ORDER BY":
                    MoveColumn<Order>(_query.Orders, indexFrom, indexTo);
                    break;
            }

            this.RenderSQL();

        }

        private void MoveColumn<T>(List<T> list, int indexFrom, int indexTo)
        {
            T temp = list[indexFrom];
            if (indexFrom < indexTo)
            {
                list.Insert(indexTo, temp);
                list.RemoveAt(indexFrom);
            }
            else
            {
                list.RemoveAt(indexFrom);
                list.Insert(indexTo, temp);
            }

        }
        #endregion

        #region Drag and Drop Tables
        /// <summary>
        /// Ao movimentar a tabela selecionada pela lista de tabelas
        /// </summary>
        /// <param name="sender">Lista</param>
        /// <param name="e">Argumentos</param>
        private void listBoxTables_DragEnter(object sender, DragEventArgs e)
        {
            if (this.listBoxTables.SelectedItem == null)
                e.Effect = DragDropEffects.None;
            else
                e.Effect = DragDropEffects.Move;
        }


        /// <summary>
        /// Função que prepara o panel pra receber a tabela
        /// </summary>
        private void DragStart()
        {
            timerStarted = true;
            timer1.Start();
            splitContainerWork.Panel1.AllowDrop = true;
        }

        /// <summary>
        /// Interrompe o Drag and Drop
        /// </summary>
        private void DragStop()
        {
            timerStarted = false;
            timer1.Stop();
            splitContainerWork.Panel1.AllowDrop = false;
        }

        /// <summary>
        /// Controla o timer que impede que o duplo clique seja interpretado como drag and drop
        /// </summary>
        private bool timerStarted = false;

        /// <summary>
        /// Evento de inicio e cancelamento do drag and drop por clique do mouse
        /// </summary>
        /// <param name="sender">Lista</param>
        /// <param name="e">Parâmetros</param>
        private void listBoxTables_MouseDown(object sender, MouseEventArgs e)
        {
            if (timerStarted)
                this.DragStop();
            else
                this.DragStart();
        }

        /// <summary>
        /// Evento de soltura da tabela na área de edição
        /// </summary>
        /// <param name="sender">Painel de Edição</param>
        /// <param name="e">Parâmetros</param>
        private void splitContainerWork_Panel1_DragDrop(object sender, DragEventArgs e)
        {
            object objSel = listBoxTables.SelectedItem;
            if (objSel != null)
                this.LoadVisualTable(((TableListItem)objSel).Table, splitContainerWork.Panel1.PointToClient(new Point(e.X,e.Y)));
            
        }

        /// <summary>
        /// Evento do Timer que controle o seleção do tabela que sejá colocada para edição da consulta
        /// </summary>
        /// <param name="sender">Temporizador</param>
        /// <param name="e">Parâmetros</param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.DoDragDrop(this.listBoxTables.SelectedIndex.ToString(), DragDropEffects.Move);
            this.DragStop();
        }

        /// <summary>
        /// Libera o Temporizador
        /// </summary>
        /// <param name="sender">Lista de Tabelas</param>
        /// <param name="e">Parâmetros</param>
        private void listBoxTables_MouseUp(object sender, MouseEventArgs e)
        {
            this.DragStop();
            
        }

        /// <summary>
        /// Arrastando a tabela selecionada sobre o área de edição
        /// </summary>
        /// <param name="sender">Área de Edição</param>
        /// <param name="e">Parâmetros</param>
        private void splitContainerWork_Panel1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }
        #endregion

        #region Visual Join

        /// <summary>
        /// Adiciona um Join visual ao Editor
        /// </summary>
        /// <param name="join"></param>
        void AddVisualJoin(Join join)
        {
            _query.Joins.Add(join);
            VisualJoin _visualObject = new VisualJoin();
            _visualObject.Top = 10;
            _visualObject.Left = 10;
            _visualObject.Join = join;
            _visualObject.JoinChanged += new JoinEventHandler(visualJoin_JoinChanged);
            _visualObject.JoinDeleted += new JoinEventHandler(visualJoin_JoinDeleted);
            _visualObject.TableLeft = _visualTables[join.Left.Table.FullName];
            _visualObject.TableRight = _visualTables[join.Right.Table.FullName];
            _visualJoins.Add(_visualObject);

            this.splitContainerWork.Panel1.Controls.Add(_visualObject);
        }

        /// <summary>
        /// Alteração no tipo do Join
        /// </summary>
        /// <param name="sender">VisualJoin</param>
        /// <param name="args">Argumentos</param>
        void visualJoin_JoinChanged(object sender, JoinEventArgs args)
        {
            this.RenderSQL();
        }

        /// <summary>
        /// Join foi Eliminado
        /// </summary>
        /// <param name="sender">VisualJoin</param>
        /// <param name="args">Argumentos</param>
        void visualJoin_JoinDeleted(object sender, JoinEventArgs args)
        {
            _query.Joins.Remove(args.Join);
            if (sender is VisualJoin)
                _visualJoins.Remove((VisualJoin)sender);
            this.RenderSQL();
            this.splitContainerWork.Panel1.Invalidate();
        }

        /// <summary>
        /// Redesenha as linhas das tabelas
        /// </summary>
        /// <param name="sender">Objeto que disparou o evento</param>
        /// <param name="e">Argumentos</param>
        private void splitContainerWork_Panel1_Paint(object sender, PaintEventArgs e)
        {
            foreach(VisualJoin _join in _visualJoins)
            {
                Point _leftP = _join.TableLeft.GetPositionOnTable(_join.Join.Left);
                Point _rightP = _join.TableRight.GetPositionOnTable(_join.Join.Right);

                // Muda a pardida do risco para o outro lado
                if (_join.TableLeft.Left < _join.TableRight.Left)
                    this.DrawJoin(e, _join, _leftP, _join.TableLeft.Size, _rightP, _join.TableRight.Size);
                else
                    this.DrawJoin(e, _join, _rightP, _join.TableRight.Size, _leftP, _join.TableLeft.Size);

            }
        }

#if false
        /// <summary>
        /// Desenha o Join na Área de Edição
        /// </summary>
        /// <param name="e">Argumento de Desenho. Ponteiro para o pintor do Windows</param>
        /// <param name="visualJoin">Elemento visual do Join</param>
        /// <param name="leftPoint">Ponto que indica Onde se encontra a tabela a esquerda</param>
        /// <param name="leftSize">Largura e Altura do Objeto a esquerda</param>
        /// <param name="rightPoint">Ponto que indica Onde se encontra a tabela a direita</param>
        /// <param name="rightSize">Largura e Altura do Objeto a esquerda</param>
        private void DrawJoin(PaintEventArgs e, VisualJoin visualJoin, Point leftPoint, Size leftSize, Point rightPoint, Size rightSize)
        {
            // Caneta para desenhas as linhas.
            Pen bluePen = new Pen(Color.Blue, 2);

            Point _leftLineStart;
            Point _leftLineEnd;
            Point _rightLineStart;
            Point _rightLineEnd;
            Point _linkTopLineStart;
            Point _linkTopLineEnd;
            Point _linkBottonLineStart;
            Point _linkBottonLineEnd;


            bool _twoByLeft = false;
            // Verifica se a conexão vai acontecer toda pela esquerda. caso em que tabela da direita está antes da tabela da esquerda
            if (leftPoint.X + leftSize.Width > rightPoint.X)
            {
                _twoByLeft = true;
                _leftLineStart = new Point(leftPoint.X - 80, leftPoint.Y);
                _leftLineEnd = leftPoint;

                _rightLineStart = new Point(_leftLineStart.X, rightPoint.Y);
                _rightLineEnd = rightPoint;

                if (leftPoint.Y < rightPoint.Y)
                {
                    _linkTopLineStart = _leftLineStart;
                    _linkTopLineEnd = _rightLineStart;
                }
                else
                {
                    _linkTopLineStart = _rightLineStart;
                    _linkTopLineEnd = _leftLineStart;
                }
            }
            else
            {
                _leftLineStart = new Point(leftPoint.X + leftSize.Width, leftPoint.Y);
                _rightLineEnd = rightPoint;

                int _midle = (_leftLineStart.X + _rightLineEnd.X) / 2;

                _leftLineEnd = new Point(_midle, _leftLineStart.Y);
                _rightLineStart = new Point(_midle, _rightLineEnd.Y);

                if (leftPoint.Y < rightPoint.Y)
                {
                    _linkTopLineStart = _leftLineEnd;
                    _linkTopLineEnd = _rightLineStart;
                }
                else
                {
                    _linkTopLineStart = _rightLineStart;
                    _linkTopLineEnd = _leftLineEnd;
                }
            }

            Point _joinPosition = new Point(((_linkTopLineStart.X + _linkTopLineEnd.X) / 2) - visualJoin.UnitHeight  / 2,
                                           ((_linkTopLineStart.Y + _linkTopLineEnd.Y) / 2) - visualJoin.UnitHeight / 2);
            if (_joinPosition != visualJoin.Location)
                visualJoin.Location = _joinPosition;

            _linkBottonLineEnd = _linkTopLineEnd;
            _linkTopLineEnd.Y = visualJoin.Top;
            _linkBottonLineStart = new Point(_linkTopLineEnd.X, visualJoin.Top + visualJoin.Height);

            bool _midleLine = true;
            if (_twoByLeft)
            {
                if (_leftLineStart.Y > visualJoin.Top && _leftLineStart.Y < visualJoin.Top + visualJoin.Height)
                {
                    _leftLineStart.X = visualJoin.Left + visualJoin.Width;
                    _rightLineStart.X = visualJoin.Left + visualJoin.Width;
                    _midleLine = false;
                }
            }
            else
            {
                if (_leftLineStart.Y > visualJoin.Top && _leftLineStart.Y < visualJoin.Top + visualJoin.Height)
                {
                    _leftLineEnd.X = visualJoin.Left;
                    _rightLineStart.X = visualJoin.Left + visualJoin.Width;
                    _midleLine = false;
                }
            }

           
            e.Graphics.DrawLine(bluePen, new PointF(_leftLineStart.X, _leftLineStart.Y), new PointF(_leftLineEnd.X, _leftLineEnd.Y));
            if (_midleLine)
            {
                e.Graphics.DrawLine(bluePen, new PointF(_linkTopLineStart.X, _linkTopLineStart.Y), new PointF(_linkTopLineEnd.X, _linkTopLineEnd.Y));
                e.Graphics.DrawLine(bluePen, new PointF(_linkBottonLineStart.X, _linkBottonLineStart.Y), new PointF(_linkBottonLineEnd.X, _linkBottonLineEnd.Y));
            }
            e.Graphics.DrawLine(bluePen, new PointF(_rightLineStart.X, _rightLineStart.Y), new PointF(_rightLineEnd.X, _rightLineEnd.Y));
        }

#else


        /// <summary>
        /// Desenha o Join na Área de Edição
        /// </summary>
        /// <param name="e">Argumento de Desenho. Ponteiro para o pintor do Windows</param>
        /// <param name="visualJoin">Elemento visual do Join</param>
        /// <param name="leftPoint">Ponto que indica Onde se encontra a tabela a esquerda</param>
        /// <param name="leftSize">Largura e Altura do Objeto a esquerda</param>
        /// <param name="rightPoint">Ponto que indica Onde se encontra a tabela a direita</param>
        /// <param name="rightSize">Largura e Altura do Objeto a esquerda</param>
        private void DrawJoin(PaintEventArgs e, VisualJoin visualJoin, Point leftPoint, Size leftSize, Point rightPoint, Size rightSize)
        {
            // Caneta para desenhas as linhas.
            Pen bluePen = new Pen(Color.Blue, 2);

            Point _leftLineStart;
            Point _leftLineEnd;
            Point _rightLineStart;
            Point _rightLineEnd;
            Point _linkTopLineStart;
            Point _linkTopLineEnd;
            Point _linkBottonLineStart;
            Point _linkBottonLineEnd;


            bool _twoByLeft = false;
            // Verifica se a conexão vai acontecer toda pela esquerda. caso em que tabela da direita está antes da tabela da esquerda
            if (leftPoint.X + leftSize.Width > rightPoint.X)
            {
                _twoByLeft = true;
                _leftLineStart = new Point(leftPoint.X - 80, leftPoint.Y);
                _leftLineEnd = leftPoint;

                _rightLineStart = new Point(_leftLineStart.X, rightPoint.Y);
                _rightLineEnd = rightPoint;

                if (leftPoint.Y < rightPoint.Y)
                {
                    _linkTopLineStart = _leftLineStart;
                    _linkTopLineEnd = _rightLineStart;
                }
                else
                {
                    _linkTopLineStart = _rightLineStart;
                    _linkTopLineEnd = _leftLineStart;
                }
            }
            else
            {
                _leftLineStart = new Point(leftPoint.X + leftSize.Width, leftPoint.Y);
                _rightLineEnd = rightPoint;

                int _midle = (_leftLineStart.X + _rightLineEnd.X) / 2;

                _leftLineEnd = new Point(_midle, _leftLineStart.Y);
                _rightLineStart = new Point(_midle, _rightLineEnd.Y);

                if (leftPoint.Y < rightPoint.Y)
                {
                    _linkTopLineStart = _leftLineEnd;
                    _linkTopLineEnd = _rightLineStart;
                }
                else
                {
                    _linkTopLineStart = _rightLineStart;
                    _linkTopLineEnd = _leftLineEnd;
                }
            }

            Point _joinPosition = new Point(((_linkTopLineStart.X + _linkTopLineEnd.X) / 2) - visualJoin.UnitHeight / 2,
                                           ((_linkTopLineStart.Y + _linkTopLineEnd.Y) / 2) - visualJoin.UnitHeight / 2);
            if (_joinPosition != visualJoin.Location)
                visualJoin.Location = _joinPosition;

            _linkBottonLineEnd = _linkTopLineEnd;
            _linkTopLineEnd.Y = visualJoin.Top;
            _linkBottonLineStart = new Point(_linkTopLineEnd.X, visualJoin.Top + visualJoin.Height);

            bool _midleLine = true;
            if (_twoByLeft)
            {
                if (_leftLineStart.Y > visualJoin.Top && _leftLineStart.Y < visualJoin.Top + visualJoin.Height)
                {
                    _leftLineStart.X = visualJoin.Left + visualJoin.Width;
                    _rightLineStart.X = visualJoin.Left + visualJoin.Width;
                    _midleLine = false;
                }
            }
            else
            {
                if (_leftLineStart.Y > visualJoin.Top && _leftLineStart.Y < visualJoin.Top + visualJoin.Height)
                {
                    _leftLineEnd.X = visualJoin.Left;
                    _rightLineStart.X = visualJoin.Left + visualJoin.Width;
                    _midleLine = false;
                }
            }

            if (_twoByLeft)
            {
                e.Graphics.DrawLine(bluePen, new PointF(_leftLineStart.X, _leftLineStart.Y), new PointF(_leftLineEnd.X, _leftLineEnd.Y));
                if (_midleLine)
                {
                    e.Graphics.DrawLine(bluePen, new PointF(_linkTopLineStart.X, _linkTopLineStart.Y), new PointF(_linkTopLineEnd.X, _linkTopLineEnd.Y));
                    e.Graphics.DrawLine(bluePen, new PointF(_linkBottonLineStart.X, _linkBottonLineStart.Y), new PointF(_linkBottonLineEnd.X, _linkBottonLineEnd.Y));
                }
                e.Graphics.DrawLine(bluePen, new PointF(_rightLineStart.X, _rightLineStart.Y), new PointF(_rightLineEnd.X, _rightLineEnd.Y));
            }
            else
            {
                e.Graphics.DrawLine(bluePen, new PointF(_leftLineStart.X, _leftLineStart.Y), new PointF(_rightLineEnd.X, _rightLineEnd.Y));
            }
        }
#endif

        #endregion

        #region Filter Tables
        /// <summary>
        /// Evento de Filtro da lista de tabelas
        /// </summary>
        /// <param name="sender">Botão</param>
        /// <param name="e">Argumento</param>
        private void toolStripButtonGo_Click(object sender, EventArgs e)
        {
            this.LoadDataBase(toolStripTextBoxFilter.TextBox.Text);
        }
        #endregion

        #region Advanced Where
        /// <summary>
        /// Edição avançada de Where
        /// </summary>
        /// <param name="sender">Grade</param>
        /// <param name="e">Argumento</param>
        private void dataGridViewWhere_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            Where _w;
            // Se é reg novo
            if (_query.Wheres.Count < e.RowIndex + 1)
            {
                _w = new Where();
                _query.Wheres.Add(_w);
            }
            else
            {
                _w = _query.Wheres[e.RowIndex];
            }


            switch (e.ColumnIndex)
            {
                case 0:
                    Column _c = _query.FindColumn(dgv.CurrentCell.Value.ToString()); // busca a coluna
                    if (_c != null)
                    {
                        _w.Left = _c;
                        dgv.CurrentRow.Cells[1].Value = "=";
                        dgv.CurrentRow.Cells[3].Value = "AND";
                    }
                    break;
                case 1:
                    _w.Operation = OperationFX.StringToOperation(dgv.CurrentCell.Value.ToString());
                    break;
                case 2:
                    _w.Right = dgv.CurrentCell.Value.ToString();
                    break;
                case 3:
                    _w.Junction = dgv.CurrentCell.Value.ToString();
                    break;
            }

            this.RenderSQL();
        }

        /// <summary>
        /// Where avançado Deleção de Linha
        /// </summary>
        /// <param name="sender">Grade</param>
        /// <param name="e">Argumento</param>
        private void dataGridViewWhere_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (_query.Wheres.Count > e.Row.Index)
                _query.Wheres.RemoveAt(e.Row.Index);
            this.RenderSQL();
        }

        private void LoadTabControl()
        {
            colunaDataGridViewComboBoxColumn.Items.Clear();
            foreach (Table _table in this._query.Tables)
                foreach (Column _column in _table.Columns)
                    colunaDataGridViewComboBoxColumn.Items.Add(_column.FullName);

            visualFilters.Refresh();

        }
        #endregion

        #region Events for Visual Modeler
        void visualFilters_ShowColumnChanged(Column column, bool selected)
        {
            if (!column.Expression)
                _visualTables[column.Table.FullName].SetSelectedColumn(column, selected);

            this.RenderSQL();
        }

        /// <summary>
        /// Carragando a Editor de Filtros básico
        /// </summary>
        /// <param name="sender">Editor de Filtros</param>
        /// <param name="e">Argumento</param>
        private void visualFilters_Load(object sender, EventArgs e)
        {
            this.visualFilters.Query = _query;
        }

        /// <summary>
        /// Evento de Redesenho da Consulta
        /// </summary>
        /// <param name="sender">Editor de Filtros</param>
        /// <param name="e">Argumento</param>
        private void visualFilters_RenderSQL(object sender, EventArgs e)
        {
            this.RenderSQL();
        }
        #endregion

        #region DragDropTreeView

        bool _movingNode = false;
        private void treeViewSQL_MouseDown(object sender, MouseEventArgs e)
        {
            if (treeViewSQL.SelectedNode != null)
            {
                timer2.Start();
            }
        }

        private void treeViewSQL_MouseUp(object sender, MouseEventArgs e)
        {
            _movingNode = false;
            timer2.Stop();
        }

        private void treeViewSQL_DragDrop(object sender, DragEventArgs e)
        {
            if (_movingNode)
            {
                timer2.Stop();
                if (e.Data.GetDataPresent(typeof(TreeNode)))
                {
                    TreeNode _this = treeViewSQL.GetNodeAt(treeViewSQL.PointToClient(new Point(e.X, e.Y)));
                    if (_this != null)
                    {
                        TreeNode _parentThis = _this.Parent;

                        TreeNode _treeNodeMove = (TreeNode)e.Data.GetData(typeof(TreeNode));
                        if (_treeNodeMove != null)
                        {
                            TreeNode _parentMove = _treeNodeMove.Parent;
                            int _indexMove = _parentMove.Nodes.IndexOf(_treeNodeMove);
                            int _indexThis = _parentThis.Nodes.IndexOf(_this);


                            // Se for não palhavra chave e tiver o mesmo pai
                            if (_treeNodeMove.Level == 2 && _parentMove.Text == _parentThis.Text && _this != _treeNodeMove)
                            {
                                this.MoveInQuery(_parentMove.Text, _indexMove, _indexThis);

                                this.treeViewSQL.SelectedNode = _treeNodeMove;

                                // Redesenha o treeview
                                this.treeViewSQL.Refresh();
                            }

                        }
                    }

                }
            }
        }

        private void treeViewSQL_DragEnter(object sender, DragEventArgs e)
        {
            if (_movingNode)
            {
                if (e.Data.GetDataPresent(typeof(TreeNode)))
                    e.Effect = DragDropEffects.Move;
                else
                    e.Effect = DragDropEffects.None;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            _movingNode = true;
            treeViewSQL.DoDragDrop(treeViewSQL.SelectedNode, DragDropEffects.Move);
        }


#endregion

        #region Carregar uma sintaxe no Editor Visual
        /// <summary>
        /// Carrega visual a Sintaxe SQL
        /// </summary>
        /// <param name="syntax"></param>
        public void LoadSyntax(string syntax)
        {
            // Sintaxes identicas não procisa fazer nada
            if (syntax == this.richTextBoxSQL.Text)
                return;
            if (syntax.EndsWith(";"))
                syntax = syntax.Remove(syntax.Length - 1);

            Database.SelectAnalyzer _sql = new Database.SelectAnalyzer(syntax);
            
            foreach(Database.SelectAnalyzer.Consulta consulta in _sql.Consultas)
                if (consulta.Tipo == Database.SelectAnalyzer.TipoConsulta.Uniao)
                    throw new Error.Excessao(197);

            if (_sql.Consultas.Length == 0)
            {
                this.Clear();
                if (syntax.Trim() == string.Empty)
                    return;
                else
                    throw new Error.Excessao(197);
            }
            Database.SelectAnalyzer.Consulta _consulta = _sql.Consultas[0];
            
            // Já tem uma sintaxe anterior
            if (this.richTextBoxSQL.Text != string.Empty)
            {
                this.Clear();
            }
            if (syntax == string.Empty)
                return;

            Point p = new Point(10, 10);
            foreach(Database.SelectAnalyzer.Consulta.AnalyzerTabelaOrigem _tableQuery in _consulta.Tabelas)
            {
                bool findTable = false;
                foreach(Table _table in _database.Tables)
                    if (Database.SelectAnalyzer.Consulta.AnalyzerTabelaOrigem.CompararNomeTabela(_tableQuery.Banco, _table.Name))
                    {
                        Table _newTable = (Table)_table.Clone();
                        _newTable.Alias = _tableQuery.Apelido;
                        this.LoadVisualTable(_newTable, p);
                        p.X += _visualTables[_newTable.FullName].Width + 10;
                        findTable = true;
                        break;
                    }
                if (!findTable)
                    throw new Error.Excessao(96, _tableQuery.Referencia);
            }

            foreach(Database.SelectAnalyzer.Consulta.AnalyzerCampo _column in _consulta.Campos)
            {
                if (_column.ColunaCompleta == "*")
                {
                    foreach (VisualTable _vt in _visualTables.Values)
                        _vt.SelectAll();
                    continue;
                }


                Column _col = _query.FindColumn(_column.NomeBanco);
                if (_col == null)
                    _col = new Column(_column.ColunaCompleta);
                else
                {
                    _col = (Column)_col.Clone();
                    if (_column.Apelido != string.Empty)
                        _col.Alias = _column.Apelido;
                    else
                        _visualTables[_col.Table.FullName].SetSelectedColumn(_col, true);
                }

                visualFilters.SetShowColumn(_col, true, true);

                _query.Columns.Add(_col);
            }

            foreach (Database.SelectAnalyzer.Consulta.AnalyzerJoin _join in _consulta.Ligacoes)
            {
                Column _left = null;
                Column _right = null;
                if (_join.Type == Database.SelectAnalyzer.Consulta.AnalyzerJoinType.RightOuterJoin)
                {
                    throw new Error.Excessao(197);
                }
                else
                {
                    _left = AssignColumn(_join.Left.ColunaCompleta);
                    _right = AssignColumn(_join.Right.ColunaCompleta);
                }
                Join _newJoin = new Join(_left, _right);
                if (_join.Type != Database.SelectAnalyzer.Consulta.AnalyzerJoinType.InnerJoin)
                    _newJoin.Operation = Operation.LeftOuterJoin;
                else
                    _newJoin.Operation = OperationFX.StringToOperation(_join.Operation);
                AddVisualJoin(_newJoin);
            }

            this.InputWhere(_consulta.Filtros);
            
            foreach (Database.SelectAnalyzer.Consulta.AnalyzerCampo _column in _consulta.Grupo)
            {
                Column _col = AssignColumn(_column.ColunaCompleta);
                visualFilters.SetGroup(_col, true);
                
            }

            foreach (Database.SelectAnalyzer.Consulta.AnalyzerOrder _order in _consulta.Ordem)
            {
                Order _ord = new Order();
                _ord.DescendingOrder = _order.Descendente;
                _ord.Column = AssignColumn(_order.Coluna.ColunaCompleta);
                _query.Orders.Add(_ord);
            }

            List<Database.SelectAnalyzer.Consulta.WherePiece> filtros = _consulta.FiltrosGrupo;
            if (filtros != null)
                if (filtros.Count  > 0 )
                    visualFilters.SetHavingList(filtros);

            this.RenderSQL();
            
        }

        /// <summary>
        /// Limpa todos os objetos da consulta anterior
        /// </summary>
        private void Clear()
        {
            _query = new Query();
            this.visualFilters.ClearAll();
            visualFilters.Query = _query;
            foreach (VisualTable _vt in _visualTables.Values)
                this.splitContainerWork.Panel1.Controls.Remove(_vt);
            _visualTables.Clear();

            foreach (VisualJoin _vj in _visualJoins)
                this.splitContainerWork.Panel1.Controls.Remove(_vj);
            _visualJoins.Clear();
        }


        /// <summary>
        /// Digita os dados do where nas suas respectivas unidades
        /// </summary>
        /// <param name="list">Lista de comandos</param>
        private void InputWhere(List<Database.SelectAnalyzer.Consulta.WherePiece> list)
        {
            if (list == null)
                return;

            if (list.Count < 1)
                return;

            int countOrs = 0;

            // Comandos não join que irão ser distribuídos no visual where
            var _goToVisualWhere = new List<Database.SelectAnalyzer.Consulta.WherePiece>();

            // retirar os Joins
            var _joinPossible = new List<Database.SelectAnalyzer.Consulta.WherePiece>();
            bool _haveOr = false;
            int _followParenteses = 0;
            foreach (var _item in list)
            {
                
                _joinPossible.Add(_item);

                // se é and ou or
                if (_item is Database.SelectAnalyzer.Consulta.WhereJunctionPiece)
                {
                    // se é um or não vai funcionar um join
                    if (((Database.SelectAnalyzer.Consulta.WhereJunctionPiece)_item).IsOr())
                    {
                        _followParenteses = 0;
                        _haveOr = true;
                        countOrs++;
                    } // se é um or
                    else if (((Database.SelectAnalyzer.Consulta.WhereJunctionPiece)_item).IsAnd())
                    {
                        // se tiver entre ands e não estiver dentro de um grupo feito por parênteses criar como join
                        if (!_haveOr && _followParenteses == 0)
                        {
                            if (this.IsJoinAndCanAddIt(_joinPossible))
                            {
                                _joinPossible.Clear();
                                continue;
                            }
                        }
                        _followParenteses = 0;
                        _haveOr = false;

                    }

                    _goToVisualWhere.AddRange(_joinPossible);

                    _joinPossible.Clear();
                }
                else if (_item is Database.SelectAnalyzer.Consulta.WhereOpenParentesesPiece)
                    _followParenteses++;
                else if (_item is Database.SelectAnalyzer.Consulta.WhereCloseParentesesPiece)
                    _followParenteses--;
            }

            if (countOrs > 6)
                throw new Error.Excessao(197);

            // Ultima parte do where
            if (_joinPossible.Count > 0)
                if (_followParenteses == 0)
                {
                    if (!this.IsJoinAndCanAddIt(_joinPossible))
                        _goToVisualWhere.AddRange(_joinPossible);
                }
                else
                    _goToVisualWhere.AddRange(_joinPossible);

            // se sobrou algo pra ser colocado no visual where
            if (_goToVisualWhere.Count > 0)
            {
                if (_goToVisualWhere[_goToVisualWhere.Count - 1] is Database.SelectAnalyzer.Consulta.WhereJunctionPiece)
                {
                    // retira o ultimo and que pode ter sobrado da criação dos joins
                    _goToVisualWhere.RemoveAt(_goToVisualWhere.Count - 1);
                }
                //throw new Error.Excessao(197);
            }

            // passar para o visual filter fazer o resto
            visualFilters.SetWhereList(_goToVisualWhere);

            
            
        }

        /// <summary>
        /// Verifica se é um join visual e em caso positivo adiciona ele na tela
        /// </summary>
        /// <param name="joinPossible">Linha de Join no Where</param>
        /// <returns>Se adicionou visualmente retorna true senão false</returns>
        private bool IsJoinAndCanAddIt(List<Database.SelectAnalyzer.Consulta.WherePiece> joinPossible)
        {
            int _openPar = 0;
            // ignora qualquer parenteses aberto antes dos comandos de ligação
            while (joinPossible[_openPar] is Database.SelectAnalyzer.Consulta.WhereOpenParentesesPiece)
                _openPar++;

            // Se fecha com a juncao ignora a junção. Depois ignora os parêteses que fecham
            int _closePar = joinPossible.Count - 1;
            if (_closePar < 2)
                return false;
            if (joinPossible[_closePar] is Database.SelectAnalyzer.Consulta.WhereJunctionPiece)
                _closePar--;
            while (joinPossible[_closePar] is Database.SelectAnalyzer.Consulta.WhereCloseParentesesPiece)
                _closePar--;

            // se ter três comandos sendo duas colunas e uma ligação lógica
            if (_closePar - _openPar == 2)
            {
                if (joinPossible[_openPar] is Database.SelectAnalyzer.Consulta.WhereColumnPiece &&
                    joinPossible[_closePar] is Database.SelectAnalyzer.Consulta.WhereColumnPiece &&
                    joinPossible[_openPar + 1] is Database.SelectAnalyzer.Consulta.WhereLogicalOperatorPiece)
                {
                    Column _left = _query.FindColumn(joinPossible[_openPar].Syntax);
                    Column _right = _query.FindColumn(joinPossible[_closePar].Syntax);


                    // Cria o Join e adiciona ele na tela
                    Join _join = new Join(_left, _right);
                    _join.Operation = OperationFX.StringToOperation(joinPossible[_openPar + 1].Syntax);
                    this.AddVisualJoin(_join);

                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Transforma uma string com o nome da coluna em um objeto coluna
        /// </summary>
        /// <param name="columnName">Nome da coluna</param>
        /// <returns>Coluna</returns>
        private Column AssignColumn(string columnName)
        {
            Column _col = _query.FindColumn(columnName);
            if (_col == null)
                _col = new Column(columnName);
            return _col;
        }

        #endregion
    }
}
