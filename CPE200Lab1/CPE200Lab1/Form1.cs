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

        float ans;
        char operate; //store previous operator 
        char operate_2; //store current operator
        bool firstDigit = true;
        bool answer = false;
        bool percent_clicked = false;
        bool operate_clicked = false;

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
                        ans = ans + (float.Parse(lblDisplay.Text) * ans / 100);
                        percent_clicked = false;
                    }
                    else
                    {
                        ans = ans + float.Parse(lblDisplay.Text);
                    }
                    break;
                case '-':
                    if (percent_clicked)
                    {
                        ans = ans - (float.Parse(lblDisplay.Text) * ans / 100);
                        percent_clicked = false;
                    }
                    else
                    {
                        ans = ans - float.Parse(lblDisplay.Text);
                    }
                    break;
                case 'X':
                    if (percent_clicked)
                    {
                        ans = ans * (float.Parse(lblDisplay.Text) * ans / 100);
                        percent_clicked = false;
                    }
                    else
                    {
                        ans = ans * float.Parse(lblDisplay.Text);
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
                            ans = ans / (float.Parse(lblDisplay.Text) * ans / 100);
                            percent_clicked = false;
                        }
                        else
                        {
                            ans = ans / float.Parse(lblDisplay.Text);
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
            calculate();
            ans = 0;
            firstDigit = true;
            answer = true;
            operate_clicked = false;
        }

      
    }
}