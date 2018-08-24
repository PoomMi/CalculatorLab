using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;

namespace CPE200Lab1
{
    public partial class Form1 : Form
    {

        float ans,num2;
        char operate; //store previous operator 
        char operate_2; //store current operator
        bool firstDigit = true;
        bool answer = false;
        bool percent_clicked = false;
        bool operate_clicked = false;
        bool equalFirstTime = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnNum_Click(object sender, EventArgs e)
        {
            Button text = (Button)sender;
            if ((lblDisplay.Text == "0" || lblDisplay.Text == "Error" || firstDigit)){
                lblDisplay.Text = string.Empty;
                firstDigit = false;
                equalFirstTime = false;
            }

            if (lblDisplay.Text.Length < 8)
            {
                lblDisplay.Text = lblDisplay.Text + text.Text;
            }
        }

        private void btnOperator_Click(object sender, EventArgs e)
        {
            Button text = (Button)sender;
            operate_2 = Convert.ToChar(text.Text);
            if (operate_clicked)
            {
                num2 = float.Parse(lblDisplay.Text);
                calculate();
                operate = operate_2;
            }
            else
            {
                operate = operate_2;
                ans = float.Parse(lblDisplay.Text);
            }
            operate_clicked = true;
            firstDigit = true;
        }



        private void btnDot_Click(object sender, EventArgs e)
        {
            if (!lblDisplay.Text.Contains("."))
            {
                lblDisplay.Text = lblDisplay.Text + ".";
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            int length = lblDisplay.Text.Length;
            lblDisplay.Text = lblDisplay.Text.Remove(length-1, 1);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = string.Empty;
            lblDisplay.Text = "0";
            ans = 0;
            firstDigit = true;
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            percent_clicked = true;
        }

        public void calculate()
        {
            switch (operate)
            {
                case '+':
                    if (percent_clicked)
                    {
                        ans = ans + (num2 * ans / 100);
                        percent_clicked = false;
                    }
                    else
                    {
                        ans = ans + num2;
                    }
                    break;
                case '-':
                    if (percent_clicked)
                    {
                        ans = ans - (num2 * ans / 100);
                        percent_clicked = false;
                    }
                    else
                    {
                        ans = ans - num2;
                    }
                    break;
                case 'X':
                    if (percent_clicked)
                    {
                        ans = ans * (num2 * ans / 100);
                        percent_clicked = false;
                    }
                    else
                    {
                        ans = ans * num2;
                    }
                    break;
                case '÷':
                    if (lblDisplay.Text == "0")
                    {
                        lblDisplay.Text = "Error";
                    }
                    else
                    {
                        if (percent_clicked)
                        {
                            ans = ans / (num2 * ans / 100);
                            percent_clicked = false;
                        }
                        else
                        {
                            ans = ans / num2;
                        }
                    }
                    break;
            }
            if (lblDisplay.Text != "Error")
            {
                lblDisplay.Text = ans.ToString();
            }
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (!equalFirstTime)
            {
                num2 = float.Parse(lblDisplay.Text);
            }
            equalFirstTime = true;
            calculate(); 
            firstDigit = true;
            answer = true;
            operate_clicked = false;
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            float tmp = float.Parse(lblDisplay.Text) * -1;
            lblDisplay.Text = tmp.ToString();
        }
    }
}