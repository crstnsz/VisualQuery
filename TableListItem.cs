
namespace VisualQuery
{
    internal class TableListItem
    {
        private Table _table = null;

        public TableListItem(Table table)
        {
            this._table = table;
        }

        public override string ToString()
        {
            return this._table.Name;
        }

        public Table Table
        {
            get { return this._table; }
        }
    }
}
