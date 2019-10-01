namespace VisualQuery
{
    partial class VisualJoin
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelIqual = new System.Windows.Forms.Label();
            this.labelLess = new System.Windows.Forms.Label();
            this.labelGreat = new System.Windows.Forms.Label();
            this.labelLessIqual = new System.Windows.Forms.Label();
            this.labelGreatIqual = new System.Windows.Forms.Label();
            this.labelDiferente = new System.Windows.Forms.Label();
            this.labelDelete = new System.Windows.Forms.Label();
            this.labelCurrent = new System.Windows.Forms.Label();
            this.labelOuterJoin = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelIqual
            // 
            this.labelIqual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelIqual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIqual.Location = new System.Drawing.Point(0, 40);
            this.labelIqual.Name = "labelIqual";
            this.labelIqual.Size = new System.Drawing.Size(19, 19);
            this.labelIqual.TabIndex = 0;
            this.labelIqual.Text = "=";
            this.labelIqual.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelLess
            // 
            this.labelLess.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelLess.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLess.Location = new System.Drawing.Point(0, 60);
            this.labelLess.Name = "labelLess";
            this.labelLess.Size = new System.Drawing.Size(19, 19);
            this.labelLess.TabIndex = 1;
            this.labelLess.Text = "<";
            this.labelLess.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelGreat
            // 
            this.labelGreat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelGreat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGreat.Location = new System.Drawing.Point(0, 100);
            this.labelGreat.Name = "labelGreat";
            this.labelGreat.Size = new System.Drawing.Size(19, 19);
            this.labelGreat.TabIndex = 3;
            this.labelGreat.Text = ">";
            this.labelGreat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelLessIqual
            // 
            this.labelLessIqual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelLessIqual.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLessIqual.Location = new System.Drawing.Point(0, 80);
            this.labelLessIqual.Name = "labelLessIqual";
            this.labelLessIqual.Size = new System.Drawing.Size(19, 19);
            this.labelLessIqual.TabIndex = 2;
            this.labelLessIqual.Text = "<=";
            this.labelLessIqual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelGreatIqual
            // 
            this.labelGreatIqual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelGreatIqual.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGreatIqual.Location = new System.Drawing.Point(0, 120);
            this.labelGreatIqual.Name = "labelGreatIqual";
            this.labelGreatIqual.Size = new System.Drawing.Size(19, 19);
            this.labelGreatIqual.TabIndex = 4;
            this.labelGreatIqual.Text = ">=";
            this.labelGreatIqual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelDiferente
            // 
            this.labelDiferente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelDiferente.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDiferente.Location = new System.Drawing.Point(0, 140);
            this.labelDiferente.Name = "labelDiferente";
            this.labelDiferente.Size = new System.Drawing.Size(19, 19);
            this.labelDiferente.TabIndex = 5;
            this.labelDiferente.Text = "<>";
            this.labelDiferente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelDelete
            // 
            this.labelDelete.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelDelete.Font = new System.Drawing.Font("Webdings", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.labelDelete.ForeColor = System.Drawing.Color.DarkRed;
            this.labelDelete.Location = new System.Drawing.Point(0, 160);
            this.labelDelete.Name = "labelDelete";
            this.labelDelete.Size = new System.Drawing.Size(19, 19);
            this.labelDelete.TabIndex = 6;
            this.labelDelete.Text = "x";
            this.labelDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelDelete.Click += new System.EventHandler(this.labelDelete_Click);
            // 
            // labelCurrent
            // 
            this.labelCurrent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrent.Location = new System.Drawing.Point(0, 0);
            this.labelCurrent.Name = "labelCurrent";
            this.labelCurrent.Size = new System.Drawing.Size(19, 19);
            this.labelCurrent.TabIndex = 7;
            this.labelCurrent.Text = "=";
            this.labelCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelCurrent.Click += new System.EventHandler(this.labelCurrent_Click);
            // 
            // labelOuterJoin
            // 
            this.labelOuterJoin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelOuterJoin.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOuterJoin.Location = new System.Drawing.Point(0, 20);
            this.labelOuterJoin.Name = "labelOuterJoin";
            this.labelOuterJoin.Size = new System.Drawing.Size(19, 19);
            this.labelOuterJoin.TabIndex = 8;
            this.labelOuterJoin.Text = "OJ";
            this.labelOuterJoin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // VisualJoin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelOuterJoin);
            this.Controls.Add(this.labelCurrent);
            this.Controls.Add(this.labelDelete);
            this.Controls.Add(this.labelDiferente);
            this.Controls.Add(this.labelGreatIqual);
            this.Controls.Add(this.labelGreat);
            this.Controls.Add(this.labelLessIqual);
            this.Controls.Add(this.labelLess);
            this.Controls.Add(this.labelIqual);
            this.Name = "VisualJoin";
            this.Size = new System.Drawing.Size(19, 179);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelIqual;
        private System.Windows.Forms.Label labelLess;
        private System.Windows.Forms.Label labelGreat;
        private System.Windows.Forms.Label labelLessIqual;
        private System.Windows.Forms.Label labelGreatIqual;
        private System.Windows.Forms.Label labelDiferente;
        private System.Windows.Forms.Label labelDelete;
        private System.Windows.Forms.Label labelCurrent;
        private System.Windows.Forms.Label labelOuterJoin;
    }
}
