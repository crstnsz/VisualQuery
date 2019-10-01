using System;
using System.Collections.Generic;

namespace VisualQuery
{
    internal class Table : ICloneable
    {
        private string _name = string.Empty;
        private string _alias = string.Empty;

        private List<Column> _columns = new List<Column>();

        public string Alias
        {
            get { return ((_alias == string.Empty)?this.Name:this._alias); }
            set
            {
                if (value.StartsWith("["))
                    _alias = "[" + value.Replace("[", "").Replace("]", "") + "]";
                else
                    _alias = value;
                _alias = _alias.Replace(".", "_");
            }
        }
        
        public Table(string name)
        {
            this._name = name;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        internal List<Column> Columns
        {
            get { return _columns; }
            set { this._columns = value; }
        }

        public string FullName 
        {
            get { return (this.HasAlias()) ? this.Name + " " + this.Alias : this.Name; }
        }

        public static bool operator == (Table left, Table right)
        {
            if ((object)left == null && (object)right == null)
                return true;
            if ((object)left == null || (object)right == null)
                return false;
            return left.FullName.Replace("[", "").Replace("]","") == right.FullName.Replace("[", "").Replace("]","");
        }

        public bool HasAlias()
        {
            return _alias != string.Empty;
        }

        public static bool operator !=(Table left, Table right)
        {
            return !(left == right);
        }

        #region ICloneable Members

        public object Clone()
        {
            Table _newTable = new Table(this.Name);
            foreach (Column _col in this.Columns)
            {
                Column _colAdd = new Column(_newTable, _col.Name, _col.Type);
                _newTable.Columns.Add(_colAdd);
            }

            return _newTable;
        }

        #endregion
    }
}
