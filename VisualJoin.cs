using System;
using System.Drawing;
using System.Windows.Forms;

namespace VisualQuery
{
    internal partial class VisualJoin : UserControl
    {
        internal event JoinEventHandler JoinChanged;
        internal event JoinEventHandler JoinDeleted;

        Join _join = null;
        internal VisualTable TableLeft;
        internal VisualTable TableRight;

        public VisualJoin()
        {
            InitializeComponent();

            this.Collapse();

            labelIqual.Click += new EventHandler(labelsWithJoinOperation_Click);
            labelLess.Click += new EventHandler(labelsWithJoinOperation_Click);
            labelLessIqual.Click += new EventHandler(labelsWithJoinOperation_Click);
            labelGreat.Click += new EventHandler(labelsWithJoinOperation_Click);
            labelGreatIqual.Click += new EventHandler(labelsWithJoinOperation_Click);
            labelDiferente.Click += new EventHandler(labelsWithJoinOperation_Click);
            labelOuterJoin.Click += new EventHandler(labelsWithJoinOperation_Click);
        }

        private bool IsCollapsed()
        {
            return this.Height == (2 * labelCurrent.Top) + labelCurrent.Height;
        }

        private void Collapse()
        {
            this.Height = (2 * labelCurrent.Top) + labelCurrent.Height;
        }

        private void Expand()
        {
            this.Height = labelDelete.Top + labelDelete.Height + labelCurrent.Top;
        }

        private void labelCurrent_Click(object sender, EventArgs e)
        {
            if (this.IsCollapsed())
                this.Expand();
            else
                this.Collapse();
        }
        private void labelsWithJoinOperation_Click(object sender, EventArgs e)
        {
            labelCurrent.Text = ((Label)sender).Text;
            labelCurrent.Font = new Font(((Label)sender).Font.FontFamily, ((Label)sender).Font.Size);
            _join.Operation = OperationFX.StringToOperation(labelCurrent.Text);
            if (JoinChanged != null)
                JoinChanged(this, new JoinEventArgs(_join, JoinEventAction.Change));
            this.Collapse();
        }

        public Join Join
        {
            get { return _join; }
            set { SetJoin(value); }
        }

        private void SetJoin(Join join)
        {
            _join = join;
            switch (Join.Operation)
            {
                case Operation.Equal:
                    labelsWithJoinOperation_Click(labelIqual, new EventArgs());
                    break;
                case Operation.Less:
                    labelsWithJoinOperation_Click(labelLess, new EventArgs());
                    break;
                case Operation.LessEqual:
                    labelsWithJoinOperation_Click(labelLessIqual, new EventArgs());
                    break;
                case Operation.Greater:
                    labelsWithJoinOperation_Click(labelGreat, new EventArgs());
                    break;
                case Operation.GreaterEqual:
                    labelsWithJoinOperation_Click(labelGreatIqual, new EventArgs());
                    break;
                case Operation.Diferente:
                    labelsWithJoinOperation_Click(labelDiferente, new EventArgs());
                    break;
                case Operation.LeftOuterJoin:
                    labelsWithJoinOperation_Click(labelOuterJoin, new EventArgs());
                    break;
                default:
                    throw new Error.Excessao(197);
            }
        }

        public int UnitHeight
        {
            get
            {
                return (this.labelCurrent.Top * 2) + this.labelCurrent.Height;
            }
        }

        private void labelDelete_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Close()
        {
            if (JoinDeleted != null)
                JoinDeleted(this, new JoinEventArgs(_join, JoinEventAction.Remove));
            this.Parent.Controls.Remove(this);
        }
    }
}
