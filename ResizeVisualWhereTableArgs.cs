using System;

namespace VisualQuery
{
    internal class ResizeVisualWhereTableArgs : EventArgs
    {
        int _index = 0;
        int _nextXPosition = 0;

        internal ResizeVisualWhereTableArgs(int index, int nextXPosition)
        {
            _index = index;
            _nextXPosition = nextXPosition;
        }

        internal int Index
        {
            get { return _index; }
        }

        public int NextXPosition
        {
            get { return _nextXPosition; }
        }
    }
}
