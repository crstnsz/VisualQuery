
namespace VisualQuery
{
    internal class Order
    {
        Column _column;
        bool _descendingOrder = false;

        internal Column Column
        {
            get { return _column; }
            set { _column = value; }
        }
        public bool DescendingOrder
        {
            get { return _descendingOrder; }
            set { _descendingOrder = value; }
        }

    }
}
