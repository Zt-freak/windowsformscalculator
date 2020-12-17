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
        public int memoryPointer = 0;
        public CalcForm()
        {
            this.memory = new System.Collections.ArrayList();
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
                    this.display.Text = button.Text;
                    if (button.Text != "-")
                    {
                        this.step++;
                        this.enableOperatorOptions(true);
                    }
                    break;
                case 2:
                    this.display.Text += button.Text;
                    this.enableOperatorOptions(false);
                    this.enableAnswerOptions(true);
                    this.step++;
                    break;
                case 1:
                case 3:
                    this.display.Text += button.Text;
                    break;
                case 4:
                    this.display.Text = button.Text;
                    {
                        this.step = 1;
                        this.enableOperatorOptions(true);
                    }
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
                case 4:
                    this.firstValue = float.Parse(this.display.Text);
                    this.mathOperator = button.Text;
                    this.display.Text = "";
                    this.step = 2;
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
                    float answer = 0;
                    switch (this.mathOperator)
                    {
                        case "+":
                            answer = this.firstValue + this.secondValue;
                            break;
                        case "-":
                            answer = this.firstValue - this.secondValue;
                            break;
                        case "*":
                            answer = this.firstValue * this.secondValue;
                            break;
                        case "/":
                            answer = this.firstValue / this.secondValue;
                            break;
                        case "%":
                            answer = (this.secondValue - this.firstValue) / this.firstValue * 100;
                            break;
                    }
                    this.memory.Add(answer);
                    if (button.Text == "€")
                    {
                        this.display.Text = answer.ToString("c2");
                    }
                    else
                    {
                        this.display.Text = answer.ToString();
                    }
                    this.step = 4;
                    this.checkDigitOptions();
                    this.enableOperatorOptions(true);
                    this.enableAnswerOptions(false);
                    this.memoryPointer = this.memory.Count - 1;
                    break;
            }
            Debug.WriteLine(this.step);
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            this.display.Text = "";
            this.step = 0;
            this.checkDigitOptions();
            this.enableOperatorOptions(false);
            Debug.WriteLine(this.step);
        }

        private void Answer_Selector(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (this.memoryPointer > 0)
                {
                    this.memoryPointer--;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (this.memoryPointer < this.memory.Count - 1)
                {
                    this.memoryPointer++;
                }
            }
            int tempPointer = 0;
            foreach (float answer in this.memory)
            {
                if (tempPointer == this.memoryPointer)
                {
                    this.display.Text = answer.ToString();
                }
            }
        }

        private void enableOperatorOptions (Boolean value)
        {
            this.operatorButtonPlus.Enabled = value;
            this.operatorButtonMinus.Enabled = value;
            this.operatorButtonMultiply.Enabled = value;
            this.operatorButtonDivide.Enabled = value;
            this.operatorButtonPercentage.Enabled = value;
        }

        private void enableAnswerOptions(Boolean value)
        {
            this.answerButton.Enabled = value;
            this.euroButton.Enabled = value;
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
                else if (digitButton.Text == "-")
                {
                    digitButton.Enabled = true;
                }
                if (this.display.TextLength >= 1 && this.display.Text.Contains('.') && digitButton.Text == "."
                    || this.display.TextLength == 0 && digitButton.Text == "."
                    || digitButton.Text == "." && this.display.Text == "-"
                    || digitButton.Text == "." && this.step == 4)
                {
                    digitButton.Enabled = false;
                }
                else if (digitButton.Text == ".")
                {
                    digitButton.Enabled = true;
                }
                tempDigitButtonIndex++;
            }
        }
    }
}
