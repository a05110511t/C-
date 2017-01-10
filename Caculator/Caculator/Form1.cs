using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Caculator
{
    public partial class Form1 : Form
    {
        Double value = 0;
        String operation = "";
        bool opreation_pressed = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_Click(object sender, EventArgs e)
        {
            if ((result.Text == "0") || (opreation_pressed ))
                result.Clear();
            opreation_pressed = false;
            Button b = (Button)sender;
            if(b.Text == ".")
            {
                if (!result.Text.Contains("."))
                    result.Text = result.Text + b.Text;
            }
            else
                result.Text = result.Text + b.Text;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            result.Clear();
            result.Text = "0";
            operatorbox.Clear();
            
        }

        private void operator_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            operation = b.Text;
            value = Double.Parse(result.Text);
            opreation_pressed = true;
            operatorbox.Clear();
            operatorbox.Text += b.Text;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                switch (operation)
                {
                    case "+":
                        result.Text = (value + Double.Parse(result.Text)).ToString();
                        operatorbox.Clear();
                        operatorbox.Text = "=";
                        break;
                    case "-":
                        result.Text = (value - Double.Parse(result.Text)).ToString();
                        operatorbox.Clear();
                        operatorbox.Text = "=";
                        break;
                    case "*":
                        result.Text = (value * Double.Parse(result.Text)).ToString();
                        operatorbox.Clear();
                        operatorbox.Text = "=";
                        break;
                    case "/":
                        result.Text = (value / Double.Parse(result.Text)).ToString();
                        operatorbox.Clear();
                        operatorbox.Text = "=";
                        break;
                    default:
                        operatorbox.Clear();
                        break;
                }
            }
            catch (UnauthorizedAccessException UAEx)
            {
                Console.WriteLine(UAEx.Message);
            }
            catch (PathTooLongException PathEx)
            {
                Console.WriteLine(PathEx.Message);
            }

                        
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
