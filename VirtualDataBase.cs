using System.Collections.Generic;
using Database;
using System.Data;

namespace VisualQuery
{
    
    internal class VirtualDataBase
    {
        #region Variable Definition
        IDataAccessManager _dataProvider;
        List<Table> _tables = null;

        internal List<Table> Tables
        {
            get {
                if (this._tables == null)
                {
                    this._tables = new List<Table>();
                    this.LoadTables();
                }
                return _tables; 
            }
        }

        #endregion


        private void LoadTables()
        {            
            DataTable _listOfTables = (new DBUtils(this._dataProvider)).ObtemTabelasUsuario();

            foreach (DataRow _row in _listOfTables.Rows)
                _tables.Add(new Table((string)_row["nometabela"]));
        }

        public void LoadColumn(ref Table table)
        {
            DataTable _definition = (new DBUtils(this._dataProvider)).ObtemDefinicaoTabela(string.Format("SELECT * FROM {0}", table.Name),true);
            foreach(DataColumn dtCol in _definition.Columns)
            {
                Column col = new Column(table);
                col.Name = dtCol.ColumnName;
                col.Type =  dtCol.DataType.UnderlyingSystemType.Name ;
                table.Columns.Add(col);
                foreach (DataColumn _pk in _definition.PrimaryKey)
                    if (_pk.ColumnName == col.Name)
                        col.PK = true;

            }
        }

        public IDataAccessManager DataProvider
        {
            get { return _dataProvider; }
            set { _dataProvider = value; _tables = null; }
        }

        public void ReloadTables()
        {
            this._tables = new List<Table>();
            this.LoadTables();
        }
    }
}
