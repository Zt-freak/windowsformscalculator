using System.Collections;

namespace Calculator
{
    partial class CalcForm
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
            this.display = new System.Windows.Forms.TextBox();
            this.digitButtons = new ArrayList();
            for (int i = 0; i < 12; i++)
            {
                this.digitButtons.Add(new DigitButton());
            }
            this.operatorButtonPlus = new System.Windows.Forms.Button();
            this.operatorButtonMinus = new System.Windows.Forms.Button();
            this.operatorButtonMultiply = new System.Windows.Forms.Button();
            this.operatorButtonDivide = new System.Windows.Forms.Button();
            this.answerButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // display
            // 
            this.display.Location = new System.Drawing.Point(13, 12);
            this.display.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.display.Name = "display";
            this.display.ReadOnly = true;
            this.display.Size = new System.Drawing.Size(315, 22);
            this.display.TabIndex = 0;

            //
            // digitButtons
            //
            int tempDigitButtonIndex = 0;
            int tempDigitButtonColumn = 0;
            int tempDigitButtonRow = 0;
            foreach (DigitButton digitButton in this.digitButtons)
            {
                if ((tempDigitButtonIndex % 3) == 0)
                {
                    tempDigitButtonColumn = 0;
                    tempDigitButtonRow++;
                }
                if (tempDigitButtonIndex == 10)
                {
                    digitButton.Text = ".";
                }
                else if (tempDigitButtonIndex == 11)
                {
                    digitButton.Text = "-";
                }
                else {
                    digitButton.Text = tempDigitButtonIndex.ToString();
                }
                digitButton.Location = new System.Drawing.Point(13 + (108 * tempDigitButtonColumn), 6 + (36 * tempDigitButtonRow));
                digitButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
                digitButton.Name = "digitButton" + tempDigitButtonIndex.ToString();
                digitButton.Size = new System.Drawing.Size(100, 28);
                digitButton.TabIndex = 1 + tempDigitButtonIndex;
                digitButton.UseVisualStyleBackColor = true;
                digitButton.Click += new System.EventHandler(this.Digit_Click);
                tempDigitButtonIndex++;
                tempDigitButtonColumn++;
            }
            // 
            // operatorButtonPlus
            // 
            this.operatorButtonPlus.Location = new System.Drawing.Point(13, 187);
            this.operatorButtonPlus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.operatorButtonPlus.Name = "button11";
            this.operatorButtonPlus.Size = new System.Drawing.Size(100, 28);
            this.operatorButtonPlus.TabIndex = 11;
            this.operatorButtonPlus.Text = "+";
            this.operatorButtonPlus.UseVisualStyleBackColor = true;
            this.operatorButtonPlus.Click += new System.EventHandler(this.Operator_Click);
            this.operatorButtonPlus.Enabled = false;
            // 
            // operatorButtonMinus
            // 
            this.operatorButtonMinus.Location = new System.Drawing.Point(121, 187);
            this.operatorButtonMinus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.operatorButtonMinus.Name = "button12";
            this.operatorButtonMinus.Size = new System.Drawing.Size(100, 28);
            this.operatorButtonMinus.TabIndex = 12;
            this.operatorButtonMinus.Text = "-";
            this.operatorButtonMinus.UseVisualStyleBackColor = true;
            this.operatorButtonMinus.Click += new System.EventHandler(this.Operator_Click);
            this.operatorButtonMinus.Enabled = false;
            // 
            // operatorButtonMultiply
            // 
            this.operatorButtonMultiply.Location = new System.Drawing.Point(229, 187);
            this.operatorButtonMultiply.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.operatorButtonMultiply.Name = "button13";
            this.operatorButtonMultiply.Size = new System.Drawing.Size(100, 28);
            this.operatorButtonMultiply.TabIndex = 13;
            this.operatorButtonMultiply.Text = "*";
            this.operatorButtonMultiply.UseVisualStyleBackColor = true;
            this.operatorButtonMultiply.Click += new System.EventHandler(this.Operator_Click);
            this.operatorButtonMultiply.Enabled = false;
            // 
            // operatorButtonDivide
            // 
            this.operatorButtonDivide.Location = new System.Drawing.Point(337, 187);
            this.operatorButtonDivide.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.operatorButtonDivide.Name = "button14";
            this.operatorButtonDivide.Size = new System.Drawing.Size(100, 28);
            this.operatorButtonDivide.TabIndex = 14;
            this.operatorButtonDivide.Text = "/";
            this.operatorButtonDivide.UseVisualStyleBackColor = true;
            this.operatorButtonDivide.Click += new System.EventHandler(this.Operator_Click);
            this.operatorButtonDivide.Enabled = false;

            // 
            // CalcForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 554);
            this.Controls.Add(this.operatorButtonDivide);
            this.Controls.Add(this.operatorButtonMultiply);
            this.Controls.Add(this.operatorButtonMinus);
            this.Controls.Add(this.operatorButtonPlus);

            foreach (DigitButton digitButton in this.digitButtons)
            {
                this.Controls.Add(digitButton);
            }
            this.Controls.Add(this.display);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "CalcForm";
            this.Text = "Calculator";
            this.Load += new System.EventHandler(this.CalcForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox display;
        private System.Collections.ArrayList digitButtons;
        private System.Windows.Forms.Button operatorButtonPlus;
        private System.Windows.Forms.Button operatorButtonMinus;
        private System.Windows.Forms.Button operatorButtonMultiply;
        private System.Windows.Forms.Button operatorButtonDivide;
        private System.Windows.Forms.Button answerButton;
        private System.Windows.Forms.Button clearButton;
        // TODO: Add element for inserting previous answers
    }
}

