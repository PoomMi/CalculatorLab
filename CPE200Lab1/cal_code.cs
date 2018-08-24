using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPE200Lab1
{
    public partial class Form1 : Form
    {
        Double num,ans;
        char operate;
        bool firstNum = true;
        bool answer = false;
        //bool operator_clicked = false;

        public Form1()
        {
            InitializeComponent();
        }

        void numberBtn_Click(string s)
        {
            if(lblDisplay.Text == "0" || lblDisplay.Text == "Error" || !firstNum || answer) 
            {
                lblDisplay.Text = s;
                firstNum = true;
                answer = false;
            }
            else
            {
                lblDisplay.Text = lblDisplay.Text + s;
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            numberBtn_Click("1");
            
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            numberBtn_Click("2");
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            numberBtn_Click("3");
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            numberBtn_Click("4");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            numberBtn_Click("5");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            numberBtn_Click("6");
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            numberBtn_Click("7");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            numberBtn_Click("8");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            numberBtn_Click("9");
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            numberBtn_Click("0");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            operate = '+';
            num = Double.Parse(lblDisplay.Text);
            firstNum = false;
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            operate = '-';
            num = Double.Parse(lblDisplay.Text);
            firstNum = false;
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            operate = '*';
            num = Double.Parse(lblDisplay.Text);
            firstNum = false;
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            operate = '/';
            num = Double.Parse(lblDisplay.Text);
            firstNum = false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            int length = lblDisplay.Text.Length;
            lblDisplay.Text = lblDisplay.Text.Remove(length-1, 1);
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (!lblDisplay.Text.Contains("."))
            {
                numberBtn_Click(".");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = string.Empty;
            lblDisplay.Text = "0";
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            switch (operate)
            {
                case '+':
                    ans = num + Double.Parse(lblDisplay.Text);
                    break;
                case '-':
                    ans = num - Double.Parse(lblDisplay.Text);
                    break;
                case '*':
                    ans = num * Double.Parse(lblDisplay.Text);
                    break;
                case '/':
                    if (lblDisplay.Text == "0")
                    {
                        lblDisplay.Text = "Error";
                    }
                    else
                    {
                        ans = num / Double.Parse(lblDisplay.Text);
                    }
                    break;
            }

            if (lblDisplay.Text != "Error")
            {
                lblDisplay.Text = ans.ToString();
                int length = lblDisplay.Text.Length;
                if (length > 8)
                {
                    if (lblDisplay.Text.Contains("."))
                    {
                        lblDisplay.Text = lblDisplay.Text.Remove(9, length - 9);
                    }
                    else
                    {
                        lblDisplay.Text = lblDisplay.Text.Remove(8, length - 8);
                    } 
                }
            }

            firstNum = true;
            answer = true;

        }
    }
}
