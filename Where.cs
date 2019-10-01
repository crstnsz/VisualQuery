using System.Text;

namespace VisualQuery
{
    /// <summary>
    /// Filtros
    /// </summary>
    internal class Where
    {
        int paretesisBlockStart = 0;

        public int ParetesisBlockStart
        {
            get { return paretesisBlockStart; }
            set { paretesisBlockStart = value; }
        }
        int paretesisBlockEnd = 0;

        public int ParetesisBlockEnd
        {
            get { return paretesisBlockEnd; }
            set { paretesisBlockEnd = value; }
        }


        private Column left = null;
        public Column Left
        {
            get { return left; }
            set { left = value; }
        }

        private string leftSufix = string.Empty;
        public string LeftSufix
        {
            get { return leftSufix; }
            set { leftSufix = value; }
        }

        private Operation operation = Operation.Equal;
        internal Operation Operation
        {
            get { return operation; }
            set { operation = value; }
        }

        private string right = string.Empty;
        public string Right
        {
            get { return right; }
            set { right = value; }
        }

        private string junction = "AND";
        internal string Junction 
        {
            get { return junction; }
            set { junction = value; }

        }

        internal string Syntax
        {
            set
            {
                right = value;
                operation = Operation.FreeStyle;
            }

            get
            {
                return this.ToString();
            }
        }



        #region ICloneable Members

        public Where Clone()
        {
            Where _clone = new Where();
            _clone.Left = this.Left;
            _clone.LeftSufix = this.LeftSufix;
            _clone.Operation = this.Operation;
            _clone.Right = this.Right;
            _clone.Junction = this.Junction;
            _clone.ParetesisBlockStart = this.ParetesisBlockStart;
            _clone.ParetesisBlockEnd = this.ParetesisBlockEnd;
            return _clone;
        }

        public override string ToString()
        {
            if (this.Operation == Operation.FreeStyle)
                return this.Right + " " + this.Junction;


            StringBuilder sb = new StringBuilder();

            for(int ps = 0;ps < paretesisBlockStart; ps++)
                sb.Append("(");
            
            sb.Append("(");
            if (this.Left == null)
                sb.Append("NULL");
            else
                sb.Append(this.Left.SchemaName);
            
            if (this.LeftSufix != string.Empty)
            {
                sb.Append(" ");
                sb.Append(this.LeftSufix);
            }

            sb.Append(" ");
            sb.Append(OperationFX.OperationToString(this.Operation));
            sb.Append(" ");


            if (this.Right == null)
                sb.Append("NULL");
            else if (this.Right.ToString().ToLower() == "null")
                sb.Append("NULL");
            else if (this.Left.Type == "System.String" && !(this.Right.Contains("'") || this.Right.Contains("\""))) 
            {
                sb.Append("'");
                sb.Append(this.Right.ToString());
                sb.Append("'");
            }
            else
                sb.Append(this.Right.ToString());

            sb.Append(")");
            for (int pe = 0; pe < paretesisBlockEnd; pe++)
                sb.Append(")");

            sb.Append(" ");

            sb.Append(this.Junction);

            return sb.ToString();

        }

        #endregion
    }
}
