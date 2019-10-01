
namespace VisualQuery
{
    internal class Join
    {
        internal Join(Column left, Column right)
        {
            this._left = left;
            this._right = right;
            operation = Operation.Equal;
        }

        private Column _left;

        internal Column Left
        {
            get { return _left; }
            set { _left = value; }
        }
        private Column _right;

        internal Column Right
        {
            get { return _right; }
            set { _right = value; }
        }

        private Operation operation;

        internal Operation Operation
        {
            get { return operation; }
            set { operation = value; }
        }
    }
}
