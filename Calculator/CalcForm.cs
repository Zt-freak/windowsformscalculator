using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Calculator
{
    public partial class CalcForm : Form
    {
        public float firstValue = 0;
        public float secondValue = 0;
        public System.Collections.ArrayList memory;
        public string mathOperator = "";
        public int step = 0;
        public CalcForm()
        {
            InitializeComponent();
        }

        private void CalcForm_Load(object sender, EventArgs e)
        {

        }

        private void Digit_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            switch (this.step)
            {
                case 0:
                    this.display.Text += button.Text;
                    this.enableOperatorOptions(true);
                    this.step++;
                    break;
                case 2:
                    this.display.Text += button.Text;
                    this.enableOperatorOptions(false);
                    this.step++;
                    break;
                case 1:
                case 3:
                    this.display.Text += button.Text;
                    break;
            }
            this.checkDigitOptions();
            //Debug.WriteLine(button.Text);
            Debug.WriteLine(this.step);
        }

        private void Operator_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            switch (this.step)
            {
                case 1:
                    this.firstValue = float.Parse(this.display.Text);
                    this.mathOperator = button.Text;
                    this.display.Text = "";
                    this.step++;
                    break;
                default:
                    this.mathOperator = button.Text;
                    break;
            }
            Debug.WriteLine(this.step);
        }

        private void Answer_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            switch (this.step)
            {
                case 3:
                    this.secondValue = float.Parse(this.display.Text);
                    this.display.Text = "";
                    // DOTO: Add logic here
                    this.step = 0;
                    break;
            }
            Debug.WriteLine(this.step);
        }

        private void enableOperatorOptions (Boolean value)
        {
            this.operatorButtonPlus.Enabled = value;
            this.operatorButtonMinus.Enabled = value;
            this.operatorButtonMultiply.Enabled = value;
            this.operatorButtonDivide.Enabled = value;
        }

        private void checkDigitOptions()
        {
            int tempDigitButtonIndex = 0;
            foreach (DigitButton digitButton in this.digitButtons)
            {
                if (this.display.TextLength >= 1 && digitButton.Text == "-")
                {
                    digitButton.Enabled = false;
                }
                if (this.display.Text.Contains('.') && digitButton.Text == ".")
                {
                    digitButton.Enabled = false;
                }
                tempDigitButtonIndex++;
            }
        }
    }
}
