using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VisualQuery
{
    public partial class ManutExpressao : Form
    {
        private Query _query = null;

        public ManutExpressao()
        {
            InitializeComponent();
        }

        private void TraduzTela()
        {
            this.Text = Literal.LiteralManager.GetLiteral("construir_expressao");
            this.labelExpression.Text = Literal.LiteralManager.GetLiteral("expressao");
            this.labelFields.Text = Literal.LiteralManager.GetLiteral("campo_da_tabela");
            this.buttonOk.Text = Literal.LiteralManager.GetLiteral("ok");
            this.buttonCancel.Text = Literal.LiteralManager.GetLiteral("cancelar");
        }

        internal Query Query
        {
            set
            {
                int _tableIndex = 0;
                foreach (Table _table in value.Tables)
                {
                    treeViewColumns.Nodes.Add(_table.Alias);
                    foreach (Column _column in _table.Columns)
                    {
                        TreeNode _newNode = new TreeNode();
                        _newNode.Text = _column.Name;
                        _newNode.Tag = _column.FullName;
                        treeViewColumns.Nodes[_tableIndex].Nodes.Add(_newNode);
                    }
                    _tableIndex++;
                }

                _query = value;

                treeViewColumns.ExpandAll();

            }
            get
            {
                return _query;
            }

        }
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeViewColumns_DoubleClick(object sender, EventArgs e)
        {
            if (this.treeViewColumns.SelectedNode != null)
            {
                if (this.treeViewColumns.SelectedNode.Level == 1)
                {
                    this.InputText(this.treeViewColumns.SelectedNode.Tag.ToString());
                }
            }
        }

        private void InputText(string text)
        {
            int start = richTextBoxExpression.SelectionStart;
            int lenght = richTextBoxExpression.SelectionLength;
            if (richTextBoxExpression.Text.Trim() != string.Empty)
            {
                if (lenght != 0)
                    richTextBoxExpression.Text = richTextBoxExpression.Text.Remove(start, lenght);
                if (start >= richTextBoxExpression.Text.Length)
                    richTextBoxExpression.Text += text;
                else
                    richTextBoxExpression.Text = richTextBoxExpression.Text.Insert(start, text);
            }
            else
                richTextBoxExpression.Text = text;
            richTextBoxExpression.SelectionStart = start + text.Length;
        }

        /// <summary>
        /// Pega ou Informa a Expressão para o editor de Expressões
        /// </summary>
        internal string Expression
        {
            get
            {
                return this.richTextBoxExpression.Text;
            }

            set
            {
                this.richTextBoxExpression.Text = value;
            }

        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            this.InputText(" + ");
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            this.InputText(" - ");
        }

        private void buttonMutiply_Click(object sender, EventArgs e)
        {
            this.InputText(" * ");
        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {
            this.InputText(" / ");
        }

        private void buttonOpenPar_Click(object sender, EventArgs e)
        {
            this.InputText(" ( ");
        }

        private void buttonClosePar_Click(object sender, EventArgs e)
        {
            this.InputText(" ) ");
        }

        private void buttonMax_Click(object sender, EventArgs e)
        {
            this.InputText(string.Format("Max ( {0} )", this.richTextBoxExpression.SelectedText ));
        }

        private void buttonMin_Click(object sender, EventArgs e)
        {
            this.InputText(string.Format("Min ( {0} )", this.richTextBoxExpression.SelectedText));
        }

        private void buttonAvg_Click(object sender, EventArgs e)
        {
            this.InputText(string.Format("Avg ( {0} )", this.richTextBoxExpression.SelectedText));
        }

        private void buttonSum_Click(object sender, EventArgs e)
        {
            this.InputText(string.Format("Sum ( {0} )", this.richTextBoxExpression.SelectedText));
        }

        private void buttonCount_Click(object sender, EventArgs e)
        {
            if (this.richTextBoxExpression.SelectedText != string.Empty)
                this.InputText(string.Format("Count ( {0} )", this.richTextBoxExpression.SelectedText));
            else
                this.InputText("Count ( * )");
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();

        }

        private void ManutExpressao_Load(object sender, EventArgs e)
        {
            TraduzTela();
        }

        private void toolStripButtonGo_Click(object sender, EventArgs e)
        {
            treeViewColumns.Nodes.Clear();
            foreach (Table _table in _query.Tables)
            {
                TreeNode _tableNode = null;
                bool _tableInserted = false;
                if (_table.Alias.Contains(toolStripTextBoxFilter.Text))
                {
                    _tableNode = treeViewColumns.Nodes.Add(_table.Alias);
                    foreach (Column _column in _table.Columns)
                    {
                        TreeNode _newNode = new TreeNode();
                        _newNode.Text = _column.Name;
                        _newNode.Tag = _column.FullName;
                        _tableNode.Nodes.Add(_newNode);
                    }
                }
                else
                {
                    foreach (Column _column in _table.Columns)
                    {
                        if (_column.FullName.Contains(toolStripTextBoxFilter.Text))
                        {
                            if (!_tableInserted)
                            {
                                _tableNode = treeViewColumns.Nodes.Add(_table.Alias);
                                _tableInserted = true;
                            }

                            TreeNode _newNode = new TreeNode();
                            _newNode.Text = _column.Name;
                            _newNode.Tag = _column.FullName;
                            _tableNode.Nodes.Add(_newNode);
                        }
                    }
                }

                treeViewColumns.ExpandAll();

            }
        }
    }
}