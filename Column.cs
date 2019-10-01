using System;

namespace VisualQuery
{
    internal class Column : ICloneable
    {
        string _name = string.Empty;
        string _alias = string.Empty;
        Table _table = null;
        string _type = string.Empty;
        bool _pk = false;
        bool _expression = false;

        private Column()
        {
        }
        
        public Column(Table table)
        {
            this._table = table;
        }

        public Column(Table table, string name, string type)
        {
            this._table = table;
            this._name = name;
            this._type = type;
        }

        public Column(string expression)
        {
            Literal.ProjectString _ps = new Literal.ProjectString();
            string[] _parts = _ps.Split(expression, " AS ");
            if (_parts.Length == 2)
            {
                _name = _parts[0];
                _alias = _parts[1];
            }
            else
                _name = expression;

            _expression = true;
        }
        
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Alias
        {
            get { return (this._alias != string.Empty)?this._alias:this.Name; }

            set { this._alias = value; }
        }

        public string SchemaName
        {
            get
            {
                if (_expression)
                    return this.Name;
                else
                    return string.Format("{0}.{1}", this.Table.Alias, this.Name); 
            }
        }

        public string FullName
        {
            get 
            {
                if (_alias != string.Empty)
                    return string.Format("{0} AS {1}", this.SchemaName , _alias); 
                else
                    return this.SchemaName; 
            }
        }
        
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public Table Table
        {
            get { return this._table; }
        }

        public bool PK
        {
            get { return _pk; }
            set { _pk = value; }
        }

        public bool Expression
        {
            get { return _expression; }
        }

        #region ICloneable Members

        public object Clone()
        {
            Column _clone = new Column();
            _clone._name = this._name;
            _clone._alias = this._alias;
            _clone._table = this._table;
            _clone._type = this._type;
            _clone._pk = this._pk;
            _clone._expression = this._expression;

            return _clone;
        }

        #endregion
    }
}
