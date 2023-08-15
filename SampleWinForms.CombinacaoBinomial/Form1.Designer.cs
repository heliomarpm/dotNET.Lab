namespace SampleWinForms.CombinacaoBinomial
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTrials = new System.Windows.Forms.TextBox();
            this.txtSuccesses = new System.Windows.Forms.TextBox();
            this.txtProbabilitySuccess = new System.Windows.Forms.TextBox();
            this.txtBinomialProbability = new System.Windows.Forms.TextBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "&Number of Trials:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Number of &Successes:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "&Probability of Success:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "&Binomial Probability:";
            // 
            // txtTrials
            // 
            this.txtTrials.Location = new System.Drawing.Point(136, 15);
            this.txtTrials.Name = "txtTrials";
            this.txtTrials.Size = new System.Drawing.Size(100, 20);
            this.txtTrials.TabIndex = 1;
            this.txtTrials.Text = "5";
            this.txtTrials.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSuccesses
            // 
            this.txtSuccesses.Location = new System.Drawing.Point(136, 43);
            this.txtSuccesses.Name = "txtSuccesses";
            this.txtSuccesses.Size = new System.Drawing.Size(100, 20);
            this.txtSuccesses.TabIndex = 1;
            this.txtSuccesses.Text = "2";
            this.txtSuccesses.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtProbabilitySuccess
            // 
            this.txtProbabilitySuccess.Location = new System.Drawing.Point(136, 71);
            this.txtProbabilitySuccess.Name = "txtProbabilitySuccess";
            this.txtProbabilitySuccess.Size = new System.Drawing.Size(100, 20);
            this.txtProbabilitySuccess.TabIndex = 1;
            this.txtProbabilitySuccess.Text = "0.75";
            this.txtProbabilitySuccess.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtBinomialProbability
            // 
            this.txtBinomialProbability.Location = new System.Drawing.Point(16, 152);
            this.txtBinomialProbability.Multiline = true;
            this.txtBinomialProbability.Name = "txtBinomialProbability";
            this.txtBinomialProbability.Size = new System.Drawing.Size(220, 42);
            this.txtBinomialProbability.TabIndex = 1;
            this.txtBinomialProbability.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBinomialProbability.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(255, 70);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(100, 20);
            this.btnCalculate.TabIndex = 2;
            this.btnCalculate.Text = "C&alculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(255, 174);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 20);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 236);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.txtBinomialProbability);
            this.Controls.Add(this.txtProbabilitySuccess);
            this.Controls.Add(this.txtSuccesses);
            this.Controls.Add(this.txtTrials);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTrials;
        private System.Windows.Forms.TextBox txtSuccesses;
        private System.Windows.Forms.TextBox txtProbabilitySuccess;
        private System.Windows.Forms.TextBox txtBinomialProbability;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnClose;
    }
}

