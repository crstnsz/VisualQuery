using System.Collections.Generic;
using System.Text;

namespace VisualQuery
{
    /// <summary>
    /// Administra e Escreve as Consultas SQL
    /// </summary>
    public class Query
    {
        private List<Column> _columns = new List<Column>();

        /// <summary>
        /// Colunas da Consulta
        /// </summary>
        internal List<Column> Columns
        {
            get { return _columns; }
            set { _columns = value; }
        }
        private List<Table> _tables = new List<Table>();

        /// <summary>
        /// Tabelas da Consulta
        /// </summary>
        internal List<Table> Tables
        {
            get { return _tables; }
            set { _tables = value; }
        }

        private List<Join> _joins = new List<Join>();

        /// <summary>
        /// Ligações entre tabelas
        /// </summary>
        internal List<Join> Joins
        {
            get { return _joins; }
            set { _joins = value; }
        }

        internal List<Where> _wheres = new List<Where>();

        /// <summary>
        /// Filtros das tabelas
        /// </summary>
        internal List<Where> Wheres
        {
            get { return _wheres; }
            set { _wheres = value; }
        }

        private List<Order> _orders = new List<Order>();

        /// <summary>
        /// Campos de Ordenação
        /// </summary>
        internal List<Order> Orders
        {
            get { return _orders; }
            set { _orders = value; }
        }

        private List<Column> _groups = new List<Column>();

        /// <summary>
        /// Agrupadores
        /// </summary>
        internal List<Column> Groups
        {
            get { return _groups; }
            set { _groups = value; }
        }

        internal List<Where> _havings = new List<Where>();

        /// <summary>
        /// Filtros das tabelas
        /// </summary>
        internal List<Where> Havings
        {
            get { return _havings; }
            set { _havings = value; }
        }


        /// <summary>
        /// Retorna a Consulta SQL Textual
        /// </summary>
        /// <returns></returns>
        internal string BuildSQL()
        {
            StringBuilder _sql = new StringBuilder("SELECT ");
            if (this._columns.Count == 0)
                _sql.Append("* ");
            else
            {
                foreach (Column _column in this._columns)
                {
                    _sql.Append(_column.FullName);
                    _sql.Append(", ");
                }
                _sql.Remove(_sql.Length - 2, 1);
            }

            _sql.Append("\nFROM ");

            // Guarda quantas vezes a tebela foi encontrada
            int[] _stepsAdded = new int[this._joins.Count];
            if (this._tables.Count > 0)
            {
                StringBuilder _allJoins = new StringBuilder();
                
                bool _inJoin = false;
                bool _firstAdd = true;

                int _innerJoinCount = 0;

                foreach (Table _table in this.Tables)
                {
                    StringBuilder _join = new StringBuilder();
                    bool _leftOuterJoin = false;
                    _inJoin = false;

                    for(int i = 0;i < _joins.Count; i ++)
                    {
                        if (_joins[i].Left.Table.Alias == _table.Alias || _joins[i].Right.Table.Alias == _table.Alias)
                        {
                            _stepsAdded[i]++;
                            // se já carregou os dois lados do join
                            if (_stepsAdded[i] == 2)
                            {
                                if (_joins[i].Operation == Operation.LeftOuterJoin)
                                    _leftOuterJoin = true;
                                if (!_inJoin)
                                {
                                    _innerJoinCount++;
                                    _join.AppendFormat("JOIN {0} \n\t\tON {1} {2} {3}", _table.FullName, _joins[i].Left.SchemaName, OperationFX.OperationToString(_joins[i].Operation), _joins[i].Right.SchemaName);
                                    _inJoin = true;
                                }
                                else
                                    _join.AppendFormat("\n\t\t\tAND {0} {1} {2}", _joins[i].Left.SchemaName, OperationFX.OperationToString(_joins[i].Operation), _joins[i].Right.SchemaName);
                            }
                        }
                    }

                    if (_inJoin)
                    {
                        if (_innerJoinCount > 1)
                            _allJoins.Append(")");

                        if (_leftOuterJoin)
                            _allJoins.Append("\n\tLEFT OUTER ");
                        else
                            _allJoins.Append("\n\tINNER ");
                        _allJoins.Append(_join.ToString());
                    }
                    else
                    {
                        if (!_firstAdd)
                        {
                            if (_innerJoinCount > 0)
                                _allJoins.Append(")");
                        }
                        else
                        {
                            if (_innerJoinCount > 1)
                                _allJoins.Append(")");
                        }

                        while(_innerJoinCount > 0)
                        {
                            _innerJoinCount --;
                            _sql.Append("(");
                        }

                        if (!_firstAdd)
                        {
                            _sql.Append(_allJoins.ToString());
                            _sql.Append(",\n\t");
                            _allJoins = new StringBuilder();
                        }
                        _allJoins.Append(_table.FullName);

                        if (_firstAdd)
                            _firstAdd = false;
                                                
                    }
                }

                while (_innerJoinCount > 1)
                {
                    _innerJoinCount--;
                    _sql.Append("(");
                }

                _sql.Append(_allJoins.ToString());
            }

            if (_wheres.Count > 0)
            {
                _sql.Append("\nWHERE ");
                bool _isExpression = false;
                string _whereSyntax = string.Empty;
                foreach(Where _where in _wheres)
                {
                    _whereSyntax = _where.ToString();
                    _sql.Append(_whereSyntax);
                    _isExpression = _where.Operation == Operation.FreeStyle;
                    if (_isExpression)
                    {
                        _whereSyntax = _whereSyntax.ToLower().Trim();
                        if (!(_whereSyntax.EndsWith("and") || _whereSyntax.EndsWith("or")))
                            _sql.Append(" AND");
                    }
                    _sql.Insert(_sql.Length - _where.Junction.Length, "\n\t");
                    _sql.Append(" ");
                }

            
                // Tira o último and ou or e o enter \r\n anterior a ele
                _sql.Remove(_sql.Length - _wheres[_wheres.Count - 1].Junction.Length - 3, _wheres[_wheres.Count - 1].Junction.Length + 3);
            }


            if (_groups.Count > 0)
            {
                _sql.Append("\nGROUP BY ");
                foreach (Column _column in this._groups)
                {
                    _sql.Append(_column.SchemaName);
                    _sql.Append(", ");
                }
                _sql.Remove(_sql.Length - 2, 1);
            }

            if (_havings.Count > 0)
            {
                _sql.Append("\nHAVING ");
                foreach (Where _having in _havings)
                {
                    _sql.Append(_having.ToString());
                    _sql.Insert(_sql.Length - _having.Junction.Length, "\n\t");
                    _sql.Append(" ");
                }

                // Tira o último and ou or
                _sql.Remove(_sql.Length - _havings[_havings.Count - 1].Junction.Length - 3, _havings[_havings.Count - 1].Junction.Length + 3);
            }

            if (_orders.Count > 0)
            {
                _sql.Append("\nORDER BY ");
                foreach (Order _order in this._orders)
                {
                    _sql.Append(_order.Column.SchemaName);
                    if (_order.DescendingOrder)
                        _sql.Append(" DESC");
                    _sql.Append(", ");
                }
                _sql.Remove(_sql.Length - 2, 1);
            }

            return _sql.ToString();
        }

        /// <summary>
        /// Procuta uma coluna dentro das tabelas
        /// </summary>
        /// <param name="fullName">Nome completo Tabela.Coluna</param>
        /// <returns>Coluna</returns>
        internal Column FindColumn(string fullName)
        {
            // Separa tabela da coluna
            string[] part = fullName.Trim().Split('.');
            if (part.Length < 1) // erro
                return null;
            if (part.Length == 1)
            {
                // Para cada tabela
                foreach (Table _t in _tables)
                {
                    // para cada coluna
                    foreach (Column _c in _t.Columns)
                    {
                        // se achou
                        if (Database.SelectAnalyzer.Consulta.AnalyzerCampo.ComparaColuna(_c.Name, part[0]))
                            return _c; // retorna
                    }
                }
            }
            else
            {
                string _columnName = string.Empty;
                string _tableName = string.Empty;
                if (part.Length == 2)
                {
                    _tableName = part[0];
                    _columnName = part[1];
                }
                else
                {
                    _tableName = string.Format("{0}.{1}", part[0], part[1]);
                    _columnName = part[2];
                }

                // Para cada tabela
                foreach (Table _t in _tables)
                {
                    // Se achou
                    if (Database.SelectAnalyzer.Consulta.AnalyzerTabelaOrigem.CompararNomeTabela(_t.Alias, _tableName))
                    {
                        // para cada coluna
                        foreach (Column _c in _t.Columns)
                        {
                            // se achou
                            if (Database.SelectAnalyzer.Consulta.AnalyzerCampo.ComparaColuna(_c.Name, _columnName))
                                return _c; // retorna
                        }
                    }
                }
            }

            return null;// não achou
        }

    }
}
