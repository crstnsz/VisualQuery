using System;

namespace VisualQuery
{
    internal enum JoinEventAction
    {
        Add,
        Remove,
        Change
    }

    internal class JoinEventArgs : EventArgs
    {
        private Join _join;
        private Column _right;
        private JoinEventAction _action;

        internal JoinEventArgs(Column left, Column righ, JoinEventAction action)
        {
            this._action = action;
            _join = new Join(left, righ);
        }

        internal JoinEventArgs(Join join, JoinEventAction action)
        {
            this._action = action;
            _join = join;
        }

        internal JoinEventAction Action
        {
            get { return _action; }
            set { _action = value; }
        }

        internal Join Join
        {
            get { return _join; }
        }
    }
}
