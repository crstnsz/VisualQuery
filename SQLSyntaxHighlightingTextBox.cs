using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using VisualQuery.SyntaxHighlightingTextBox;
using System.Windows.Forms;
using System.Drawing;

namespace VisualQuery
{
    public partial class SQLSyntaxHighlightingTextBox : SyntaxHighlightingTextBox.SyntaxHighlightingTextBox
    {
        public SQLSyntaxHighlightingTextBox()
        {
            InitializeComponent();
            this.LoadReservedWords();
        }

        public SQLSyntaxHighlightingTextBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            this.LoadReservedWords();
        }

        private void LoadReservedWords()
        {
            this.Seperators.Add(' ');
            this.Seperators.Add('\r');
            this.Seperators.Add('\n');
            this.Seperators.Add('\t');
            this.Seperators.Add(',');
            this.Seperators.Add('.');
            this.Seperators.Add('-');
            this.Seperators.Add('+');
            this.Seperators.Add('(');
            this.Seperators.Add(')');
            this.Seperators.Add('*');
            this.Seperators.Add('/');


            this.WordWrap = false;
            this.ScrollBars = RichTextBoxScrollBars.Both;// & RichTextBoxScrollBars.ForcedVertical;

            this.FilterAutoComplete = false;
            /*shtb.HighlightDescriptors.Add(new HighlightDescriptor("<", Color.Gray, null, DescriptorType.Word, DescriptorRecognition.WholeWord, true));

            shtb.HighlightDescriptors.Add(new HighlightDescriptor("<<", ">>", Color.DarkGreen, null, DescriptorType.ToCloseToken, DescriptorRecognition.StartsWith, false));
*/
            this.HighlightDescriptors.Add(new HighlightDescriptor("SELECT", Color.Blue, null, DescriptorType.Word, DescriptorRecognition.WholeWord, true));
            this.HighlightDescriptors.Add(new HighlightDescriptor("FROM", Color.Blue, null, DescriptorType.Word, DescriptorRecognition.WholeWord, true));
            this.HighlightDescriptors.Add(new HighlightDescriptor("WHERE", Color.Blue, null, DescriptorType.Word, DescriptorRecognition.WholeWord, true));
            this.HighlightDescriptors.Add(new HighlightDescriptor("GROUP", Color.Blue, null, DescriptorType.Word, DescriptorRecognition.WholeWord, true));
            this.HighlightDescriptors.Add(new HighlightDescriptor("ORDER", Color.Blue, null, DescriptorType.Word, DescriptorRecognition.WholeWord, true));
            this.HighlightDescriptors.Add(new HighlightDescriptor("BY", Color.Blue, null, DescriptorType.Word, DescriptorRecognition.WholeWord, true));
            this.HighlightDescriptors.Add(new HighlightDescriptor("UNION", Color.Blue, null, DescriptorType.Word, DescriptorRecognition.WholeWord, true));
            this.HighlightDescriptors.Add(new HighlightDescriptor("NOT", Color.Blue, null, DescriptorType.Word, DescriptorRecognition.WholeWord, true));
            this.HighlightDescriptors.Add(new HighlightDescriptor("IN", Color.Blue, null, DescriptorType.Word, DescriptorRecognition.WholeWord, true));
            this.HighlightDescriptors.Add(new HighlightDescriptor("EXISTS", Color.Blue, null, DescriptorType.Word, DescriptorRecognition.WholeWord, true));
            this.HighlightDescriptors.Add(new HighlightDescriptor("BETWEEN", Color.Blue, null, DescriptorType.Word, DescriptorRecognition.WholeWord, true));
            this.HighlightDescriptors.Add(new HighlightDescriptor("AND", Color.Blue, null, DescriptorType.Word, DescriptorRecognition.WholeWord, true));
            this.HighlightDescriptors.Add(new HighlightDescriptor("OR", Color.Blue, null, DescriptorType.Word, DescriptorRecognition.WholeWord, true));
            this.HighlightDescriptors.Add(new HighlightDescriptor("INNER", Color.Blue, null, DescriptorType.Word, DescriptorRecognition.WholeWord, true));
            this.HighlightDescriptors.Add(new HighlightDescriptor("JOIN", Color.Blue, null, DescriptorType.Word, DescriptorRecognition.WholeWord, true));
            this.HighlightDescriptors.Add(new HighlightDescriptor("LEFT", Color.Blue, null, DescriptorType.Word, DescriptorRecognition.WholeWord, true));
            this.HighlightDescriptors.Add(new HighlightDescriptor("OUTER", Color.Blue, null, DescriptorType.Word, DescriptorRecognition.WholeWord, true));
            this.HighlightDescriptors.Add(new HighlightDescriptor("ON", Color.Blue, null, DescriptorType.Word, DescriptorRecognition.WholeWord, true));
            
            this.HighlightDescriptors.Add(new HighlightDescriptor("Max", Color.Red, null, DescriptorType.Word, DescriptorRecognition.WholeWord, true));
            this.HighlightDescriptors.Add(new HighlightDescriptor("Min", Color.Red, null, DescriptorType.Word, DescriptorRecognition.WholeWord, true));
            this.HighlightDescriptors.Add(new HighlightDescriptor("Sum", Color.Red, null, DescriptorType.Word, DescriptorRecognition.WholeWord, true));
            this.HighlightDescriptors.Add(new HighlightDescriptor("Count", Color.Red, null, DescriptorType.Word, DescriptorRecognition.WholeWord, true));
            this.HighlightDescriptors.Add(new HighlightDescriptor("Avg", Color.Red, null, DescriptorType.Word, DescriptorRecognition.WholeWord, true));
            //this.HighlightDescriptors.Add(new HighlightDescriptor("/*", "*/", Color.Magenta, null, DescriptorType.ToCloseToken, DescriptorRecognition.StartsWith, false));
        }
    }
}
